using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class Fund
    {
        public Fund(decimal principal, decimal yieldRate)
        {
            Principal = principal;
            YieldRate = yieldRate;
        }

        /// <summary>
        /// 本金
        /// </summary>
        public decimal Principal { get; set; }
        /// <summary>
        /// 收益率
        /// </summary>
        public decimal YieldRate { get; set; }

        /// <summary>
        /// 算收益
        /// </summary>
        /// <returns></returns>
        public decimal CalYield()
        {
            return Principal * YieldRate;
        }
    }
}
