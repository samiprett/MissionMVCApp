using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MissionMVCApp.Models
{
    public class AddMovieSubmission
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Year")]
        public ushort Year { get; set; }
        [Required(ErrorMessage = "Please enter Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please select Rating")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        public string Notes { get; set; }


        [Required(ErrorMessage = "Please select Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
