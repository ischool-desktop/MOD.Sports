using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournaments
{
    public class Util
    {
        /// <summary>
        /// 根據參賽隊伍數量找出對應的 2 的自乘數
        /// </summary>
        /// <param name="targetCount">參賽隊伍數量</param>
        /// <returns></returns>
        public static int findModeCount(int targetCount)
        {
            int pwr = Util.findModePower(targetCount, 1);
            return (int)Math.Pow(2, pwr);
        }

        /// <summary>
        /// 根據參賽隊伍數量找出對應的 2 次方數
        /// </summary>
        /// <param name="targetCount"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int findModePower(int targetCount, int level)
        {
            if (targetCount <= 0)
            {
                return 0;
            }

            if (targetCount > Math.Pow(2, level) && targetCount <= Math.Pow(2, level+1 ))
            {
                return level + 1;
            }
            else if (targetCount > Math.Pow(2, level + 1))
            {
                return Util.findModePower(targetCount, level + 1);
            }
            else
            {
                return Util.findModePower(targetCount, level - 1);
            }
        }
    }
}
