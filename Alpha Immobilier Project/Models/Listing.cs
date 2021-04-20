using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alpha_Immobilier_Project.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string DescListing { get; set; }

        [Display(Name = "Image")]
        public string imageListing { get; set; }

        [Required]
        [Display(Name = "Price")]
        public Double PrixListing { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CityListing { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string AdressListing { get; set; }

        [Required]
        [Display(Name = "Numbre rooms")]
        public int NbrChambre { get; set; }

        [Required]
        [Display(Name = "Numbre bath")]
        public int NbrBath { get; set; }

        [Required]
        [Display(Name = "Numbre bed")]
        public int NbrBed { get; set; }

        [Required]
        [Display(Name = "Size")]
        public int size { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Type Listing")]
        public int TypeListingId { get; set; }
        public virtual TypeListing TypeListing { get; set; }
        public virtual Category Category { get; set; }
    }
}