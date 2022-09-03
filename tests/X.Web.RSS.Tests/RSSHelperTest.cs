using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using X.Web.RSS.Enumerators;
using X.Web.RSS.Structure;
using X.Web.RSS.Structure.Validators;
using Xunit;

namespace X.Web.RSS.Tests;

public class RSSHelperTest
{
    [Fact]
    public void WriteRead_LargeObject_Ok()
    {
        var ms = new MemoryStream();
        var rss = GetFullRss();

        RssDocument.WriteRSS(rss, ms);
        ms.Position = 0;
        var newRss = RssDocument.Load(ms);

        Assert.Equal(rss.Channel.Description, newRss.Channel.Description);
    }

    [Fact]
    public void Read_External_Ok()
    {
        var ms = new MemoryStream();
        var array = Encoding.UTF8.GetBytes(GetPartRssText());
        ms.Write(array, 0, array.Length);
        ms.Position = 0;

        var rss = RssDocument.Load(ms);
        Assert.Equal("channel title", rss.Channel.Title);
        Assert.Equal("long description", rss.Channel.Description);
    }

    [Fact]
    public void Test()
    {
        var request = WebRequest.Create("https://news.microsoft.com/feed/");
        var response = request.GetResponse();
        var stream = response.GetResponseStream();

        var rss = RssDocument.Load(stream);

        Assert.Equal("Stories", rss.Channel.Title);
        Assert.Equal("Microsoft news, features, events, and press materials", rss.Channel.Description);
    }
    
    private static RssDocument GetFullRss()
    {
        return new RssDocument
        {
            Channel =
                new RssChannel
                {
                    AtomLink = new RssLink("http://atomlink.com") { Rel = Rel.self, Type = "text/plain" },
                    Category = "category",
                    Cloud =
                        new RssCloud
                        {
                            Domain = "domain",
                            Path = "path",
                            Port = 1234,
                            Protocol = Protocol.xmlrpc,
                            RegisterProcedure = "registerProcedure"
                        },
                    Copyright = "copyrignt (c)",
                    Description = "long description",
                    Image =
                        new RssImage
                        {
                            Description = "Image Description",
                            Height = 100,
                            Width = 100,
                            Link = new RssUrl("http://image.link.url.com"),
                            Title = "title",
                            Url = new RssUrl("http://image.url.com")
                        },
                    Language = new CultureInfo("en"),
                    LastBuildDate = new DateTime(2011, 7, 17, 15, 55, 41),
                    Link = new RssUrl("http://channel.url.com"),
                    ManagingEditor = new RssPerson("Manager", "managingEditor@mail.com"),
                    PubDate = new DateTime(2011, 7, 17, 15, 55, 41),
                    Rating = "rating",
                    SkipDays = new List<Day> { Day.Thursday, Day.Wednesday },
                    SkipHours = new List<Hour> { new Hour(22), new Hour(15), new Hour(4) },
                    TextInput =
                        new RssTextInput
                        {
                            Description = "text input desctiption",
                            Link = new RssUrl("http://text.input.link.com"),
                            Name = "text input name",
                            Title = "text input title"
                        },
                    Title = "channel title",
                    TTL = 10,
                    WebMaster = new RssPerson("webmaster", "webmaster@mail.ru"),
                    Items =
                        new List<RssItem>
                        {
                            new RssItem
                            {
                                Author = new RssEmail("item.author@mail.ru (author)"),
                                Category =
                                    new RssCategory
                                    {
                                        Domain = "category domain value", 
                                        Text = "category text value"
                                    },
                                Comments = new RssUrl("http://rss.item.comment.url.com"),
                                Description = "item description",
                                Enclosure =
                                    new RssEnclosure
                                    {
                                        Length = 1234,
                                        Type = "text/plain",
                                        Url = new RssUrl("http://rss.item.enclosure.type.url.com")
                                    },
                                Link = new RssUrl("http://rss.item.link.url.com"),
                                PubDate = new DateTime(2011, 7, 17, 15, 55, 41),
                                Title = "item title",
                                Guid = new RssGuid { IsPermaLink = false, Value = "guid value" },
                                Source = new RssSource { Url = new RssUrl("http://rss.item.source.url.com") }
                            }
                        }
                }
        };
    }

    private static string GetFullRssText()
    {
        return
            @"<?xml version=""1.0""?>
<rss xmlns:content=""http://purl.org/rss/1.0/modules/content/"" xmlns:atom=""http://www.w3.org/2005/Atom"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" version=""2.0"">
  <channel>
    <atom:link rel=""self"" type=""text/plain"" href=""http://atomlink.com/"" />
    <category>category</category>
    <cloud domain=""domain"" path=""path"" port=""1234"" protocol=""xmlrpc"" registerProcedure=""registerProcedure"" />
    <copyright>copyrignt (c)</copyright>
    <description>long description</description>
    <docs>http://www.rssboard.org/rss-specification</docs>
    <generator>ApmeM RSS Generator</generator>
    <image>
      <description>Image Description</description>
      <height>100</height>
      <link>http://image.link.url.com/</link>
      <title>title</title>
      <url>http://image.url.com/</url>
      <width>100</width>
    </image>
    <language>en</language>
    <lastBuildDate>Sun, 17 Jul 2011 15:55:41 GMT</lastBuildDate>
    <pubDate>Sun, 17 Jul 2011 15:55:41 GMT</pubDate>
    <ttl>10</ttl>
    <link>http://channel.url.com/</link>
    <managingEditor>managingEditor@mail.com (manager)</managingEditor>
    <rating>rating</rating>
    <skipDays>
      <day>Thursday</day>
      <day>Wednesday</day>
    </skipDays>
    <skipHours>
      <hour>22</hour>
      <hour>15</hour>
      <hour>4</hour>
    </skipHours>
    <textInput>
      <description>text input desctiption</description>
      <link>http://text.input.link.com/</link>
      <name>text input name</name>
      <title>text input title</title>
    </textInput>
    <title>channel title</title>
    <webMaster>webmaster@mail.ru (webmaster)</webMaster>
    <item>
      <author>item.author@mail.ru (author)</author>
      <category domain=""category domain value"">category text value</category>
      <comments>http://rss.item.comment.url.com/</comments>
      <description>item description</description>
      <enclosure length=""1234"" type=""text/plain"" url=""http://rss.item.enclosure.type.url.com/"" />
      <guid isPermaLink=""false"">guid value</guid>
      <link>http://rss.item.link.url.com/</link>
      <source url=""http://rss.item.source.url.com/"" />
      <title>item title</title>
      <pubDate>Sun, 17 Jul 2011 15:55:41 GMT</pubDate>
    </item>
  </channel>
</rss>";
    }

    private static string GetPartRssText()
    {
        return
            @"<?xml version=""1.0""?>
<rss version=""2.0"">
  <channel>
    <title>channel title</title>
    <link>http://channel.url.com/</link>
    <description>long description</description>
    <language>en</language>
    <managingEditor>managingEditor@mail.com (manager)</managingEditor>
    <generator>ApmeM RSS Generator</generator>
    <pubDate>Sun, 17 Jul 2011 15:55:41 GMT</pubDate>
    <lastBuildDate>Sun, 17 Jul 2011 15:55:41 GMT</lastBuildDate>
  </channel>
</rss>";
    }
}