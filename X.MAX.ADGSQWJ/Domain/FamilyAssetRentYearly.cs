using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class FamilyAssetRentYearly
    {
        /// <summary>
        /// 序号，从0开始
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 期初净资产
        /// </summary>
        public decimal InitialNetAsset { get; set; }

        /// <summary>
        /// 利息收入
        /// </summary>
        public decimal IncomeInterest { get; set; }

        /// <summary>
        /// 房贷转移收入
        /// </summary>
        public decimal IncomeHouseLoan { get; set; }

        /// <summary>
        /// 房租支出
        /// </summary>
        public decimal ExpenseHouseRent { get; set; }

        /// <summary>
        /// 期末净资产
        /// </summary>
        public decimal FinalNetAsset { get { return InitialNetAsset + IncomeInterest + IncomeHouseLoan - ExpenseHouseRent; } }
    }
}
