using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class HouseAsset
    {
        public HouseAsset(decimal housePrice, decimal houseDepreciationRate, decimal housePriceRiseRate, decimal priceRentRatio, decimal downPaymentRatio, decimal loanRateYearly, int loanYears)
        {
            HousePrice = housePrice;
            HouseDepreciationRate = houseDepreciationRate;
            HousePriceRiseRate = housePriceRiseRate;
            PriceRentRatio = priceRentRatio;
            DownPaymentRatio = downPaymentRatio;
            LoanRateYearly = loanRateYearly;
            LoanYears = loanYears;

            //计算房贷还款额
            LoanRateMonthly = LoanRateYearly / 12;
            LoanPrincipal = HousePrice * (1 - DownPaymentRatio);
            MonthlyLoanPayment = CalMonthlyLoanPayment();
            YearlyLoanPayment = MonthlyLoanPayment * 12;
            MonthlyLoanPaymentPrincipleFactor = MonthlyLoanPayment - LoanPrincipal * LoanRateMonthly;

            //计算房贷还款及剩余本金
            var residualPrinciple = LoanPrincipal;
            for (int i = 0; i < LoanYears * 12; i++)
            {
                var paymentPrinciple = CalMonthlyLoanPaymentPrinciple(i + 1);
                residualPrinciple -= paymentPrinciple;
                MonthlyLoanPaymentPrincipleList.Add(paymentPrinciple);
                MonthlyLoanResidualPrincipleList.Add(residualPrinciple);
                if ((i + 1) % 12 == 0)
                    YearlyLoanResidualPrincipleList.Add(residualPrinciple);
            }
        }

        /// <summary>
        /// 总房价
        /// </summary>
        public decimal HousePrice { get; private set; }
        /// <summary>
        /// 年化折旧率
        /// </summary>
        public decimal HouseDepreciationRate { get; private set; }
        /// <summary>
        /// 房价年化上升率
        /// </summary>
        public decimal HousePriceRiseRate { get; private set; }
        /// <summary>
        /// 年化售租比
        /// </summary>
        public decimal PriceRentRatio { get; private set; }
        /// <summary>
        /// 房贷首付比
        /// </summary>
        public decimal DownPaymentRatio { get; private set; }
        /// <summary>
        /// 房贷年化利率
        /// </summary>
        public decimal LoanRateYearly { get; private set; }
        /// <summary>
        /// 房贷年数
        /// </summary>
        public int LoanYears { get; private set; }

        /// <summary>
        /// 房贷月利率
        /// </summary>
        private decimal LoanRateMonthly { get; set; }
        /// <summary>
        /// 房贷本金
        /// </summary>
        public decimal LoanPrincipal { get; private set; }
        /// <summary>
        /// 房贷月还款总额
        /// </summary>
        public decimal MonthlyLoanPayment { get; private set; }
        /// <summary>
        /// 房贷年还款总额
        /// </summary>
        public decimal YearlyLoanPayment { get; private set; }
        /// <summary>
        /// 房贷月还款本金计算因子
        /// </summary>
        private decimal MonthlyLoanPaymentPrincipleFactor { get; set; }
        /// <summary>
        /// 房贷月还款本金列表
        /// </summary>
        private IList<decimal> MonthlyLoanPaymentPrincipleList { get; } = new List<decimal>();
        /// <summary>
        /// 房贷月末剩余本金列表
        /// </summary>
        private IList<decimal> MonthlyLoanResidualPrincipleList { get; } = new List<decimal>();
        /// <summary>
        /// 房贷年末剩余本金列表
        /// </summary>
        private IList<decimal> YearlyLoanResidualPrincipleList { get; } = new List<decimal>();

        #region 房贷
        /// <summary>
        /// 算房贷月还款总额
        /// </summary>
        /// <returns></returns>
        private decimal CalMonthlyLoanPayment()
        {
            var tmp = (decimal)Math.Pow((1 + (double)LoanRateMonthly), LoanYears * 12);
            var rate = LoanRateMonthly * tmp / (tmp - 1);
            return LoanPrincipal * rate;
        }

        /// <summary>
        /// 算房贷月还款本金
        /// </summary>
        /// <returns></returns>
        public decimal CalMonthlyLoanPaymentPrinciple(int month)
        {
            if (month < 1 || month > LoanYears * 12) return 0;
            var factor2 = (decimal)Math.Pow((1 + (double)LoanRateMonthly), month - 1);
            return MonthlyLoanPaymentPrincipleFactor * factor2;
        }

        /// <summary>
        /// 算房贷年末剩余本金
        /// </summary>
        /// <returns></returns>
        public decimal CalYearlyLoanResidualPrinciple(int year)
        {
            if (year < 1) return LoanPrincipal;
            if (year > LoanYears) return 0;
            return YearlyLoanResidualPrincipleList[year - 1];
        }
        #endregion 房贷

        #region 折旧与房租
        /// <summary>
        /// 算折旧后的房价
        /// </summary>
        /// <returns></returns>
        public decimal CalHouseDepreciationPrice(int year)
        {
            if (year == 0) return HousePrice;
            var residueRate = 1 - HouseDepreciationRate * year;
            if (residueRate <= 0) return 0;
            var riseRate = (decimal)Math.Pow(1 + (double)HousePriceRiseRate, year);
            return HousePrice * residueRate * riseRate;
        }

        /// <summary>
        /// 算房租
        /// </summary>
        /// <returns></returns>
        public decimal CalRent(int year)
        {
            return CalHouseDepreciationPrice(year) / PriceRentRatio;
        }
        #endregion 折旧与房租
    }
}
