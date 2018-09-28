using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 體育競賽報名人員
    /// </summary>
    [TableName("ischool.sports.sports_registration")]

    public class SportsRegistration : ActiveRecord
    {

        /// <summary>
        /// 年度比賽項目編號
        /// </summary>
        [Field(Field = "ref_event_id", Indexed = false)]
        public int RefEventID { get; set; }

        /// <summary>
        /// 學生帳號
        /// </summary>
        [Field(Field = "account", Indexed = false)]
        public string Account { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int RefStudentID { get; set; }

    }
}
