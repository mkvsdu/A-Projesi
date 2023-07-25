using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICevapService
    {
        public void CevapAdd(Cevap cevap);
        public void CevapDelete(Cevap cevap);
        public void CevapUpdate(Cevap cevap);
        public Cevap GetById(int id);
        public List<Cevap> CevapList();
    }
}
