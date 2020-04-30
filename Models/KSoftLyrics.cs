using System.Collections.Generic;

namespace KSoftNet.Responses {
    public class KSoftLyricsData {
        public string Artist { get; set; }
        public int ArtistId { get; set; }
        public string Album { get; set; }
        public string AlbumIds { get; set; }
        public string AlbumYear { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public string SearchStr { get; set; }
        public string Id { get; set; }
        public double SearchScore { get; set; }
    }

    public class KSoftLyrics {
        public int Total { get; set; }
        public int Took { get; set; }
        public IList<KSoftLyricsData> Data { get; set; }
    }
}