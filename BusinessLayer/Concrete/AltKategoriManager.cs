using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AltKategoriManager : IAltKategoriService
    {
        IAltKategoriDal _altKategoriDal;
        public AltKategoriManager(IAltKategoriDal altKategoriDal)
        {
           _altKategoriDal = altKategoriDal;    
        }
        public AltKategori GetById(int id)
        {
           return _altKategoriDal.GetById(id);
        }

        public void KategoriAdd(AltKategori kategori)
        {
            _altKategoriDal.Insert(kategori);
        }

        public void KategoriDelete(AltKategori kategori)
        {
            _altKategoriDal.Delete(kategori);
        }

        public List<AltKategori> KategoriList()
        {
            return _altKategoriDal.GetListAll();
        }

        public void KategoriUpdate(AltKategori kategori)
        {
            _altKategoriDal.Update(kategori);
        }
    }
}
