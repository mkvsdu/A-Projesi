using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAltKategoriService
    {
        public void KategoriAdd(AltKategori kategori);
        public void KategoriDelete(AltKategori kategori);
        public void KategoriUpdate(AltKategori kategori);
        public AltKategori GetById(int id);
        public List<AltKategori> KategoriList();
    }
}
