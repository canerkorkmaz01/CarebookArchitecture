
using Carebook.Entities;
using System;
using System.Collections.Generic;

namespace Carebook.Common.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<CarViewModel> Cars { get; set; } = new HashSet<CarViewModel>();

    }
}
