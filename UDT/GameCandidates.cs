using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 比賽對象
    /// </summary>
    [TableName("ischool.sports.game_candidates")]

    public class GameCandidates : ActiveRecord
    {
        /// <summary>
        /// 比賽場次編號
        /// </summary>
        [Field(Field = "ref_game_id", Indexed = false)]
        public int RefGameId { get; set; }

        /// <summary>
        /// 比賽場次唯一識別碼
        /// </summary>
        [Field(Field = "ref_game_uuid", Indexed = false)]
        public string RefGameUuid { get; set; }

        /// <summary>
        /// 唯一識別碼
        /// </summary>
        [Field(Field = "uuid", Indexed = false)]
        public string UUID { get; set; }

        /// <summary>
        /// 第一輪編號
        /// </summary>
        [Field(Field = "lot_no", Indexed = false)]
        public int LotNo { get; set; }

        /// <summary>
        /// 第一區或第二區
        /// </summary>
        [Field(Field = "div_no", Indexed = false)]
        public int DivNo { get; set; }

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

    }
}