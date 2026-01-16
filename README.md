# Jellyfin Plugin Extended Naming

## Описание (Русский)

Этот плагин для Jellyfin расширяет возможности распознавания имён файлов эпизодов сериалов, добавляя поддержку форматов именования, которые часто используются в торрент-релизах.

Плагин добавляет дополнительные регулярные выражения в систему парсинга Jellyfin, позволяя корректно распознавать эпизоды с нестандартными именами файлов.

### Поддерживаемые форматы

Плагин добавляет поддержку следующих паттернов (на основе реальных торрент-релизов):

1. **Год + сезон**: `Shadow.and.Bone.2021.S01.WEB-DL.1080p-Kyle/Shadow.and.Bone.2021.S01E02.WEB-DL.1080p-Kyle.mkv`
2. **Сезон + год**: `Zhuki.S02.2021.WEB-DL.1080p/06.Zhuki.S02.2021.WEB-DL.1080p.mkv`
3. **Только сезон**: `Gde.logika.S07.WEB-DL.1080.25Kuzmich/Gde.logika.S07.E05.WEB-DL.1080.25Kuzmich.mkv`
4. **Только год**: `Zhuki.2019.WEB-DL.(1080p).Getty/Zhuki.e17.Film.o.seriale.2019.WEB-DL.(1080p).Getty.mkv`

### Установка

Администрирование - Панель - Расширенное - Плагины - вкладка Репозитории - добавить адрес https://raw.githubusercontent.com/LinFor/jellyfin-plugin-extended-naming/refs/heads/main/dist/manifest.json

После этого на вкладке Каталог найти "Extended Media Files Patterns" (раздел General) и установить.

### Сборка

```bash
dotnet build --configuration Release
```

### Тестирование

```bash
dotnet test
```

## Description (English)

This Jellyfin plugin extends episode file naming recognition capabilities by adding support for naming formats commonly used in torrent releases.

The plugin adds additional regular expressions to Jellyfin's parsing system, allowing correct recognition of episodes with non-standard file names.

### Supported Formats

The plugin adds support for the following patterns (based on real torrent releases):

1. **Year + Season**: `Shadow.and.Bone.2021.S01.WEB-DL.1080p-Kyle/Shadow.and.Bone.2021.S01E02.WEB-DL.1080p-Kyle.mkv`
2. **Season + Year**: `Zhuki.S02.2021.WEB-DL.1080p/06.Zhuki.S02.2021.WEB-DL.1080p.mkv`
3. **Season Only**: `Gde.logika.S07.WEB-DL.1080.25Kuzmich/Gde.logika.S07.E05.WEB-DL.1080.25Kuzmich.mkv`
4. **Year Only**: `Zhuki.2019.WEB-DL.(1080p).Getty/Zhuki.e17.Film.o.seriale.2019.WEB-DL.(1080p).Getty.mkv`

### Installation

Administration - Dashboard - Advanced - Plugins - Repositories tab - add the address https://raw.githubusercontent.com/LinFor/jellyfin-plugin-extended-naming/refs/heads/main/dist/manifest.json

Then go to the Catalog tab, find "Extended Media Files Patterns" (General section) and install it.

### Building

```bash
dotnet build --configuration Release
```

### Testing

```bash
dotnet test
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
