using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace muscshop.Models
{
    public class Album
    {
        [Required(ErrorMessage = "Please, enter the title")]
        public string Title { get; set; }

        [Range(1, 300, ErrorMessage = "please enter price: 1 to 300")]
        public double Price { get; set; }

        [Display(Name = "Photo URL")]
        public string AlbumUrl { get; set; }

        [Required(ErrorMessage = "ReleaseYear is required")]
        [Display(Name = "Release Year")]
        [Range(1960, 2020, ErrorMessage = "please enter year: 1960 to 2020")]
        public int ReleaseYear { get; set; }

        public Artist Artist { get; set; }

        public Genre Genre { get; set; }

        public int AlbumId { get; set; }

        [MaxLength(100, ErrorMessage = "Max 100 symbols")]
        public string Description { get; set; } = "albumDescr";

        public int ArtistId { get; set; }

        public int GenreId { get; set; }

        public void UpdateAlb(Album newalbum)
        {
            Price = newalbum.Price;
            Title = newalbum.Title;
            ReleaseYear = newalbum.ReleaseYear;
            Description = newalbum.Description;
            AlbumUrl = newalbum.AlbumUrl;
            GenreId = newalbum.GenreId;
            ArtistId = newalbum.ArtistId;
        }
    }
}