# Simple RSS [English](README-EN.md)

## 简介

使用该库，可以很容易地创建简单的RSS订阅和阅读RSS源。

所有过程都基于XmlSerializer来完成的，可被用作如何使用XmlSerializer的一个例子 :)

## 例程

为了创建Rss，你需要填充`Rss`对象的几个必须属性，然后调用`RSSHelper.WriteRSS`方法获得你需要的任何Stream。

```
    MemoryStream ms = new MemoryStream();
    Rss rss = GetFullRSS();
    RSSHelper.WriteRSS(rss, ms);
    var result = Encoding.UTF8.GetString(ms.GetBuffer()).Trim('\0');
    Assert.AreEqual(GetFullRSSText(), result);
```

为了读取Rss，你需要获取包含rss的stream，然后调用`RSSHelper.ReadRSS`方法

```
    var request = WebRequest.Create("http://bash.org.ru/rss/");
    var response = request.GetResponse();
    var stream = response.GetResponseStream();
    Rss rss = RSSHelper.ReadRSS(stream);
    Assert.AreEqual("Bash.Org.Ru", rss.Channel.Title);
```

### RSS对象创建例程

完整的rss对象如下：

```
    return new Rss
            {
                Channel =
                    new RssChannel
                    {
                        AtomLink =
                            new RssLink { Href = new RssUrl("http://atomlink.com"), Rel = Rel.self, Type = "text/plain" },
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
```

## Features

Resulted rss are valid for w3c rss validator located at http://validator.w3.org/feed/

