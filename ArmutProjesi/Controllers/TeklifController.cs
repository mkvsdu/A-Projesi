using ArmutProjesi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace ArmutProjesi.Controllers
{
    public class TeklifController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly SorularManager _sorularmanager;
        private readonly CevaplarManager _cevaplarManager;

        public TeklifController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            this._databaseContext = databaseContext;
            this._sorularmanager = new SorularManager(new EFSoruRepository(this._databaseContext));
            this._cevaplarManager=new CevaplarManager(new EFCevapRepository(this._databaseContext));    
        }
        public IActionResult teklif(int id)
        {
            //List<string> sorularvecevaplar=new List<string>();
            //string soru = _sorularmanager.SoruList().FirstOrDefault(x => x.AltKategoriId == id).Sorular.ToString();
            //int soruid = _sorularmanager.SoruList().FirstOrDefault(x => x.Sorular == soru).SoruId;

            SoruCevap sorucevap = new SoruCevap();
            sorucevap.Soru = _sorularmanager.SoruList().FirstOrDefault(x => x.AltKategoriId == id);
            sorucevap.Cevaplar.AddRange(_cevaplarManager.CevapList().Where(x => x.SoruId == sorucevap.Soru.SoruId).ToList());

            //sorularvecevaplar.Add(soru);
            //sorularvecevaplar.AddRange(_cevaplarManager.CevapList().Where(x => x.SoruId == soruid).Select(x=>x.Cevaplar).ToList());
            return View(sorucevap);
        }
    }
}
