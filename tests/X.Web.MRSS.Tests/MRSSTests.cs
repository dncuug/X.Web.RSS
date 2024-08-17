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