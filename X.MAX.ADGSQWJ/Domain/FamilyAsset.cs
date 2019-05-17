using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.MAX.ADGSQWJ.Domain
{
    public class FamilyAsset
    {
        public FamilyAsset(decimal housePrice, decimal houseDepreciationRate, decimal housePriceRiseRate, decimal priceRentRatio, decimal downPaymentRatio, decimal loanRateYearly, int loanYears, decimal yieldRate)
        {
            _HouseAsset = new HouseAsset(housePrice, houseDepreciationRate, housePriceRiseRate, priceRentRatio, downPaymentRatio, loanRateYearly, loanYears);
            _Fund = new Fund(housePrice * downPaymentRatio, yieldRate);
        }

        private HouseAsset _HouseAsset;
        private Fund _Fund;

        public IList<FamilyAssetBuyYearly> _BuyList { get; set; } = new List<FamilyAssetBuyYearly>();
        public IList<FamilyAssetRentYearly> _RentList { get; set; } = new List<FamilyAssetRentYearly>();

        public FamilyAsset BuildListYearly(int years)
        {
            FamilyAssetRentYearly last = null;
            for (int i = 0; i < years; i++)
            {
                if (last != null)
                    _Fund.Principal = last.FinalNetAsset;

                var buy = new FamilyAssetBuyYearly();
                buy.Index = i;
                buy.InitialHousePrice = _HouseAsset.CalHouseDepreciationPrice(i);
                buy.InitialHouseDebt = _HouseAsset.CalYearlyLoanResidualPrinciple(i);
                buy.ExpenseHouseLoan = _HouseAsset.YearlyLoanPayment;
                buy.FinalHousePrice = _HouseAsset.CalHouseDepreciationPrice(i + 1);
                buy.FinalHouseDebt = _HouseAsset.CalYearlyLoanResidualPrinciple(i + 1);
                _BuyList.Add(buy);

                var rent = new FamilyAssetRentYearly();
                rent.Index = i;
                rent.InitialNetAsset = _Fund.Principal;
                rent.IncomeInterest = _Fund.CalYield();
                rent.IncomeHouseLoan = _HouseAsset.YearlyLoanPayment;
                rent.ExpenseHouseRent = _HouseAsset.CalRent(i);
                _RentList.Add(rent);
                last = rent;
            }
            return this;
        }
    }
}
