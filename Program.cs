using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA;
using FISCA.UDT;
using K12.Data.Configuration;
using FISCA.Presentation;
using FISCA.Permission;
using FISCA.Presentation.Controls;

namespace ischool.Sports
{
    public class Program
    {
        /// <summary>
        /// 體育競賽模組專用腳色名稱
        /// </summary>
        public static string _roleName = "體育競賽管理員";

        /// <summary>
        /// 體育競賽模組專用角色的功能權限
        /// </summary>
        public static string _permission = "";
        public static string _roleID;


        [MainMethod("體育競賽模組")]
        static public void Main()
        {
            string MODName = "體育競賽(開發中)";
            #region Init UDT
            {
                ConfigData cd = K12.Data.School.Configuration["體育競賽模組載入設定"];

                bool checkUDT = false;
                string name = "體育競賽UDT是否已載入";

                 //cd[name] = "false";

                //如果尚無設定值,預設為
                if (string.IsNullOrEmpty(cd[name]))
                {
                    cd[name] = "false";
                }

                //檢查是否為布林
                bool.TryParse(cd[name], out checkUDT);

                if (!checkUDT) //
                {
                    AccessHelper access = new AccessHelper();
                    access.Select<UDT.Admin>("UID = '00000'");
                    access.Select<UDT.Events>("UID = '00000'");
                    access.Select<UDT.EventTemplates>("UID = '00000'");
                    access.Select<UDT.Games>("UID = '00000'");
                    access.Select<UDT.GameTypes>("UID = '00000'");
                    access.Select<UDT.GroupTypes>("UID = '00000'");
                    access.Select<UDT.HistoricalRecords>("UID = '00000'");
                    access.Select<UDT.Players>("UID = '00000'");
                    access.Select<UDT.ScoreTypes>("UID = '00000'");
                    access.Select<UDT.Teams>("UID = '00000'");
                    access.Select<UDT.GameCandidates>("UID = '00000'");
                    access.Select<UDT.SportsChief>("UID = '00000'");

                    cd[name] = "true";
                    cd.Save();
                }
            }
            #endregion

            #region 體育競賽

            MotherForm.AddPanel(SportsPanel.Instance);

            #endregion

            #region Init Role
            {
                // 檢查腳色是否存在
                if (!DAO.Role.CheckRoleExist())
                {
                    // 建立腳色
                    _roleID = DAO.Role.CreatRole();
                }
                else
                {
                    _roleID = DAO.Role.GetRoleID();
                }
            }
            #endregion

            #region 設定組別
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定組別"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定組別"].Click += delegate
                {
                    (new frmGroupTypes()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 設定計分方式
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定計分方式"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定計分方式"].Click += delegate
                {
                    (new frmScoreTypes()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 設定賽制
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定賽制"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定賽制"].Click += delegate
                {
                    (new frmGameTypes()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 管理競賽
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽"].Click += delegate
                {
                    (new frmEvents()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 管理競賽樣板
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽樣板"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽樣板"].Click += delegate
                {
                    (new frmEventTemplates()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 管理報名記錄
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理報名記錄"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理報名記錄"].Click += delegate
                {
                    (new frmRegistrationRecord()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion

            #region 管理賽程
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理賽程"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理賽程"].Click += delegate
                {
                    (new frmGameProducer()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion
            #region 管理體育股長
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["管理體育股長"].Enable = true;//Permissions.設定時段權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["管理體育股長"].Click += delegate
                {
                    (new frmSetSportsChief()).ShowDialog();

                    //if (DAO.Actor.Instance().CheckAdmin())
                    //{
                    //    (new frmGroupTypes()).ShowDialog();
                    //}
                    //else
                    //{
                    //    MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    //}

                };
            }
            #endregion
        }

    }
}
