using KSoftNet.Models;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace KSoftNet.KSoft {
    /// <summary>
    /// Random hand-picked images, random memes from Reddit and other Reddit parsers.
    /// </summary>
    public class ImagesAPI {

        private readonly KSoftAPI _kSoftAPI;
        /// <summary>
        /// Random hand-picked images, random memes from Reddit and other Reddit parsers.
        /// </summary>
        /// <param name="kSoftAPI"></param>
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
        public async Task<KSoftImage> RandomImage(string tag, bool nsfw = false) {
            NameValueCollection queries = new NameValueCollection();

            queries.Add(name: "tag", value: tag);
            queries.Add(name: "nsfw", value: nsfw.ToString());

            return await _kSoftAPI.ExecuteAsync<KSoftImage>(HttpMethod.Get, "images/random-image", queries);
        }

        /// <summary>
        /// Retrieve the list of all available tags.
        /// </summary>
        /// <returns>KSoftTags</returns>
        public async Task<KSoftTags> Tags() {
            NameValueCollection queries = new NameValueCollection();

            return await _kSoftAPI.ExecuteAsync<KSoftTags>(HttpMethod.Get, "images/tags", queries);
        }

        /// <summary>
        /// Search for tags.
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>KSoftTags</returns>
        public async Task<KSoftTags> TagSearch(string query) {
            return await _kSoftAPI.ExecuteAsync<KSoftTags>(HttpMethod.Get, $"images/tags/{query}");
        }

        /// <summary>
        /// Retrieve image data.
        /// </summary>
        /// <param name="snowflake">Image snowflake (unique ID)</param>
        /// <returns>KSoftImage</returns>
        public async Task<KSoftImage> ImageFromSnowflake(string snowflake) {
            return await _kSoftAPI.ExecuteAsync<KSoftImage>(HttpMethod.Get, $"images/image/{snowflake}");
        }

        /// <summary>
        /// Retrieves a random meme from the cache. Source: reddit
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public async Task<KSoftRedditPost> RandomMeme() {
            return await _kSoftAPI.ExecuteAsync<KSoftRedditPost>(HttpMethod.Get, "images/random-meme");
        }

        /// <summary>
        /// Retrieves weird images from WikiHow
        /// </summary>
        /// <param name="nsfw">Default: false, if to display nsfw content.</param>
        /// <returns>KSoftWikiHowPost</returns>
        public async Task<KSoftWikiHowPost> RandomWikiHow(bool nsfw = false) {
            NameValueCollection queries = new NameValueCollection();

            queries.Add(name: "nsfw", value: nsfw.ToString());

            return await _kSoftAPI.ExecuteAsync<KSoftWikiHowPost>(HttpMethod.Get, "images/random-wikihow", queries);
        }

        /// <summary>
        /// Get random cute pictures, mostly animals.
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public async Task<KSoftRedditPost> RandomAww() {
            return await _kSoftAPI.ExecuteAsync<KSoftRedditPost>(HttpMethod.Get, "images/random-meme");

        }

        /// <summary>
        /// Retrieves random NSFW pics. (real life stuff)
        /// </summary>
        /// <param name="gifs">Default: false, if to retrieve gifs instead of images</param>
        /// <returns>KSoftRedditPost</returns>
        public async Task<KSoftRedditPost> RandomNsfw(bool gifs) {
            NameValueCollection queries = new NameValueCollection();

            queries.Add(name: "gifs", value: gifs.ToString());

            return await _kSoftAPI.ExecuteAsync<KSoftRedditPost>(HttpMethod.Get, "images/random-nsfw", queries);
        }

        /// <summary>
        /// Retrieve images from the specified subreddit.
        /// </summary>
        /// <param name="subreddit">Specified subreddit</param>
        /// <param name="removeNsfw">Default: false, if set to true, endpoint will filter out nsfw posts.</param>
        /// <param name="span">Default: "day", value: select range from which to get the images. Can be one of the following: "hour", value: "day", value: "week", value: "month", value: "year", value: "all"</param>
        /// <returns>KSoftRedditPost</returns>
        public async Task<KSoftRedditPost> RandomReddit(string subreddit, bool removeNsfw, string span) {
            NameValueCollection queries = new NameValueCollection();

            queries.Add(name: "remove-nsfw", value: removeNsfw.ToString());
            queries.Add(name: "span", value: span);

            return await _kSoftAPI.ExecuteAsync<KSoftRedditPost>(HttpMethod.Get, $"images/rand-reddit/{subreddit}", queries);
        }

        #endregion

    }
}