using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA.UDT;

namespace ischool.Sports.UDT
{
    /// <summary>
    /// 參賽選手
    /// </summary>
    [TableName("ischool.sports.players")]

    public class Players : ActiveRecord
    {
        /// <summary>
        /// 年度比賽項目編號
        /// </summary>
        [Field(Field = "ref_event_id", Indexed = false)]
        public int RefEventId { get; set; }

        /// <summary>
        /// 學生編號
        /// </summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int RefStudentId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        /// <summary>
        /// 當時班級名稱
        /// </summary>
        [Field(Field = "class_name", Indexed = false)]
        public string ClassName { get; set; }

        /// <summary>
        /// 當時座號
        /// </summary>
        [Field(Field = "seat_no", Indexed = false)]
        public int SeatNo { get; set; }

        /// <summary>
        /// 參賽隊伍編號
        /// </summary>
        [Field(Field = "ref_team_id", Indexed = false)]
        public int? RefTeamId { get; set; }

        /// <summary>
        /// 是否是隊長
        /// </summary>
        [Field(Field = "is_team_leader", Indexed = false)]
        public bool IsTeamLeader { get; set; }

        /// <summary>
        /// 抽籤號
        /// </summary>
        [Field(Field = "lot_no", Indexed = false)]
        public int? LotNo { get; set; }

        /// <summary>
        /// 建立者帳號
        /// </summary>
        [Field(Field = "created_by", Indexed = false)]
        public string CreatedBy { get; set; }
    }
}