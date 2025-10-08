using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTicariSite.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Girebilirsin")]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsin")]
        public string CariAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsin", MinimumLength = 1)]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsin")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Girebilirsin")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsin")]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Girebilirsin")]
        [Required(ErrorMessage ="Bu Alanı Boş Geçemezsin")]
        public string CariMail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En Fazla 50 Karakter Girebilirsin")]
        [Required(ErrorMessage = "Bu Alanı Boş Geçemezsin")]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}