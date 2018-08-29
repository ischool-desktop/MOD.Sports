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
using FISCA.UDT;

namespace ischool.Sports
{
    public partial class frmEvents : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();

        List<UDT.Events> _EventsList = new List<UDT.Events>();
        List<UDT.GroupTypes> _GroupTypesList = new List<UDT.GroupTypes>();
        List<UDT.GameTypes> _GameTypesList = new List<UDT.GameTypes>();
        Dictionary<string, UDT.GroupTypes> _GroupTypesDict = new Dictionary<string, UDT.GroupTypes>();
        Dictionary<string, UDT.GameTypes> _GameTypesDict = new Dictionary<string, UDT.GameTypes>();

        BackgroundWorker _bgw = new BackgroundWorker();

        public frmEvents()
        {
            InitializeComponent();
            _bgw.WorkerReportsProgress = true;
            _bgw.DoWork += _bgw_DoWork;
            _bgw.RunWorkerCompleted += _bgw_RunWorkerCompleted;
        }

        private void _bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = true;
        }

        private void _bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 讀取 比賽項目
            LoadEventsList();

            // 讀取賽制
            LoadGameTypesList();

            // 讀取組別
            LoadGroupTypesList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UDT.Events addEvents = null;

            frmEventsTemplateAdd1 feta = new frmEventsTemplateAdd1();
            if (feta.ShowDialog() == DialogResult.OK)
            {
                addEvents = feta.GetEvents();
            }

            frmSubEvents addFrom = new frmSubEvents();
            addFrom.SetEvents(addEvents);
            addFrom.SetIsAddMode(true);
            addFrom.SetGameTypesDict(_GameTypesDict);
            addFrom.SetGroupTypesDict(_GroupTypesDict);
            if (addFrom.ShowDialog() == DialogResult.OK)
            {
                addEvents = addFrom.GetEventData();
            }
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = false;
            _bgw.RunWorkerAsync();

        }

        private void LoadEventsList()
        {
            _EventsList = _access.Select<UDT.Events>();

        }

        private void LoadGroupTypesList()
        {
            _GroupTypesList = _access.Select<UDT.GroupTypes>();
            // 建立對照
            _GroupTypesDict.Clear();
            foreach(var data in _GroupTypesList)
            {
                if (!_GroupTypesDict.ContainsKey(data.UID))
                    _GroupTypesDict.Add(data.UID, data);

                if (!_GroupTypesDict.ContainsKey(data.Name))
                    _GroupTypesDict.Add(data.Name, data);
            }
        }

        private void LoadGameTypesList()
        {
            _GameTypesList = _access.Select<UDT.GameTypes>();
            _GameTypesDict.Clear();
            foreach(var data in _GameTypesList)
            {
                if (!_GameTypesDict.ContainsKey(data.UID))
                    _GameTypesDict.Add(data.UID, data);

                if (!_GameTypesDict.ContainsKey(data.Name))
                    _GameTypesDict.Add(data.Name, data);

            }
        }
    }
}
