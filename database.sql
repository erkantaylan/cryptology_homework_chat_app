USE [master]
GO
/****** Object:  Database [CryptologyMessageDb]    Script Date: 03/29/2016 16:29:26 ******/
CREATE DATABASE [CryptologyMessageDb] ON  PRIMARY 
( NAME = N'CryptologyMessageDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CryptologyMessageDb.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CryptologyMessageDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CryptologyMessageDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CryptologyMessageDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CryptologyMessageDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CryptologyMessageDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET ARITHABORT OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CryptologyMessageDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CryptologyMessageDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CryptologyMessageDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [CryptologyMessageDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CryptologyMessageDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CryptologyMessageDb] SET  READ_WRITE
GO
ALTER DATABASE [CryptologyMessageDb] SET RECOVERY SIMPLE
GO
ALTER DATABASE [CryptologyMessageDb] SET  MULTI_USER
GO
ALTER DATABASE [CryptologyMessageDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CryptologyMessageDb] SET DB_CHAINING OFF
GO
USE [CryptologyMessageDb]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 03/29/2016 16:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (1, N'Ecem', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (2, N'Erkan', N'4321')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (3, N'Theresa', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (4, N'Donna', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (5, N'Carolyn', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (6, N'Johnny', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (7, N'Carl', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (8, N'Victor', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (9, N'Philip', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (10, N'Norma', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (11, N'Jeremy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (12, N'Aaron', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (13, N'Deborah', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (14, N'Matthew', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (15, N'Albert', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (16, N'Kathy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (17, N'Laura', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (18, N'Scott', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (19, N'Sharon', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (20, N'Todd', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (21, N'Gary', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (22, N'Gloria', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (23, N'Edward', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (24, N'John', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (25, N'Albert', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (26, N'Kelly', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (27, N'Andrew', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (28, N'Kathy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (29, N'Joseph', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (30, N'Todd', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (31, N'Jason', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (32, N'Rachel', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (33, N'Betty', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (34, N'Roy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (35, N'Kelly', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (36, N'Christina', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (37, N'Nicholas', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (38, N'Ann', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (39, N'Alice', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (40, N'Steven', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (41, N'Christina', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (42, N'Harry', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (43, N'Diane', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (44, N'Sarah', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (45, N'Rose', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (46, N'Henry', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (47, N'Rose', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (48, N'Steve', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (49, N'Janet', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (50, N'Katherine', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (51, N'Gregory', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (52, N'Douglas', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (53, N'Brandon', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (54, N'Todd', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (55, N'Evelyn', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (56, N'Jason', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (57, N'Donald', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (58, N'Frances', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (59, N'Peter', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (60, N'Laura', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (61, N'Mark', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (62, N'Cheryl', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (63, N'Edward', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (64, N'Charles', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (65, N'Brenda', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (66, N'Amanda', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (67, N'Gloria', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (68, N'Jack', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (69, N'Antonio', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (70, N'Shirley', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (71, N'Bruce', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (72, N'Sandra', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (73, N'Diane', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (74, N'Marie', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (75, N'Marie', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (76, N'Billy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (77, N'Michelle', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (78, N'Doris', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (79, N'Christine', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (80, N'Steve', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (81, N'Rose', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (82, N'Sean', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (83, N'Roy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (84, N'Dennis', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (85, N'Norma', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (86, N'Sarah', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (87, N'Anne', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (88, N'Kathleen', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (89, N'Ann', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (90, N'Tina', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (91, N'Wayne', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (92, N'Wanda', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (93, N'Jose', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (94, N'Jason', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (95, N'Willie', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (96, N'Jonathan', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (97, N'Julia', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (98, N'Roy', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (99, N'Earl', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (100, N'Linda', N'1234')
GO
print 'Processed 100 total records'
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (101, N'Julie', N'1234')
INSERT [dbo].[tblUser] ([userId], [username], [password]) VALUES (102, N'Amanda', N'1234')
SET IDENTITY_INSERT [dbo].[tblUser] OFF
/****** Object:  Table [dbo].[tblKey]    Script Date: 03/29/2016 16:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblKey](
	[keyId] [int] IDENTITY(1,1) NOT NULL,
	[keyString] [varchar](24) NOT NULL,
 CONSTRAINT [PK_tblKey] PRIMARY KEY CLUSTERED 
(
	[keyId] ASC,
	[keyString] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblKey] ON
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (17, N'MCym6O8sN8UZug2GgLSE8aK8')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (18, N'FQBr1z19Gw1ZKuyQ0J5XbHl0')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (19, N'TTdzmfPxijZJgH75sq4h6dyP')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (20, N'c29DsFz99q34TjeGjLiTvTCf')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (21, N'R3weF2E4n3gK0DzLGtB0cND7')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (22, N'pvZGlzOHs5DMYE2U89tlb3dH')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (23, N'IVt5oU9cHczSnx7jqKkwpULm')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (24, N'WeMNX36A9a9oz4CjwLwV05EH')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (25, N'pJEnevZSbjihmxEbflI3xrwa')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (26, N'bYyTIXKIGsSam4ccoCZsMW60')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (27, N'IhQCwX6GavnV77rA1gXnYAVB')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (28, N'RDReKErDMlcIILbJXDo7mBBl')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (29, N'u8Iax8EOLwL9yphcGfD7mOfg')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (30, N'9Qu8KvwQXdvZXrZ3CfQdJ1Zw')
INSERT [dbo].[tblKey] ([keyId], [keyString]) VALUES (31, N'yNwxCiNPtl3s9ZM1Qf8sXjpj')
SET IDENTITY_INSERT [dbo].[tblKey] OFF
/****** Object:  Table [dbo].[tblCryptingType]    Script Date: 03/29/2016 16:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCryptingType](
	[cryptingTypeId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblCryptingType] PRIMARY KEY CLUSTERED 
(
	[cryptingTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCryptingType] ON
INSERT [dbo].[tblCryptingType] ([cryptingTypeId], [name]) VALUES (1, N'3DES')
SET IDENTITY_INSERT [dbo].[tblCryptingType] OFF
/****** Object:  Table [dbo].[tblMessage]    Script Date: 03/29/2016 16:29:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMessage](
	[messageId] [int] IDENTITY(1,1) NOT NULL,
	[fromId] [int] NOT NULL,
	[toId] [int] NOT NULL,
	[message] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tblMessage] PRIMARY KEY CLUSTERED 
(
	[messageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblMessage] ON
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (56, 2, 12, N'lets send some unprotected text')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (57, 2, 12, N'u7STKKLbdkFJ3d82YljM+mqP6GKctkIfabelUAFo8/Mc4OqwahJJFkEYPkHYNnfrJHQeXe659rr9Bz8UsUdXCA==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (58, 2, 3, N'MUu4Zt46q+fOtqK5e0G8jg==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (59, 2, 3, N'wkbZ2omibP10UHrmETtPbvcY2GTv/lbb')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (60, 2, 3, N'nf/bmi6kkAWDti5Ly/q2DzLSJWwFw0A82SoeiUXhNOcMZRmkoVcRuJ7APm5FW/wRBKgy7Il77Vg=')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (61, 2, 3, N'puXGeU16ofz3EGIJBGnQlbfQ0yRV0rm9ugZED6jLuRnOn2Rl+P6rtg==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (62, 2, 3, N'fbR1gyol1GPW8zsN5tesABXD2TwfomIzDGUZpKFXEbiewD5uRVv8EcN4vTGmXGjlzp9kZfj+q7Y=')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (63, 2, 10, N'JG99Q5vEoVj7z3YYeboKJg==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (64, 10, 2, N'XECSNc6yrNJ3YCYrLaSN5g==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (65, 10, 2, N'AOfcyKYztD02gDVoHVyhOg==')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (66, 2, 11, N'XLNbUUjZcPa7J6UNqqnrUqnCmYRSSPt/')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (67, 2, 9, N'Hello Philip this is a uncripted text')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (68, 2, 9, N'So everone can see this text')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (69, 2, 9, N'eyAgK3Qgx+NZyK/pjsRnM8eFn4yYnw7KrLG2pHsStvGeubFPxVC6db7ldm2QNX0EEbWFUeHtp704vn0pJCnkvLs074M+yiujqQ78hjXzJGPIpr5j8Su7GLLr52Zyl6XTHeAVLPFgUWk=')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (70, 9, 1, N'Hello Ecem')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (71, 1, 9, N'You forgot to cryp the text')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (72, 9, 1, N'XBZxorKdb8UgTEP/xKLxKJgW7M578N389WwSlTWxFmWVmlDhqBz7Vkztzmb1cHvB')
INSERT [dbo].[tblMessage] ([messageId], [fromId], [toId], [message]) VALUES (73, 1, 9, N'dY8wrmyAAiAGTiMZ7LX20g==')
SET IDENTITY_INSERT [dbo].[tblMessage] OFF
/****** Object:  View [dbo].[viewMessagesWithUserNames]    Script Date: 03/29/2016 16:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewMessagesWithUserNames]
AS
SELECT m.messageId , m.message
,(SELECT u.username FROM tblUser AS u WHERE m.fromId = u.userId) as sender
,(SELECT u.username FROM tblUser AS u WHERE m.toId = u.userId) as receiver

FROM tblMessage AS m
GO
/****** Object:  Table [dbo].[tblMessageKey]    Script Date: 03/29/2016 16:29:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMessageKey](
	[messageKeyId] [int] IDENTITY(1,1) NOT NULL,
	[messageId] [int] NOT NULL,
	[cryptingTypeId] [int] NOT NULL,
	[keyId] [int] NOT NULL,
 CONSTRAINT [PK_tblMessageKey] PRIMARY KEY CLUSTERED 
(
	[messageKeyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblMessageKey] ON
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (14, 56, 1, -1)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (15, 57, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (16, 58, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (17, 59, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (18, 60, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (19, 61, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (20, 62, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (21, 63, 1, 31)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (22, 64, 1, 31)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (23, 65, 1, 31)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (24, 66, 1, 18)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (25, 67, 1, -1)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (26, 68, 1, -1)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (27, 69, 1, 17)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (28, 70, 1, -1)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (29, 71, 1, -1)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (30, 72, 1, 31)
INSERT [dbo].[tblMessageKey] ([messageKeyId], [messageId], [cryptingTypeId], [keyId]) VALUES (31, 73, 1, 31)
SET IDENTITY_INSERT [dbo].[tblMessageKey] OFF
/****** Object:  ForeignKey [FK_tblMessage_tblUser]    Script Date: 03/29/2016 16:29:27 ******/
ALTER TABLE [dbo].[tblMessage]  WITH CHECK ADD  CONSTRAINT [FK_tblMessage_tblUser] FOREIGN KEY([fromId])
REFERENCES [dbo].[tblUser] ([userId])
GO
ALTER TABLE [dbo].[tblMessage] CHECK CONSTRAINT [FK_tblMessage_tblUser]
GO
/****** Object:  ForeignKey [FK_tblMessage_tblUser1]    Script Date: 03/29/2016 16:29:27 ******/
ALTER TABLE [dbo].[tblMessage]  WITH CHECK ADD  CONSTRAINT [FK_tblMessage_tblUser1] FOREIGN KEY([toId])
REFERENCES [dbo].[tblUser] ([userId])
GO
ALTER TABLE [dbo].[tblMessage] CHECK CONSTRAINT [FK_tblMessage_tblUser1]
GO
/****** Object:  ForeignKey [FK_tblMessageKey_tblCryptingType]    Script Date: 03/29/2016 16:29:28 ******/
ALTER TABLE [dbo].[tblMessageKey]  WITH CHECK ADD  CONSTRAINT [FK_tblMessageKey_tblCryptingType] FOREIGN KEY([cryptingTypeId])
REFERENCES [dbo].[tblCryptingType] ([cryptingTypeId])
GO
ALTER TABLE [dbo].[tblMessageKey] CHECK CONSTRAINT [FK_tblMessageKey_tblCryptingType]
GO
/****** Object:  ForeignKey [FK_tblMessageKey_tblMessage]    Script Date: 03/29/2016 16:29:28 ******/
ALTER TABLE [dbo].[tblMessageKey]  WITH CHECK ADD  CONSTRAINT [FK_tblMessageKey_tblMessage] FOREIGN KEY([messageId])
REFERENCES [dbo].[tblMessage] ([messageId])
GO
ALTER TABLE [dbo].[tblMessageKey] CHECK CONSTRAINT [FK_tblMessageKey_tblMessage]
GO
