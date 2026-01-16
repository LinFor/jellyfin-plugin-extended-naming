using Emby.Naming.TV;
using Xunit;

namespace Jellyfin.Plugin.ExtendedNaming.Tests
{
    public class MyEpisodeNumberTests
    {
        private readonly Emby.Naming.Common.NamingOptions _namingOptions;

        public MyEpisodeNumberTests()
        {
            _namingOptions = new Emby.Naming.Common.NamingOptions();
            Jellyfin.Plugin.ExtendedNaming.CustomExpressions.Patch(_namingOptions);
        }

        [Theory]
        // Usenet: year then season number
        [InlineData("Shadow.and.Bone.2021.S01.WEB-DL.1080p-Kyle/Shadow.and.Bone.2021.S01E02.WEB-DL.1080p-Kyle.mkv", 2)]

        // Usenet: Season number then year
        [InlineData("Zhuki.S02.2021.WEB-DL.1080p/06.Zhuki.S02.2021.WEB-DL.1080p.mkv", 6)]
        [InlineData("Atiye.s01.2019.L2.WEBRip1080p/Atiye.e04.2019.L2.WEBRip1080p.mp4", 4)]
        [InlineData("IP.Pirogova.S04.2021.WEB-DL.(1080p)/IP.Pirogova.s04e03.2021.WEB-DL.(1080p).mkv", 3)]
        [InlineData("Лимитчицы.S02.2025.WEB-DL 1080p.Files-x/05. Лимитчицы.S02.2025.WEB-DL 1080p.Files-x.mkv", 5)]

        // Usenet: Season number only
        [InlineData("Gde.logika.S07.WEB-DL.1080.25Kuzmich/Gde.logika.S07.E05.WEB-DL.1080.25Kuzmich.mkv", 5)]
        [InlineData("The.Girlfriend.Experience.S01.HDTV.1080p.FocusStudio/The.Girlfriend.Experience.S01E07.HDTV.1080p.FocusStudio.mkv", 7)]

        // Usenet: Year only
        [InlineData("Zhuki.2019.WEB-DL.(1080p).Getty/Zhuki.e17.Film.o.seriale.2019.WEB-DL.(1080p).Getty.mkv", 17)]
        [InlineData("Mediator.2021.WEB-DL.(1080p).Getty/Mediator.e04.2021.WEB-DL.(1080p).Getty.mkv", 4)]
        [InlineData("V.aktivnom.poiske.2021.WEB-DL.1080p/07.V.aktivnom.poiske.2021.WEB-DL.1080p.mkv", 7)]
        [InlineData("Chto.Gde.Kogda.Vesennjaja serija.Igr.2021.HDTV(1080i).25Kuzmich/04.Chto.Gde.Kogda.Vesennjaja serija.Igr.2021.HDTV(1080i).25Kuzmich.ts", 4)]
        [InlineData("MosGaz.2012.WEB-DL.(1080p).lunkin/MosGaz.07.serya.WEB-DL.(1080p).by.lunkin.mkv", 7)]
        public void Test_ParseEpisodeNumber_WithExtendedExpressions(string filename, int expectedEpisodeNumber)
        {
            var result = new EpisodePathParser(_namingOptions)
                .Parse(filename, false);

            Assert.Equal(expectedEpisodeNumber, result.EpisodeNumber);
        }
    }
}
