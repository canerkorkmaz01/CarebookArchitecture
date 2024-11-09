

namespace Carebook.Common.ViewModels
{ 
    public class PricingViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal DailyWages { get; set; }
        public decimal MonthlyFee { get; set; }
        public virtual CarViewModel Cars { get; set; }
    }
}
