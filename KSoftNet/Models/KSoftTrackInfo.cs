using System.Collections.Generic;

namespace KSoftNet.Models {
    public class KSoftTrackInfoArtist {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    public class KSoftTrackInfoAlbum {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Uri { get; set; }
    }

    public class KSoftTrackInfoOther {
        public int Bpm { get; set; }
        public int Gain { get; set; }
    }

    public class KSoftTrackInfoDeezer {
        public object Album { get; set; }
        public object Track { get; set; }
        public IList<KSoftTrackInfoArtist> Artists { get; set; }
    }

    public class KSoftTrackInfoSpotify {
        public object Album { get; set; }
        public object Track { get; set; }
        public IList<KSoftTrackInfoArtist> Artists { get; set; }
    }

    public class KSoftTrackInfoMeta {
        public KSoftTrackInfoOther Other { get; set; }
        public KSoftTrackInfoDeezer Deezer { get; set; }
        public IList<KSoftTrackInfoArtist> Artists { get; set; }
        public KSoftTrackInfoSpotify Spotify { get; set; }
    }

    public class KSoftTrackInfo {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public KSoftTrackInfoArtist Artist { get; set; }
        public IList<KSoftTrackInfoAlbum> Albums { get; set; }
        public string Lyrics { get; set; }
        public IList<string> Singalong { get; set; }
        public KSoftTrackInfoMeta Meta { get; set; }
        public string Url { get; set; }
        public int Popularity { get; set; }
    }
}
