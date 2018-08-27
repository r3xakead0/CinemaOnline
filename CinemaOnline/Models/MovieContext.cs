using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaOnline.Models
{
    public class MovieContext: DbContext 
    {
        public MovieContext() :
            base("CinemaConnection")
        { }

        //User
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        //Movie
        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        //public DbSet<Country> Countries { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

    public class UserDbInitializer : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext db)
        {
            db.Roles.Add(new Role { Id = 1, Name = "admin" });
            db.Roles.Add(new Role { Id = 2, Name = "user" });
            db.Users.Add(new User
            {
                Name = "Nikol",
                Email = "Goncharovnik@ukr.net",
                Password = "123456",
                RoleId = 1
            });
            //заполнение таб которые не сработали при include
            {
                //db.Genres.AddRange(new List<Genre>
                //{
                //    new Genre { NameG = "вестерн" },
                //    new Genre { NameG = "история" },
                //    new Genre { NameG = "семейный" },

                //    new Genre { NameG = "биография" },
                //    new Genre { NameG = "комедия" },
                //    new Genre { NameG = "сериалы" },

                //    new Genre { NameG = "боевик" },
                //    new Genre { NameG = "криминал" },
                //    new Genre { NameG = "спорт" },

                //    new Genre { NameG = "военный" },
                //    new Genre { NameG = "мелодрама" },
                //    new Genre { NameG = "триллер" },

                //    new Genre { NameG = "детектив" },
                //    new Genre { NameG = "музыка" },
                //    new Genre { NameG = "ужасы" },

                //    new Genre { NameG = "драма" },
                //    new Genre { NameG = "мультфильм" },
                //    new Genre { NameG = "фэнтези" },

                //    new Genre { NameG = "документальный" },
                //    new Genre { NameG = "приключения" },
                //    new Genre { NameG = "фантастика" }
                //});
                //db.Countries.AddRange(new List<Country>
                //{
                //    new Country { NameC = "Австралия" },
                //    new Country { NameC = "Австрия " },
                //    new Country { NameC = "Аргентина" },
                //    new Country { NameC = "Багамы" },
                //    new Country { NameC = "Белоруссия" },
                //    new Country { NameC = "Бельгия" },
                //    new Country { NameC = "Бразилия" },
                //    new Country { NameC = "Великобритания" },
                //    new Country { NameC = "Гватемала" },
                //    new Country { NameC = "Германия" },
                //    new Country { NameC = "Греция" },
                //    new Country { NameC = "Грузия " },
                //    new Country { NameC = "Дания" },
                //    new Country { NameC = "Египет" },
                //    new Country { NameC = "Израиль" },
                //    new Country { NameC = "Индия" },
                //    new Country { NameC = "Ирландия " },
                //    new Country { NameC = "Испания" },
                //    new Country { NameC = "Камбоджа" },
                //    new Country { NameC = "Канада" },
                //    new Country { NameC = "КНР" },
                //    new Country { NameC = "КНДР" },
                //    new Country { NameC = "Корея" },
                //    new Country { NameC = "Латвия" },
                //    new Country { NameC = "Нигерия" },
                //    new Country { NameC = "Новая Зеландия " },
                //    new Country { NameC = "Норвегия" },
                //    new Country { NameC = "Польша " },
                //    new Country { NameC = "Россия" },
                //    new Country { NameC = "Румыния" },
                //    new Country { NameC = "Сирия" },
                //    new Country { NameC = "Словакия" },
                //    new Country { NameC = "США" },
                //    new Country { NameC = "Турция " },
                //    new Country { NameC = "Украина" },
                //    new Country { NameC = "Финляндия" },
                //    new Country { NameC = "Франция" },
                //    new Country { NameC = "Хорватия " },
                //    new Country { NameC = "Швеция" },
                //    new Country { NameC = "Швейцария" },
                //    new Country { NameC = "ЮАР " },
                //    new Country { NameC = "Япония" }
                //});
                //Genre g = (from m in db.Genres where m.NameG == "приключения" select m).FirstOrDefault();
                //Genre g1 = (from m in db.Genres where m.NameG == "криминал" select m).FirstOrDefault();
                //db.Movies.Add(new Movie
                //{
                //    NameM = "8 подруг Оушена",
                //    Description = "После выхода из тюрьмы Дебби сразу же разыскивает свою старую сообщницу Лу Миллер, а также собирает команду профессионалов, которая поможет осуществить задуманное. А сделать нужно всего-то пустяки — украсть бриллиантовое колье стоимостью сто пятьдесят миллионов долларов, которое будет красоваться на шее известной актрисы во время проведения ежегодного бала в музее «Метрополитен». На все про все у подруг Оушена три недели. ",
                //    Age = 2018,
                //    DownloadDate = DateTime.Now,
                //    Time = (float)1.33,
                //    Rating = 0,
                //    Producer = "Гэри Росс",
                //    Actor = "Сандра Буллок, Энн Хэтэуэй, Кейт Бланшетт",
                //    ImgLogoSrc = "~/image/LogoMovieImg/7ac196477_200x300.jpg",
                //    VideoLinkSrc = "http://pandastream.cc/video/7cb08ddff85e9446/iframe?block_geo=US",
                //    Genre = new List<Genre>() { g, g1 }
                //});
            }


            base.Seed(db);
        }
    }


}