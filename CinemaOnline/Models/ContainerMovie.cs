using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaOnline.Models
{
    public class ContainerMovie
    {
        public Movie OneMovie { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Имя")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Контент")]
        public string Content { get; set; }

        [Display(Name = "id фильма")]
        public int? MovieId { get; set; }
    }
}