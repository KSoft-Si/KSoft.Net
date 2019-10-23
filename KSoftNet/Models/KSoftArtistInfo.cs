using System.Collections.Generic;

namespace KSoftNet.Responses {
    public class KSoftArtistInfoAlbum {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class KSoftArtistInfoTrack {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KSoftArtistInfo {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<KSoftArtistInfoAlbum> Albums { get; set; }
        public IList<KSoftArtistInfoTrack> Tracks { get; set; }

        // Error
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}