using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaOnline.Models
{
    public class MoviessListViewModel
    {
        public IEnumerable<Movie> moviespage { get; set; }
        public IEnumerable<Movie> MoviesListAll { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}