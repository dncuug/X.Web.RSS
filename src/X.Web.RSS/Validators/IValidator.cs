using JetBrains.Annotations;

namespace X.Web.RSS.Validators;

[PublicAPI]
public interface IValidator<in T>
{
    /// <summary>
    /// Validate value
    /// </summary>
    /// <param name="value"></param>
    void Validate(T value);
}