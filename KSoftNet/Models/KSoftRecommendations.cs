using System.Collections.Generic;

namespace KSoftNet.Responses {
    public class KSoftRecommendationsYoutube {
        public string Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
    }

    public class KSoftRecommendationsAlbum {
        public string Name { get; set; }
        public string AlbumArt { get; set; }
        public string Link { get; set; }
    }

    public class KSoftRecommendationsArtist {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class KSoftRecommendationsSpotify {
        public string Id { get; set; }
        public KSoftRecommendationsAlbum Album { get; set; }
        public IList<KSoftRecommendationsArtist> Artists { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class KSoftRecommendationsTrack {
        public KSoftRecommendationsYoutube Youtube { get; set; }
        public KSoftRecommendationsSpotify Spotify { get; set; }
        public string Name { get; set; }
    }

    public class KSoftRecommendations {
        public string Provider { get; set; }
        public int Total { get; set; }
        public IList<KSoftRecommendationsTrack> Tracks { get; set; }
    }
}