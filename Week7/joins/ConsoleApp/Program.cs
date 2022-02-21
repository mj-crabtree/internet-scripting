using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Music db = new Music();
            
            var albums = db.Albums.Select(
                a => new Album()
                {
                    AlbumId = a.AlbumId,
                    ArtistId = a.ArtistId,
                    AlbumTitle = a.AlbumTitle
                });

            var artists = db.Artists.Select(
                a => new Artist()
                {
                    ArtistId = a.ArtistId,
                    ArtistName = a.ArtistName
                });

            var queryResults = db.Albums.Join(
                db.Artists,
                album => album.AlbumId,
                artist => artist.ArtistId,
                (album, artist) => new QueryResult()
                {
                    AlbumId = album.AlbumId,
                    ArtistName = artist.ArtistName,
                    AlbumTitle = album.AlbumTitle
                }).ToList();

            foreach (Album a in albums)
            {
                Console.WriteLine($"{a.AlbumId} {a.AlbumTitle} {a.ArtistId}");
            }

            foreach (var artist in artists)
            {
                System.Console.WriteLine($"{artist.ArtistId} {artist.ArtistName}");
            }
            
            System.Console.WriteLine("query results");
            
            foreach (var q in queryResults)
            {
                System.Console.WriteLine($"{q.AlbumId}: {q.AlbumTitle} - {q.ArtistName}");
            }

            // IList<string> albumTitles = db.Albums.Select(a => a.AlbumTitle).ToList();
            // foreach (var a in albumTitles)
            // {
            //     Console.WriteLine($"{a}");
            // }


        }
    }
}
