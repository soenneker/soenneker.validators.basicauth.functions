using Soenneker.Validators.BasicAuth.Functions.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Validators.BasicAuth.Functions.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BasicAuthValidatorTests : HostedUnitTest
{
    private readonly IBasicAuthValidator _validator;

    public BasicAuthValidatorTests(Host host) : base(host)
    {
        _validator = Resolve<IBasicAuthValidator>(true);
    }

    [Test]
    public void Default()
    {

    }
}
