using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISoruService
    {
        public void SoruAdd(Soru soru);
        public void SoruDelete(Soru soru);
        public void SoruUpdate(Soru soru);
        public Soru GetById(int id);
        public List<Soru> SoruList();
    }
}
