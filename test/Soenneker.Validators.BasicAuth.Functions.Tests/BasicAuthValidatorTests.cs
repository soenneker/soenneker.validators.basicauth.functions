using Soenneker.Validators.BasicAuth.Functions.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Validators.BasicAuth.Functions.Tests;

[Collection("Collection")]
public sealed class BasicAuthValidatorTests : FixturedUnitTest
{
    private readonly IBasicAuthValidator _validator;

    public BasicAuthValidatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _validator = Resolve<IBasicAuthValidator>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
