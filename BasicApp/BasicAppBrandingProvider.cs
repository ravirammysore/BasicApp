using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BasicApp;

[Dependency(ReplaceServices = true)]
public class BasicAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BasicApp";
}
