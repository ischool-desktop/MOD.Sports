using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using K12.Data;
using FISCA.UDT;
using FISCA.Data;
using Tournaments;
using Aspose.Cells;

namespace ischool.Sports
{
    public partial class frmGameProducer : BaseForm
    {
        BackgroundWorker _bgwRun = new BackgroundWorker();
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        private AccessHelper _access = new AccessHelper();
        BackgroundWorker _bgwRunReport = new BackgroundWorker();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        int _defaultSchoolYear = 0, _selectSchoolYear = 0;
        BackgroundWorker _bgwLoadPlayer = new BackgroundWorker();
        List<UDT.Games> _GameList = new List<UDT.Games>();

        Dictionary<int, UDT.GroupTypes> _GroupTypeMapDict = new Dictionary<int, UDT.GroupTypes>();
        Dictionary<string, int> _GameTypeDict = new Dictionary<string, int>();
        Dictionary<string, UDT.Events> _EventItemDict = new Dictionary<string, UDT.Events>();
        int _playerCount = 0, _TeamCount = 0;
        Dictionary<int, List<DAO.rptCell>> rptMapDict = new Dictionary<int, List<DAO.rptCell>>();


        UDT.Events _selectedEvent = null;

        public frmGameProducer()
        {
            InitializeComponent();
            _bgwLoadData.WorkerReportsProgress = true;
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
            _bgwRun.DoWork += _bgwRun_DoWork;
            _bgwRun.RunWorkerCompleted += _bgwRun_RunWorkerCompleted;
            _bgwLoadPlayer.DoWork += _bgwLoadPlayer_DoWork;
            _bgwLoadPlayer.RunWorkerCompleted += _bgwLoadPlayer_RunWorkerCompleted;
            _bgwRunReport.DoWork += _bgwRunReport_DoWork;
            _bgwRunReport.RunWorkerCompleted += _bgwRunReport_RunWorkerCompleted;
        }

        private void _bgwRunReport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnReport.Enabled = true;
        }

        private void _bgwRunReport_DoWork(object sender, DoWorkEventArgs e)
        {
            rptMapDict.Clear();

            System.IO.MemoryStream ms = new System.IO.MemoryStream(Properties.Resources.單淘汰賽程樣板);
            Workbook wb = new Workbook(ms);
            Cell cellTemp = wb.Worksheets[1].Cells["A1"];
            Style style = cellTemp.GetStyle();


            // 取得隊伍數
            int pCount = GetPCount();

            Tournaments.SingleElimination se = new Tournaments.SingleElimination(pCount);
            se.startMatching();
            runRptMatches(se);

            int r = rptMapDict.Count;

            int round = 0;
            foreach (int i in rptMapDict.Keys)
            {
                if (i > round)
                {
                    round = i;
                }
            }

            int col = 0;
            int LeftRo = 1;
            int RightRo = round;

            int right1x = round * 2 - 1;
            // 解析位置
            foreach (int i in rptMapDict.Keys)
            {
                bool lc = false;
                bool rc = false;

                foreach (DAO.rptCell cel in rptMapDict[i])
                {
                    if (cel.RoundNo == i && cel.divNo == 1)
                    {

                        cel.Column = i - 1;
                        cel.Row = i - 1;
                        if (lc)
                        {
                            cel.Row += cel.GetMoveInt();
                        }
                        lc = true;
                    }

                    if (cel.RoundNo == i && cel.divNo == 2)
                    {

                        cel.Column = right1x - i + 1;
                        cel.Row = i - 1;
                        if (rc)
                        {
                            cel.Row += cel.GetMoveInt();
                        }
                        rc = true;
                    }
                }
            }

            foreach (int i in rptMapDict.Keys)
            {
                foreach (DAO.rptCell cel in rptMapDict[i])
                {
                    if (cel.Team1No == 0 && cel.Team2No == 0)
                        continue;



                    wb.Worksheets[0].Cells[cel.Row, cel.Column].PutValue(cel.Team1No);
                    wb.Worksheets[0].Cells[cel.Row + cel.GetMoveRow() - 1, cel.Column].PutValue(cel.Text);
                    wb.Worksheets[0].Cells[cel.Row + cel.GetMoveRow(), cel.Column].PutValue(cel.Team2No);
                }
            }

            //for (int ro = 1; ro <= round; ro ++)
            //{
            //    wb.Worksheets[0].Cells[ro+1, col].PutValue(ro);


            //    if (rptMapDict.ContainsKey(ro))
            //    {
            //        foreach(DAO.rptCell cel in rptMapDict[ro])
            //        {
            //            if (cel.divNo == 1)
            //            {
            //                wb.Worksheets[0].Cells[ro + 1, col].PutValue(cel.Team1No);
            //                wb.Worksheets[0].Cells[ro + 2, col].PutValue(cel.Team2No);
            //            }
            //            if(cel.divNo == 2)
            //            {
            //                wb.Worksheets[0].Cells[ro + 1, col + round + 1].PutValue(cel.Team1No);
            //                wb.Worksheets[0].Cells[ro + 2, col + round + 1].PutValue(cel.Team2No);
            //            }
            //        }
            //    }


            //    LeftRo++;
            //    RightRo--;
            //    col++;

            //}

            wb.Worksheets.RemoveAt(1);
            string fileName = Application.StartupPath + "\\test.xlsx";
            wb.Save(fileName);



        }



        private void _bgwLoadPlayer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbxEventItem.Enabled = true;
            if (_selectedEvent != null)
            {
                if (_selectedEvent.IsTeam)
                {
                    lblPlayerCount.Text = "參賽" + _TeamCount + "隊";
                }
                else
                {
                    lblPlayerCount.Text = "參賽" + _playerCount + "人";
                }

                LoadGameDataGridView();

            }
        }

        private void runRptMatches(SingleElimination se)
        {
            StringBuilder resultHTML = new StringBuilder();

            for (int i = 0; i < se.roundCount; i++)
            {
                List<Match> mat1s = se.getMatchesOfDiv(1, i + 1);
                if (mat1s.Count > 0)
                {
                    foreach (Match m in mat1s)
                    {

                        if (m.is_virtual)
                        {
                            String msg = @"左空白\n";
                            resultHTML.Append(msg);
                            if (!rptMapDict.ContainsKey(0))
                                rptMapDict.Add(0, new List<DAO.rptCell>());
                            DAO.rptCell cell = new DAO.rptCell();
                            cell.divNo = 1;
                            cell.Text = "空白";
                            rptMapDict[m.round_no].Add(cell);
                        }
                        else
                        {
                            int c1 = m.getCandidates()[0].lotsNo;
                            int c2 = m.getCandidates()[1].lotsNo;
                            string msg = @"左 {0}({1} - {2}){3}\n";

                            if (!rptMapDict.ContainsKey(m.round_no))
                                rptMapDict.Add(m.round_no, new List<DAO.rptCell>());

                            DAO.rptCell cell = new DAO.rptCell();
                            cell.GameNo = m.no;
                            cell.RoundNo = m.round_no;
                            cell.Team1No = c1;
                            cell.Team2No = c2;
                            cell.divNo = 1;
                            cell.Text = "(" + m.round_no + "-" + m.no + ")";
                            rptMapDict[m.round_no].Add(cell);

                            resultHTML.Append(String.Format(msg, c1, m.round_no, m.no, c2));
                        }


                    }
                }

            }


            for (int i = se.roundCount - 1; i > -1; i--)
            {
                List<Match> mat2s = se.getMatchesOfDiv(2, i + 1);
                if (mat2s.Count > 0)
                {
                    foreach (Match m in mat2s)
                    {
                        // console.log( m );
                        if (m.is_virtual)
                        {
                            string msg = @"右空白\n";
                            resultHTML.Append(msg);
                            if (!rptMapDict.ContainsKey(0))
                                rptMapDict.Add(0, new List<DAO.rptCell>());
                            DAO.rptCell cell = new DAO.rptCell();
                            cell.divNo = 2;
                            cell.Text = "空白";
                            rptMapDict[m.round_no].Add(cell);
                        }
                        else
                        {

                            int c1 = m.getCandidates()[0].lotsNo;
                            int c2 = m.getCandidates()[1].lotsNo;
                            string msg = @"右 {0}({1} - {2}){3}\n";

                            if (!rptMapDict.ContainsKey(m.round_no))
                                rptMapDict.Add(m.round_no, new List<DAO.rptCell>());

                            DAO.rptCell cell = new DAO.rptCell();
                            cell.GameNo = m.no;
                            cell.RoundNo = m.round_no;
                            cell.Team1No = c1;
                            cell.Team2No = c2;
                            cell.divNo = 2;
                            cell.Text = "(" + m.round_no + "-" + m.no + ")"; ;
                            rptMapDict[m.round_no].Add(cell);

                            resultHTML.Append(String.Format(msg, c1, m.round_no, m.no, c2));
                        }
                    }
                }

            }

            Console.WriteLine(resultHTML);
        }

        private void LoadGameDataGridView()
        {
            dgData.Rows.Clear();
            foreach (UDT.Games data in _GameList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Cells[colRoundNo.Index].Value = data.RoundNo;
                dgData.Rows[rowIdx].Cells[colGameNo.Index].Value = data.GameNo;

            }
        }

        private void _bgwLoadPlayer_DoWork(object sender, DoWorkEventArgs e)
        {
            _playerCount = _TeamCount = 0;
            if (_selectedEvent != null)
            {
                List<UDT.Players> pList = GetPlayerByEventUid(_selectedEvent.UID);
                List<int> teamCount = new List<int>();
                List<int> playCount = new List<int>();
                foreach (UDT.Players data in pList)
                {
                    if (data.RefTeamId.HasValue)
                    {
                        if (!teamCount.Contains(data.RefTeamId.Value))
                            teamCount.Add(data.RefTeamId.Value);
                    }
                    if (!playCount.Contains(data.RefStudentId))
                        playCount.Add(data.RefStudentId);
                }
                _playerCount = playCount.Count;
                _TeamCount = teamCount.Count;
                LoadGames();
            }
        }

        private void _bgwRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _bgwRun_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BindComboData();
            if (cbxGameType.Items.Count > 0)
                cbxGameType.SelectedIndex = 0;
            btnRun.Enabled = true;
            cbxEventItem.Enabled = true;
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadEvents();
            LoadGameType();
            LoadGames();
        }

        private void BindComboData()
        {
            cbxEventItem.Items.Clear();
            foreach (string key in _EventItemDict.Keys)
                cbxEventItem.Items.Add(key);

            cbxGameType.Items.Clear();
            foreach (string key in _GameTypeDict.Keys)
                cbxGameType.Items.Add(key);

        }

        private void frmGameProducer_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            btnRun.Enabled = false;
            cbxEventItem.Enabled = false;
            lblPlayerCount.Text = "";
            // 載入預設學年度
            iptSchoolYear.Value = _defaultSchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
            _bgwLoadData.RunWorkerAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private int GetPCount()
        {
            int value = 0;
            if (_selectedEvent != null)
            {
                if (_selectedEvent.IsTeam)
                {
                    value = _TeamCount;
                }
                else
                {
                    value = _playerCount;
                }
            }
            return value;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            // 單淘汰賽
            if (_selectedEvent != null)
            {
                // 取得隊伍數
                int pCount = GetPCount();

                if (_GameList.Count > 0)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("當按「是」將刪除舊資料", "刪除舊資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        // 刪除舊資料
                        DeleteOldGameData();
                    }
                    else
                    {
                        btnRun.Enabled = true;
                        return;
                    }

                }

                Tournaments.SingleElimination se = new Tournaments.SingleElimination(pCount);
                se.startMatching();
                runMatches(se);
                btnRun.Enabled = true;
                _bgwLoadPlayer.RunWorkerAsync();
            }
        }

        private void DeleteOldGameData()
        {
            List<int> delGameId = new List<int>();
            AccessHelper acc = new AccessHelper();

            foreach (var d in _GameList)
            {
                delGameId.Add(int.Parse(d.UID));
                d.Deleted = true;
            }

            if (delGameId.Count > 0)
            {
                List<UDT.GameCandidates> gcList = acc.Select<UDT.GameCandidates>(" ref_game_id in(" + string.Join(",", delGameId.ToArray()) + ")");
                foreach (var d in gcList)
                    d.Deleted = true;

                gcList.SaveAll();
            }

            _GameList.SaveAll();

        }

        private void runMatches(SingleElimination se)
        {
            StringBuilder resultHTML = new StringBuilder();
            AccessHelper acc = new AccessHelper();

            List<UDT.Games> addGameLeftList = new List<UDT.Games>();
            List<UDT.Games> addGameRightList = new List<UDT.Games>();
            List<UDT.GameCandidates> addGameCandidates = new List<UDT.GameCandidates>();
            int ref_event_id = int.Parse(_selectedEvent.UID);

            for (int i = 0; i < se.roundCount; i++)
            {
                List<Match> mat1s = se.getMatchesOfDiv(1, i + 1);
                if (mat1s.Count > 0)
                {
                    foreach (Match m in mat1s)
                    {
                        if (m.is_virtual)
                        {
                            String msg = @"左空白\n";
                            resultHTML.Append(msg);
                        }
                        else
                        {
                            UDT.Games gL = new UDT.Games();
                            gL.RefEventId = ref_event_id;
                            gL.UUID = Guid.NewGuid().ToString();
                            gL.GameNo = m.no;
                            gL.RoundNo = m.round_no;
                            gL.CreatedBy = _userAccount;
                            addGameLeftList.Add(gL);

                            int c1 = m.getCandidates()[0].lotsNo;
                            int c2 = m.getCandidates()[1].lotsNo;
                            string msg = @"左 {0}({1} - {2}){3}\n";
                            resultHTML.Append(String.Format(msg, c1, m.round_no, m.no, c2));
                        }

                    }
                }

            }


            for (int i = se.roundCount - 1; i > -1; i--)
            {
                List<Match> mat2s = se.getMatchesOfDiv(2, i + 1);
                //console.log(` === div:2, round:${i+1}, matches count: ${(mat2s ? mat2s.length : 0)}`)
                if (mat2s.Count > 0)
                {
                    foreach (Match m in mat2s)
                    {
                        // console.log( m );
                        if (m.is_virtual)
                        {
                            string msg = @"右空白\n";
                            resultHTML.Append(msg);
                        }
                        else
                        {
                            UDT.Games gR = new UDT.Games();
                            gR.RefEventId = ref_event_id;
                            gR.UUID = Guid.NewGuid().ToString();
                            gR.GameNo = m.no;
                            gR.RoundNo = m.round_no;
                            gR.CreatedBy = _userAccount;
                            addGameRightList.Add(gR);

                            int c1 = m.getCandidates()[0].lotsNo;
                            int c2 = m.getCandidates()[1].lotsNo;
                            string msg = @"右 {0}({1} - {2}){3}\n";
                            resultHTML.Append(String.Format(msg, c1, m.round_no, m.no, c2));
                        }
                    }
                }

            }

            if (addGameLeftList.Count > 0)
            {
                addGameLeftList.SaveAll();
                // 處理第一輪
                List<UDT.Games> gL = acc.Select<UDT.Games>("ref_event_id = " + ref_event_id + " AND round_no=1");
                if (gL.Count > 0)
                {
                    foreach (UDT.Games data in gL)
                    {
                        UDT.GameCandidates gc = new UDT.GameCandidates();
                        gc.RefGameId = int.Parse(data.UID);
                        gc.RefGameUuid = data.UUID;
                        gc.UUID = Guid.NewGuid().ToString();
                        gc.DivNo = 1;
                        gc.CreatedBy = _userAccount;
                        addGameCandidates.Add(gc);
                    }
                }
            }

            if (addGameRightList.Count > 0)
            {
                addGameRightList.SaveAll();
                // 處理第一輪
                List<UDT.Games> gL = acc.Select<UDT.Games>("ref_event_id = " + ref_event_id + " AND round_no=1");
                if (gL.Count > 0)
                {
                    foreach (UDT.Games data in gL)
                    {
                        UDT.GameCandidates gc = new UDT.GameCandidates();
                        gc.RefGameId = int.Parse(data.UID);
                        gc.RefGameUuid = data.UUID;
                        gc.UUID = Guid.NewGuid().ToString();
                        gc.DivNo = 2;
                        gc.CreatedBy = _userAccount;
                        addGameCandidates.Add(gc);
                    }
                }
            }

            if (addGameCandidates.Count > 0)
            {
                addGameCandidates.SaveAll();
            }

            Console.WriteLine(resultHTML);
        }


        /// <summary>
        /// 載入組別資料
        /// </summary>
        private void LoadGroupType()
        {
            _GroupTypeMapDict.Clear();

            List<UDT.GroupTypes> gpList = _access.Select<UDT.GroupTypes>();
            foreach (UDT.GroupTypes data in gpList)
            {
                int uid = int.Parse(data.UID);

                if (!_GroupTypeMapDict.ContainsKey(uid))
                    _GroupTypeMapDict.Add(uid, data);
            }
        }

        /// <summary>
        /// 載入賽制
        /// </summary>
        private void LoadGameType()
        {
            _GameTypeDict.Clear();
            List<UDT.GameTypes> gtList = _access.Select<UDT.GameTypes>();
            foreach (UDT.GameTypes data in gtList)
            {
                if (!_GameTypeDict.ContainsKey(data.Name))
                    _GameTypeDict.Add(data.Name, int.Parse(data.UID));
            }
        }
        /// <summary>
        /// 載入競賽項目
        /// </summary>
        private void LoadEvents()
        {
            if (_selectSchoolYear > 0)
            {
                LoadGroupType();

                _EventItemDict.Clear();

                List<UDT.Events> events = _access.Select<UDT.Events>(" school_year = " + _selectSchoolYear);
                foreach (UDT.Events data in events)
                {
                    // 建立 key
                    string key = data.Name;

                    if (_GroupTypeMapDict.ContainsKey(data.RefGroupTypeId))
                    {
                        key += "-" + _GroupTypeMapDict[data.RefGroupTypeId].Name;
                    }

                    if (!_EventItemDict.ContainsKey(key))
                    {
                        _EventItemDict.Add(key, data);
                    }
                }
            }
        }

        /// <summary>
        /// 載入賽程
        /// </summary>
        private void LoadGames()
        {
            if (_selectedEvent != null)
            {
                _GameList.Clear();
                AccessHelper acc = new AccessHelper();
                _GameList = acc.Select<UDT.Games>(" ref_event_id = " + _selectedEvent.UID);

                _GameList = _GameList.OrderBy(x => x.GameNo).ToList();

            }
        }

        private void cbxEventItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEventItem.Enabled = false;
            // 取得畫面所選 event uid
            _selectedEvent = null;
            if (_EventItemDict.ContainsKey(cbxEventItem.Text))
            {
                _selectedEvent = _EventItemDict[cbxEventItem.Text];
                _bgwLoadPlayer.RunWorkerAsync();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (_selectedEvent != null)
            {
                btnReport.Enabled = false;
                _bgwRunReport.RunWorkerAsync();
            }
        }

        private List<UDT.Players> GetPlayerByEventUid(string uid)
        {
            List<UDT.Players> value = new List<UDT.Players>();
            value = _access.Select<UDT.Players>(" ref_event_id = " + uid);
            return value;
        }

        private void iptSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            cbxEventItem.Enabled = false;
            // 當不同學年度不能執行產生賽程
            if (!iptSchoolYear.IsEmpty)
            {
                _selectSchoolYear = iptSchoolYear.Value;
                if (_selectSchoolYear == _defaultSchoolYear)
                {
                    btnRun.Enabled = true;
                    cbxEventItem.Enabled = true;
                }
            }
        }
    }
}
