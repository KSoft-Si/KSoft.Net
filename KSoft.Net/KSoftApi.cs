using RestSharp;
using RestSharp.Authenticators;
using System;
using KSoft.Net.Responses;

namespace KSoft.Net
{
    public class KSoftApi
    {
        const string BaseUrl = "https://api.ksoft.si/";

        readonly IRestClient _client;

        string _accountToken;

        public KSoftApi(string accountSid, string secretKey) {
            _client = new RestClient(BaseUrl);
            _accountToken = accountSid;
        }

        public T Execute<T>(RestRequest request) where T : new() {
            request.AddParameter("Authorization", "Bearer" + _accountToken);
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null) {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var ksoftException = new ApplicationException(message, response.ErrorException);
                throw ksoftException;
            }
            return response.Data;
        }

        #region Images API

        /// <summary>
        /// Gets random image from the specified tag.
        /// </summary>
        /// <param name="tag">Default: false, if to show nsfw content</param>
        /// <param name="nsfw">Name of the tag</param>
        /// <returns>KSoftImage</returns>
        public KSoftImage RandomImage(string tag, bool nsfw = false) {
            var request = new RestRequest("images/random-image");

            request.AddParameter("tag", tag, ParameterType.UrlSegment);
            request.AddParameter("nsfw", nsfw, ParameterType.UrlSegment);

            return Execute<KSoftImage>(request);
        }

        /// <summary>
        /// Retrieve the list of all available tags.
        /// </summary>
        /// <returns>KSoftTags</returns>
        public KSoftTags Tags() {
            var request = new RestRequest("images/tags");

            return Execute<KSoftTags>(request);
        }

        /// <summary>
        /// Search for tags.
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>KSoftTags</returns>
        public KSoftTags TagSearch(string query) {
            var request = new RestRequest($"images/tags/{query}");

            return Execute<KSoftTags>(request);
        }

        /// <summary>
        /// Retrieve image data.
        /// </summary>
        /// <param name="snowflake">Image snowflake (unique ID)</param>
        /// <returns>KSoftImage</returns>
        public KSoftImage ImageFromSnowflake(string snowflake) {
            var request = new RestRequest($"images/image/{snowflake}");

            return Execute<KSoftImage>(request);
        }

        /// <summary>
        /// Retrieves a random meme from the cache. Source: reddit
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomMeme() {
            var request = new RestRequest("images/random-meme");

            return Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieves weird images from WikiHow
        /// </summary>
        /// <param name="nsfw">Default: false, if to display nsfw content.</param>
        /// <returns>KSoftWikiHowPost</returns>
        public KSoftWikiHowPost RandomWikiHow(bool nsfw = false) {
            var request = new RestRequest("images/random-meme");

            request.AddParameter("nsfw", nsfw, ParameterType.UrlSegment);

            return Execute<KSoftWikiHowPost>(request);
        }

        /// <summary>
        /// Get random cute pictures, mostly animals.
        /// </summary>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomAww() {
            var request = new RestRequest("images/random-aww");

            return Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieves random NSFW pics. (real life stuff)
        /// </summary>
        /// <param name="gifs">Default: false, if to retrieve gifs instead of images</param>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomNsfw(bool gifs) {
            var request = new RestRequest("images/random-nsfw");

            request.AddParameter("gifs", gifs, ParameterType.UrlSegment);

            return Execute<KSoftRedditPost>(request);
        }

        /// <summary>
        /// Retrieve images from the specified subreddit.
        /// </summary>
        /// <param name="subreddit">Specified subreddit</param>
        /// <param name="removeNsfw">Default: false, if set to true, endpoint will filter out nsfw posts.</param>
        /// <param name="span">Default: "day", select range from which to get the images. Can be one of the following: "hour", "day", "week", "month", "year", "all"</param>
        /// <returns>KSoftRedditPost</returns>
        public KSoftRedditPost RandomReddit(string subreddit, bool removeNsfw, string span) {
            var request = new RestRequest("images/rand-reddit");

            request.AddParameter("remove-nsfw", removeNsfw, ParameterType.UrlSegment);
            request.AddParameter("span", span, ParameterType.UrlSegment);

            return Execute<KSoftRedditPost>(request);
        }
        #endregion

        #region Bans API

        // Bans API

        #endregion
    }
}
