
using Carebook.Entities;
using System;

namespace Carebook.Common.ViewModels
{
    public class CarPictureViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        public string Photo { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual int UserId { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual User? User { get; set; }

        public virtual CarViewModel Cars { get; set; }
    }
}
