using X.Web.RSS.Structure.Validators;
using Xunit;

namespace X.Web.RSS.Tests.Validators;

public class RssEmailTest
{
    [Fact]
    public void Ctor_ValidEmailParameter_Ok()
    {
        // Arrange
        const string Email = "valid@mail.ru";

        // Action
        RssEmail rssEmail = new RssEmail(Email);

        // Assert
        Assert.Equal(Email, rssEmail.Email);
    }
        
    [Fact]
    public void SetEmail_ValidDateParameter_Ok()
    {
        // Arrange
        RssEmail rssEmail = new RssEmail();
        const string Email = "valid@mail.ru";

        // Action
        rssEmail.Email = Email;

        // Assert
        Assert.Equal(Email, rssEmail.Email);
    }

    [Fact]
    public void SetString_Null_StringNull()
    {
        // Arrange
        RssEmail rssEmail = new RssEmail();

        // Action
        rssEmail.Email = null;

        // Assert
        Assert.Equal(null, rssEmail.Email);
    }
}