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
    public class SorularManager : ISoruService
    {
        ISoruDal _soruDal;
        public SorularManager(ISoruDal soruDal)
        {
            _soruDal = soruDal;
        }

        public Soru GetById(int id)
        {
            return _soruDal.GetById(id);
        }

        public void SoruAdd(Soru soru)
        {
            _soruDal.Insert(soru);
        }

        public void SoruDelete(Soru soru)
        {
            _soruDal.Delete(soru);
        }

        public List<Soru> SoruList()
        {
           return _soruDal.GetListAll();
        }

        public void SoruUpdate(Soru soru)
        {
            _soruDal.Update(soru);
        }
    }
}
