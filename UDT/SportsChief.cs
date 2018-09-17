using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 體育股長
    /// </summary>
    [TableName("ischool.sports.sports_chief")]

    public class SportsChief : ActiveRecord
    {

        /// <summary>
        /// 學生帳號
        /// </summary>
        [Field(Field = "account", Indexed = false)]
        public string Account { get; set; }

        /// <summary>
        /// 學年度
        /// </summary>
        [Field(Field = "school_year", Indexed = false)]
        public int SchoolYear { get; set; }

        /// <summary>
        /// 班級系統編號
        /// </summary>
        [Field(Field = "ref_class_id", Indexed = false)]
        public int RefClassID { get; set; }

        /// <summary>
        /// 學生系統編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int RefStudentID { get; set; }

    }
}
