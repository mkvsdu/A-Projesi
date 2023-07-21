﻿using Armut.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Table("Kullanıcı")]
    public class Kullanici
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

        [MinLength(6), MaxLength(16), Required]
        public string Sifre { get; set; }

        public string? Adres { get; set; }
        public string? Adres2 { get; set; }

        [StringLength(5), Required]
        public string Cinsiyet { get; set; }

        public bool Aktif { get; set; }

        [StringLength(25)]
        public string TelefonNumarası { get; set; }
       
        public DateTime KayitTarihi { get; set; }

        public virtual KullaniciRol KullaniciRol { get; set; }
    }

}

