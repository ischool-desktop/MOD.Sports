using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    /// <summary>
    /// 候選人
    /// </summary>
    public class Candidate
    {
        public String matchUUID = "";  //所屬場次的 uuid，當被指定到一個場次時，才知道期 uuid 
        public int lotsNo = -1;     //編號。應該只有第一場比賽的 Candidate 會有 no
        public int divNo = 0;   //第一區或第二區
        public bool isEmpty = false ;   //是否輪空
        public SourceType sourceType = SourceType.None ;  //來源物件類型，預設是 None
        public String sourceUUID = "" ;      // 來源物件。可能是 Match 或是 Candidate 如果是第一場比賽的，不會有 source。
        public object playerObject ; // 對應的選手物件


        public Candidate( int divNo): this(Guid.NewGuid().ToString(), divNo)
        {
        }

        public Candidate(String uqid, int divNo)
        {
            this.sourceUUID = uqid;
            this.divNo = divNo;
        }

        public Candidate clone()
        {
            Candidate c = new Candidate(this.sourceUUID, this.divNo);
            c.isEmpty = this.isEmpty;
            c.lotsNo = lotsNo;
            c.sourceType = this.sourceType;
            c.playerObject = this.playerObject;

            return c;
        }
    }
}
