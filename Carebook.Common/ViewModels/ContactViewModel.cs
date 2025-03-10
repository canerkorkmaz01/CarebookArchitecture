using Carebook.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Carebook.Common.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }

        public virtual int UserId { get; set; }

         public virtual DateTime DateCreated { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual User User { get; set; }
    }
}
