using System;
using X.Web.RSS.Structure;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssDateIsoTests
{
    [Fact]
    public void DateStringISO8601_WhenDateIsNull_ReturnsEmptyString()
    {
        var rssDate = new RssDate();
        Assert.True(string.IsNullOrEmpty(rssDate.DateStringISO8601));
    }

    [Fact]
    public void DateStringISO8601_FormatIncludesDate_WhenDateSet()
    {
        var date = new DateTime(2021, 12, 31, 23, 59, 59);
        var rssDate = new RssDate(date);

        var iso = rssDate.DateStringISO8601;

        Assert.Contains("2021-12-31T23:59:59", iso);
        // implementation uses a dot before 'Z' in format string, assert presence of dot
        Assert.Contains(".", iso);
    }
}
