using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 計分方式
    /// </summary>
    [TableName("ischool.sports.score_types")]

    public class ScoreTypes : ActiveRecord
    {
        /// <summary>
        /// 名稱
        /// </summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        /// <summary>
        /// 代號
        /// </summary>
        [Field(Field = "key", Indexed = false)]
        public string Key { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}
