using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ChinookService.TrackService
{
    public interface ITrackService
    {
        public Track MakeNewTrack(TrackBindingModel trackData);
        public void Save(Track track);
        public ICollection<Track> BuildNewTrackList(IEnumerable<TrackBindingModel> trackList);
        public TrackBindingModel[] AddNewAlbumFromTrackArrayStrings(string[] tracklist);
        
    }
}