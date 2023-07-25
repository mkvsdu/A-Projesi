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
    public class CevaplarManager : ICevapService
    {
        ICevapDal _cevapDal;
        public CevaplarManager(ICevapDal cevapDal)
        {
            _cevapDal = cevapDal;
        }
        public void CevapAdd(Cevap cevap)
        {
            _cevapDal.Insert(cevap);
        }

        public void CevapDelete(Cevap cevap)
        {
           _cevapDal.Delete(cevap);
        }

        public List<Cevap> CevapList()
        {
            return _cevapDal.GetListAll();
        }

        public void CevapUpdate(Cevap cevap)
        {
            _cevapDal.Update(cevap);
        }

        public Cevap GetById(int id)
        {
            return _cevapDal.GetById(id);
        }
    }
}
