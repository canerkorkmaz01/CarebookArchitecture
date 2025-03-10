using Microsoft.AspNetCore.Identity;

namespace Carebook.Common.ViewModels
{ 
    public class RoleViewModel : IdentityRole<int>
    {
        public string DisplayName { get; set; }

        public RoleViewModel(string name):base(name) 
        {
           DisplayName = name;
        }
        public RoleViewModel()
        {
                    
        }
    }
    
}


