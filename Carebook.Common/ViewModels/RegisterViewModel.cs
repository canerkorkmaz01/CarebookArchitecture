﻿using Carebook.Common.Enums;

namespace Carebook.Common.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
