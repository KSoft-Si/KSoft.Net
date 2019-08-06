using System.Collections.Generic;

namespace KSoft.Net.Responses
{
    public class KSoftAlbumInfoArtist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KSoftAlbumInfoTrack
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KSoftAlbumInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public KSoftAlbumInfoArtist Artist { get; set; }
        public IList<KSoftAlbumInfoTrack> Tracks { get; set; }

        // Error
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}