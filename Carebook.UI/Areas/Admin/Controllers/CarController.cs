using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Carebook.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.Drawing;
using System.Security.Claims;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;
using Size = SixLabors.ImageSharp.Size;



namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        //private const string entityName = "Araç Ekleme";
        private readonly ICarFeatureService _carFeatureService;
        private readonly ICarPageListService _carPageListService;
        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;

        public CarController(ICarPageListService carPageListService, ICarFeatureService carFeatureService, IService<FeatureViewModel> featureService, IService<CarViewModel> carService)
        {
            _carPageListService = carPageListService;
            _carFeatureService = carFeatureService;
            _featureService = featureService;
            _carService = carService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            // Service üzerinden veriyi alıyoruz
            var model = await _carPageListService.GetPagedCarsAsync(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Feature = _carService.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
            return View();
        }



        //[HttpPost]

        [HttpPost]

        public async Task<IActionResult> Create(CarViewModel model)
        {
            if (model.PhotoFile != null)
            {
                try
                {
                    using (var image = Image.Load(model.PhotoFile.OpenReadStream()))
                    {
                        image.Mutate(p =>
                        {
                            p.Resize(new ResizeOptions
                            {
                                Mode = ResizeMode.Max,
                                Size = new Size(600, 600)
                            });
                            p.BackgroundColor(Color.White);
                            model.Photo = image.ToBase64String(JpegFormat.Instance);
                        });
                    }
                }
                catch (UnknownImageFormatException)
                {
                    ModelState.AddModelError("", "Yüklenen dosya bilinen bir görsel biçiminde değil!");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen bir logo yükleyiniz!");
                return View(model);
            }

            if (model.PhotoFiles != null)
                foreach (var photoFile in model.PhotoFiles)
                {
                    try
                    {
                        using (var image = Image.Load(photoFile.OpenReadStream()))
                        {
                            image.Mutate(p =>
                            {
                                p.Resize(new ResizeOptions
                                {
                                    Mode = ResizeMode.Max,
                                    Size = new Size(600, 600)
                                });
                                p.BackgroundColor(Color.White);
                                var photo = new CarPicture
                                {
                                    UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                                    DateCreated = DateTime.Now,
                                    Enabled = model.Enabled,
                                    Photo = image.ToBase64String(JpegFormat.Instance)
                                };
                                model.CarPictures.Add(photo);
                                context.Entry(photo).State = EntityState.Added;

                            });

                        }
                    }
                    catch (UnknownImageFormatException)
                    {

                    }
                }

            if (model.SelectedFeatures != null)
            {
                var features = await context.Features.ToListAsync();
                model.SelectedFeatures.ToList().ForEach(p => model.Features.Add(features.Single(q => q.Id == p)));
            }


            model.DateCreated = DateTime.Now;
            model.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            context.Entry(model).State = EntityState.Added;
            ////model.Safe = Enum.GetName((Kasa)Convert.ToInt32(model.Safe));
            try
            {
                await context.SaveChangesAsync();
                TempData["success"] = $"{entityName} ekleme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} ekleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                return View(model);
            }


























            //if (ModelState.IsValid)
            //{
            //    // Fotoğraf dosyasını işleyelim ve 600x600 boyutunda kaydedelim
            //    if (PhotoFile != null)
            //    {
            //        using (var image = await Image.LoadAsync(PhotoFile.OpenReadStream()))
            //        {
            //            // Boyutlandırma işlemi
            //            image.Mutate(x => x.Resize(600, 600));

            //            var filePath = Path.Combine("wwwroot", "uploads", PhotoFile.FileName);
            //            await image.SaveAsync(filePath, new JpegEncoder());

            //            model.Photo = PhotoFile.FileName; // Resmin adını kaydediyoruz
            //        }
            //    }

            //    // Çoklu fotoğraf yüklemesi varsa
            //    if (PhotoFiles != null && PhotoFiles.Length > 0)
            //    {
            //        foreach (var file in PhotoFiles)
            //        {
            //            using (var image = await Image.LoadAsync(file.OpenReadStream()))
            //            {
            //                // Boyutlandırma işlemi
            //                image.Mutate(x => x.Resize(600, 600));

            //                var filePath = Path.Combine("wwwroot", "uploads", file.FileName);
            //                await image.SaveAsync(filePath, new JpegEncoder());
            //            }
            //        }
            //    }

            //    // Araç özelliklerini seçili olanlardan al
            //    if (model.SelectedFeatures != null)
            //    {


            //        var features = await _featureService.GetAllAsync();
            //        model.SelectedFeatures.ToList().ForEach(p => model.Features.Add(features.Single(q => q.Id == p)));


            //        //model.Features = model.SelectedFeatures
            //        //    .Select(id => _carFeatureService.GetFeatureById(id) // Find metoduyla her ID'yi buluyoruz
            //        //    .Where(feature => feature != null)  // Null olanları filtreliyoruz
            //        //    .ToList());
            //    }

            //    // Araç verisini kaydetme
            //    model.Enabled = true; // Varsayılan olarak etkinleştir
            //    await _carService.AddAsync(model);

            //    // Başarılı işlem sonrası kullanıcıyı liste sayfasına yönlendiriyoruz
            //    return RedirectToAction("Index", "Car");
            //}

            //// Eğer model geçerli değilse, formu yeniden gösteriyoruz
            //ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync(); // Özellikler listesi
            //return View(model);
        }
    }
}
    //public async Task<IActionResult> Create(CarViewModel model)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        // ViewBag verilerini tekrar yükleyelim çünkü View hata durumunda açılacak.
    //        ViewBag.Feature = await _carService.GetAllAsync();
    //        ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
    //        return View(model);
    //    }

    //    // Resim işlemleri
    //    if (model.PhotoFiles != null && model.PhotoFiles.Any())
    //    {
    //        var allowedSize = 600; // 600x600 sınırı
    //        foreach (var photoFile in model.PhotoFiles)
    //        {
    //            using var stream = new MemoryStream();
    //            await photoFile.CopyToAsync(stream);
    //            stream.Position = 0;

    //            using var image = SixLabors.ImageSharp.Image.Load(stream);

    //            // Resim boyutlarını kontrol et
    //            if (image.Width > allowedSize || image.Height > allowedSize)
    //            {
    //                ModelState.AddModelError("", "Yüklenen resimler 600x600 pikselden büyük olamaz.");
    //                ViewBag.Feature = await _carService.GetAllAsync();
    //                ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
    //                return View(model);
    //            }

    //            // İstersen yeniden boyutlandır
    //            image.Mutate(x => x.Resize(allowedSize, allowedSize));

    //            // Kaydetme işlemi için tekrar MemoryStream'e yazalım
    //            using var resizedStream = new MemoryStream();
    //            image.SaveAsJpeg(resizedStream);
    //            resizedStream.Position = 0;

    //            // Burada resizedStream'i veritabanına veya dosya dizinine kaydedebilirsiniz.
    //            // Örnek: Dosyaya kaydetme
    //            var filePath = Path.Combine("wwwroot/uploads", Guid.NewGuid() + ".jpg");
    //            await System.IO.File.WriteAllBytesAsync(filePath, resizedStream.ToArray());
    //        }
    //    }

    //    // Modelden Service katmanına dönüştürme
    //    //var carEntity = _mapper.Map<Car>(model);

    //    // Veritabanına kaydet
    //    await _carService.AddAsync(model);

    //    // Başarılıysa listeleme sayfasına yönlendirme
    //    return RedirectToAction("Index");
    //}







