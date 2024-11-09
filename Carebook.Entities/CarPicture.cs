using Carebook.Entities.Infrastructure;

namespace Carebook.Entities
{
    public class CarPicture :BaseEntity
    {
        public int CarId { get; set; }

        public string Photo { get; set; }

        public virtual Car Car { get; set; }
    }
}
