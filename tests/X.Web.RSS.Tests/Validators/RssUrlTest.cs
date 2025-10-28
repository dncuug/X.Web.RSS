using System;
using X.Web.RSS.Structure;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssUrlTest
{
    [Fact]
    public void Constructor_WithUri_SetsUrlString()
    {
        // Arrange
        var uri = new Uri("http://test.url.com");

        // Action
        var rssUrl = new RssUrl(uri);

        // Assert
        Assert.Equal(uri.ToString(), rssUrl.Url);
    }

    [Fact]
    public void Setter_WithString_SetsUrlString()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();
        Uri uri = new Uri("http://test.url.com");

        // Action
        rssUrl.Url = uri.ToString();

        // Assert
        Assert.Equal(uri.ToString(), rssUrl.Url);
    }

    [Fact]
    public void Constructor_WithString_SetsUrl()
    {
        // Arrange
        String uri = new Uri("http://test.url.com").ToString();

        // Action
        RssUrl rssUrl = new RssUrl(uri);

        // Assert
        Assert.Equal(uri, rssUrl.Url);
    }

    [Fact]
    public void Setter_WithStringProperty_SetsUrl()
    {
        // Arrange
        var rssUrl = new RssUrl();
        String uri = new Uri("http://test.url.com").ToString();

        // Action
        rssUrl.Url = uri;

        // Assert
        Assert.Equal(uri, rssUrl.Url);
    }

    [Fact]
    public void SettingWithAbsoluteUriString_PreservesNormalizedString()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();
        Uri uri = new Uri("http://test.url.com");

        // Action
        rssUrl.Url = uri.AbsoluteUri;

        // Assert
        Assert.Equal(uri.ToString(), rssUrl.Url);
    }

    [Fact]
    public void SettingWithToStringUriString_PreservesAbsoluteUri()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();
        Uri uri = new Uri("http://test.url.com");

        // Action
        rssUrl.Url = uri.ToString();

        // Assert
        Assert.Equal(uri.AbsoluteUri, rssUrl.Url);
    }

    [Fact]
    public void SettingNullUrl_AllowsNull()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();

        // Action
        rssUrl.Url = null;

        // Assert
        Assert.Null(rssUrl.Url);
    }

    [Fact]
    public void SettingNullUrl_OnNewRssUrl_AllowsNull()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();

        // Action
        rssUrl.Url = null;

        // Assert
        Assert.Null(rssUrl.Url);
    }

    [Fact]
    public void SettingInvalidString_ThrowsUriFormatException()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();
        const string InvalidUri = "adsfsadf";

        // Action
        UriFormatException e = null;
        try
        {
            rssUrl.Url = InvalidUri;
        }
        catch (UriFormatException ex)
        {
            e = ex;
        }

        // Assert
        Assert.NotNull(e);
    }

    [Fact]
    public void Constructor_WithInvalidString_ThrowsUriFormatException()
    {
        // Arrange
        const string InvalidUri = "adsfsadf";

        // Action
        UriFormatException e = null;
        try
        {
            new RssUrl(InvalidUri);
        }
        catch (UriFormatException ex)
        {
            e = ex;
        }


        // Assert
        Assert.NotNull(e);
    }
}