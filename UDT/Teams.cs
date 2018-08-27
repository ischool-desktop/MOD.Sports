using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 比賽隊伍
    /// </summary>
    [TableName("ischool.sports.teams")]

    class Teams : ActiveRecord
    {
        /// <summary>
        /// 年度比賽項目編號
        /// </summary>
        [Field(Field = "ref_event_id", Indexed = false)]
        public int RefEventId { get; set; }

        /// <summary>
        /// 隊伍名稱
        /// </summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        /// <summary>
        /// 抽籤號
        /// </summary>
        [Field(Field = "lot_no", Indexed = false)]
        public int LotNo { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}