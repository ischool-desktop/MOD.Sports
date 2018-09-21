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
        public static string _permission = @"<Permissions>
<Feature Code=""18641FBE-D04F-429E-B9FC-D606F4BC9CDB"" Permission=""Execute""/>
<Feature Code=""32E7D48F-A373-4967-AC34-1FD0907F7359"" Permission=""Execute""/>
<Feature Code=""50B5B0F4-43B9-4E80-9607-A3881ADB2C9B"" Permission=""Execute""/>
<Feature Code=""1FBEBE26-3E48-487F-B0DA-8418E5ED6D7F"" Permission=""Execute""/>
<Feature Code=""112D28C7-07C1-49B7-8E17-FF7D3973EFBB"" Permission=""Execute""/>
<Feature Code=""47FAA49A-6832-497C-B9CA-7022DA9FAAF0"" Permission=""Execute""/>
<Feature Code=""AE234B9C-FE8A-4540-97F2-B766DE817D1C"" Permission=""Execute""/>
<Feature Code=""E8F13373-5C90-4ED8-9FBD-DE1DAC9B6E28"" Permission=""Execute""/>
<Feature Code=""AC9170BD-E80E-4CDE-BAA5-D097BF019A0E"" Permission=""Execute""/>
<Feature Code=""783839F5-161F-47E5-BD3C-4E558BD3E38E"" Permission=""Execute""/>
<Feature Code=""FB8CC43D-7C13-4115-BA43-9F9E79F70B5D"" Permission=""Execute""/>
<Feature Code=""E2448E87-B79E-4F45-9F71-185772BF14A2"" Permission=""Execute""/>
<Feature Code=""7D8AD083-3A66-4116-BAE8-72C90E95AB67"" Permission=""Execute""/>
<Feature Code=""66C5D1F8-C03C-4D9C-BD26-7C432461E34C"" Permission=""Execute""/>
<Feature Code=""81FBBE8F-3767-4ACB-8720-35DC8F078097"" Permission=""Execute""/>
<Feature Code=""FEBDF352-8CB4-41D4-906C-E1F444EDCEA8"" Permission=""Execute""/>
<Feature Code=""AF62B6A2-69AE-48F4-910E-63586A2593D7"" Permission=""Execute""/>
<Feature Code=""EDE14B67-0827-4E29-BB79-F383690474AD"" Permission=""Execute""/>
<Feature Code=""9D6766B3-A27D-49EF-8AB8-BB5E9352819B"" Permission=""Execute""/>
<Feature Code=""F227014D-F8C7-4DA5-AD89-5D492D8513DA"" Permission=""Execute""/>
<Feature Code=""584E7615-D986-44E4-8ACD-B513889E4C18"" Permission=""Execute""/>
<Feature Code=""BEF49287-7C2D-4702-ACE0-5515636C0048"" Permission=""Execute""/>
</Permissions>";

        public static string _roleID;


        [MainMethod("體育競賽模組")]
        static public void Main()
        {

            string MODName = "體育競賽";
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

            MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"].Image = Properties.Resources.foreign_language_config_64;
            MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"].Size = RibbonBarButton.MenuButtonSize.Large;

            MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"].Image = Properties.Resources.schedule_config_64;
            MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"].Size = RibbonBarButton.MenuButtonSize.Large;
            MotherForm.RibbonBarItems[MODName, "管理"]["管理"].Image = Properties.Resources.recreation_info_64;
            MotherForm.RibbonBarItems[MODName, "管理"]["管理"].Size = RibbonBarButton.MenuButtonSize.Large;
            #region 設定組別
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定組別"].Enable = Permissions.設定組別權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定組別"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmGroupTypes()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 設定計分方式
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定計分方式"].Enable = Permissions.設定計分方式權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定計分方式"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmScoreTypes()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 設定賽制
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定賽制"].Enable = Permissions.設定賽制權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["競賽設定"]["設定賽制"].Click += delegate
                {

                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmGameTypes()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 管理競賽樣板
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽樣板"].Enable = Permissions.管理競賽樣板權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽樣板"].Click += delegate
                {

                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmEventTemplates()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 管理競賽
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽"].Enable = Permissions.管理競賽權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理競賽"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmEvents()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 管理報名記錄
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理報名記錄"].Enable = Permissions.管理報名記錄權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理報名記錄"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmRegistrationRecord()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }
                };
            }
            #endregion

            #region 管理賽程
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理賽程"].Enable = Permissions.管理賽程權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理賽程"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmGameProducer()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion
            #region 設定體育股長
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["設定體育股長"].Enable = Permissions.設定體育股長權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["設定體育股長"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmSetSportsChief()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            #region 管理歷年紀錄
            {
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理歷年紀錄"].Enable = Permissions.管理歷年紀錄權限;
                MotherForm.RibbonBarItems[MODName, "管理"]["管理"]["管理歷年紀錄"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmHistoricalRecords()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion
            #region 設定管理員
            {
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["設定管理員"].Enable = Permissions.設定管理員權限;
                MotherForm.RibbonBarItems[MODName, "基本設定"]["人員設定"]["設定管理員"].Click += delegate
                {
                    if (DAO.Actor.Instance().CheckAdmin())
                    {
                        (new frmAdmin()).ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show("此帳號沒有體育競賽管理權限!");
                    }

                };
            }
            #endregion

            Catalog detail = new Catalog();
            detail = RoleAclSource.Instance["體育競賽"]["功能按鈕"];
            detail.Add(new RibbonFeature(Permissions.設定體育股長, "設定體育股長"));
            detail.Add(new RibbonFeature(Permissions.設定管理員, "設定管理員"));
            detail.Add(new RibbonFeature(Permissions.管理賽程, "管理賽程"));
            detail.Add(new RibbonFeature(Permissions.設定賽制, "設定賽制"));
            detail.Add(new RibbonFeature(Permissions.設定計分方式, "設定計分方式"));
            detail.Add(new RibbonFeature(Permissions.設定組別, "設定組別"));
            detail.Add(new RibbonFeature(Permissions.管理報名記錄, "管理報名記錄"));
            detail.Add(new RibbonFeature(Permissions.管理競賽, "管理競賽"));
            detail.Add(new RibbonFeature(Permissions.管理競賽樣板, "管理競賽樣板"));
            detail.Add(new RibbonFeature(Permissions.管理歷年紀錄, "管理歷年紀錄"));
        }

    }
}
