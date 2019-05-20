using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class FamilyAssetBuyYearly
    {
        /// <summary>
        /// 序号，从0开始
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 期初房产价值
        /// </summary>
        public decimal InitialHousePrice { get; set; }
        /// <summary>
        /// 期初房贷负债
        /// </summary>
        public decimal InitialHouseDebt { get; set; }
        /// <summary>
        /// 期初净资产
        /// </summary>
        public decimal InitialNetAsset { get { return InitialHousePrice - InitialHouseDebt; } }

        /// <summary>
        /// 房贷支出
        /// </summary>
        public decimal ExpenseHouseLoan { get; set; }

        /// <summary>
        /// 期末房产价值
        /// </summary>
        public decimal FinalHousePrice { get; set; }
        /// <summary>
        /// 期末房贷负债
        /// </summary>
        public decimal FinalHouseDebt { get; set; }
        /// <summary>
        /// 期末净资产
        /// </summary>
        public decimal FinalNetAsset { get { return FinalHousePrice - FinalHouseDebt - ExpenseHouseLoan; } }

        /// <summary>
        /// 期末相对净资产
        /// </summary>
        public decimal FinalNetAssetRelative { get; set; }
    }
}
