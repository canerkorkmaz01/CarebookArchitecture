using Carebook.Business.Interfaces;
using Carebook.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System.Security.Claims;
using Color = SixLabors.ImageSharp.Color;
using Image = SixLabors.ImageSharp.Image;
using Size = SixLabors.ImageSharp.Size;



namespace Carebook.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrators")]
    public class CarController : Controller
    {
        private const string entityName = "Araç Ekleme";

        private readonly ICarFeatureService _carFeatureService;
        private readonly ICarPageListService _carPageListService;
        private readonly IService<FeatureViewModel> _featureService;
        private readonly IService<CarViewModel> _carService;
        private readonly IFeatureService _featureList;
        private readonly ICarPictureService _carPictureService;

        public CarController(ICarPageListService carPageListService, ICarFeatureService carFeatureService,
            IService<FeatureViewModel> featureService, IService<CarViewModel> carService ,IFeatureService featureList, ICarPictureService carPictureService)
        {
            _featureList = featureList;
            _carPageListService = carPageListService;
            _carFeatureService = carFeatureService;
            _featureService = featureService;
            _carService = carService;
            _carPictureService = carPictureService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var model = await _carPageListService.GetPagedCarsAsync(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Feature = await _carService.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
            return View();
        }

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
            //else
            //{
            //    ModelState.AddModelError("", "Lütfen bir logo yükleyiniz!");
            //    return View(model);
            //}
            //var photo = new CarPictureViewModel();
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
                                var photo = new CarPictureViewModel
                                {
                                    UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0,
                                    DateCreated = DateTime.Now,
                                    Enabled = model.Enabled,
                                    Photo = image.ToBase64String(JpegFormat.Instance)
                                };
                                model.CarPictures.Add(photo);

                                model.Photo = image.ToBase64String(JpegFormat.Instance);
                            });

                        }
                    }
                    catch (UnknownImageFormatException)
                    {

                    }
                }
          

            if (model.SelectedFeatures != null)
            {
                var features = await _featureList.GetAllAsync();
                model.SelectedFeatures.ToList().ForEach(p => model.Features.Add(features.Single(q => q.Id == p)));
            }

            model.DateCreated = DateTime.Now;
            model.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            try
            {
                await _carService.AddAsync(model);  
                TempData["success"] = $"{entityName} ekleme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} ekleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
                return View(model);
            }



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
            if (id == 0)
            {
                return NotFound();
            }
            var model = await _carService.GetByIdAsync(id);
            var features = await _featureList.GetAllAsync();
            ViewBag.CarFeatures = await _carFeatureService.GetEditCarFeaturesAsync();
            ViewBag.CarPicture = await _carPictureService.CarPictureAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarViewModel model)
        {

            var original = await _carService.GetByIdAsync(model.Id);
            var featuresIds = await _carFeatureService.GetCarFeatureIdsAsync(model.Id);
            var features =  await _featureList.GetAllAsync();



            if (model.SelectedFeatures != null)
            {
                model.SelectedFeatures
                    .Except(featuresIds).ToList()
                    .ForEach(p => original.Features.Add(features.Single(x => x.Id == p)));

                featuresIds
                    .Except(model.SelectedFeatures)
                    .ToList()
                    .ForEach(p => original.Features.Remove(features.Single(x => x.Id == p)));
            }

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
            //else
            //{
            //    ModelState.AddModelError("", "Lütfen bir logo yükleyiniz!");
            //    return View(model);
            //}
            //var photo = new CarPictureViewModel();
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
                                var photo = new CarPictureViewModel
                                {
                                    UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0,
                                    DateCreated = DateTime.Now,
                                    Enabled = model.Enabled,
                                    Photo = image.ToBase64String(JpegFormat.Instance)
                                };
                                model.CarPictures.Add(photo);

                                model.Photo = image.ToBase64String(JpegFormat.Instance);
                            });

                        }
                    }
                    catch (UnknownImageFormatException)
                    {

                    }
                }

            model.DateCreated = DateTime.Now;
            model.UserId = int.TryParse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : 0;
            try
            {
                await _carService.Update(model);
                TempData["success"] = $"{entityName} ekleme işlemi başarıyla tamamlanmıştır.";
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                TempData["error"] = $"{entityName} ekleme işlemi aynı isimli bir kayıt olduğu için tamamlanamıyor.";
                ViewBag.CarFeatures = await _carFeatureService.GetCarFeaturesAsync();
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var model = await _carService.GetByIdAsync(id);
            try
            {
                await _carService.Remove(model);
                TempData["success"] = $"{entityName} silme işlemi başarıyla tamamlanmıştır.";
            }
            catch (DbUpdateException e)
            {
                TempData["success"] = $"{e} silme işlemi Başarısız Olmuştur";
            }
            return RedirectToAction("Index");
        }

    }
}
    







