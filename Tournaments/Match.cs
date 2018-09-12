using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    /// <summary>
    ///  代表一場比賽，裡面會有兩個對手
    ///  還有場次號碼，
    ///  額外有時間，場地等資訊。
    /// </summary>
    public class Match
    {
        /**
     * 建構子
     * @param {number} round 第幾輪比賽
     * @param {number} no 第幾場比賽
     * @memberof Match
     */
        public Match(int div_no, int round, int no)
        {
            this.div_no = div_no;
            this.no = no;
            this.round_no = round;
            this.uqid = Guid.NewGuid().ToString();
        }

        public string uqid;

        /**
         * 第幾區
         */
        public int div_no;

        /**
         * 第幾場比賽
         */
        public int no = 0;

        /**
         * 第幾輪比賽
         */
        public int round_no = 0;

        /**
         * 是否虛擬的場次。
         * 此欄位用來註記在第一輪輪空的人，
         * 這樣畫畫面時才能保留這空間，才能正確。
         */
        public bool is_virtual = false;

        private List<Candidate> candidates = new List<Candidate>();

        public void addCandidate(Candidate c)
        {
            if (c == null)
            {
                return;
            }
            // 一場比賽只會有兩隊
            if (this.candidates.Count > 1)
            {
                return;
            }

            this.candidates.Add(c);
        }

        public List<Candidate> getCandidates()
        {
            return this.candidates;
        }
    }
}
