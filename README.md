
# KSoft.Net

## Contents

- [KSoftApi](#T-KSoft-Net-KSoftApi 'KSoft.Net.KSoftApi')
  - [KSoftAPI(accountToken)](#M-KSoft-Net-KSoftApi-#ctor-System-String- 'KSoft.Net.KSoftApi.#ctor(System.String)')
  - [AddBan(userID, reason, proof, mod, userName, userDiscriminator, appealPossible)](#M-KSoft-Net-KSoftApi-AddBan-System-Int64,System-String,System-String,System-Int64,System-String,System-String,System-Boolean- 'KSoft.Net.KSoftApi.AddBan(System.Int64,System.String,System.String,System.Int64,System.String,System.String,System.Boolean)')
  - [AdvancedWeather(latitude, longitude, reportType, units, language, icons)](#M-KSoft-Net-KSoftApi-AdvancedWeather-System-Single,System-Single,System-String,System-String,System-String,System-String- 'KSoft.Net.KSoftApi.AdvancedWeather(System.Single,System.Single,System.String,System.String,System.String,System.String)')
  - [AlbumByID(id)](#M-KSoft-Net-KSoftApi-AlbumByID-System-Int32- 'KSoft.Net.KSoftApi.AlbumByID(System.Int32)')
  - [ArtistByID(id)](#M-KSoft-Net-KSoftApi-ArtistByID-System-Int32- 'KSoft.Net.KSoftApi.ArtistByID(System.Int32)')
  - [BanCheck(userID)](#M-KSoft-Net-KSoftApi-BanCheck-System-Int64- 'KSoft.Net.KSoftApi.BanCheck(System.Int64)')
  - [BanInfo(userID)](#M-KSoft-Net-KSoftApi-BanInfo-System-Int64- 'KSoft.Net.KSoftApi.BanInfo(System.Int64)')
  - [BanList(page, perPage)](#M-KSoft-Net-KSoftApi-BanList-System-Int32,System-Int32- 'KSoft.Net.KSoftApi.BanList(System.Int32,System.Int32)')
  - [BanUpdates(timestamp)](#M-KSoft-Net-KSoftApi-BanUpdates-System-DateTimeOffset- 'KSoft.Net.KSoftApi.BanUpdates(System.DateTimeOffset)')
  - [BasicWeather(reportType, query, units, language, icons)](#M-KSoft-Net-KSoftApi-BasicWeather-System-String,System-String,System-String,System-String,System-String- 'KSoft.Net.KSoftApi.BasicWeather(System.String,System.String,System.String,System.String,System.String)')
  - [CurrencyConversion(from, to, value)](#M-KSoft-Net-KSoftApi-CurrencyConversion-System-String,System-String,System-Single- 'KSoft.Net.KSoftApi.CurrencyConversion(System.String,System.String,System.Single)')
  - [DeleteBan(userID,force)](#M-KSoft-Net-KSoftApi-DeleteBan-System-Int64,System-Boolean- 'KSoft.Net.KSoftApi.DeleteBan(System.Int64,System.Boolean)')
  - [Execute(request)](#M-KSoft-Net-KSoftApi-Execute-RestSharp-RestRequest- 'KSoft.Net.KSoftApi.Execute(RestSharp.RestRequest)')
  - [GeoIP(ip)](#M-KSoft-Net-KSoftApi-GeoIP-System-String- 'KSoft.Net.KSoftApi.GeoIP(System.String)')
  - [ImageFromSnowflake(snowflake)](#M-KSoft-Net-KSoftApi-ImageFromSnowflake-System-String- 'KSoft.Net.KSoftApi.ImageFromSnowflake(System.String)')
  - [RandomAww()](#M-KSoft-Net-KSoftApi-RandomAww 'KSoft.Net.KSoftApi.RandomAww')
  - [RandomImage(tag, nsfw)](#M-KSoft-Net-KSoftApi-RandomImage-System-String,System-Boolean- 'KSoft.Net.KSoftApi.RandomImage(System.String,System.Boolean)')
  - [RandomMeme()](#M-KSoft-Net-KSoftApi-RandomMeme 'KSoft.Net.KSoftApi.RandomMeme')
  - [RandomNsfw(gifs)](#M-KSoft-Net-KSoftApi-RandomNsfw-System-Boolean- 'KSoft.Net.KSoftApi.RandomNsfw(System.Boolean)')
  - [RandomReddit(subreddit, removeNsfw, span)](#M-KSoft-Net-KSoftApi-RandomReddit-System-String,System-Boolean,System-String- 'KSoft.Net.KSoftApi.RandomReddit(System.String,System.Boolean,System.String)')
  - [RandomWikiHow(nsfw)](#M-KSoft-Net-KSoftApi-RandomWikiHow-System-Boolean- 'KSoft.Net.KSoftApi.RandomWikiHow(System.Boolean)')
  - [SearchLocation(query, fast, more, mapZoom, includeMap)](#M-KSoft-Net-KSoftApi-SearchLocation-System-String,System-Boolean,System-Boolean,System-Int32,System-Boolean- 'KSoft.Net.KSoftApi.SearchLocation(System.String,System.Boolean,System.Boolean,System.Int32,System.Boolean)')
  - [SearchLyrics(query, textOnly, limit)](#M-KSoft-Net-KSoftApi-SearchLyrics-System-String,System-Boolean,System-Int32- 'KSoft.Net.KSoftApi.SearchLyrics(System.String,System.Boolean,System.Int32)')
  - [TagSearch(query)](#M-KSoft-Net-KSoftApi-TagSearch-System-String- 'KSoft.Net.KSoftApi.TagSearch(System.String)')
  - [Tags()](#M-KSoft-Net-KSoftApi-Tags 'KSoft.Net.KSoftApi.Tags')
  - [TrackByID(id)](#M-KSoft-Net-KSoftApi-TrackByID-System-Int32- 'KSoft.Net.KSoftApi.TrackByID(System.Int32)')

<a name='M-KSoft-Net-KSoftApi-#ctor-System-String-'></a>
### KSoftApi(accountToken) `class`

##### Summary

KSoft API class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| accountToken | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Token from your dashboard https://api.ksoft.si/dashboard |

<a name='M-KSoft-Net-KSoftApi-AddBan-System-Int64,System-String,System-String,System-Int64,System-String,System-String,System-Boolean-'></a>
### AddBan(userID, reason, proof, mod, userName, userDiscriminator, appealPossible) `method`

##### Summary

This endpoint allows you to add bans to the list. If you don't have BAN_MANAGER permission your ban will be automatically converted to a ban report and we will take a look and act accordingly.

##### Returns

KSoftBan

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userID | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Users Discord ID that you are banning/reporting |
| reason | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Reason why user should be globally banned |
| proof | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | URL of the image showing the act |
| mod | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Users Discord ID who posted/reported the ban |
| userName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Users Discord username |
| userDiscriminator | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Users Discord discriminator |
| appealPossible | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | If appeal should be disabled for that user. |

<a name='M-KSoft-Net-KSoftApi-AdvancedWeather-System-Single,System-Single,System-String,System-String,System-String,System-String-'></a>
### AdvancedWeather(latitude, longitude, reportType, units, language, icons) `method`

##### Summary

Gets weather by coordinates, this endpoint is faster than weather - easy, because it doesn't need to lookup the location.

##### Returns

KSoftWeather

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| latitude | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Latitude coordinate |
| longitude | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Longitude coordinate |
| reportType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Select weather type. Can be one of: "currently", "minutely", "hourly", "daily" |
| units | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: auto, select units, you can choose from: "si", "us", "uk2", "ca", "auto" |
| language | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs', 'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb', 'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw' |
| icons | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: original, select icon pack |

<a name='M-KSoft-Net-KSoftApi-AlbumByID-System-Int32-'></a>
### AlbumByID(id) `method`

##### Summary

Retrieves artist name and all tracks in the album.

##### Returns

KSoftAlbumInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Album ID, you can get it from the lyrics search |

<a name='M-KSoft-Net-KSoftApi-ArtistByID-System-Int32-'></a>
### ArtistByID(id) `method`

##### Summary

Retrieves all albums and songs by that artist.

##### Returns

KSoftArtistInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Artist ID, you can get it from the lyrics search |

<a name='M-KSoft-Net-KSoftApi-BanCheck-System-Int64-'></a>
### BanCheck(userID) `method`

##### Summary

Simple way to check if the user is banned

##### Returns

KSoftBanCheck

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userID | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Users Discord ID that you'd like to check |

<a name='M-KSoft-Net-KSoftApi-BanInfo-System-Int64-'></a>
### BanInfo(userID) `method`

##### Summary

Get more information about a ban

##### Returns

KSoftBanInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userID | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Users Discord ID who's ban you'd like to check |

<a name='M-KSoft-Net-KSoftApi-BanList-System-Int32,System-Int32-'></a>
### BanList(page, perPage) `method`

##### Summary

Pagination of bans, you can request up to 1000 records per page, default is 20.

##### Returns

KSoftBanList

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| page | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Page number (default: 1) |
| perPage | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of bans per page (default: 20) |

<a name='M-KSoft-Net-KSoftApi-BanUpdates-System-DateTimeOffset-'></a>
### BanUpdates(timestamp) `method`

##### Summary

Gets updates from the previous update

##### Returns

KSoftBanUpdates

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| timestamp | [System.DateTimeOffset](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTimeOffset 'System.DateTimeOffset') | Timestamp in seconds from 1.1.1970 (epoch time) |

<a name='M-KSoft-Net-KSoftApi-BasicWeather-System-String,System-String,System-String,System-String,System-String-'></a>
### BasicWeather(reportType, query, units, language, icons) `method`

##### Summary

Gets weather by location.

##### Returns

KSoftWeather

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reportType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Select weather report type. Can be one of: "currently", "minutely", "hourly", "daily" |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Location query |
| units | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: auto, select units, you can choose from: "si", "us", "uk2", "ca", "auto" |
| language | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: en, select language, all available languages: 'ar', 'az', 'be', 'bg', 'bs', 'ca', 'cs', 'da', 'de', 'el', 'en', 'es', 'et', 'fi', 'fr', 'he', 'hr', 'hu', 'id', 'is', 'it', 'ja', 'ka', 'ko', 'kw', 'nb', 'nl', 'no', 'pl', 'pt', 'ro', 'ru', 'sk', 'sl', 'sr', 'sv', 'tet', 'tr', 'uk', 'x-pig-latin', 'zh', 'zh-tw' |
| icons | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: original, select icon pack |

<a name='M-KSoft-Net-KSoftApi-CurrencyConversion-System-String,System-String,System-Single-'></a>
### CurrencyConversion(from, to, value) `method`

##### Summary

Currency conversion.

##### Returns

KSoftCurrency

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| from | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes |
| to | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | ISO Standard for 3 letter currency naming: https://en.wikipedia.org/wiki/ISO_4217#Active_codes |
| value | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Float or Integer you want to convert |

<a name='M-KSoft-Net-KSoftApi-DeleteBan-System-Int64,System-Boolean-'></a>
### DeleteBan(userID, force) `method`

##### Summary

Delete a ban, only users with BAN_MANAGER permission can use this.

##### Returns

KSoftBanDeletion

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| userID | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | Users Discord ID |
| force | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if true it deletes the entry from the database instead of deactivating |

<a name='M-KSoft-Net-KSoftApi-Execute-RestSharp-RestRequest-'></a>
### Execute(request) `method`

##### Summary

Method to execute requests

##### Returns

Type provided

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| request | [RestSharp.RestRequest](#T-RestSharp-RestRequest 'RestSharp.RestRequest') | Rest request to execute |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | Type to return |

<a name='M-KSoft-Net-KSoftApi-GeoIP-System-String-'></a>
### GeoIP(ip) `method`

##### Summary

Gets location data from the IP address.

##### Returns

KSoftGeoIP

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ip | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | IP address |

<a name='M-KSoft-Net-KSoftApi-ImageFromSnowflake-System-String-'></a>
### ImageFromSnowflake(snowflake) `method`

##### Summary

Retrieve image data.

##### Returns

KSoftImage

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| snowflake | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Image snowflake (unique ID) |

<a name='M-KSoft-Net-KSoftApi-RandomAww'></a>
### RandomAww() `method`

##### Summary

Get random cute pictures, mostly animals.

##### Returns

KSoftRedditPost

##### Parameters

This method has no parameters.

<a name='M-KSoft-Net-KSoftApi-RandomImage-System-String,System-Boolean-'></a>
### RandomImage(tag, nsfw) `method`

##### Summary

Gets random image from the specified tag.

##### Returns

KSoftImage

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tag | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: false, if to show nsfw content |
| nsfw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Name of the tag |

<a name='M-KSoft-Net-KSoftApi-RandomMeme'></a>
### RandomMeme() `method`

##### Summary

Retrieves a random meme from the cache. Source: reddit

##### Returns

KSoftRedditPost

##### Parameters

This method has no parameters.

<a name='M-KSoft-Net-KSoftApi-RandomNsfw-System-Boolean-'></a>
### RandomNsfw(gifs) `method`

##### Summary

Retrieves random NSFW pics. (real life stuff)

##### Returns

KSoftRedditPost

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gifs | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if to retrieve gifs instead of images |

<a name='M-KSoft-Net-KSoftApi-RandomReddit-System-String,System-Boolean,System-String-'></a>
### RandomReddit(subreddit, removeNsfw, span) `method`

##### Summary

Retrieve images from the specified subreddit.

##### Returns

KSoftRedditPost

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| subreddit | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Specified subreddit |
| removeNsfw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if set to true, endpoint will filter out nsfw posts. |
| span | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Default: "day", select range from which to get the images. Can be one of the following: "hour", "day", "week", "month", "year", "all" |

<a name='M-KSoft-Net-KSoftApi-RandomWikiHow-System-Boolean-'></a>
### RandomWikiHow(nsfw) `method`

##### Summary

Retrieves weird images from WikiHow

##### Returns

KSoftWikiHowPost

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| nsfw | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if to display nsfw content. |

<a name='M-KSoft-Net-KSoftApi-SearchLocation-System-String,System-Boolean,System-Boolean,System-Int32,System-Boolean-'></a>
### SearchLocation(query, fast, more, mapZoom, includeMap) `method`

##### Summary

You can get coordinates and more information about the searched location, if needed image of the area is generated.

##### Returns

KSoftLocation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Your location query |
| fast | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: fast, return location data faster, but with less information |
| more | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, return more than one location |
| mapZoom | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Default: 12, set your own zoom level, if fast is not set or false, then this setting will be ignored because map zoom is calculated |
| includeMap | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if to include an image of the area |

<a name='M-KSoft-Net-KSoftApi-SearchLyrics-System-String,System-Boolean,System-Int32-'></a>
### SearchLyrics(query,textOnly, limit) `method`

##### Summary

Searches for lyrics and returns a list of results.

##### Returns

KSoftLyrics

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Search query. |
| textOnly | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Default: false, if set to 'true' then it only searches inside the lyrcis. |
| limit | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Default: 10, how many results should the endpoint return. |

<a name='M-KSoft-Net-KSoftApi-TagSearch-System-String-'></a>
### TagSearch(query) `method`

##### Summary

Search for tags.

##### Returns

KSoftTags

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| query | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Search query |

<a name='M-KSoft-Net-KSoftApi-Tags'></a>
### Tags() `method`

##### Summary

Retrieve the list of all available tags.

##### Returns

KSoftTags

##### Parameters

This method has no parameters.

<a name='M-KSoft-Net-KSoftApi-TrackByID-System-Int32-'></a>
### TrackByID(id) `method`

##### Summary

Get info about a song.

##### Returns

KSoftTrackInfo

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Track ID, you can get it from artist by id, album by id or lyrics search endpoints |
