using BusinessLayer.Concrete;
using EntityLayer;

namespace ArmutProjesi.Models
{
    public class SoruCevap
    {
        public List<Cevap> Cevaplar { get; set; }
        public Soru Soru { get; set; }
        public SoruCevap()
        {
            Cevaplar = new List<Cevap>();
        }

        
    }
}
