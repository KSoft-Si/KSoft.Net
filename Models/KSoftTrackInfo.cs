using System.Collections.Generic;

namespace KSoftNet.Responses {

    public class KSoftTrackInfoArtist {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KSoftTrackInfoAlbum {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class KSoftTrackInfo {
        public string Name { get; set; }
        public KSoftTrackInfoArtist Artist { get; set; }
        public IList<KSoftTrackInfoAlbum> Albums { get; set; }
        public string Lyrics { get; set; }

        // Error
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
