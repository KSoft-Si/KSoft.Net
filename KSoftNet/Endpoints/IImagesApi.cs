using System.Threading.Tasks;
using KSoftNet.Enums;
using KSoftNet.Models.Images;
using Refit;

namespace KSoftNet.Endpoints {
  /// <summary>
  /// Random hand-picked images, random memes from Reddit and other Reddit parsers.
  /// </summary>
  public interface IImagesApi {
    /// <summary>
    /// Gets random image from the specified tag.
    /// </summary>
    /// <param name="tag">Name of the tag</param>
    /// <param name="nsfw">Default: false, if to show nsfw content</param>
    /// <returns>Image</returns>
    [Get("/images/random-image")]
    Task<Image> GetRandomImage(string tag, bool nsfw = false);

    /// <summary>
    /// Retrieve the list of all available tags.
    /// </summary>
    /// <returns>Tag list</returns>
    [Get("/images/tags")]
    Task<TagList> GetAllTags();

    /// <summary>
    /// Search for tags.
    /// </summary>
    /// <param name="search">Search query</param>
    /// <returns>Tag list</returns>
    [Get("/images/tags/{search}")]
    Task<TagList> SearchTags(string search);

    /// <summary>
    /// Retrieve image data.
    /// </summary>
    /// <param name="snowflake">Image snowflake (unique ID)</param>
    /// <returns>Image</returns>
    [Get("/images/image/{snowflake}")]
    Task<Image> GetImageFromId(string snowflake);

    /// <summary>
    /// Retrieves a random meme from the cache. Source: reddit
    /// </summary>
    /// <returns>Reddit post</returns>
    [Get("/images/random-meme")]
    Task<RedditPost> GetRandomMeme();

    /// <summary>
    /// Retrieves weird images from WikiHow
    /// </summary>
    /// <param name="nsfw">Default: false, if to display nsfw content.</param>
    /// <returns>WikiHow post</returns>
    [Get("/images/random-wikihow")]
    Task<WikihowPost> GetRandomWikihow(bool nsfw = false);

    /// <summary>
    /// Get random cute pictures, mostly animals.
    /// </summary>
    /// <returns>Reddit post</returns>
    [Get("/images/random-aww")]
    Task<RedditPost> GetRandomAww();

    /// <summary>
    /// Retrieves random NSFW pics. (real life stuff)
    /// </summary>
    /// <param name="gifs">Default: false, if to retrieve gifs instead of images</param>
    /// <returns>Reddit post</returns>
    [Get("/images/random-nsfw")]
    Task<RedditPost> GetRandomNsfw(bool gifs = false);

    /// <summary>
    /// Retrieve images from the specified subreddit.
    /// </summary>
    /// <param name="subreddit">Specified subreddit</param>
    /// <param name="span">Default: "day", select range from which to get the images. Can be one of the following: "hour", "day", "week", "month", "year", "all"</param>
    /// <param name="removeNsfw">Default: false, if set to true, endpoint will filter out nsfw posts.</param>
    /// <returns>Reddit post</returns>
    [Get("/images/rand-reddit/{subreddit}")]
    Task<RedditPost> GetRandomReddit(string subreddit, Span span = Span.Day, [AliasAs("remove_nsfw")] bool removeNsfw = false);
  }
}