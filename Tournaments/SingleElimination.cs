using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    /// <summary>
    /// 產生單淘汰賽程的類別
    /// </summary>
    public class SingleElimination
    {
        public int teamCount;
        public List<Candidate> div1;
        public List<Candidate> div2;
        public List<Candidate> all;

        public int modeCount = 0;  // 參賽隊伍數對應的2的自乘數
        public int roundCount = 0; // 回合數
        public int emptyCount = 0;          // 需要輪空的隊伍數
        public int emptyCountDiv1 = 0;      // 第一區需要輪空的對隊伍數
        public int emptyCountDiv2 = 0;      // 第二區需要輪空的隊伍數，  emptyCountDiv1 + emptyCountDiv2 = emptyCount

        private SingleEliminationMatchesCreator _semc;

        public SingleElimination(int count)
        {
            this.teamCount = count;
            this.div1 = new List<Candidate>();
            this.div2 = new List<Candidate>();
            this.all = new List<Candidate>();

            this.initplayer();
            this.roundCount = Util.findModePower(this.teamCount, 1);
            this.modeCount = (int)Math.Pow(2, this.roundCount);    //參賽隊伍數對應的2的自乘數
            this.calculateEmptyCount();

            this._semc = new SingleEliminationMatchesCreator(this.div1, this.div2);
        }

        /**
         * 計算總輪空數，以及第一區及第二區的輪空數
         */
        private void calculateEmptyCount()
        {
            this.emptyCount = this.modeCount - this.all.Count;    //需要輪空的隊伍數
            for (int i = 0; i < this.emptyCount; i++)
            {
                if (i % 2 == 0)
                {
                    this.emptyCountDiv2++;
                }
                else {
                    this.emptyCountDiv1++;
                }
            }
        }

        /**
         * 標示第一輪需要輪空的隊伍
         */
        private void markEmptyCandidates()
        {
            SingleEliminationEmptyMarker seem1 = new SingleEliminationEmptyMarker(this.div1, 1, this.emptyCountDiv1);
            seem1.mark();
            seem1.testMark();
            SingleEliminationEmptyMarker seem2 = new SingleEliminationEmptyMarker(this.div2, 2, this.emptyCountDiv2);
            seem2.mark();
            seem2.testMark();
        }

        /**
         * 找出每一輪的場次，以及場次的選手或隊伍(如果已經知道的話)。規則為：
         * 1. 各別針對 div1 和 div2，
         *     第一輪處理：
         *      對於 div1 中的每個選手或隊伍：
         *          如果是輪空，就直接放到第二輪候選。
         *          如果沒有輪空，應該與下一個一起，每兩個 Candidate 可以建立一個 Match，紀錄該 match 中的兩個選手或隊伍。然後在第二輪建立一個候選人，來自這個 match。
         *      
         * @memberof SingleElimination
         */
        public void startMatching()
        {
            this.markEmptyCandidates();  //標示出要輪空的選手位置

            SingleEliminationMatchesCreator semc = new SingleEliminationMatchesCreator(this.div1, this.div2);
            semc.createMatches();

            this._semc = semc;
        }

        public List<Match> getMatchesOfDiv(int div_no, int round_no)
        {
            if (this._semc == null)
            {
                return new List<Match>();
            }
            else {
                return this._semc.getMatchesOfDiv(div_no, round_no);
            }
        }

        //根據參賽隊伍數量找出對應的 2 的自乘數
        private int findModeCount(int targetCount)
        {
            return Util.findModeCount(targetCount);
        }

        /**
         * 根據參賽隊伍數
         */
        private void initplayer()
        {
            for (int i = 0; i < this.teamCount; i++)
            {
                Candidate c = new Candidate(0);
                c.lotsNo = (i + 1);
                decimal x = this.teamCount;
                decimal half = Math.Ceiling(x / 2);
                if (i <= half - 1)
                {
                    c.divNo = 1;
                    this.div1.Add(c);
                }
                else {
                    c.divNo = 2;
                    this.div2.Add(c);
                }
                this.all.Add(c);
            }
        }

        private void showPlayers()
        {

            //        foreach()
            //this.div1.forEach(p => {
            //    console.log(p);
            //});

            //console.log("----");
            //this.div2.forEach(p => {
            //    console.log(p);
            //});
        }
    }
}
