using KSoftNet.Responses;
using RestSharp;

namespace KSoftNet.KSoft {
    /// <summary>
    /// Random hand-picked images, random memes from Reddit and other Reddit parsers.
    /// </summary>
    public class ImagesAPI {

        private KSoftAPI _kSoftAPI;
        public ImagesAPI(KSoftAPI kSoftAPI) {
            _kSoftAPI = kSoftAPI;
        }
        #region Images API

        /// <summary>
        /// Gets random image from the specified tag.
        /// </summary>
        /// <param name="tag">Default: false, if to show nsfw content</param>
        /// <param name="nsfw">Name of the tag</param>  
        /// <returns>KSoftImage</returns>
        public KSoftImage RandomImage(string tag, bool nsfw = false) {
            RestRequest request = new RestRequest("images/random-image");

            request.AddQueryParameter(name: "tag", value: tag);
            request.AddQueryParameter(name: "nsfw", value: nsfw.ToString());

            return _kSoftAPI.Execute<KSoftImage>(request);
        }

        /// <summary>
        /// Retrieve the list of all available tags.
        /// </summary>
        /// <returns>KSoftTags</returns>
        public KSoftTags Tags() {
            RestRequest request = new RestRequest("images/tags");

            return _kSoftAPI.Execute<KSoftTags>(request);
        }

        /// <summary>
        /// Search for tags.
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>KSoftTags</returns>
        public KSoftTags TagSearch(string query) {
            RestRequest request = new RestRequest($"images/tags/{query}");

            return _kSoftAPI.Execute<KSoftTags>(request);
        }

        /// <summary>
        /// Retrieve image data.
        /// </summary>
        /// <param name="snowflake">Image snowflake (unique ID)</param>
        /// <returns>KSoftImage</returns>
        public KSoftImage ImageFromSnowflake(string snowflake) {
            RestRequest request = new RestRequest($"images/image/{snowflake}");

            return _kSoftAPI.Execute<KSoftImage>(request);
        }

        /// <summary>
        /// Retrieves a random meme from the cache. Source: reddit
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomMeme() {
            RestRequest request = new RestRequest("images/random-meme");

            return _kSoftAPI.Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieves weird images from WikiHow
        /// </summary>
        /// <param name="nsfw">Default: false, if to display nsfw content.</param>
        /// <returns>KSoftWikiHowPost</returns>
        public KSoftWikiHowPost RandomWikiHow(bool nsfw = false) {
            RestRequest request = new RestRequest("images/random-wikihow");

            request.AddQueryParameter(name: "nsfw", value: nsfw.ToString());

            return _kSoftAPI.Execute<KSoftWikiHowPost>(request);
        }

        /// <summary>
        /// Get random cute pictures, mostly animals.
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomAww() {
            RestRequest request = new RestRequest("images/random-aww");

            return _kSoftAPI.Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieves random NSFW pics. (real life stuff)
        /// </summary>
        /// <param name="gifs">Default: false, if to retrieve gifs instead of images</param>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomNsfw(bool gifs) {
            RestRequest request = new RestRequest("images/random-nsfw");

            request.AddQueryParameter(name: "gifs", value: gifs.ToString());

            return _kSoftAPI.Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieve images from the specified subreddit.
        /// </summary>
        /// <param name="subreddit">Specified subreddit</param>
        /// <param name="removeNsfw">Default: false, if set to true, endpoint will filter out nsfw posts.</param>
        /// <param name="span">Default: "day", value: select range from which to get the images. Can be one of the following: "hour", value: "day", value: "week", value: "month", value: "year", value: "all"</param>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomReddit(string subreddit, bool removeNsfw, string span) {
            RestRequest request = new RestRequest($"images/rand-reddit/{subreddit}");

            request.AddQueryParameter(name: "remove-nsfw", value: removeNsfw.ToString());
            request.AddQueryParameter(name: "span", value: span);

            return _kSoftAPI.Execute<KSoftRedditPost>(request);
        }

        #endregion

    }
}