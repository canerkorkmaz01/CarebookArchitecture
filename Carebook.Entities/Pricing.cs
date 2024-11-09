using Carebook.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carebook.Entities
{
    public class Pricing : BaseEntity
    {

        //[Display(Name = "Araç Adı")]
        public int CarId { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal DailyWages { get; set; }
        public decimal MonthlyFee { get; set; }
        public virtual Car Cars { get; set; }
    }
}
