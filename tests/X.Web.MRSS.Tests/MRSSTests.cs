using Xunit;

namespace X.Web.MRSS.Tests;

public class MRSSTests
{
    [Fact]
    public void LoadMRSS_Ok()
    {
        var xml = GetFullRss();

        var serializer = new MediaRssDocumentSerializer();

        var rss = serializer.Deserialize(xml);

        Assert.NotNull(rss);

        Assert.Equal(rss.Channel.Description, rss.Channel.Description);
    }

    // [Fact]
    // public void WriteRead_LargeObject_Ok()
    // {        
    //     var rss = GetFullRss();
    //
    //     var serializer = new RssDocumentSerializer();
    //
    //     var xml = serializer.Serialize(rss);
    //
    //     var newRss = serializer.Deserialize(xml);
    //
    //     Assert.NotNull(newRss);
    //     
    //     Assert.Equal(rss.Channel.Description, newRss.Channel.Description);
    // }

    // [Fact]
    // public void Read_External_Ok()
    // {
    //     var serializer = new RssDocumentSerializer();
    //     
    //     var xml = GetPartRssText();
    //
    //     var rss = serializer.Deserialize(xml);
    //     Assert.Equal("channel title", rss.Channel.Title);
    //     Assert.Equal("long description", rss.Channel.Description);
    // }
    //
    // [Fact]
    // public async Task Test()
    // {
    //     var serializer = new RssDocumentSerializer();
    //     
    //     var request = WebRequest.Create("https://feeds.bbci.co.uk/news/world/rss.xml");
    //     var response = await request.GetResponseAsync();
    //     var stream = response.GetResponseStream();
    //     var streamReader = new StreamReader(stream);
    //     var xml = await streamReader.ReadToEndAsync();
    //
    //     var rss = serializer.Deserialize(xml);
    //
    //     Assert.Equal("BBC News", rss.Channel.Title);
    //     Assert.Equal("BBC News - World", rss.Channel.Description);
    // }
    //
    // private static RssDocument GetFullRss()
    // {
    //     return new RssDocument
    //     {
    //         Channel =
    //             new RssChannel
    //             {
    //                 AtomLink = new RssLink("http://atomlink.com") { Rel = Rel.self, Type = "text/plain" },
    //                 Category = "category",
    //                 Cloud =
    //                     new RssCloud
    //                     {
    //                         Domain = "domain",
    //                         Path = "path",
    //                         Port = 1234,
    //                         Protocol = Protocol.xmlrpc,
    //                         RegisterProcedure = "registerProcedure"
    //                     },
    //                 Copyright = "copyrignt (c)",
    //                 Description = "long description",
    //                 Image =
    //                     new RssImage
    //                     {
    //                         Description = "Image Description",
    //                         Height = 100,
    //                         Width = 100,
    //                         Link = new RssUrl("http://image.link.url.com"),
    //                         Title = "title",
    //                         Url = new RssUrl("http://image.url.com")
    //                     },
    //                 Language = new CultureInfo("en"),
    //                 LastBuildDate = new DateTime(2011, 7, 17, 15, 55, 41),
    //                 Link = new RssUrl("http://channel.url.com"),
    //                 ManagingEditor = new RssPerson("Manager", "managingEditor@mail.com"),
    //                 PubDate = new DateTime(2011, 7, 17, 15, 55, 41),
    //                 Rating = "rating",
    //                 SkipDays = new List<Day> { Day.Thursday, Day.Wednesday },
    //                 SkipHours = new List<Hour> { new Hour(22), new Hour(15), new Hour(4) },
    //                 TextInput =
    //                     new RssTextInput
    //                     {
    //                         Description = "text input desctiption",
    //                         Link = new RssUrl("http://text.input.link.com"),
    //                         Name = "text input name",
    //                         Title = "text input title"
    //                     },
    //                 Title = "channel title",
    //                 TTL = 10,
    //                 WebMaster = new RssPerson("webmaster", "webmaster@mail.ru"),
    //                 Items =
    //                     new List<RssItem>
    //                     {
    //                         new RssItem
    //                         {
    //                             Author = new RssEmail("item.author@mail.ru (author)"),
    //                             Category =
    //                                 new RssCategory
    //                                 {
    //                                     Domain = "category domain value", 
    //                                     Text = "category text value"
    //                                 },
    //                             Comments = new RssUrl("http://rss.item.comment.url.com"),
    //                             Description = "item description",
    //                             Enclosure =
    //                                 new RssEnclosure
    //                                 {
    //                                     Length = 1234,
    //                                     Type = "text/plain",
    //                                     Url = new RssUrl("http://rss.item.enclosure.type.url.com")
    //                                 },
    //                             Link = new RssUrl("http://rss.item.link.url.com"),
    //                             PubDate = new DateTime(2011, 7, 17, 15, 55, 41),
    //                             Title = "item title",
    //                             Guid = new RssGuid { IsPermaLink = false, Value = "guid value" },
    //                             Source = new RssSource { Url = new RssUrl("http://rss.item.source.url.com") }
    //                         }
    //                     }
    //             }
    //     };
    // }

    private static string GetFullRss()
    {
        return
            @"<rss version=""2.0"" xmlns:media=""http://search.yahoo.com/mrss/""
  xmlns:georss=""http://www.georss.org/georss""
  xmlns:gml=""http://www.opengis.net/gml"">

  <channel>
    <title>Song Site</title>
    <description>Media RSS example with new fields added in v1.5.0</description>
    <item>
      <link>http://www.foo.com</link>
      <pubDate>Mon, 27 Aug 2001 16:08:56 PST</pubDate>
      <media:content url=""http://www.foo.com/video.mov"" fileSize=""2000"" bitrate=""128"" type=""video/quicktime"" expression=""full"" />
      <media:community>
        <media:starRating average=""3.5"" count=""20"" min=""1"" max=""10"" />
        <media:statistics views=""5"" favorites=""5"" />
        <media:tags>news: 5, abc:3</media:tags>
      </media:community>
      <media:comments>
        <media:comment>comment1</media:comment>
        <media:comment>comment2</media:comment>
      </media:comments>
      <media:embed url=""http://www.foo.com/player.swf"" width=""512"" height=""323"">
        <media:param name=""type"">application/x-shockwave-flash</media:param>
        <media:param name=""width"">512</media:param>
        <media:param name=""height"">323</media:param>
        <media:param name=""allowFullScreen"">true</media:param>
        <media:param name=""flashVars"">
          id=12345&amp;vid=678912i&amp;lang=en-us&amp;intl=us&amp;thumbUrl=http://www.foo.com/thumbnail.jpg
        </media:param>
      </media:embed>
      <media:responses>
        <media:response>http://www.response1.com</media:response>
        <media:response>http://www.response2.com</media:response>
      </media:responses>
      <media:backLinks>
        <media:backLink>http://www.backlink1.com</media:backLink>
        <media:backLink>http://www.backlink2.com</media:backLink>
      </media:backLinks>
      <media:status state=""active"" />
      <media:price type=""rent"" price=""19.99"" currency=""EUR"" />
      <media:license type=""text/html"" href=""http://www.licensehost.com/license""> Sample license for a video</media:license>
      <media:subTitle type=""application/smil"" lang=""en-us"" href=""http://www.foo.org/subtitle.smil"" />
      <media:peerLink type=""application/x-bittorrent "" href=""http://www.foo.org/sampleFile.torrent"" />
      <media:location description=""My house"" start=""00:01"" end=""01:00"">
        <georss:where>
          <gml:Point>
          <gml:pos>35.669998 139.770004</gml:pos>
          </gml:Point>
        </georss:where>
      </media:location>
      <media:restriction type=""sharing"" relationship=""deny"" />
      <media:scenes>
        <media:scene>
          <sceneTitle>sceneTitle1</sceneTitle>
          <sceneDescription>sceneDesc1</sceneDescription>
          <sceneStartTime>00:15</sceneStartTime>
          <sceneEndTime>00:45</sceneEndTime>
        </media:scene>
      </media:scenes>
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