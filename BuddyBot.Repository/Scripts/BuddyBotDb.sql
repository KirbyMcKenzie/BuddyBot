IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Coordinate] (
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    CONSTRAINT [PK_Coordinate] PRIMARY KEY ([Latitude], [Longitude])
);

GO

CREATE TABLE [City] (
    [Id] int NOT NULL IDENTITY,
    [CoordinatesLatitude] float NULL,
    [CoordinatesLongitude] float NULL,
    [Country] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_City_Coordinate_CoordinatesLatitude_CoordinatesLongitude] FOREIGN KEY ([CoordinatesLatitude], [CoordinatesLongitude]) REFERENCES [Coordinate] ([Latitude], [Longitude]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_City_CoordinatesLatitude_CoordinatesLongitude] ON [City] ([CoordinatesLatitude], [CoordinatesLongitude]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180530090049_Init', N'2.1.1-rtm-30846');

GO

CREATE TABLE [WeatherConditionResponse] (
    [Id] int NOT NULL IDENTITY,
    [Condition] nvarchar(max) NULL,
    [Group] nvarchar(max) NULL,
    [MappedConditionResponse] nvarchar(max) NULL,
    CONSTRAINT [PK_WeatherConditionResponse] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180715051406_AddWeatherConditionResponse', N'2.1.1-rtm-30846');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Condition', N'Group', N'MappedConditionResponse') AND [object_id] = OBJECT_ID(N'[WeatherConditionResponse]'))
    SET IDENTITY_INSERT [WeatherConditionResponse] ON;
INSERT INTO [WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse])
VALUES (200, N'thunderstorm with light rain', N'Thunderstorm', N'thunderstorm with light rain'),
(601, N'snow', N'Snow', N'snow'),
(602, N'heavy snow', N'Snow', N'heavy snow'),
(611, N'sleet', N'Snow', N'sleet'),
(612, N'shower sleet', N'Snow', N'shower sleet'),
(615, N'light rain and snow', N'Snow', N'light rain and snow'),
(616, N'rain and snow', N'Snow', N'rain and snow'),
(620, N'light shower snow', N'Snow', N'light shower snow'),
(621, N'shower snow', N'Snow', N'shower snow'),
(622, N'heavy shower snow', N'Snow', N'heavy shower snow'),
(701, N'mist', N'Atmosphere', N'mist'),
(600, N'light snow', N'Snow', N'light snow'),
(711, N'smoke', N'Atmosphere', N'smoke'),
(731, N'sand, dust whirls', N'Atmosphere', N'sand, dust whirls'),
(741, N'fog', N'Atmosphere', N'fog'),
(751, N'sand', N'Atmosphere', N'sand'),
(761, N'dust', N'Atmosphere', N'dust'),
(762, N'volcanic ash', N'Atmosphere', N'volcanic ash'),
(771, N'squalls', N'Atmosphere', N'squalls'),
(781, N'tornado', N'Atmosphere', N'tornado'),
(800, N'clear sky', N'Clear', N'clear sky'),
(801, N'few clouds', N'Clouds', N'few clouds'),
(802, N'scattered clouds', N'Clouds', N'scattered clouds'),
(721, N'haze', N'Atmosphere', N'haze'),
(531, N'ragged shower rain', N'Rain', N'ragged shower rain'),
(522, N'heavy intensity shower rain', N'Rain', N'heavy intensity shower rain'),
(521, N'shower rain', N'Rain', N'shower rain'),
(201, N'thunderstorm with rain', N'Thunderstorm', N'thunderstorm with rain'),
(202, N'thunderstorm with heavy rain', N'Thunderstorm', N'thunderstorm with heavy rain'),
(210, N'light thunderstorm', N'Thunderstorm', N'light thunderstorm'),
(211, N'thunderstorm', N'Thunderstorm', N'thunderstorm'),
(212, N'heavy thunderstorm', N'Thunderstorm', N'heavy thunderstorm'),
(221, N'ragged thunderstorm', N'Thunderstorm', N'ragged thunderstorm'),
(230, N'thunderstorm with light drizzle', N'Thunderstorm', N'thunderstorm with light drizzle'),
(231, N'thunderstorm with drizzle', N'Thunderstorm', N'thunderstorm with drizzle'),
(232, N'thunderstorm with heavy drizzle', N'Thunderstorm', N'thunderstorm with heavy drizzle'),
(300, N'light intensity drizzle', N'Drizzle', N'light intensity drizzle'),
(301, N'drizzle', N'Drizzle', N'drizzle'),
(302, N'heavy intensity drizzle', N'Drizzle', N'heavy intensity drizzle'),
(310, N'light intensity drizzle rain', N'Drizzle', N'light intensity drizzle rain'),
(311, N'drizzle rain', N'Drizzle', N'drizzle rain'),
(312, N'heavy intensity drizzle rain', N'Drizzle', N'heavy intensity drizzle rain'),
(313, N'shower rain and drizzle', N'Drizzle', N'shower rain and drizzle'),
(500, N'light rain', N'Rain', N'light rain'),
(501, N'moderate rain', N'Rain', N'moderate rain'),
(502, N'heavy intensity rain', N'Rain', N'heavy intensity rain'),
(503, N'very heavy rain', N'Rain', N'very heavy rain'),
(504, N'extreme rain', N'Rain', N'extreme rain'),
(511, N'freezing rain', N'Rain', N'freezing rain'),
(520, N'light intensity shower rain', N'Rain', N'light intensity shower rain'),
(803, N'broken clouds', N'Clouds', N'broken clouds'),
(804, N'overcast clouds', N'Clouds', N'overcast clouds');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Condition', N'Group', N'MappedConditionResponse') AND [object_id] = OBJECT_ID(N'[WeatherConditionResponse]'))
    SET IDENTITY_INSERT [WeatherConditionResponse] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180719094344_AddSeedData', N'2.1.1-rtm-30846');

GO

