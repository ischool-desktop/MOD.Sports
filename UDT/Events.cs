using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 年度比賽項目
    /// </summary>
    [TableName("ischool.sports.events")]

    class Events : ActiveRecord
    {
        /// <summary>
        /// 學年度
        /// </summary>
        [Field(Field = "school_year", Indexed = false)]
        public int SchoolYear { get; set; }

        /// <summary>
        /// 項目樣板編號
        /// </summary>
        [Field(Field = "ref_item_template_id", Indexed = false)]
        public int RefItemTemplateId { get; set; }

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
        /// 組別編號
        /// </summary>
        [Field(Field = "ref_group_type_id", Indexed = false)]
        public int RefGroupTypeId { get; set; }

        /// <summary>
        /// 賽制編號
        /// </summary>
        [Field(Field = "ref_game_type_id", Indexed = false)]
        public int RefGameTypeId { get; set; }

        /// <summary>
        /// 是否團體賽
        /// </summary>
        [Field(Field = "is_team", Indexed = false)]
        public bool is_team { get; set; }

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
        /// 報名開始時間
        /// </summary>
        [Field(Field = "reg_start_date", Indexed = false)]
        public DateTime RegStartDate { get; set; }

        /// <summary>
        /// 報名結束時間
        /// </summary>
        [Field(Field = "reg_end_date", Indexed = false)]
        public DateTime RegEndDate { get; set; }

        /// <summary>
        /// 活動開始時間
        /// </summary>
        [Field(Field = "event_start_date", Indexed = false)]
        public DateTime EventStartDate { get; set; }


        /// <summary>
        /// 活動結束時間
        /// </summary>
        [Field(Field = "event_end_date", Indexed = false)]
        public DateTime EventEndDate { get; set; }

        /// <summary>
        /// 是否抽籤
        /// </summary>
        [Field(Field = "is_draw_lots", Indexed = false)]
        public bool IsDrawLots { get; set; }

        /// <summary>
        /// 抽籤日期
        /// </summary>
        [Field(Field = "draw_lots_date", Indexed = false)]
        public DateTime DrawLotsDate { get; set; }

        /// <summary>
        /// 比賽說明
        /// </summary>
        [Field(Field = "event_description", Indexed = false)]
        public string EventDescription { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }

    }
}