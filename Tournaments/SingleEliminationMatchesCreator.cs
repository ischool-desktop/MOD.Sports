using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    /// <summary>
    /// 針對單淘汰制度，產生相關的賽程。
    /// </summary>
    class SingleEliminationMatchesCreator
    {
        private List<Candidate> candidates;
        private List<Match> matches;   //比賽場次
        private int roundCount;    //共有幾輪
        private Dictionary<int, List<Candidate>> dicCandidatesPerRound;
        private Dictionary<int, List<Match>> dicMatchesPerRound;

        private int matchNo = 0;    //場次編號

        /**
     * 建構子。
     * @param div1 第一區的候選人，已註明輪空
     * @param div2 第一區的候選人，已註明輪空
     */
        public SingleEliminationMatchesCreator(List<Candidate> div1, List<Candidate> div2)
        {
            this.candidates = new List<Candidate>();
            foreach(Candidate c in div1)
            {
                this.candidates.Add(c);
            }
            this.candidates.AddRange(div2);
            this.matches = new List<Match>();
            this.roundCount = Util.findModePower(this.candidates.Count, 1);

            this.dicCandidatesPerRound = new Dictionary<int, List<Candidate>>();
            this.dicMatchesPerRound = new Dictionary<int, List<Match>>();

            for (int i = 0; i < this.roundCount; i++)
            {
                this.dicCandidatesPerRound[i + 1] = new List<Candidate>();
                this.dicMatchesPerRound[i + 1] = new List<Match>();
            }
            this.dicCandidatesPerRound[1] = this.candidates;  //第一回合的候選人清單
        }

        /**
         * 建立場此
         */
        public void createMatches()
        {
            //this.handleRound1();
            for (int i = 0; i < this.roundCount; i++)
            {
                this.handleRound(i + 1);
            }
            // this.testMatches();
            //this.showMatches();
        }

        /**
         * 取得指定區域的比賽場次
         * @param div_no 1 or 2 , 第一區或第二區
         * @param round_no , 第幾回合
         */
        public List<Match> getMatchesOfDiv(int div_no, int round_no)
        {
            List<Match> result = this.matches.FindAll(
                delegate (Match m)
                {
                    return (m.div_no == div_no) && (m.round_no == round_no);
                }
            );

            return result;
        }

        private void showMatches()
        {
            for (int i = 0; i < this.roundCount; i++)
            {
                Console.WriteLine(String.Format(" ---round :{0} ----", (i + 1).ToString()));
                List<Match> matches = this.dicMatchesPerRound[i + 1];
                foreach (Match m in matches)
                {
                    Console.WriteLine("******");
                    Console.WriteLine(String.Format("Match : {0}", m.ToString()));
                    foreach (Candidate c in m.getCandidates())
                    {
                        Console.WriteLine(String.Format("Candidate : {0}", c.ToString()));
                    }
                }
            }
        }
    

    private void testMatches()
    {
        List<Match> realMatches = this.matches.FindAll( delegate (Match m) { return !m.is_virtual; });

        int realMatchCount = realMatches.Count;
        //const msg = String.Format(realMatchCount == this.candidates.length - 1) ? `已成功建立${ realMatchCount}
        //筆賽程`  : `建立賽程由問題，隊數：${ this.candidates.length}, 預計建立：${ this.candidates.length - 1}, 實際：${ realMatchCount}` ;
        //console.log(msg);
    }

    /**
     * 處理每一輪的候選人與場次
     * @param roundIndex 第幾輪
     */
    private void handleRound(int roundIndex)
    {
        int index = 0;
        List<Candidate> tempContainers = new List<Candidate>();

        // 對於這一輪的所有候選人
        foreach(Candidate c in this.dicCandidatesPerRound[roundIndex])
            {

            if (c.isEmpty)
            {    //是否輪空？只有第一輪才有輪空

                // 如果輪空，則建立一個候選人，加到第二輪去
                Candidate cp = c.clone();
                cp.isEmpty = false;
                cp.sourceType = SourceType.Candidate;
                cp.sourceUUID = c.sourceUUID;
                cp.lotsNo = c.lotsNo;  //抽籤號要一起過來
                this.dicCandidatesPerRound[roundIndex + 1].Add(cp); //加到第二輪去
                // 建立一個虛擬的 Match，這樣畫畫面才會保留位置，才會正確
                Match m = new Match(c.divNo, roundIndex, -1);
                m.is_virtual = true;
                m.addCandidate(c);
                this.matches.Add(m);

                //加到這一輪的場次中
                this.dicMatchesPerRound[roundIndex].Add(m);
            }
            else {
                index++;
                tempContainers.Add(c);

                //如果湊成兩個，則建立一個 Match 場次物件，加到這一輪的場次中。
                if (index % 2 == 0)
                {
                    // 建立一個 Match 場次物件
                    this.matchNo += 1;
                    Match m = new Match(c.divNo, roundIndex, this.matchNo);
                    foreach(Candidate cand in tempContainers)
                        {
                            m.addCandidate(cand);
                            cand.matchUUID = m.uqid;
                        }
                    this.matches.Add(m);

                    //加到這一輪的場次中
                    this.dicMatchesPerRound[roundIndex].Add(m);

                    if (roundIndex < this.roundCount)
                    {
                        //建立這場次同時也要產生一個第二輪的候選人
                        Candidate c2 = new Candidate(c.divNo);
                        c2.isEmpty = false;
                        c2.sourceType = SourceType.Match;
                        c2.sourceUUID = m.uqid;
                        this.dicCandidatesPerRound[roundIndex + 1].Add(c2); //加到第二輪去
                    }

                    //清掉資料
                    index = 0;
                    tempContainers.Clear();
                }
            }
        }
    }

}
}
