using Microsoft.AspNetCore.Identity;

namespace Carebook.Entities
{
    public class Role : IdentityRole<int>
    {
        public string DisplayName { get; set; }

        public Role(string name) : base(name)
        {
            DisplayName = name;
        }
        public Role()
        {
            
        }
    }
}
