using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    /// <summary>
    /// 根據隊伍數量，針對單淘汰制度，標示第一輪輪空的隊伍。
    /// </summary>
    public class SingleEliminationEmptyMarker
    {

        private List<Candidate> candidates;
        private int div_no; //第一區或是第二區
        private int empty_count; //要輪空的數量

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="candidates">指定區的候選人清單</param>
        /// <param name="divNo">第一區或第二區，這會牽涉到</param>
        /// <param name="empty_count">該區要輪空的隊伍數</param>
        public SingleEliminationEmptyMarker(List<Candidate> candidates, int divNo, int empty_count)
        {
            this.candidates = candidates;
            this.div_no = divNo;
            this.empty_count = empty_count;
        }


        /**
           * 標示哪些隊伍是第一輪輪空。
           * 因為輪空後，剩下的隊伍數量一定是偶數，所以規則：
           * 1. 如果要輪空數與隊伍總數相同，則全部標示為輪空。
           * 2. 如果輪空數為 1，則 若第一區，則標第一筆。若第二區，則標示為最後一筆。
           * 3. 如果輪空數為 2，則 若第一區，則標最後一筆。若第二區，則標示為第一筆。
           * 4. 輪空數大於2 :
           *      a. 第一筆開始從左邊往右，每 3 筆設一個 empty
           *      b. 如果超過 最後一筆，則開始從最後補回來：
           *
           *
       */
        public void mark()
        {
            if (this.empty_count >= 1)
            {
                //標示第一筆
                int targetIndex = this.div_no == 1 ? 0 : this.candidates.Count - 1;
                this.candidates[targetIndex].isEmpty = true;
            }

            if (this.empty_count >= 2)
            {
                //標示最後一筆
                int targetIndex = this.div_no == 1 ? this.candidates.Count - 1 : 0;
                this.candidates[targetIndex].isEmpty = true;

                if (this.candidates.Count == this.empty_count)
                {
                    this.markAllAsEmpty();
                }
                else {
                    if (this.div_no == 1)
                    {
                        int startIndex = 0;
                        int currentIndex = 0;
                        int markedEmptyCountIndex = 1;    //已經標示過的 empty count 位置，

                        // 對於大於2之後的 empty_count 每3筆標示為 empty，直到超過最後一筆，則停止，交由下一步驟
                        for (int i = 2; i < this.empty_count; i++)
                        {
                            // 每3筆標示為 empty，直到超過最後一筆
                            currentIndex = startIndex + (i - 1) * 3;
                            // 如果 index 指到或超過最後一筆，則停止，交由下一步驟
                            if (currentIndex >= this.candidates.Count - 1)
                            {
                                break;
                            }
                            else {
                                this.candidates[currentIndex].isEmpty = true;
                                markedEmptyCountIndex = i;
                            }
                        }

                        // 如果還有尙未標示的 empty count，則再由最後逐一填回
                        if (markedEmptyCountIndex < this.empty_count - 1)
                        {
                            //對於剩下尚未標示的
                            for (int j = markedEmptyCountIndex; j < this.empty_count - 1; j++)
                            {
                                // 從最後往前掃所有的 candidate，只要不是 empty，就改成 empty
                                for (int k = 0; k < this.candidates.Count; k++)
                                {
                                    Candidate c = this.candidates[this.candidates.Count - k - 1];
                                    if (!c.isEmpty)
                                    {
                                        c.isEmpty = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        int startIndex = this.candidates.Count - 1;
                        int currentIndex = startIndex;
                        int markedEmptyCountIndex = 1;

                        // 對於大於2之後的 empty_count 每3筆標示為 empty，直到超過第一筆，則停止，交由下一步驟
                        for (int i = markedEmptyCountIndex + 1; i < this.empty_count; i++)
                        {
                            // 每3筆標示為 empty，直到超過最後一筆
                            currentIndex = startIndex - (i - 1) * 3;
                            // 如果 index 指導或超過第一筆，則停止，交由下一步驟
                            if (currentIndex <= 0)
                            {
                                break;
                            }
                            else {
                                this.candidates[currentIndex].isEmpty = true;
                                markedEmptyCountIndex = i;
                            }
                        }

                        // 如果還有尙未標示的 empty count，則再由第一筆往後逐一填寫
                        if (markedEmptyCountIndex < this.empty_count - 1)
                        {
                            //對於剩下尚未標示的 empty count
                            for (int j = markedEmptyCountIndex; j < this.empty_count - 1; j++)
                            {
                                // 從最後往前掃所有的 candidate，只要不是 empty，就改成 empty
                                for (int k = 0; k < this.candidates.Count; k++)
                                {
                                    Candidate c = this.candidates[k];
                                    if (!c.isEmpty)
                                    {
                                        c.isEmpty = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void markAllAsEmpty()
        {
            foreach (Candidate c in this.candidates)
            {
                c.isEmpty = true;
            }
        }

        /**
         * 測試標記輪空的結果。規則為：
         * 掃完所有隊伍的輪空數，與要標記的總輪空數是否相同？
         */
        public void testMark()
        {
            int totalMarkedCount = 0;
            foreach (Candidate c in this.candidates)
            {
                if (c.isEmpty)
                {
                    totalMarkedCount += 1;
                }
            }
            //        this.candidates.forEach(c => {
            //            if (c.isEmpty)
            //            {
            //                totalMarkedCount++;
            //            }
            //        });
            //        console.log(
            //          totalMarkedCount == this.empty_count
            //            ? `***div${ this.div_no}
            //        標記測試成功`
            //    : `***div${ this.div_no}
            //        標記測試失敗, 要標記數：${
            //            this.empty_count
            //      }, 實際標記數：${ totalMarkedCount}`
            //);
        }
    }
}
