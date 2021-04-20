using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alpha_Immobilier_Project.Models
{
    public class TypeListing
    {
        public int Id { get; set; }
        [Display(Name ="Type Listing")]
        public string type { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}