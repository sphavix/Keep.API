using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Keep.Web.Models
{
    public class LinkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the link title.")]
        [Display(Name = "Title")]
        public string LinkName { get; set; }

        [Required(ErrorMessage = "Enter the link description.")]
        [MaxLength(500, ErrorMessage = "Enter at least 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the url.")]
        [Display(Name = "URL")]
        public string LinkUrl { get; set; }
    }
}