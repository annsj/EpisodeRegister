using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CultureApp.Models
{
    public partial class TvShow
    {
        public int Id { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel är obligatorisk")]
        public string Title { get; set; }

        [DisplayName("Säsong")]
        //[RegularExpression(@"^\d{1,}$", ErrorMessage = "Ange ett positivt heltal, tack.")]
        [Range(1, 500, ErrorMessage = "Ange ett tal 1-500")]
        public int? Season { get; set; }

        [DisplayName("Avsnitt")]
        [Range(0, 500, ErrorMessage = "Ange ett tal 0-500")]
        public int? Episode { get; set; }

        [DisplayName("På is")]
        public bool IsOnHold { get; set; } = true;

        [DisplayName("Avslutad")]
        public bool IsCompleted  { get; set; }

    }
}
