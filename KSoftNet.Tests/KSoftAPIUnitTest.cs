using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KSoftNet.Enums;
using KSoftNet.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace KSoftNet.Tests {

  /// <summary>
  /// Not real unit tests
  /// </summary>
  [TestClass]
  public class KSoftApiUnitTest {
    private readonly KSoftApi _kSoftApi;
    public KSoftApiUnitTest() {
      var configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
      var token = configuration["token"];
      // _kSoftApi = new KSoftApi(token);
      var httpClient = new HttpClient(new HttpLoggingHandler()) {
        BaseAddress = new Uri("https://api.ksoft.si"),
        DefaultRequestHeaders = {
          Authorization = new AuthenticationHeaderValue("Bearer", token)
        }
      };
      _kSoftApi = new KSoftApi(httpClient);
    }

    [TestMethod]
    public void TestUrlFormatter() {
      var formatter = new ParameterFormatter();

      Assert.AreEqual("auto", formatter.Format(Unit.Auto, null, typeof(Unit)));
      Assert.AreEqual("uk2", formatter.Format(Unit.Uk2, null, typeof(Unit)));
      Assert.AreEqual("us", formatter.Format(Unit.Us, null, typeof(Unit)));
      Assert.AreEqual("AUD", formatter.Format(CurrencyCode.Aud, null, typeof(CurrencyCode)));
      Assert.AreEqual("ar", formatter.Format(Language.Ar, null, typeof(Language)));
      Assert.AreEqual("x-pig-latin", formatter.Format(Language.XPigLatin, null, typeof(Language)));
      Assert.AreEqual("zh-tw", formatter.Format(Language.ZhTw, null, typeof(Language)));
      Assert.AreEqual("original", formatter.Format(IconPack.Original, null, typeof(IconPack)));
      Assert.AreEqual("currently", formatter.Format(ReportType.Currently, null, typeof(ReportType)));
      Assert.AreEqual("hourly", formatter.Format(ReportType.Hourly, null, typeof(ReportType)));
      Assert.AreEqual("all", formatter.Format(Span.All, null, typeof(Span)));
      Assert.AreEqual("month", formatter.Format(Span.Month, null, typeof(Span)));
      Assert.AreEqual("year", formatter.Format(Span.Year, null, typeof(Span)));
    }

    [TestMethod]
    public void TestKebabFormatter() {
      const string test1 = "TestCase";
      const string test2 = "testcase";
      const string test3 = "testCase";
      const string test4 = "Test1Case";
      const string test5 = "TestCase1";
      const string test6 = "Test-Case1";

      Assert.AreEqual("test-case", test1.PascalToKebabCase());
      Assert.AreEqual("testcase", test2.PascalToKebabCase());
      Assert.AreEqual("test-case", test3.PascalToKebabCase());
      Assert.AreEqual("test-1-case", test4.PascalToKebabCase());
      Assert.AreEqual("test-case-1", test5.PascalToKebabCase());
      Assert.AreEqual("test-case-1", test6.PascalToKebabCase());
    }

    [TestMethod]
    public void TestCreation() {
      Assert.IsNotNull(_kSoftApi.ImagesApi);
      Assert.IsNotNull(_kSoftApi.KumoApi);
      Assert.IsNotNull(_kSoftApi.MusicApi);
      Assert.IsNotNull(_kSoftApi.ImagesApi);
    }

    [TestMethod]
    public async Task TestRandomImage() {
      var image = await _kSoftApi.ImagesApi.GetRandomImage("pepe");

      LogObject(image);

      Assert.IsFalse(image.Nsfw);
      Assert.IsNotNull(image.Url);
      Assert.IsNotNull(image.Snowflake);
      Assert.IsNotNull(image.Tag);
    }

    [TestMethod]
    public async Task TestTags() {
      var tags = await _kSoftApi.ImagesApi.GetAllTags();

      LogObject(tags);

      Assert.IsNotNull(tags.Models);
      Assert.IsNotNull(tags.NsfwTags);
      Assert.IsNotNull(tags.Tags);
    }

    [TestMethod]
    public async Task TestTagSearch() {
      var tags = await _kSoftApi.ImagesApi.SearchTags("birb");

      LogObject(tags);

      Assert.IsNotNull(tags.Models);
      Assert.IsNotNull(tags.Tags);
    }

    [TestMethod]
    public async Task TestImageFromSnowflake() {
      var image = await _kSoftApi.ImagesApi.GetImageFromId("i-7n36tlpw-30");

      LogObject(image);

      Assert.IsNotNull(image.Tag);
      Assert.AreEqual("i-7n36tlpw-30", image.Snowflake);
      Assert.IsNotNull(image.Nsfw);
      Assert.IsNotNull(image.Url);
    }

    [TestMethod]
    public async Task TestRandomMeme() {
      var meme = await _kSoftApi.ImagesApi.GetRandomMeme();

      LogObject(meme);

      Assert.IsNotNull(meme.ImageUrl);
      Assert.IsNotNull(meme.Source);
      Assert.IsNotNull(meme.Subreddit);
      Assert.IsNotNull(meme.Nsfw);
      Assert.IsNotNull(meme.Title);
      Assert.IsNotNull(meme.Upvotes);
      Assert.IsNotNull(meme.Downvotes);
      Assert.IsNotNull(meme.Awards);
      Assert.IsNotNull(meme.CreatedAt);
      Assert.IsNotNull(meme.Comments);
      Assert.IsNotNull(meme.Author);
      Assert.IsNotNull(meme.MetaCached);
      Assert.IsNotNull(meme.MetaProcessed);
    }

    [TestMethod]
    public async Task TestRandomWikiHow() {
      var wh = await _kSoftApi.ImagesApi.GetRandomWikihow();

      LogObject(wh);

      Assert.IsNotNull(wh.ImageUrl);
      Assert.IsNotNull(wh.ArticleUrl);
      Assert.IsFalse(wh.Nsfw);
      Assert.IsNotNull(wh.Title);
    }

    [TestMethod]
    public async Task TestRandomAww() {
      var aww = await _kSoftApi.ImagesApi.GetRandomAww();

      LogObject(aww);

      Assert.IsNotNull(aww.ImageUrl);
      Assert.IsNotNull(aww.Source);
      Assert.IsNotNull(aww.Subreddit);
      Assert.IsNotNull(aww.Nsfw);
      Assert.IsNotNull(aww.Title);
      Assert.IsNotNull(aww.Upvotes);
      Assert.IsNotNull(aww.Downvotes);
      Assert.IsNotNull(aww.Awards);
      Assert.IsNotNull(aww.CreatedAt);
      Assert.IsNotNull(aww.Comments);
      Assert.IsNotNull(aww.Author);
      Assert.IsNotNull(aww.MetaCached);
      Assert.IsNotNull(aww.MetaProcessed);
    }

    [TestMethod]
    public async Task TestRandomNsfw() {
      var nsfw = await _kSoftApi.ImagesApi.GetRandomNsfw(false);

      LogObject(nsfw);

      Assert.IsNotNull(nsfw.ImageUrl);
      Assert.IsNotNull(nsfw.Source);
      Assert.IsNotNull(nsfw.Subreddit);
      Assert.IsTrue(nsfw.Nsfw);
      Assert.IsNotNull(nsfw.Title);
      Assert.IsNotNull(nsfw.Upvotes);
      Assert.IsNotNull(nsfw.Downvotes);
      Assert.IsNotNull(nsfw.Awards);
      Assert.IsNotNull(nsfw.CreatedAt);
      Assert.IsNotNull(nsfw.Comments);
      Assert.IsNotNull(nsfw.Author);
      Assert.IsNotNull(nsfw.MetaCached);
      Assert.IsNotNull(nsfw.MetaProcessed);
    }

    [TestMethod]
    public async Task TestRandomReddit() {
      var aww = await _kSoftApi.ImagesApi.GetRandomReddit("all", Span.Day, true);

      LogObject(aww);

      Assert.IsNotNull(aww.ImageUrl);
      Assert.IsNotNull(aww.Source);
      Assert.IsNotNull(aww.Subreddit);
      Assert.IsFalse(aww.Nsfw);
      Assert.IsNotNull(aww.Title);
      Assert.IsNotNull(aww.Upvotes);
      Assert.IsNotNull(aww.Downvotes);
      Assert.IsNotNull(aww.Awards);
      Assert.IsNotNull(aww.CreatedAt);
      Assert.IsNotNull(aww.Comments);
      Assert.IsNotNull(aww.Author);
      Assert.IsNotNull(aww.MetaCached);
      Assert.IsNotNull(aww.MetaProcessed);
    }

    [TestMethod]
    public async Task TestGeoIp() {
      var geoip = await _kSoftApi.KumoApi.GeoIp("8.8.8.8");

      LogObject(geoip);

      Assert.IsFalse(geoip.Error);
      Assert.IsNotNull(geoip.Data);
      Assert.IsNotNull(geoip.Data.Apis);
      Assert.IsNotNull(geoip.Data.Apis.Gis);
      Assert.AreEqual(200, geoip.Code);
    }

    [TestMethod]
    public async Task TestCurrencyConversion() {
      var currency = await _kSoftApi.KumoApi.ConvertCurrency(CurrencyCode.Usd, CurrencyCode.Cad, 1239.554);

      LogObject(currency);

      Assert.IsNotNull(currency.Value);
      Assert.IsNotNull(currency.Pretty);
    }


    // [TestMethod]
    // public async Task TestSearchLyrics() {
    //   var lyrics = await _kSoftApi.MusicApi.lyrics :( ("Is this the real life? Is this just fantasy?", true, 1);
    //
    //   LogObject(lyrics);
    //
    //   Assert.IsNotNull(lyrics.Total);
    //   Assert.IsNotNull(lyrics.Data);
    //   Assert.IsNotNull(lyrics.Took);
    // }

    // [TestMethod]
    // public async Task TestArtistById() {
    //   var artist = await _kSoftApi.MusicApi.GetArtistById("28333");
    //
    //   LogObject(artist);
    //
    //   Assert.AreEqual(28333, artist.Id);
    //   Assert.IsNotNull(artist.Name);
    //   Assert.IsNotNull(artist.Tracks);
    //   Assert.IsNotNull(artist.Albums);
    // }

    // [TestMethod]
    // public async Task TestAlbumById() {
    //   var album = await _kSoftApi.MusicApi.GetAlbumById(88287);
    //
    //   LogObject(album);
    //
    //   Assert.AreEqual(28333, album.Id);
    //   Assert.IsNotNull(album.Name);
    //   Assert.IsNotNull(album.Tracks);
    //   Assert.IsNotNull(album.Artist);
    //   Assert.IsNotNull(album.Year);
    // }

    // [TestMethod]
    // public async Task TestTrackById() {
    //   var track = await _kSoftApi.MusicApi.GetTrackById(628942);
    //
    //   LogObject(track);
    //
    //   Assert.AreEqual(628942, track.Id);
    //   Assert.IsNotNull(track.Name);
    //   Assert.IsNotNull(track.Artist);
    //   Assert.IsNotNull(track.Albums);
    //   Assert.IsNotNull(track.Lyrics);
    //   // Assert.IsNotNull(track.Singalong);
    //   // Assert.IsNotNull(track.Meta);
    //   // Assert.IsNotNull(track.Url);
    //   // Assert.IsNotNull(track.Uri);
    //   // Assert.IsNotNull(track.Popularity);
    // }


    [TestMethod]
    public async Task TestBanInfo() {
      var banInfo = await _kSoftApi.BansApi.GetBanInfo(766186017979760681);

      LogObject(banInfo);

      Assert.AreEqual("766186017979760681", banInfo.Id);
      Assert.AreEqual("Conquestor", banInfo.Name);
      Assert.AreEqual("4578", banInfo.Discriminator);
      Assert.AreEqual("267831837240328192", banInfo.ModeratorId);
      Assert.AreEqual("DM ads", banInfo.Reason);
      Assert.AreEqual("https://i.imgur.com/2cwSjPy.png", banInfo.Proof);
      Assert.IsTrue(banInfo.IsBanActive);
      Assert.IsTrue(banInfo.CanBeAppealed);
      Assert.AreEqual("", banInfo.AppealReason);
      Assert.IsTrue(banInfo.Exists);
      Assert.AreEqual("267831837240328192", banInfo.RequestedBy);
      Assert.IsNotNull(banInfo.Timestamp);
    }

    [TestMethod]
    public async Task TestBanCheck() {
      var banCheck = await _kSoftApi.BansApi.CheckBan("69");

      LogObject(banCheck);

      Assert.IsFalse(banCheck.IsBanned);
    }

    [TestMethod]
    public async Task TestBanCheck2() {
      var banCheck = await _kSoftApi.BansApi.CheckBan("766186017979760681");

      LogObject(banCheck);

      Assert.IsTrue(banCheck.IsBanned);
    }

    [TestMethod]
    public async Task TestBanList() {
      var banList = await _kSoftApi.BansApi.ListBans(1, 2);

      LogObject(banList);

      Assert.AreEqual(1, banList.Page);
      Assert.AreEqual(2, banList.PerPage);
      Assert.IsNull(banList.PreviousPage);
      Assert.IsNotNull(banList.BanCount);
      Assert.IsNotNull(banList.PageCount);
      Assert.AreEqual(2, banList.OnPage);
      Assert.IsNotNull(banList.Bans);
    }

    [TestMethod]
    public async Task TestBanUpdates() {
      var timestamp = (long)DateTimeOffset.Now.ToUnixTimeSeconds() - (long)TimeSpan.FromDays(29).TotalSeconds;

      var banUpdates = await _kSoftApi.BansApi.GetBanUpdates(timestamp);
      LogObject(timestamp);
      LogObject(banUpdates);

      Assert.IsNotNull(banUpdates.CurrentTimestamp);
      Assert.IsNotNull(banUpdates.Bans);
    }

    private static void LogObject(object obj) {
      Console.WriteLine(obj.ToJson());
    }
  }

  public static class StringExtensions {
    public static string ToJson(this object obj) {
      return JsonConvert.SerializeObject(obj);
    }
  }
}