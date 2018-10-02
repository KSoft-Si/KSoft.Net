#region

using KSoftDotNet.Interfaces;
using KSoftDotNet.Model.KSoftTags;
using KSoftDotNet.Model.Results;
using KSoftDotNet.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

#endregion

namespace KSoftDotNet.Manager
{
    public class KSoft
    {
        private readonly IWebManager _webManager = new WebManager();
        private readonly string _token;

        private const string BaseUrl = "https://api.ksoft.si/";
        private const string BaseImage = "images";
        private const string BaseBans = "bans";

        /// <summary>
        /// Initialize KSoft Manager.
        /// </summary>
        /// <param name="token">Key used for authentication.</param>
        public KSoft(string token)
        {
            _token = token;
        }

        #region Image api
        /// <summary>
        /// Get random image.
        /// </summary>
        /// <param name="tag">Optional: Used to get images with a specific tag.</param>
        /// <param name="nsfw">Optional: Used to enable or disable NSFW images.</param>
        /// <returns>A KSoftImage object</returns>
        public async Task<KSoftImage> GetRandomImage(string tag = null, bool nsfw = false)
        {
            var nvc = new NameValueCollection();
            if (!string.IsNullOrEmpty(tag))
                nvc.Add("tag", tag);
            nvc.Add("nsfw", nsfw.ToString());

            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/random-image{UriExtensions.ToQueryString(nvc)}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get image: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftImage>(result.ResultJson);
        }

        /// <summary>
        /// Get list of all tags.
        /// </summary>
        /// <returns>KSoftTags object</returns>
        public async Task<KSoftTags> GetTags()
        {
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/tags"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get tags: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftTags>(result.ResultJson);
        }

        /// <summary>
        /// Search for tags.
        /// </summary>
        /// <param name="tag">Required: Search query.</param>
        /// <returns>KSoftTags object</returns>
        public async Task<KSoftTags> SearchTags(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new Exception($"Query cannot be null or empty: {tag}");
            }
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/tags/{tag}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get tag: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftTags>(result.ResultJson);
        }

        /// <summary>
        /// Get image via snowflake.
        /// </summary>
        /// <param name="snowflake">Required: Search query.</param>
        /// <returns>KSoftImage object</returns>
        public async Task<KSoftImage> GetImageFromSnowflake(string snowflake)
        {
            if (string.IsNullOrEmpty(snowflake))
            {
                throw new Exception($"Snowflake query cannot be null or empty: {snowflake}");
            }
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/image/{snowflake}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get image: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftImage>(result.ResultJson);
        }

        /// <summary>
        /// Get random meme.
        /// </summary>
        /// <returns>KSoftRedditPost object</returns>
        public async Task<KSoftRedditPost> GetRandomMeme()
        {
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/random-meme"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get meme: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftRedditPost>(result.ResultJson);
        }

        /// <summary>
        /// Retrieve weird images from WikiHow.
        /// </summary>
        /// <param name="nsfw">Optional: Toggles possibility of NSFW images.</param>
        /// <returns>KSoftWikihowPost object</returns>
        public async Task<KSoftWikihowPost> GetRandomWikihow(bool nsfw = false)
        {
            var nvc = new NameValueCollection { { "nsfw", nsfw.ToString() } };
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/random-wikihow{UriExtensions.ToQueryString(nvc)}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get wikihow article: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftWikihowPost>(result.ResultJson);
        }

        /// <summary>
        /// Get random cute images.
        /// </summary>
        /// <returns>KSoftRedditPost object</returns>
        public async Task<KSoftRedditPost> GetRandomAww()
        {
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/random-aww"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get post: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftRedditPost>(result.ResultJson);
        }

        /// <summary>
        /// Get random NSFW images.
        /// </summary>
        /// <param name="gifs">Optional: Toggles possibility of gifs.</param>
        /// <returns>KSoftRedditPost object</returns>
        public async Task<KSoftRedditPost> GetRandomNsfw(bool gifs = false)
        {
            var nvc = new NameValueCollection { { "gifs", gifs.ToString() } };
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/random-nsfw{UriExtensions.ToQueryString(nvc)}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get post: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftRedditPost>(result.ResultJson);
        }

        /// <summary>
        /// Get random reddit post.
        /// </summary>
        /// <param name="subreddit">Required: Subreddit to get post from.</param>
        /// <param name="span">Optional: Timespan in which to get post (Ex: Day = random post from within the last day).</param>
        /// <returns>KSoftRedditPost object</returns>
        public async Task<KSoftRedditPost> GetRandomSubredditImage(string subreddit = "all", string span = "Day")
        {
            var nvc = new NameValueCollection { { "span", span } };
            var result = await _webManager.GetData(new Uri($"{BaseUrl}{BaseImage}/rand-reddit/{subreddit}{UriExtensions.ToQueryString(nvc)}"), _token);
            if (!result.IsSuccess)
            {
                throw new WebException($"Failed to get post: {result.ResultJson}");
            }
            return JsonConvert.DeserializeObject<KSoftRedditPost>(result.ResultJson);
        }

        #endregion

        #region Bans API

        public async Task<KSoftBan> AddBan(int userID, string reason, string proof, int reporterID = -0, string userName = null, int userDiscrim = -0, bool appealPossible = false)
        {
            var nvc = new NameValueCollection
            {
                { "appeal_possible", appealPossible.ToString() },
                { "user", userID.ToString() },
                { "reason", reason },
                { "proof", proof }
            };
            if (reporterID != -0)
                nvc.Add("mod", reporterID.ToString());
            if (!string.IsNullOrEmpty(userName))
                nvc.Add("user_name", userName);
            if (userDiscrim != -0)
                nvc.Add("user_discriminator", userDiscrim.ToString());
            var json = JsonConvert.SerializeObject(nvc);
            HttpContent httpContent = new StringContent(json);
            Console.WriteLine("json: " + json);
            Console.WriteLine("httpContent: " + httpContent.ReadAsStringAsync());
            Console.WriteLine("nvc: " + nvc.AllKeys.ToString());
            var result = await _webManager.PostData(new Uri($"{BaseUrl}{BaseBans}/add"), httpContent, _token);
            return JsonConvert.DeserializeObject<KSoftBan>(result.ResultJson);
        }

        #endregion
    }
}
