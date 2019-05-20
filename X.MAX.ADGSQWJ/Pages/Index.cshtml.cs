using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.MAX.ADGSQWJ.Domain;

namespace X.MAX.ADGSQWJ.Pages
{
    public class IndexModel : PageModel
    {
        public decimal? _HousePrice { get; set; } = 3000000;
        public decimal? _HouseDepreciationRate { get; set; } = 0.02m;
        public decimal? _HousePriceRiseRate { get; set; } = 0.05m;
        public decimal? _PriceRentRatio { get; set; } = 60;
        public decimal? _DownPaymentRatio { get; set; } = 0.3m;
        public decimal? _LoanRateYearly { get; set; } = 0.04405m;
        public int? _LoanYears { get; set; } = 30;
        public decimal? _YieldRate { get; set; } = 0.04m;
        public int? _BuildYears { get; set; } = 50;

        public IList<FamilyAssetBuyYearly> _BuyList { get; set; } = new List<FamilyAssetBuyYearly>();
        public IList<FamilyAssetRentYearly> _RentList { get; set; } = new List<FamilyAssetRentYearly>();

        public void OnGet()
        {

        }

        public void OnPost(decimal? HousePrice, decimal? HouseDepreciationRate, decimal? HousePriceRiseRate, decimal? PriceRentRatio, decimal? DownPaymentRatio, decimal? LoanRateYearly, int? LoanYears, decimal? YieldRate, int? BuildYears)
        {
            _HousePrice = HousePrice;
            _HouseDepreciationRate = HouseDepreciationRate;
            _HousePriceRiseRate = HousePriceRiseRate;
            _PriceRentRatio = PriceRentRatio;
            _DownPaymentRatio = DownPaymentRatio;
            _LoanRateYearly = LoanRateYearly;
            _LoanYears = LoanYears;
            _YieldRate = YieldRate;
            _BuildYears = BuildYears;

            var m = new FamilyAsset(HousePrice.Value, HouseDepreciationRate.Value, HousePriceRiseRate.Value, PriceRentRatio.Value, DownPaymentRatio.Value, LoanRateYearly.Value, LoanYears.Value, YieldRate.Value).BuildListYearly(BuildYears.Value);
            _BuyList = m._BuyList;
            _RentList = m._RentList;
        }
    }
}
