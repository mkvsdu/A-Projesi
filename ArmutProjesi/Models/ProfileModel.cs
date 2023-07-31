using System.ComponentModel.DataAnnotations;

namespace ArmutProjesi.Models
{
    public class ProfileModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [MinLength(2), MaxLength(30)]
        public string? Ad { get; set; }
        [StringLength(30)]
        public string? Soyad { get; set; }
        [StringLength(100), Required]
        public string Email { get; set; }

        [MinLength(6), MaxLength(16)]
        public string Sifre { get; set; }
        [Compare("Sifre"), MinLength(6), MaxLength(16)]
        public string SifreTekrar { get; set; }

        public string? Adres { get; set; }
        public string? Adres2 { get; set; }

        [StringLength(5), Required]
        public string Cinsiyet { get; set; }

        public bool Aktif { get; set; }

        [StringLength(25)]
        public string TelefonNumarası { get; set; }

        public DateTime KayitTarihi { get; set; }
    }
}
