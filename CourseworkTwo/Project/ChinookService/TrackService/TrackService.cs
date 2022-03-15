using System;
using ChinookContext;
using ChinookEntities;
using ChinookEntities.BindingModels;

namespace ChinookService.TrackService
{
    public class TrackService : ITrackService
    {
        private static ApplicationContext _applicationContext;

        public TrackService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Track MakeNewTrack(TrackBindingModel trackData)
        {
            var newTrack = ChinookEntityFactory.Track();

            newTrack.Name = trackData.TrackName;
            newTrack.AlbumId = trackData.AlbumId;
            newTrack.MediaTypeId = trackData.MediaTypeId;
            newTrack.GenreId = trackData.GenreId;
            newTrack.Composer = trackData.TrackComposer;
            newTrack.UnitPrice = trackData.Price;
            newTrack.Milliseconds = calculateMilliseconds(trackData);
            newTrack.Bytes = calculateBytes(trackData);

            return newTrack;
        }

        public void Save(Track track)
        {
            try
            {
                _applicationContext.Tracks.Add(track);
                _applicationContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private long calculateMilliseconds(TrackBindingModel trackBindingModel)
        {
            long result = 0;
            result += ConvertMinutesToMilliseconds(trackBindingModel.LengthMinutes);
            result += ConvertSecondsToMilliseconds(trackBindingModel.LengthSeconds);
            return result;
        }

        private long calculateBytes(TrackBindingModel trackBindingModel)
        {
            return (long)(trackBindingModel.SizeInMegabytes * (1024 * 1024.0));
        }

        public static long ConvertSecondsToMilliseconds(double seconds)
        {
            return (long)TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }

        public static long ConvertMinutesToMilliseconds(double minutes)
        {
            return (long)TimeSpan.FromMinutes(minutes).TotalMilliseconds;
        }
    }
}