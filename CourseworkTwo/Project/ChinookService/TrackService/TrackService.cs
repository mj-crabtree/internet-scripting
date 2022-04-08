using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<Track> BuildNewTrackList(IEnumerable<TrackBindingModel> trackList)
        {
            ICollection<Track> result = null;
            foreach (var track in trackList)
            {
                var newTrack = MakeNewTrack(track);
                result.Add(newTrack);
            }

            return result;
        }

        public TrackBindingModel[] AddNewAlbumFromTrackArrayStrings(string[] tracklist)
        {
            var output = new TrackBindingModel[tracklist.Length];

            for (var i = 0; i < tracklist.Length; i++)
            {
                var track = tracklist[i];
                var t = new TrackBindingModel();
                t.TrackName = track;
                output[i] = t;
            }

            return output;
        }

        public void DeleteTrack(int trackId)
        {
            var track = GetTrack(trackId);
            _applicationContext.Tracks.Remove(track);
        }

        private static Track GetTrack(int trackId)
        {
            return _applicationContext.Tracks.First(t => t.TrackId == trackId);
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