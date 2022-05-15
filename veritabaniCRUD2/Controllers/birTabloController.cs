using Microsoft.AspNetCore.Mvc;
using veritabaniCRUD2.Data;
using veritabaniCRUD2.Models;

namespace veritabaniCRUD2.Controllers
{
    public class birTabloController : Controller
    {
        private readonly ApplicationDbContext _context; //kırmızı alt çizgi Ctrl. ile düzelir

        public birTabloController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<birTablo>? _tablo { get; set; }    //kırmızı alt çizgi Ctrl. ile düzelir

        public IActionResult Index(string? aranan = null, string? sirala = null)
        {
            if (aranan != null)
            {
                _tablo = _context.birTablo.Where(x => x.isim.Contains(aranan)).ToList();
                if (_tablo.Count > 0)
                {
                    ViewData["mesaj"] = aranan + ", " + _tablo.Count + " adet bulundu";
                }
                else
                    ViewData["mesaj"] = aranan + " bulunamadı...";
            }
            else
            {
                if (sirala != null)
                {
                    switch (sirala)
                    {
                        case "Id":
                            _tablo = _context.birTablo.OrderBy(x=>x.Id).ToList();
                            ViewData["mesaj"] = "Id ile sıralandı.";
                            break;
                        case "isim":
                            _tablo = _context.birTablo.OrderBy(x => x.isim).ToList();
                            ViewData["mesaj"] = "İsim ile sıralandı.";
                            break;
                        case "ucret":
                            _tablo = _context.birTablo.OrderBy(x => x.ucret).ToList();
                            ViewData["mesaj"] = "Ücret ile sıralandı.";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    _tablo = _context.birTablo.ToList();
                    ViewData["mesaj"] = "Aranan kişinin adını giriniz.";
                }
            }

            return View(_tablo.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Ekle([Bind("Id,isim,ucret")] birTablo tablo)
        {
            _context.Add(tablo);
            await _context.SaveChangesAsync();

            return View(tablo);
        }

        public IActionResult Sil(int? Id = null)
        {
            if (Id != null)
            {

                var tablo = _context.birTablo.Find(Id);
                _context.birTablo.Remove(tablo);
                _context.SaveChanges(); //değişiklikleri kaydeder

                ViewData["mesaj"] = "Silindi";
            }
            else
                ViewData["mesaj"] = "Silinecek kişiyi seçiniz.";
            return View();
        }

        public IActionResult Guncelle(int? Id = null)
        {
            var tablo = _context.birTablo.Find(Id);
            //ViewData["mesaj"] = "Kişi bilgilerini giriniz.";
            return View(tablo);
        }

        [HttpPost]
        public IActionResult Guncelle(int Id, [Bind("Id,isim,ucret")] birTablo birTablo)
        {
            _context.Update(birTablo);
            _context.SaveChangesAsync();
            ViewData["mesaj"] = "Kişi güncellendi.";
            return View(birTablo);
        }
    }
}
