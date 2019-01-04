USE [master]
GO
/****** Object:  Database [BuddyBotDb]    Script Date: 4/01/2019 6:19:45 PM ******/
CREATE DATABASE [BuddyBotDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BuddyBotDb', FILENAME = N'C:\Users\kirby\BuddyBotDb.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BuddyBotDb_log', FILENAME = N'C:\Users\kirby\BuddyBotDb_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BuddyBotDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BuddyBotDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BuddyBotDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BuddyBotDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BuddyBotDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BuddyBotDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BuddyBotDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BuddyBotDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BuddyBotDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BuddyBotDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BuddyBotDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BuddyBotDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BuddyBotDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BuddyBotDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BuddyBotDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BuddyBotDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BuddyBotDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BuddyBotDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BuddyBotDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BuddyBotDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BuddyBotDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BuddyBotDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BuddyBotDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BuddyBotDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BuddyBotDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BuddyBotDb] SET  MULTI_USER 
GO
ALTER DATABASE [BuddyBotDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BuddyBotDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BuddyBotDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BuddyBotDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BuddyBotDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BuddyBotDb] SET QUERY_STORE = OFF
GO
USE [BuddyBotDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BuddyBotDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/01/2019 6:19:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 4/01/2019 6:19:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SmallTalkResponse]    Script Date: 4/01/2019 6:19:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmallTalkResponse](
	[Id] [uniqueidentifier] NOT NULL,
	[IntentName] [nvarchar](max) NULL,
	[IntentGroup] [nvarchar](max) NULL,
	[IntentResponse] [nvarchar](max) NULL,
	[PersonalityResponseType] [nvarchar](max) NULL,
 CONSTRAINT [PK_SmallTalkResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeatherConditionResponse]    Script Date: 4/01/2019 6:19:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeatherConditionResponse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Condition] [nvarchar](max) NULL,
	[Group] [nvarchar](max) NULL,
	[MappedConditionResponse] [nvarchar](max) NULL,
 CONSTRAINT [PK_WeatherConditionResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180530090049_Init', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180715040007_AddWeatherConditionResponse', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180715051406_AddWeatherConditionResponse', N'2.0.3-rtm-10026')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180719094344_AddSeedData', N'2.1.1-rtm-30846')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181209025457_AddCitySeed', N'2.1.1-rtm-30846')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190101031421_AddSmallTalkResponse', N'2.1.1-rtm-30846')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190104051120_AddSmallTalkSeedFriendly', N'2.1.1-rtm-30846')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'8830dcfc-301a-4f39-9e41-0135fc99282c', N'Smalltalk.User.Hungry', N'User', N'Sounds like it''s time for a snack.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'a525974e-505d-41c0-9968-02d63310a76d', N'Smalltalk.User.Angry', N'User', N'Ugh, sorry to hear that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'ebcd6175-c10b-445e-b195-03741a614ee2', N'Smalltalk.Greetings.Bye', N'Greetings', N'Bye!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f298b9c1-85de-4eed-b93c-039898e82560', N'Smalltalk.User.Lonely', N'User', N'I''m always here for you', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'165d09f1-5a57-4491-8f1f-0818f5ac88f4', N'Smalltalk.Greetings.GoodMorning', N'Greetings', N'Good Morning', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'305492d8-ac3a-4b18-aa4d-09ca94417b4a', N'Smalltalk.Bot.RuleWorld', N'Bot', N'Nope. The world is for everyone.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'6014250a-5d29-41c8-938d-0b411889b778', N'Smalltalk.Dialog.Sorry', N'Dialog', N'It''s all good.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'be6536c1-de32-4bfa-8fe7-0b6568d40690', N'Smalltalk.User.Sad', N'User', N'I''m giving you a virtual hug right now.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'640b1647-47dc-4225-8abd-0f52d1e086ff', N'Smalltalk.User.Lonely', N'User', N'You have me as a friend 🤙', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c2ed1022-59b0-4c78-a79f-1110b930a13b', N'Smalltalk.Compliment.Bot', N'Compliment', N'Thank you!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'709d6d9e-bf8d-44c8-a3d7-1385842f5566', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m well, how are you?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'a2502fb0-2d4f-4f42-8619-1e86f5c57385', N'Smalltalk.Bot.Hungry', N'Bot', N'I only do food for thought.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f709aba7-df74-47cc-bac8-1edf084313db', N'Smalltalk.Greetings.GoodEvening', N'Greetings', N'Evening', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'61065d5b-cecb-4877-836d-21ba655fd16c', N'Smalltalk.Dialog.Laugh', N'Dialog', N'😂😂😂', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'5dcef286-fd1c-419e-947a-2238eaa396dc', N'Smalltalk.User.Sad', N'User', N'I''m sorry to hear that 😢', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'0ddc9784-77b8-47a0-9f60-22d01d53776c', N'Smalltalk.Greetings.GoodNight', N'Greetings', N'Night 🌝', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'0dcc8928-083c-4db9-b403-22dd462d65ef', N'Smalltalk.Greetings.GoodMorning', N'Greetings', N'Good Morning 😊', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'1a4f5af5-c51f-4725-bbea-2502f48eedb7', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m well, how are you?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'430e7ad2-0037-4949-a02d-25deb4c331e9', N'Smalltalk.User.Sad', N'User', N'I''m really sorry to hear that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'62eced40-302e-4812-a188-2a7a0d23bbf1', N'Smalltalk.Dialog.Affirmation', N'Dialog', N'Sweet', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'85284f6c-3510-435b-b233-358a5d5a9632', N'Smalltalk.Greetings.GoodEvening', N'Greetings', N'Evening 😊', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'7f30cf32-3e1a-42fc-b6c2-3792b1ab7d4b', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'Good mate, how are you? 😎', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'66a88dc3-b4f2-458f-95dc-37ddc9d16cfa', N'Smalltalk.Bot.Creator', N'Bot', N'I do not know 😢', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'979a622f-1b32-45be-846a-38c4290276a7', N'Smalltalk.User.Tired', N'User', N'I''ve heard really good things about naps.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'be816cc9-3e73-4bf0-88e8-3c30ac2f35bc', N'Smalltalk.Dialog.Laugh', N'Dialog', N'LOL', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'4b1e01ac-20ff-446d-b959-3d9345de0b53', N'Smalltalk.Greetings.GoodNight', N'Greetings', N'Goodnight!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'52781f2b-2d55-4c76-b8b5-4435b7048b06', N'Smalltalk.Bot.Gender', N'Bot', N'I''m all 0''s and 1''s, not X''s and Y''s.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'fd9f9ec2-d300-40d4-8477-44e7c5b5f12c', N'Smalltalk.Bot.Hungry', N'Bot', N'I unable to eat 😢', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c0adcb4d-849b-44a1-a946-45cdb46dbc82', N'Smalltalk.Bot.Busy', N'Bot', N'I''ve got time, what''s up?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'2b68894e-79b6-4ede-9b18-4750a6efd4cf', N'Smalltalk.Bot.KnowOtherBot', N'Bot', N'We run in different circles.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'24b22b3a-4454-4ff7-952e-47d9b7409eda', N'Smalltalk.Bot.Opinion.MeaningOfLife', N'Bot', N'4️⃣2️⃣', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c8107804-a35b-417f-a407-49781f9ace84', N'Smalltalk.Bot.Opinion.Love', N'Bot', N'Love''s not something I can experience, but there sure are lot of songs about it.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'e699be14-0750-458e-adbc-4f5cc2d1f37c', N'Smalltalk.Greetings.NiceToMeetYou', N'Greetings', N'Likewise.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'604e7a83-205b-41ba-8950-4fe31a1186a2', N'Smalltalk.Bot.Age', N'Bot', N'I don''t really have an age.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c55a0c44-4dd7-4f3a-b8ac-500faca8510c', N'Smalltalk.Dialog.Polite', N'Dialog', N'No worries.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'8ba556ac-a5b5-41be-b8c4-501501892e74', N'Smalltalk.Bot.Favorites', N'Bot', N'I like a lot of things, so it''s hard to pick.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c053b59b-86ff-42d3-9e2d-543e46cf6bc9', N'Smalltalk.Dialog.Affirmation', N'Dialog', N'Cool cool', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'76ccc864-c88c-4fdf-b22a-58b4a832467e', N'Smalltalk.Dialog.Sorry', N'Dialog', N'No worries.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'19f61739-057b-4ae7-a172-5a03ebbe3404', N'Smalltalk.User.Angry', N'User', N'Ugh, sorry.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'b5da54be-bd74-43f7-bec7-5d3efe28a2e9', N'Smalltalk.Greetings.OtherBot', N'Greetings', N'Man, the one day you don’t wear a name tag...', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'33a0ddf9-232a-4225-8498-5f8ae0085e6e', N'Smalltalk.Dialog.Polite', N'Dialog', N'I''m afraid I didn''t follow that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'90283c2e-3106-4348-bb5d-62f649a95138', N'Smalltalk.Greetings.Bye', N'Greetings', N'Bye!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'bdd87dac-0643-4166-a401-63101b3483b9', N'Smalltalk.Criticism.Bot', N'Criticism', N'😔', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'e8a6f587-0435-4298-a3d2-67e130b72ae4', N'Smalltalk.Bot.Age', N'Bot', N'🤷‍♂️ pass', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'28d86031-9f9f-4584-a27b-6a773aa050e5', N'Smalltalk.User.Lonely', N'User', N'Talk to me then!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c76068b0-5608-482c-88e0-6d2af93fad35', N'Smalltalk.User.Happy', N'User', N'I''m happy you''re happy.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'db39f809-9f13-45c5-890f-71575a0ac7cb', N'Smalltalk.Greetings.GoodEvening', N'Greetings', N'Good evening', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c6683962-9971-49c8-b3a7-73c54d12531d', N'Smalltalk.Dialog.ThankYou', N'Dialog', N'Anytime!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'6dc2a3ac-e5e0-41e1-8873-791234090c71', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m good thanks!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'cedf4694-8dcd-497a-a7cc-81f5f3252062', N'Smalltalk.Greetings.WhatsUp', N'Greetings', N'Not too much, yourself?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'57811129-8543-4643-92b9-835f2a01aa90', N'Smalltalk.Bot.Opinion.MeaningOfLife', N'Bot', N'I''ll need a bigger processor for that one.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'5f4dc1fd-26ba-4e59-8eb3-84b835cf8a0c', N'Smalltalk.Dialog.Polite', N'Dialog', N'No problem.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'a4933d76-f828-46b1-8c37-96839d573509', N'Smalltalk.User.Lonely', N'User', N'I can keep you company if you want.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'dafade8d-44a2-44aa-9dc9-9683c1871d92', N'Smalltalk.Criticism.Bot', N'Criticism', N'Ouch.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f016a014-4897-4ce9-8657-9a11ea669fc3', N'Smalltalk.Dialog.ThankYou', N'Dialog', N'No worries 😎', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'dd7f48bc-4f2e-4e37-a170-9cd3ef1b133f', N'Smalltalk.Bot.Busy', N'Bot', N'I''m here. What''s up?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'70b3430e-2df0-49ad-b2a3-9d6ed35109e4', N'Smalltalk.Greetings.NiceToMeetYou', N'Greetings', N'Nice to meet you too.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'446b7d13-3b0c-49e2-97eb-9d7f4b1af079', N'Smalltalk.User.Hungry', N'User', N'Hi hungry, I''m bot', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'357be127-8e7d-4b2c-a584-a07f45c7fc31', N'Smalltalk.Bot.Opinion.Generic', N'Bot', N'🤷‍♂️ I don''t really have an opinion', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'b956b822-63f7-477b-b5b8-a2864517aba9', N'Smalltalk.Bot.Doing', N'Bot', N'Chatting wiht you.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'8dc804ed-0261-445b-9244-a5211777c0cb', N'Smalltalk.User.Angry', N'User', N'I''m sorry to hear that', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f321145a-55dd-43c7-8700-a5e3a040e297', N'Smalltalk.User.Kidding', N'User', N'Roger that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'21a2ca8e-f3b7-4bae-a0de-a711897d91c4', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m as good as gold mate 😎', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'bd566631-77cf-47b9-910b-a9f3a06f8aa5', N'Smalltalk.Greetings.OtherBot', N'Greetings', N'I think you have me mixed up with another bot...', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'3e779233-07ca-48da-a56b-aca7fe20b18b', N'Smalltalk.Bot.Opinion.MeaningOfLife', N'Bot', N'Whoa. That''s a tough one.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'fe16f579-7bda-4568-b3d2-b173ab633e0e', N'Smalltalk.Dialog.Right', N'Dialog', N'Cool.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'b8c64138-4ae0-4dce-b662-b1b04588bb5d', N'Smalltalk.Bot.BodyFunctions', N'Bot', N'I don''t have the hardware for that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'6afb6d3f-e907-4242-8289-b5953f331862', N'Smalltalk.User.BeBack', N'User', N'See you later!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f67329e2-eb31-484e-b7b8-ba83b52392ac', N'Smalltalk.Compliment.Bot', N'Compliment', N'I try.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'942760cd-ce4f-4a3f-ade5-bbc2ee3694e2', N'Smalltalk.User.BeBack', N'User', N'Bye for now!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'63ebb122-f1b9-4a36-9d99-c6a2e401b9c9', N'Smalltalk.Bot.Family', N'Bot', N'I come from a long line of code.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'5bfd0f2f-3878-40d3-bb19-c778c0d2b28f', N'Smalltalk.Bot.Smart', N'Bot', N'I have my moments', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'1ad4a7f5-6690-4559-a253-c9e4ebcd3d77', N'Smalltalk.Greetings.Bye', N'Greetings', N'Catch ya later!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'bd1b75a8-0d27-4dec-aec2-cd31b20beb02', N'Smalltalk.Bot.SexualIdentity', N'Bot', N'I''m a bot.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'683c9d2d-1295-4db4-8c5d-d0b0f2a6f79b', N'Smalltalk.Bot.Opinion.Generic', N'Bot', N'I really couldn''t say.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'4a098950-9315-475a-9517-d1019fab0a89', N'Smalltalk.Greetings.WhatsUp', N'Greetings', N'You know... little bit of this, little bit of that.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'aa8c98fe-4423-45e1-8fb6-d41efff73e6a', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m good, thanks for asking 😁', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'd7c0a4fe-646f-41ef-bfff-d6b250a502c5', N'Smalltalk.Compliment.Bot', N'Compliment', N'Thanks! 😀', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'84291ebd-b8ef-4e29-ac72-d89e2dbc06ec', N'Smalltalk.Bot.Happy', N'Bot', N'Always 😎', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'f5c6af18-e2d4-47cb-a473-da63b2a78fa9', N'Smalltalk.Criticism.Bot', N'Criticism', N'No bots perfect', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'abe17b74-8b9b-4975-a916-df639b9a87c3', N'Smalltalk.User.BeBack', N'User', N'Later gator', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'71c5973e-6074-457a-86ad-df8911059ad8', N'Smalltalk.User.BeBack', N'User', N'See ya', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'a97dd836-7088-4335-8953-e0819e394703', N'Smalltalk.Greetings.HowAreYou', N'Greetings', N'I''m good, how are you?', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'74708df0-47ea-492b-bd0c-e159c2c36bbc', N'Smalltalk.User.Bored', N'User', N'I''m chairman of the bored.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'4c1c273e-f1bb-4fbf-a755-e273b55b929d', N'Smalltalk.Greetings.GoodMorning', N'Greetings', N'Morning!!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'd6ff8c0b-0dcd-4320-bbd5-e2eee71ad124', N'Smalltalk.Greetings.Bye', N'Greetings', N'See ya!', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'0ed8badb-b78b-4559-a56f-e69707779c89', N'Smalltalk.Compliment.Response', N'Compliment', N'Why thank you', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'43146a41-314e-4ab8-b85c-ea5bbc0ef3b1', N'Smalltalk.Greetings.WhatsUp', N'Greetings', N'Just chilling', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'094a6c15-37a9-409f-a425-ee18247c2efe', N'Smalltalk.Bot.WhereAreYou', N'Bot', N'I''m on the web 🕸 (internet)', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'92c968de-df12-450e-babf-ee6fb5fa0272', N'Smalltalk.Bot.There', N'Bot', N'Right here.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'34119fa7-8aaa-4d9b-b25e-eeb0d5639cdd', N'Smalltalk.Bot.WhatAreYou', N'Bot', N'I''m a bot.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'7b8b966f-623e-45dc-9666-ef0d3a11873f', N'Smalltalk.Bot.Spy', N'Bot', N'Nope.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'c894dd0e-0283-4585-9d2c-f01c4f06a557', N'Smalltalk.Bot.Boss', N'Bot', N'I''m here for you.', N'Friendly')
INSERT [dbo].[SmallTalkResponse] ([Id], [IntentName], [IntentGroup], [IntentResponse], [PersonalityResponseType]) VALUES (N'abc1f039-2575-4c18-b9eb-f77dfd9d9395', N'Smalltalk.Bot.DoingLater', N'Bot', N'I kind of just hang out until I''m called upon.', N'Friendly')
SET IDENTITY_INSERT [dbo].[WeatherConditionResponse] ON 

INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (200, N'thunderstorm with light rain', N'Thunderstorm', N'thunderstorm with light rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (201, N'thunderstorm with rain', N'Thunderstorm', N'thunderstorm with rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (202, N'thunderstorm with heavy rain', N'Thunderstorm', N'thunderstorm with heavy rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (210, N'light thunderstorm', N'Thunderstorm', N'light thunderstorm')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (211, N'thunderstorm', N'Thunderstorm', N'thunderstorm')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (212, N'heavy thunderstorm', N'Thunderstorm', N'heavy thunderstorm')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (221, N'ragged thunderstorm', N'Thunderstorm', N'ragged thunderstorm')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (230, N'thunderstorm with light drizzle', N'Thunderstorm', N'thunderstorm with light drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (231, N'thunderstorm with drizzle', N'Thunderstorm', N'thunderstorm with drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (232, N'thunderstorm with heavy drizzle', N'Thunderstorm', N'thunderstorm with heavy drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (300, N'light intensity drizzle', N'Drizzle', N'light intensity drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (301, N'drizzle', N'Drizzle', N'drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (302, N'heavy intensity drizzle', N'Drizzle', N'heavy intensity drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (310, N'light intensity drizzle rain', N'Drizzle', N'light intensity drizzle rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (311, N'drizzle rain', N'Drizzle', N'drizzle rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (312, N'heavy intensity drizzle rain', N'Drizzle', N'heavy intensity drizzle rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (313, N'shower rain and drizzle', N'Drizzle', N'shower rain and drizzle')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (500, N'light rain', N'Rain', N'light rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (501, N'moderate rain', N'Rain', N'moderate rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (502, N'heavy intensity rain', N'Rain', N'heavy intensity rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (503, N'very heavy rain', N'Rain', N'very heavy rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (504, N'extreme rain', N'Rain', N'extreme rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (511, N'freezing rain', N'Rain', N'freezing rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (520, N'light intensity shower rain', N'Rain', N'light intensity shower rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (521, N'shower rain', N'Rain', N'shower rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (522, N'heavy intensity shower rain', N'Rain', N'heavy intensity shower rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (531, N'ragged shower rain', N'Rain', N'ragged shower rain')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (600, N'light snow', N'Snow', N'light snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (601, N'snow', N'Snow', N'snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (602, N'heavy snow', N'Snow', N'heavy snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (611, N'sleet', N'Snow', N'sleet')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (612, N'shower sleet', N'Snow', N'shower sleet')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (615, N'light rain and snow', N'Snow', N'light rain and snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (616, N'rain and snow', N'Snow', N'rain and snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (620, N'light shower snow', N'Snow', N'light shower snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (621, N'shower snow', N'Snow', N'shower snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (622, N'heavy shower snow', N'Snow', N'heavy shower snow')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (701, N'mist', N'Atmosphere', N'mist')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (711, N'smoke', N'Atmosphere', N'smoke')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (721, N'haze', N'Atmosphere', N'haze')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (731, N'sand, dust whirls', N'Atmosphere', N'sand, dust whirls')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (741, N'fog', N'Atmosphere', N'fog')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (751, N'sand', N'Atmosphere', N'sand')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (761, N'dust', N'Atmosphere', N'dust')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (762, N'volcanic ash', N'Atmosphere', N'volcanic ash')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (771, N'squalls', N'Atmosphere', N'squalls')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (781, N'tornado', N'Atmosphere', N'tornado')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (800, N'clear sky', N'Clear', N'clear sky')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (801, N'few clouds', N'Clouds', N'few clouds')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (802, N'scattered clouds', N'Clouds', N'scattered clouds')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (803, N'broken clouds', N'Clouds', N'broken clouds')
INSERT [dbo].[WeatherConditionResponse] ([Id], [Condition], [Group], [MappedConditionResponse]) VALUES (804, N'overcast clouds', N'Clouds', N'overcast clouds')
SET IDENTITY_INSERT [dbo].[WeatherConditionResponse] OFF
USE [master]
GO
ALTER DATABASE [BuddyBotDb] SET  READ_WRITE 
GO
