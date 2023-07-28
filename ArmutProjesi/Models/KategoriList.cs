using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ArmutProjesi.Models
{
    public class KategoriList : ViewComponent
    {
        private readonly KategoriManager _kategoriManager;
        private readonly DatabaseContext _databaseContext;
        public KategoriList(DatabaseContext databaseContext)
        {
            this._kategoriManager = new KategoriManager(new EFKategoriRepository(this._databaseContext));
        }

        public IViewComponentResult Invoke()
        {
            return View(_kategoriManager.KategoriList().ToList());
        }
    }
}
