using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ischool.Sports.DAO
{
    public class rptCell
    {
        public int GameNo { get; set; }
        public int RoundNo { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int GetMoveInt()
        {
            int v = 0;
            v = int.Parse(Math.Pow(2, (RoundNo)).ToString()) * 2;
            return v;
        }

        public int GetMoveRow()
        {
            int v = 0;
            if (divNo == 1)
            {

            }
            v = int.Parse(Math.Pow(2, (RoundNo)).ToString()) ;
            return v;
        }

        public string Text { get; set; }

        public int Team1No { get; set; }
        public int Team2No { get; set; }

        public int divNo { get; set; }
    }
}
