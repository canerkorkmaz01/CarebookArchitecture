using Carebook.Entities.Infrastructure;

namespace Carebook.Entities
{
    public class Feature : SortableBaseEntity
    {
        //[Display(Name = "Kategori Adı")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
