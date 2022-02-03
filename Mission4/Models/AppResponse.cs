using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// Models for creating the database

namespace Mission4.Models
{
    public class AppResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
    
        [Required(ErrorMessage = "Please fill in the Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please fill in the Year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please fill in the Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please select a Rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string Lent { get; set; }
        public string Notes{ get; set; }


        //Foreign Key relationship
        [ForeignKey("Categories")]
        [Required]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

    }
}

