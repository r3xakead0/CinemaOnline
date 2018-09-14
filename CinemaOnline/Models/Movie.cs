using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaOnline.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название")]
        public string NameM { get; set; } 

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Год выхода")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Дата загрузки")]
        public DateTime DownloadDate { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Рейтинг")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Продолжительность")]
        public float Time { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Ссылка на видео")]
        public string VideoLinkSrc { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "ссылка на лого к фильму")]
        public string ImgLogoSrc { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Режиссер")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Актер")]
        public string Actor { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Жанры")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Страны")]
        public string Country { get; set; }

    }

    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Имя")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Контент")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Время")]
        public DateTime TimeC { get; set; }

        [Display(Name = "id фильма")]
        public int? MovieId { get; set; }

        public Movie Movie { get; set; }
    }

}