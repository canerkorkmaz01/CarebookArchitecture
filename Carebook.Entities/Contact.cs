using Carebook.Entities.Infrastructure;

namespace Carebook.Entities
{
    public class Contact: BaseEntity
    {
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}
