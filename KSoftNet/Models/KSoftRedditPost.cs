namespace KSoftNet.Models {
    public class KSoftRedditPost {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Source { get; set; }
        public string Subreddit { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int Comments { get; set; }
        public double CreatedAt { get; set; }
        public bool Nsfw { get; set; }
        public string Author { get; set; }
        public int Awards { get; set; }
        public bool MetaCached { get; set; }
        public bool MetaProcessed { get; set; }
    }
}