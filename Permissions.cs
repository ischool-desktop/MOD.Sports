using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ischool.Sports
{
    class Permissions
    {
        public static string 設定體育股長 { get { return "18641FBE-D04F-429E-B9FC-D606F4BC9CDB"; } }
        public static bool 設定體育股長權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[設定體育股長].Executable;
            }
        }

        public static string 設定管理員 { get { return "32E7D48F-A373-4967-AC34-1FD0907F7359"; } }
        public static bool 設定管理員權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[設定管理員].Executable;
            }
        }

        public static string 管理賽程 { get { return "50B5B0F4-43B9-4E80-9607-A3881ADB2C9B"; } }
        public static bool 管理賽程權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[管理賽程].Executable;
            }
        }

        public static string 設定賽制 { get { return "1FBEBE26-3E48-487F-B0DA-8418E5ED6D7F"; } }
        public static bool 設定賽制權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[設定賽制].Executable;
            }
        }

        public static string 設定計分方式 { get { return "112D28C7-07C1-49B7-8E17-FF7D3973EFBB"; } }
        public static bool 設定計分方式權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[設定計分方式].Executable;
            }
        }

        public static string 設定組別 { get { return "47FAA49A-6832-497C-B9CA-7022DA9FAAF0"; } }
        public static bool 設定組別權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[設定組別].Executable;
            }
        }

        public static string 管理報名記錄 { get { return "AE234B9C-FE8A-4540-97F2-B766DE817D1C"; } }
        public static bool 管理報名記錄權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[管理報名記錄].Executable;
            }
        }

        public static string 管理競賽 { get { return "E8F13373-5C90-4ED8-9FBD-DE1DAC9B6E28"; } }
        public static bool 管理競賽權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[管理競賽].Executable;
            }
        }

        public static string 管理競賽樣板 { get { return "AC9170BD-E80E-4CDE-BAA5-D097BF019A0E"; } }
        public static bool 管理競賽樣板權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[管理競賽樣板].Executable;
            }
        }
        public static string 管理歷年紀錄 { get { return "783839F5-161F-47E5-BD3C-4E558BD3E38E"; } }
        public static bool 管理歷年紀錄權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[管理歷年紀錄].Executable;
            }
        }
    }
}
