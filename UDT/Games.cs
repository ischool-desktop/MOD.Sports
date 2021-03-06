﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 比賽場次
    /// </summary>
    [TableName("ischool.sports.games")]

    public class Games : ActiveRecord
    {
        /// <summary>
        /// 年度比賽項目編號
        /// </summary>
        [Field(Field = "ref_event_id", Indexed = false)]
        public int RefEventId { get; set; }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        [Field(Field = "uuid", Indexed = false)]
        public string UUID { get; set; }

        /// <summary>
        /// 第幾場比賽
        /// </summary>
        [Field(Field = "game_no", Indexed = false)]
        public int GameNo { get; set; }

        /// <summary>
        /// 第幾輪比賽
        /// </summary>
        [Field(Field = "round_no", Indexed = false)]
        public int RoundNo { get; set; }

        /// <summary>
        /// 比賽時間
        /// </summary>
        [Field(Field = "occur_time", Indexed = false)]
        public DateTime? OccurTime { get; set; }

        /// <summary>
        /// 比賽地點
        /// </summary>
        [Field(Field = "place", Indexed = false)]
        public string Place { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 比賽抽籤1
        /// </summary>
        [Field(Field = "lot_no1", Indexed = false)]
        public int? LotNo1 { get; set; }

        /// <summary>
        /// 比賽抽籤2
        /// </summary>
        [Field(Field = "lot_no2", Indexed = false)]
        public int? LotNo2 { get; set; }

    }
}