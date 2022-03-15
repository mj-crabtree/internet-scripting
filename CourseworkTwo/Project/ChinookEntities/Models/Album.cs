using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ChinookEntities
{
    [Table("albums")]
    [Index(nameof(ArtistId), Name = "IFK_AlbumArtistId")]
    public partial class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public Album(string title, long artistId, Artist artist, ICollection<Track> tracks)
        {
            Title = title;
            ArtistId = artistId;
            Artist = artist;
            Tracks = tracks;
        }

        [Key]
        public long AlbumId { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(160)")]
        public string Title { get; set; }
        public long ArtistId { get; set; }

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Albums")]
        public virtual Artist Artist { get; set; }
        [InverseProperty(nameof(Track.Album))]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}