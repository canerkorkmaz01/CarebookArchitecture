
namespace Carebook.Common.ViewModels
{
    public class CarPictureViewModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        public string Photo { get; set; }

        public virtual CarViewModel Cars { get; set; }
    }
}
