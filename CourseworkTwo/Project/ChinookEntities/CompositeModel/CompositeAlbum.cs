namespace ChinookEntities.CompositeModel
{
    public class CompositeAlbum
    {
        public string AlbumName { get; private set; }
        public string AlbumArtist { get; private set; }

        public CompositeAlbum(string albumName, string albumArtist)
        {
            AlbumName = albumName;
            AlbumArtist = albumArtist;
        }
    }
}