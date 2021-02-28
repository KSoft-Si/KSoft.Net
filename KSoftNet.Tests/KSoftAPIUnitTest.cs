using KSoftNet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace KSoftNet.Tests {
    [TestClass]
    public class KSoftAPIUnitTest {

        public string token = "";
        readonly KSoftAPI kSoftAPI;

        public KSoftAPIUnitTest() {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            token = configuration["token"];

            kSoftAPI = new KSoftAPI(token);
        }


        public JsonSerializerSettings jsonSettings = new JsonSerializerSettings {
            ContractResolver = new DefaultContractResolver {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public void LogObject(object obj) {
            Console.WriteLine(JsonConvert.SerializeObject(obj, jsonSettings));
        }

        [TestMethod]
        public void TestCreation() {
            Assert.IsNotNull(kSoftAPI.imagesAPI);
            Assert.IsNotNull(kSoftAPI.kumoAPI);
            Assert.IsNotNull(kSoftAPI.musicAPI);
            Assert.IsNotNull(kSoftAPI.imagesAPI);
            Assert.IsNotNull(kSoftAPI.BaseUrl);
        }

        [TestMethod]
        public async Task TestRandomImage() {
            KSoftImage image = await kSoftAPI.imagesAPI.RandomImage("pepe");

            LogObject(image);

            Assert.AreNotEqual(404, image.Code);
            Assert.IsFalse(image.Nsfw);
            Assert.IsNotNull(image.Url);
            Assert.IsNotNull(image.Snowflake);
            Assert.IsNotNull(image.Tag);
        }

        [TestMethod]
        public async Task TestTags() {
            KSoftTags tags = await kSoftAPI.imagesAPI.Tags();

            LogObject(tags);

            Assert.IsNotNull(tags.Models);
            Assert.IsNotNull(tags.NsfwTags);
            Assert.IsNotNull(tags.Tags);
        }

        [TestMethod]
        public async Task TestTagSearch() {
            KSoftTags tags = await kSoftAPI.imagesAPI.TagSearch("birb");

            LogObject(tags);

            Assert.IsNotNull(tags.Models);
            Assert.IsNotNull(tags.Tags);
        }

        [TestMethod]
        public async Task TestImageFromSnowflake() {
            KSoftImage image = await kSoftAPI.imagesAPI.ImageFromSnowflake("i-7n36tlpw-30");

            LogObject(image);

            Assert.IsNotNull(image.Tag);
            Assert.AreEqual("i-7n36tlpw-30", image.Snowflake);
            Assert.IsNotNull(image.Nsfw);
            Assert.IsNotNull(image.Url);
        }

        [TestMethod]
        public async Task TestRandomMeme() {
            KSoftRedditPost meme = await kSoftAPI.imagesAPI.RandomMeme();

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
            KSoftWikiHowPost wh = await kSoftAPI.imagesAPI.RandomWikiHow();

            LogObject(wh);

            Assert.IsNotNull(wh.Url);
            Assert.IsNotNull(wh.ArticleUrl);
            Assert.IsFalse(wh.Nsfw);
            Assert.IsNotNull(wh.Title);
        }

        [TestMethod]
        public async Task TestRandomAww() {
            KSoftRedditPost aww = await kSoftAPI.imagesAPI.RandomAww();

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
            KSoftRedditPost nsfw = await kSoftAPI.imagesAPI.RandomNsfw(false);

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
            KSoftRedditPost aww = await kSoftAPI.imagesAPI.RandomReddit("pics", true, "day");

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
        public async Task TestGeoIP() {
            KSoftGeoIP geoip = await kSoftAPI.kumoAPI.GeoIP("8.8.8.8");

            LogObject(geoip);

            Assert.IsFalse(geoip.Error);
            Assert.IsNotNull(geoip.Data);
            Assert.AreEqual(200, geoip.Code);
        }

        [TestMethod]
        public async Task TestCurrencyConversion() {
            KSoftCurrency currency = await kSoftAPI.kumoAPI.CurrencyConversion("USD", "CAD", 100);

            LogObject(currency);

            Assert.IsFalse(currency.Error);
            Assert.AreEqual(127.371, currency.Value);
            Assert.AreEqual("127.37 CAD", currency.Pretty);
        }


        [TestMethod]
        public async Task TestSearchLyrics() {
            KSoftLyrics lyrics = await kSoftAPI.musicAPI.SearchLyrics("Is this the real life? Is this just fantasy?", true, 1);

            LogObject(lyrics);

            Assert.IsNotNull(lyrics.Total);
            Assert.IsNotNull(lyrics.Data);
            Assert.IsNotNull(lyrics.Took);
        }

        [TestMethod]
        public async Task TestArtistByID() {
            KSoftArtistInfo artist = await kSoftAPI.musicAPI.ArtistByID(28333);

            LogObject(artist);

            Assert.IsFalse(artist.Error);
            Assert.AreEqual(28333, artist.Id);
            Assert.IsNotNull(artist.Name);
            Assert.IsNotNull(artist.Tracks);
            Assert.IsNotNull(artist.Albums);
            Assert.IsNotNull(artist.Uri);
        }

        [TestMethod]
        public async Task TestAlbumByID() {
            KSoftAlbumInfo album = await kSoftAPI.musicAPI.AlbumByID(88287);

            LogObject(album);

            Assert.IsFalse(album.Error);
            Assert.AreEqual(28333, album.Id);
            Assert.IsNotNull(album.Name);
            Assert.IsNotNull(album.Tracks);
            Assert.IsNotNull(album.Artist);
            Assert.IsNotNull(album.Uri);
            Assert.IsNotNull(album.Year);
        }

        [TestMethod]
        public async Task TestTrackByID() {
            KSoftTrackInfo track = await kSoftAPI.musicAPI.TrackByID(628942);

            LogObject(track);

            Assert.AreEqual(628942, track.Id);
            Assert.IsNotNull(track.Name);
            Assert.IsNotNull(track.Artist);
            Assert.IsNotNull(track.Albums);
            Assert.IsNotNull(track.Lyrics);
            Assert.IsNotNull(track.Singalong);
            Assert.IsNotNull(track.Meta);
            Assert.IsNotNull(track.Url);
            Assert.IsNotNull(track.Uri);
            Assert.IsNotNull(track.Popularity);
        }


        [TestMethod]
        public async Task TestBanInfo() {
            KSoftBanInfo banInfo = await kSoftAPI.bansAPI.BanInfo("766186017979760681");

            LogObject(banInfo);

            Assert.IsFalse(banInfo.Error);
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
            KSoftBanCheck banCheck = await kSoftAPI.bansAPI.BanCheck("69");

            LogObject(banCheck);

            Assert.IsFalse(banCheck.IsBanned);
        }

        [TestMethod]
        public async Task TestBanCheck2() {
            KSoftBanCheck banCheck = await kSoftAPI.bansAPI.BanCheck("766186017979760681");

            LogObject(banCheck);

            Assert.IsTrue(banCheck.IsBanned);
        }

        [TestMethod]
        public async Task TestBanList() {
            KSoftBanList banList = await kSoftAPI.bansAPI.BanList(1, 2);

            LogObject(banList);

            Assert.IsFalse(banList.Error);
            Assert.AreEqual(1, banList.Page);
            Assert.AreEqual(2, banList.PerPage);
            Assert.IsNull(banList.PreviousPage);
            Assert.IsNotNull(banList.BanCount);
            Assert.IsNotNull(banList.PageCount);
            Assert.AreEqual(2, banList.OnPage);
            Assert.IsNotNull(banList.Data);
        }

        [TestMethod]
        public async Task TestBanUpdates() {

            DateTime time = DateTime.Now - TimeSpan.FromDays(10);
            KSoftBanUpdates banUpdates = await kSoftAPI.bansAPI.BanUpdates(time);

            LogObject(banUpdates);

            Assert.IsNotNull(banUpdates.CurrentTimestamp);
            Assert.IsNotNull(banUpdates.Data);
        }



    }
}
