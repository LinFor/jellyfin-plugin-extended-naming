using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using Emby.Naming.Common;

namespace Jellyfin.Plugin.ExtendedNaming;

public class PluginConfiguration : BasePluginConfiguration
{
}

    public class Plugin : BasePlugin<PluginConfiguration>
    {
        private readonly NamingOptions _namingOptions;

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, NamingOptions namingOptions)
            : base(applicationPaths, xmlSerializer)
        {
            _namingOptions = namingOptions;
            CustomExpressions.Patch(_namingOptions);
        }

        public override string Name => "Extended Media Files Patterns";

        public override string Description => "Adds custom episode naming expressions for better parsing";

        public override Guid Id => Guid.Parse("a3df8fb9-836d-4e38-a16b-aea22f1fcba8");
    }
