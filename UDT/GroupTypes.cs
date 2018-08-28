using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 組別
    /// </summary>
    [TableName("ischool.sports.group_types")]
    public class GroupTypes : ActiveRecord
    {
        /// <summary>
        /// 名稱
        /// </summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        /// <summary>
        /// 性別限定
        /// </summary>
        [Field(Field = "gender", Indexed = false)]
        public string Gender { get; set; }

        /// <summary>
        /// 年級限定
        /// </summary>
        [Field(Field = "grade", Indexed = false)]
        public int? Grade { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}
