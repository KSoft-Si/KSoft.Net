# KSoft.Net

A wrapper for the KSoft API written in C#

***

Currently, the Images API is completed, the bans and lyrics api are next though

***

Table of contents
=================

   * [KSoft.Net](#ksoft-net)
   * [Table of contents](#table-of-contents)
   * [Usage](#usage)
      * [GetRandomImage()](#getrandomimage-)
      * [GetTags()](#gettags-)
      * [SearchTags()](#searchtags-)
      * [GetImageFromSnowflake()](#getimagefromsnowflake-)
      * [GetRandomMeme()](#getrandommeme-)
      * [GetRandomWikihow()](#getrandomwikihow-)
      * [GetRandomAww()](#getrandomaww-)
      * [GetRandomSubredditImage()](#getrandomsubredditimage-)

***

# Usage

## GetRandomImage( )

Gets a random image based on optional tag

| Parameter | Description | Default |
| --------- | ----------- | ------- |
| `tag` | Optional: Used to specify tag to search image | `null` |
| `nsfw` | Optional: Enables or disables NSFW content | `false` |

Returns a `KSoftImage` object

| Type | Name |
| ---- | ---- |
| `string` | Url |
| `string` | Snowflake |
| `bool` | Nsfw |
| `string` | Tag |

***

## GetTags( )

Gets list of all tags.

***

Returns a `KSoftTags` object

| Type | Name |
| ---- | ---- |
| `IList<Model>` | Models |
| `IList<string>` | Tags |
| `IList<string>` | Nsfw_tags |

`Model` type

| Type | Name |
| ---- | ---- |
| `string` | Name |
| `bool` | Nsfw |

***

## SearchTags( )

Searches for a tag

| Parameter | Description | Default |
| --------- | ----------- | ------- |
| `tag` | Required: Search query | `null` |

Returns a `KSoftTags` object

| Type | Name |
| ---- | ---- |
| `IList<Model>` | Models |
| `IList<string>` | Tags |
| `IList<string>` | Nsfw_tags |

`Model` type

| Type | Name |
| ---- | ---- |
| `string` | Name |
| `bool` | Nsfw |

***

## GetImageFromSnowflake( )

Gets list of comments on a post

| Parameter | Description | Default |
| --------- | ----------- | ------- |
| `snowflake` | Required: Search query | `null` |

Returns a `KSoftImage` object

| Type | Name |
| ---- | ---- |
| `string` | Url |
| `string` | Snowflake |
| `bool` | Nsfw |
| `string` | Tag |

***

## GetRandomMeme( )

Gets a random meme

Returns a `KSoftRedditPost` object

| Type | Name |
| ---- | ---- |
| `string` | Title |
| `string` | ImageUrl |
| `string` | Source |
| `string` | Subreddit |
| `float` | Upvotes |
| `float` | Downvotes |
| `float` | Comments |
| `float` | CreatedAt |
| `bool` | Nsfw |
| `string` | Author |

***

## GetRandomWikihow

Gets a random wikihow article

Returns a `KSoftWikihow` object

| Type | Name |
| ---- | ---- |
| `string` | Url |
| `string` | Title |
| `bool` | Nsfw |
| `string` | ArticleUrl |

***

## GetRandomAww( )

Gets a random aww image

Returns a `KSoftRedditPost` object

| Type | Name |
| ---- | ---- |
| `string` | Title |
| `string` | ImageUrl |
| `string` | Source |
| `string` | Subreddit |
| `float` | Upvotes |
| `float` | Downvotes |
| `float` | Comments |
| `float` | CreatedAt |
| `bool` | Nsfw |
| `string` | Author |

***

## GetRandomNsfw( )

Gets a random NSFW image

Returns a `KSoftRedditPost` object

| Type | Name |
| ---- | ---- |
| `string` | Title |
| `string` | ImageUrl |
| `string` | Source |
| `string` | Subreddit |
| `float` | Upvotes |
| `float` | Downvotes |
| `float` | Comments |
| `float` | CreatedAt |
| `bool` | Nsfw |
| `string` | Author |

***

## GetRandomSubredditImage

Gets a random reddit post

| Parameter | Description | Default |
| --------- | ----------- | ------- |
| `subreddit` | Optional: Subreddit to get post from | `all` |
| `span` | Optional: Timespan from which to get the post | `day` |

Returns a `KSoftRedditPost` object

| Type | Name |
| ---- | ---- |
| `string` | Title |
| `string` | ImageUrl |
| `string` | Source |
| `string` | Subreddit |
| `float` | Upvotes |
| `float` | Downvotes |
| `float` | Comments |
| `float` | CreatedAt |
| `bool` | Nsfw |
| `string` | Author |
