using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaOnline.Models
{
    public class LoginModel
        {
            [Required]
            [Display(Name = "Логин")]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

    public class RegisterModel
        {
            [Required]
            [Display(Name = "Логин")]
            public string Name { get; set; }

            [Required]
            [MinLength(6, ErrorMessage = "Пароль должен состоять от 6 до 16 символов")]
            [MaxLength(16, ErrorMessage = "Пароль должен состоять от 6 до 16 символов")]
            [Display(Name = "Пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Повторный пароль")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Некорректный E-mail")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail не прошел валидация")]
            public string Email { get; set; }
    }

    public class CommentModel
    {
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
    }

    public class MovieModel
    {
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

}