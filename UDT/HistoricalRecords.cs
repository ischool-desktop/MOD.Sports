using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 歷年紀錄
    /// </summary>
    [TableName("ischool.sports.historical_records")]

    public class HistoricalRecords : ActiveRecord
    {
        /// <summary>
        /// 年度比賽項目編號
        /// </summary>
        [Field(Field = "ref_event_id", Indexed = false)]
        public int RefEventId { get; set; }

        /// <summary>
        /// 名次
        /// </summary>
        [Field(Field = "rank", Indexed = false)]
        public int Rank { get; set; }

        /// <summary>
        /// 選手姓名
        /// </summary>
        [Field(Field = "players", Indexed = false)]
        public string Players { get; set; }

        /// <summary>
        /// 隊伍名稱
        /// </summary>
        [Field(Field = "team_name", Indexed = false)]
        public string TeamName { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}