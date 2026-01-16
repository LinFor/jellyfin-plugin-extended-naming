using Emby.Naming.Common;

namespace Jellyfin.Plugin.ExtendedNaming;

public static class CustomExpressions
{
    public static EpisodeExpression[] ExtendedExpressions { get; } = new EpisodeExpression[]
    {
        // Usenet: year then season number
        new EpisodeExpression(@"(?<seriesname>[\w\.\ ]+?)\.(?<year>[1-2]\d{3})\.[Ss](?<seasonnumber>\d{1,2})\..*[\\\/](\k<seriesname>\.)?(\k<year>\.)?([Ss]\k<seasonnumber>)?([Ee]?(?<epnumber>(\d{1,3}|[3-90]\d{3})))\.(\k<seriesname>\.)?(\k<year>\.)?([Ss]\k<seasonnumber>\.)?((?<epname>[\w\.\ ]+)\.)?(\k<year>\.)?.*$")
        {
            IsNamed = true
        },

        // Usenet: Season number then year
        new EpisodeExpression(@"(?<seriesname>[\w\.\ ]+?)\.[Ss](?<seasonnumber>\d{1,2})\.(?<year>[1-2]\d{3})\..*[\\\/](\k<seriesname>\.)?([Ss]\k<seasonnumber>\.)?(\k<year>\.)?([Ss]\k<seasonnumber>)?([Ee]?(?<epnumber>(\d{1,3}|[3-90]\d{3})))\.(\k<seriesname>\.)?([Ss]\k<seasonnumber>\.)?(\k<year>\.)?((?<epname>[\w\.\ ]+)\.)?(\k<year>\.)?.*$")
        {
            IsNamed = true
        },

        // Usenet: Season number only
        new EpisodeExpression(@"(?<seriesname>[\w\.\ ]+?)\.[Ss](?<seasonnumber>\d{1,2})\..*[\\\/](\k<seriesname>\.)?([Ss]\k<seasonnumber>\.?)?([Ee]?(?<epnumber>(\d{1,3}|[3-90]\d{3})))\.(\k<seriesname>\.)?([Ss]\k<seasonnumber>\.)?((?<epname>[\w\.\ ]+)\.)??.*$")
        {
            IsNamed = true
        },

        // Usenet: Year only
        new EpisodeExpression(@"(?<seriesname>[\w\.\ ]+?)\.(?<year>[1-2]\d{3})\..*[\\\/](\k<seriesname>\.)?(\k<year>\.)?([Ee]?(?<epnumber>(\d{1,3}|[3-90]\d{3})))\.(\k<seriesname>\.)?(\k<year>\.)?((?<epname>[\w\.\ ]+)\.)?(\k<year>\.)?.*$")
        {
            IsNamed = true
        }
    };

    public static void Patch(NamingOptions namingOptions)
    {
        var original = namingOptions.EpisodeExpressions;
        namingOptions.EpisodeExpressions = ExtendedExpressions.Concat(original).ToArray();
    }
}
