using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 比賽項目樣板
    /// </summary>
    [TableName("ischool.sports.event_templates")]

    class EventTemplates : ActiveRecord
    {
        /// <summary>
        /// 類別
        /// </summary>
        [Field(Field = "category", Indexed = false)]
        public string Category { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        /// <summary>
        /// 計分方式
        /// </summary>
        [Field(Field = "ref_score_type_id", Indexed = false)]
        public int RefScoreTypeId { get; set; }

        /// <summary>
        /// 是否團體賽
        /// </summary>
        [Field(Field = "is_team", Indexed = false)]
        public bool IsTeam { get; set; }

        /// <summary>
        /// 一隊最多人數
        /// </summary>
        [Field(Field = "max_member_count", Indexed = false)]
        public int MaxMemberCount { get; set; }

        /// <summary>
        /// 一隊最少人數
        /// </summary>
        [Field(Field = "min_member_count", Indexed = false)]
        public int MinMemberCount { get; set; }

        /// <summary>
        /// 僅能體育股長報名
        /// </summary>
        [Field(Field = "athletic_only", Indexed = false)]
        public bool AthleticOnly { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}