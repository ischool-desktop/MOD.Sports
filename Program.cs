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

        public static string _roleID;

        [MainMethod("體育競賽模組")]
        static public void Main()
        {
            #region Init UDT
            {
                ConfigData cd = K12.Data.School.Configuration["體育競賽模組載入設定"];

                bool checkUDT = false;
                string name = "體育競賽UDT是否已載入";

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


                    cd[name] = "true";
                    cd.Save();
                }
            }
            #endregion

            #region 體育競賽

            MotherForm.AddPanel(SportsPanel.Instance);

#endregion
        }
    }
}
