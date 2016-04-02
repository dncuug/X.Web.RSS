namespace RSS.Test
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RSS.Enumerators;
    using RSS.Structure;
    using RSS.Structure.Validators;

    #endregion

    [TestClass]
    public class RSSHelperTest
    {
        #region Public Methods

        [TestMethod]
        public void GetRSS_AllData_ValidRssXml()
        {
            MemoryStream ms = new MemoryStream();
            Rss rss = GetFullRSS();

            RSSHelper.WriteRSS(rss, ms);

            var result = Encoding.UTF8.GetString(ms.GetBuffer()).Trim('\0');
            Assert.AreEqual(GetFullRSSText(), result);
        }

        [TestMethod]
        public void WriteRead_LargeObject_Ok()
        {
            MemoryStream ms = new MemoryStream();
            Rss rss = GetFullRSS();

            RSSHelper.WriteRSS(rss, ms);
            ms.Position = 0;
            Rss newRss = RSSHelper.ReadRSS(ms);

            Assert.AreEqual(rss.Channel.Description, newRss.Channel.Description);
        }

        [TestMethod]
        public void Read_External_Ok()
        {
            MemoryStream ms = new MemoryStream();
            var array = Encoding.UTF8.GetBytes(GetPartRSSText());
            ms.Write(array, 0, array.Length);
            ms.Position = 0;

            Rss rss = RSSHelper.ReadRSS(ms);
            Assert.AreEqual("channel title", rss.Channel.Title);
            Assert.AreEqual("long description", rss.Channel.Description);
        }

        /*
                [TestMethod]
                public void Test()
                {
                    var request = WebRequest.Create("http://bash.org.ru/rss/");
                    var response = request.GetResponse();
                    var stream = response.GetResponseStream();

                    Rss rss = RSSHelper.ReadRSS(stream);

                    Assert.AreEqual("Bash.Org.Ru", rss.Channel.Title);
                    Assert.AreEqual("Цитатник Рунета", rss.Channel.Description);
                }
        */

        private static Rss GetFullRSS()
        {
            return new Rss
            {
                Channel =
                    new RssChannel
                    {
                        AtomLink =
                            new RssLink { Href = new RssUrl("http://atomlink.com"), Rel = Rel.Self, Type = "text/plain" },
                        Category = "category",
                        Cloud =
                            new RssCloud
                            {
                                Domain = "domain",
                                Path = "path",
                                Port = 1234,
                                Protocol = Protocol.XmlRpc,
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
                        ManagingEditor = new RssEmail("managingEditor@mail.com (manager)"),
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
                        WebMaster = new RssEmail("webmaster@mail.ru (webmaster)"),
                        Item =
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
                                    Guid = new RssGuid {IsPermaLink = false, Value = "guid value"},
                                    Source = new RssSource {Url = new RssUrl("http://rss.item.source.url.com")}
                                }
                            }
                    }
            };
        }

        private static string GetFullRSSText()
        {
            return
@"<?xml version=""1.0""?>
<rss xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:content=""http://purl.org/rss/1.0/modules/content/"" xmlns:atom=""http://www.w3.org/2005/Atom"" version=""2.0"">
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

        private static string GetPartRSSText()
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

        #endregion
    }
}