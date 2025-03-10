

using Carebook.Entities;
using System;


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
        public virtual int UserId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool Enabled { get; set; }
        public virtual User? User { get; set; }
        //public List<SelectListItem> CarDropdown { get; set; }
    }
}
