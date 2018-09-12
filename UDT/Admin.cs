using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;
namespace ischool.Sports.UDT
{

        /// <summary>
        /// 管理員()
        /// </summary>
        [TableName("ischool.sports.admin")]
        public class Admin : ActiveRecord
        {
            /// <summary>
            /// 登入帳號
            /// </summary>
            [Field(Field = "account", Indexed = false)]
            public string Account { get; set; }

            /// <summary>
            /// 教師編號
            /// </summary>
            [Field(Field = "ref_teacher_id", Indexed = false)]
            public int RefTeacherID { get; set; }

            /// <summary>
            /// 建立者帳號
            /// </summary>
            [Field(Field = "created_by", Indexed = false)]
            public string CreatedBy { get; set; }
        }
    
}
