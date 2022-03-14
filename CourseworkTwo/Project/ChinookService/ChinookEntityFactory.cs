using ChinookEntities;
using ChinookEntities.BindingModels;

namespace ChinookService
{
    public static class ChinookEntityFactory
    {
        public static Album Album() => new Album();
        public static AlbumBindingModel AlbumBindingModel => new AlbumBindingModel();
        public static Track Track() => new Track();
        public static Artist Artist() => new Artist();
    }
}