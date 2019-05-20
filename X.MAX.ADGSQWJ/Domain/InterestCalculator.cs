using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class InterestCalculator
    {
        /// <summary>
        /// 计算N期后的增长比例
        /// </summary>
        /// <param name="rate">利率</param>
        /// <param name="periods">期数</param>
        /// <returns></returns>
        public static decimal CalGrowthRatio(decimal rate, int periods)
        {
            return (decimal)Math.Pow((double)(1 + rate), periods);
        }
    }
}
