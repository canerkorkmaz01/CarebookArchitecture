
namespace Carebook.Common.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarViewModel> Cars { get; set; } = new HashSet<CarViewModel>();

    }
}
