using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using RSS;
using RSS.Enumerators;
using RSS.Structure;
using RSS.Structure.Validators;

namespace Demo
{
    public partial class RssPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/xml"; // 输出并按xml格式显示
            MemoryStream ms = new MemoryStream();
            Rss rss = GetFullRSS();
            RSSHelper.WriteRSS(rss, ms);
            var result = Encoding.UTF8.GetString(ms.GetBuffer()).Trim('\0');
            Response.Write(result);
        }

        private static Rss GetFullRSS()
        {
            return new Rss
            {
                Channel =
                    new RssChannel
                    {
                        AtomLink =
                            new RssLink {Href = new RssUrl("http://atomlink.com"), Rel = Rel.self, Type = "text/plain"},
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
                        SkipDays = new List<Day> {Day.Thursday, Day.Wednesday},
                        SkipHours = new List<Hour> {new Hour(22), new Hour(15), new Hour(4)},
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
    }
}