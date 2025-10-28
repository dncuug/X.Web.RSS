using System;
using X.Web.RSS.Structure;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssUrlTest
{
    [Fact]
    public void Ctor_ValidUriParameter_Ok()
    {
        // Arrange
        var uri = new Uri("http://test.url.com");

        // Action
        var rssUrl = new RssUrl(uri);

        // Assert
        Assert.Equal(uri.ToString(), rssUrl.Url);
    }

    [Fact]
    public void SetUri_ValidUriParameter_Ok()
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
    public void Ctor_ValidStringParameter_Ok()
    {
        // Arrange
        String uri = new Uri("http://test.url.com").ToString();

        // Action
        RssUrl rssUrl = new RssUrl(uri);

        // Assert
        Assert.Equal(uri, rssUrl.Url);
    }

    [Fact]
    public void SetString_ValidStringParameter_Ok()
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
    public void SetUri_ConvertToString_String()
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
    public void SetString_ConvertToUri_Uri()
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
    public void SetString_Null_UriNull()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();

        // Action
        rssUrl.Url = null;

        // Assert
        Assert.Null(rssUrl.Url);
    }

    [Fact]
    public void SetUri_Null_StringNull()
    {
        // Arrange
        RssUrl rssUrl = new RssUrl();

        // Action
        rssUrl.Url = null;

        // Assert
        Assert.Null(rssUrl.Url);
    }

    [Fact]
    public void SetString_InvalidUriFormat_Error()
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
    public void Ctor_InvalidUriFormat_Error()
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