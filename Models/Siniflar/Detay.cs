using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariSite.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength (50)]
        public string Urunad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Urunbilgi { get; set; }
    }
}