using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alpha_Immobilier_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }

        [Required]
        [Display(Name = "Category Icon")]
        public string CategoryIcon { get; set; }
        public ICollection<Listing> Listings { get; set; }
    }
}