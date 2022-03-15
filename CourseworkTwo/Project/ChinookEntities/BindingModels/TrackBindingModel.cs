using System;

namespace ChinookEntities.BindingModels
{
    public class TrackBindingModel
    {
        public String TrackName { get; set; }
        public String AlbumName { get; set; }
        public String Composer { get; set; }
        public String ArtistName { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public int LengthMinutes { get; set; }
        public int LengthSeconds { get; set; }
        public int SizeInMegabytes { get; set; }

        public TrackBindingModel(string trackName, string albumName, string composer, string artistName, decimal price, int genreId, int artistId, int albumId, int lengthMinutes, int lengthSeconds, int sizeInMegabytes)
        {
            TrackName = trackName;
            AlbumName = albumName;
            Composer = composer;
            ArtistName = artistName;
            Price = price;
            GenreId = genreId;
            ArtistId = artistId;
            AlbumId = albumId;
            LengthMinutes = lengthMinutes;
            LengthSeconds = lengthSeconds;
            SizeInMegabytes = sizeInMegabytes;
        }
    }
}