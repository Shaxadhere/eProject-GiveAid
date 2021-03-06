USE [master]
GO
/****** Object:  Database [db_GiveAidPro]    Script Date: 20/05/2019 9:01:07 AM ******/
CREATE DATABASE [db_GiveAidPro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_GiveAidPro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\db_GiveAidPro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_GiveAidPro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\db_GiveAidPro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_GiveAidPro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_GiveAidPro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_GiveAidPro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_GiveAidPro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_GiveAidPro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_GiveAidPro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET RECOVERY FULL 
GO
ALTER DATABASE [db_GiveAidPro] SET  MULTI_USER 
GO
ALTER DATABASE [db_GiveAidPro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_GiveAidPro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_GiveAidPro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_GiveAidPro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_GiveAidPro] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_GiveAidPro', N'ON'
GO
ALTER DATABASE [db_GiveAidPro] SET QUERY_STORE = OFF
GO
USE [db_GiveAidPro]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [db_GiveAidPro]
GO
/****** Object:  Table [dbo].[tbl_About]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_About](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[What We Do] [varchar](2500) NULL,
	[Our Mission] [varchar](2500) NULL,
	[Career With Us] [varchar](2500) NULL,
	[About Us] [varchar](2500) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Activity]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Activity](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](2500) NULL,
	[DateTime] [datetime] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
	[Picture] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Donation]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Donation](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User] [int] NULL,
	[FK_NGO] [int] NULL,
	[FK_DonationCause] [int] NULL,
	[DateTime] [datetime] NULL,
	[Amount] [money] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DonationCause]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonationCause](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[DonationCauseName] [varchar](50) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
	[Picture] [varchar](1000) NULL,
	[Description] [varchar](2500) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DonationCauseNGO]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonationCauseNGO](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_DonationCause] [int] NULL,
	[FK_NGO] [int] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Gallery]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Gallery](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Picture] [varchar](1000) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
	[Title] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_IntrestActivities]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_IntrestActivities](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User] [int] NULL,
	[FK_Activity] [int] NULL,
	[Message] [varchar](2500) NULL,
	[DateTime] [datetime] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_NGO]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NGO](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[NGOName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Logo] [varchar](1000) NULL,
	[Phone] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Fk_DonationCause] [int] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_OurAchievements]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OurAchievements](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Picture] [varchar](1000) NULL,
	[Description] [varchar](2500) NULL,
	[DateTime] [datetime] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Partner]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Partner](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[PartnerName] [varchar](50) NULL,
	[Website] [varchar](250) NULL,
	[Logo] [varchar](1000) NULL,
	[Description] [varchar](2500) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Position]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Position](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [varchar](50) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_QnA]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_QnA](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_User] [int] NULL,
	[Question] [varchar](2500) NULL,
	[Answer] [varchar](2500) NULL,
	[DateTime] [datetime] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TeamMember]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TeamMember](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[FK_Position] [int] NULL,
	[Picture] [varchar](1000) NULL,
	[Description] [varchar](250) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NULL,
	[Picture] [varchar](1000) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FK_UserType] [int] NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserType]    Script Date: 20/05/2019 9:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserType](
	[PK_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [varchar](50) NULL,
	[Active] [bit] NULL,
	[Deleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_About] ON 

INSERT [dbo].[tbl_About] ([PK_ID], [What We Do], [Our Mission], [Career With Us], [About Us], [Active], [Deleted]) VALUES (1, N'With your support, together we can uplift the physical, mental and spiritual well-being of our patients. This means people and their families can to live their lives to the fullest, whatever that means to them.

While some people are only with us for a matter of days, others need months or years of support.

To read more about our clinical services, visit the clinical hospice website here. Or read on for more information about how your gifts can help our patients.', N'Give Aid. is a Non-Profit organization dedicated to working with children, families, and communities to overcome a lack of food, poverty, and homelessness. Helping Humanity, we are committed to working with the world''s most needy people regardless of religion, race, ethnicity, or gender. ', N'Global Impact employees are a diverse group committed to supporting charitable efforts to help the millions of people affected by poverty, disaster and neglect worldwide. Through the efforts of our dedicated staff, we are a recognized leader in growing global philanthropy.

We value our full-time and part-time employees and offer a wide range of benefits to meet the specific needs of our staff and their families. Employee health, wellness and career development are top priorities, and we re-evaluate our benefits program to ensure that our employee benefits remain competitive.', N'Giv Aid is the largest and most-utilized charity evaluator in the world. The organization helps guide intelligent giving by evaluating the Financial Health, Accountability and Transparency of over 9,000 charities and provides basic data on the rest of the 1.8 million World''s nonprofits. Give Aid accepts no advertising or donations from the organizations', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_About] OFF
SET IDENTITY_INSERT [dbo].[tbl_Activity] ON 

INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (1, N'Provided Security', N'We provided Security to the areas where crime rate was high and people who live their could not afford it. Over the decades, the UN has helped to end numerous conflicts, often through actions of the Security Council — the organ with primary responsibility, under the United Nations Charter, for the maintenance of international peace and security. When a complaint concerning a threat to peace is brought before it, the Council''s first action is usually to recommend to the parties to try to reach agreement by peaceful means. In some cases, the Council itself undertakes investigation and mediation. It may appoint special representatives or request the Secretary-General to do so or to use his good offices. It may set forth principles for a peaceful settlement.', CAST(N'2019-01-01T12:32:00.000' AS DateTime), 1, 0, N'cause-2.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (2, N'Gave Food and Shelter', N'We gave shelters and food to people in Africa, The world is witnessing the highest levels of displacement on record. An unprecedented 65.6 million people around the world have been forced from home by conflict and persecution at the end of 2016. Among them are nearly 22.5 million refugees, over half of whom are under the age of 18. There are also 10 million stateless people, who have been denied a nationality and access to basic rights such as education, healthcare, employment and freedom of movement. 

An agency to help Refugees
People fleeing persecution and conflict have been granted asylum in foreign lands for thousands of years. The UN agency that helps refugees is UNHCR (also known as the UN Refugee Agency), which emerged in the wake of World War II to help Europeans displaced by that conflict.', CAST(N'2019-03-01T12:32:00.000' AS DateTime), 1, 0, N'image_1.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (3, N'Free Medical Checkup', N'We provided free medical checkup and treatment to the people suffering from AIDs. At the outset, it was decided that WHO’s top priorities would be malaria, women’s and children’s health, tuberculosis, venereal disease, nutrition and environmental pollution. Many of those remain on WHO’s agenda today, in addition to such relatively new diseases as HIV/AIDS, diabetes, cancer and emerging diseases such as SARS (Severe Acute Respiratory Syndrome), Ebola or Zika virus.', CAST(N'2016-12-01T12:32:00.000' AS DateTime), 1, 0, N'Health.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (4, N'Good Food Good Health', N'Provided help to the needy people in africa, gave them food and medical checkups, For two decades, leading up to the millennium, global demand for food increased steadily, along with growth in the world’s population, record harvests, improvements in incomes, and the diversification of diets.  As a result, food prices continued to decline through 2000. But beginning in 2004, prices for most grains began to rise.  Although there was an increase in production, the increase in demand was greater.

Food stocks became depleted.  And then, in 2005, food production was dramatically affected by extreme weather incidents in major food-producing countries.  By 2006, world cereal production had fallen by 2.1 percent.  In 2007, rapid increases in oil prices increased fertilizer and other food production costs.', CAST(N'2019-06-15T12:32:00.000' AS DateTime), 1, 0, N'Food.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (5, N'Clean Water Survey', N'Provide pure clean water to the people who were in need of it, Water is at the core of sustainable development and is critical for socio-economic development, energy and food production, healthy ecosystems and for human survival itself. Water is also at the heart of adaptation to climate change, serving as the crucial link between the society and the environment. 

Water is also a rights issue. As the global population grows, there is an increasing need to balance all of the competing commercial demands on water resources so that communities have enough for their needs. In particular, women and girls must have access to clean, private sanitation facilities to manage menstruation and maternity in dignity and safety.

At the human level, water cannot be seen in isolation from sanitation. Together, they are vital for reducing the global burden of disease and improving the health, education and economic productivity of populations. ', CAST(N'2019-08-01T12:32:00.000' AS DateTime), 1, 0, N'Water.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (6, N'Ending Poverty', N'Poverty entails more than the lack of income and productive resources to ensure sustainable livelihoods. Its manifestations include hunger and malnutrition, limited access to education and other basic services, social discrimination and exclusion, as well as the lack of participation in decision-making. Today, more than 780 million people live below the international poverty line. More than 11% of the world population is living in extreme poverty and struggling to fulfil the most basic needs like health, education, and access to water and sanitation, to name a few. There are 122 women aged 25 to 34 living in poverty for every 100 men of the same age group, and more than 160 million children are at risk of continuing to live in extreme poverty by 2030.', CAST(N'2019-08-10T12:32:00.000' AS DateTime), 1, 0, N'endingpoverty.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (1003, N'newgjkhgjkhnklhnkjhnkjhnkj,', N'vjkmgbjkhbkjhkjkjh', CAST(N'2019-05-17T16:13:22.663' AS DateTime), 0, 1, N'587092585IMG-20190405-WA0026.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (1006, N'mujahid', N'najhnjksandkjanjk', CAST(N'2019-05-18T12:13:16.513' AS DateTime), 0, 1, N'2137185765image_1.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (1007, N'nmkn,mnn,m,mmnmnmn', N'nmnmnmn', CAST(N'2019-05-18T12:14:48.900' AS DateTime), 0, 1, N'1583267143061815_05.jpg')
INSERT [dbo].[tbl_Activity] ([PK_ID], [Title], [Description], [DateTime], [Active], [Deleted], [Picture]) VALUES (1008, N'mkm', N'nmnm', CAST(N'2019-05-18T12:27:25.997' AS DateTime), 0, 1, N'1971602296061815_05.jpg')
SET IDENTITY_INSERT [dbo].[tbl_Activity] OFF
SET IDENTITY_INSERT [dbo].[tbl_Donation] ON 

INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (2, 5, 1, 1, CAST(N'2019-05-06T14:32:32.207' AS DateTime), 4000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (3, 5, 1002, 6, CAST(N'2019-05-13T16:35:15.647' AS DateTime), 20000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (4, 5, 1003, 4, CAST(N'2019-05-13T16:42:20.083' AS DateTime), 30000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (5, 5, 1002, 7, CAST(N'2019-05-13T16:47:35.640' AS DateTime), 28000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (6, 5, 1002, 1, CAST(N'2019-05-13T16:50:21.260' AS DateTime), 8000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (7, 5, 1001, 2, CAST(N'2019-05-13T16:56:35.070' AS DateTime), 70000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (8, 5, 1001, 2, CAST(N'2019-05-13T16:56:39.427' AS DateTime), 70000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (9, 5, 1002, 6, CAST(N'2019-05-13T17:01:10.507' AS DateTime), 9000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (10, 5, 1002, 6, CAST(N'2019-05-13T17:02:41.480' AS DateTime), 8000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1003, 5, 1001, 2, CAST(N'2019-05-15T10:08:35.210' AS DateTime), 4000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1004, 5, 1001, 6, CAST(N'2019-05-16T11:07:04.497' AS DateTime), 4000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1005, 5, 1010, 8, CAST(N'2019-05-17T08:23:01.627' AS DateTime), 1213322.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1006, 5, 1001, 2, CAST(N'2019-05-19T15:56:22.923' AS DateTime), 4000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1007, 5, 1001, 1, CAST(N'2019-05-19T15:57:38.437' AS DateTime), 45465453.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1008, 5, 1001, 2, CAST(N'2019-05-19T16:03:04.340' AS DateTime), 8000.0000, 1, 0)
INSERT [dbo].[tbl_Donation] ([PK_ID], [FK_User], [FK_NGO], [FK_DonationCause], [DateTime], [Amount], [Active], [Deleted]) VALUES (1009, 5, 1001, 2, CAST(N'2019-05-19T16:06:17.770' AS DateTime), 8000.0000, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Donation] OFF
SET IDENTITY_INSERT [dbo].[tbl_DonationCause] ON 

INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (1, N'Childern', 1, 0, N'Childern.jpg', N'Our NGO''s look after the caring and feeding of babies and children

Mostly these abandoned newborn babies are provided to the childless couples, who in accordance with our own policies, 
after ensuring that they are fully deserved and exactly suitable for this noble cause. After completely 
going through the background of the couples, and undertaking a rigorous screening process our volunteers decides that the couple 
or the family is precisely suitable for the baby adoption.

On annual basis, We are giving over 250 babies or children for adoption. Till to date, over 23,320 babies 
and children have been provided to the childless couples and families.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (2, N'Food', 1, 0, N'Food.jpg', N'For two decades, leading up to the millennium, global demand for food increased steadily, along with growth in the world’s population, record harvests, improvements in incomes, and the diversification of diets.  As a result, food prices continued to decline through 2000. But beginning in 2004, prices for most grains began to rise.  Although there was an increase in production, the increase in demand was greater.

Food stocks became depleted.  And then, in 2005, food production was dramatically affected by extreme weather incidents in major food-producing countries.  By 2006, world cereal production had fallen by 2.1 percent.  In 2007, rapid increases in oil prices increased fertilizer and other food production costs.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (3, N'Education', 1, 0, N'Education.jpg', N'Following more than a decade of focus on child health issues, GiveAid expanded  its interests to address the needs of the whole child. Thus began an abiding concern with education, starting with support for teacher training and classroom equipment in newly independent countries. Much has been accomplished since the adoption of the Convention, from declining infant mortality to rising school enrolment, but much remains to be done. Every child has the right to health, education and protection, and every society has a stake in expanding children’s opportunities in life. Yet, around the world, millions of children are denied a fair chance for no reason other than the country, gender or circumstances into which they are born.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (4, N'Ending Poverty', 1, 0, N'Poverty.jpg', N'Poverty entails more than the lack of income and productive resources to ensure sustainable livelihoods. Its manifestations include hunger and malnutrition, limited access to education and other basic services, social discrimination and exclusion, as well as the lack of participation in decision-making. Today, more than 780 million people live below the international poverty line. More than 11% of the world population is living in extreme poverty and struggling to fulfil the most basic needs like health, education, and access to water and sanitation, to name a few. There are 122 women aged 25 to 34 living in poverty for every 100 men of the same age group, and more than 160 million children are at risk of continuing to live in extreme poverty by 2030.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (5, N'Environment', 1, 0, N'Environment.jpg', N'Climate Change is the defining issue of our time and we are at a defining moment. From shifting weather patterns that threaten food production, to rising sea levels that increase the risk of catastrophic flooding, the impacts of climate change are global in scope and unprecedented in scale. Without drastic action today, adapting to these impacts in the future will be more difficult and costly.
Greenhouse gases occur naturally and are essential to the survival of humans and millions of other living things, by keeping some of the sun’s warmth from reflecting back into space and making Earth livable. But after more than a century and a half of industrialization, deforestation, and large scale agriculture, quantities of greenhouse gases in the atmosphere have risen to record levels not seen in three million years.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (6, N'Health', 1, 0, N'Health.jpg', N'We, since its inception, has been actively involved in promoting and protecting good health worldwide. Leading that effort within the system is the GiveAid Health. At the outset, it was decided that GiveAid Health’s top priorities would be malaria, women’s and children’s health, tuberculosis, venereal disease, nutrition and environmental pollution. Many of those remain on GiveAid Health’s agenda today, in addition to such relatively new diseases as HIV/AIDS, diabetes, cancer and emerging diseases such as SARS (Severe Acute Respiratory Syndrome), Ebola or Zika virus.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (7, N'Women', 1, 0, N'Women.jpg', N'Women and girls represent half of the world’s population and, therefore, also half of its potential. Gender equality, besides being a fundamental human right, is essential to achieve peaceful societies, with full human potential and sustainable development. Moreover, it has been shown that empowering women spurs productivity and economic growth.

Unfortunately, there is still a long way to go to achieve full equality of rights and opportunities between men and women, warns UN Women. Therefore, it is of paramount importance to end the multiple forms of gender violence and secure equal access to quality education and health, economic resources and participation in political life for both women and girls and men and boys. It is also essential to achieve equal opportunities in access to employment and to positions of leadership and decision-making at all levels.')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (8, N'Clean Water', 1, 0, N'Water.jpg', N'Water is at the core of sustainable development and is critical for socio-economic development, energy and food production, healthy ecosystems and for human survival itself. Water is also at the heart of adaptation to climate change, serving as the crucial link between the society and the environment. 

Water is also a rights issue. As the global population grows, there is an increasing need to balance all of the competing commercial demands on water resources so that communities have enough for their needs. In particular, women and girls must have access to clean, private sanitation facilities to manage menstruation and maternity in dignity and safety.



')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (9, N'ssss', 0, 1, N'2141471786iris-uijttewaal-1111847-unsplash.jpg', N'sssss')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (10, N'Children Welfare Activity', 0, 1, N'1196962018image_1.jpg', N'kkkkkk')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (12, N'hola de como estas', 0, 1, N'6713078621000w_q95.jpg', N'ldjks')
INSERT [dbo].[tbl_DonationCause] ([PK_ID], [DonationCauseName], [Active], [Deleted], [Picture], [Description]) VALUES (13, N'holannnnsjnjjnnj', 0, 1, N'1709277304directrelief.jpg', N'hkhaikj')
SET IDENTITY_INSERT [dbo].[tbl_DonationCause] OFF
SET IDENTITY_INSERT [dbo].[tbl_DonationCauseNGO] ON 

INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (1, 1, 1001, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (2, 2, 1001, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (3, 6, 1001, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (4, 7, 1001, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (5, 1, 1002, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (6, 6, 1002, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (7, 7, 1002, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (8, 1, 1003, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (9, 4, 1003, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (10, 2, 1007, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (11, 8, 1007, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (12, 2, 1010, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (13, 8, 1010, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (14, 1, 1011, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (17, 2, 1017, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (18, 3, 1017, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (19, 8, 1017, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (20, 2, 1020, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (21, 8, 1020, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (22, 2, 1025, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (23, 1, 1030, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (28, 1, 1050, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (29, 2, 1050, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (1026, 2, 2042, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (1027, 8, 2042, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (2024, 2, 3042, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (2025, 3, 3042, 1, 0)
INSERT [dbo].[tbl_DonationCauseNGO] ([PK_ID], [FK_DonationCause], [FK_NGO], [Active], [Deleted]) VALUES (2026, 4, 3042, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_DonationCauseNGO] OFF
SET IDENTITY_INSERT [dbo].[tbl_Gallery] ON 

INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (3, N'1506399446OperationChristmasChild.jpeg', 0, 1, N'Giving gift boxes to childern in Ghana')
INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (4, N'253498516maxresdefault.jpg', 1, 0, N'njnnjjjjj')
INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (1001, N'398703783IMG-20190405-WA0026.jpg', 1, 0, N'HHHHH')
INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (1002, N'1061541374image_1.jpg', 1, 0, N'bbb')
INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (1003, N'573488832068928146061815_05.jpg', 0, 1, N'bbbbbbbjbkjbhjkhkjhj')
INSERT [dbo].[tbl_Gallery] ([PK_ID], [Picture], [Active], [Deleted], [Title]) VALUES (1004, N'941795753NRDC.jpg', 1, 0, N'momomomom')
SET IDENTITY_INSERT [dbo].[tbl_Gallery] OFF
SET IDENTITY_INSERT [dbo].[tbl_IntrestActivities] ON 

INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (1, 5, 0, N'hjsdhadjkahsdkakj', CAST(N'2019-05-14T12:03:12.243' AS DateTime), 1, 0)
INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (2, 5, NULL, N'boooom', CAST(N'2019-05-14T12:06:43.260' AS DateTime), 1, 0)
INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (3, 5, 6, N'momomomom', CAST(N'2019-05-14T12:26:44.273' AS DateTime), 1, 0)
INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (4, 5, 5, N'66ttggtg', CAST(N'2019-05-15T08:48:04.620' AS DateTime), 1, 0)
INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (5, 5, 6, N'njjjjj', CAST(N'2019-05-15T10:53:43.120' AS DateTime), 1, 0)
INSERT [dbo].[tbl_IntrestActivities] ([PK_ID], [FK_User], [FK_Activity], [Message], [DateTime], [Active], [Deleted]) VALUES (6, 5, 6, N',,,,  n', CAST(N'2019-05-19T16:21:27.223' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_IntrestActivities] OFF
SET IDENTITY_INSERT [dbo].[tbl_NGO] ON 

INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1, N'Edhi Welfare Organization', N'contact@edhi.org', N'edhi.png', N'03000300030', N'edhi.org', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (2, N'Saylani Welfare', N'contact@saylani.org', N'saylani.jpg', N'03030010320', N'saylani.org', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1001, N'Shaxad Walfare', N'shaxad.here@gmail.com', N'System.Web.HttpPostedFileWrapper', N'30328048566', N'http://shaxad.somee.com', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1002, N'Talk To Me Pakistan', N'contact@talktome.pk', N'System.Web.HttpPostedFileWrapper', N'021021021021', N'http://talktome.pk', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1003, N'hellow worldsda', N'hwllo@gmail.com', N'System.Web.HttpPostedFileWrapper', N'03030303030', N'http://hello.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1004, N'Chhipa Welfare', N'contact@chhipa.pk', N'217391810v4.jpg', N'030303303030', N'https://www.chhipa.pk', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1007, N'this walfare should be deleted', N'this@mail.com', N'660210794cause-2.jpg', N'0303030303', N'http://this.pk', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1010, N'this is a check welfare', N'contact@saylani.org', N'1593541320cause-4.jpg', N'2265262626', N'http://sss.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1011, N'nnnnnnnnnnnnn', N'nnnnnnnn@mail.com', N'1436154904cause-5.jpg', N'0020202020', N'http://htht.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1017, N'boooom', N'shaxad.here@gmail.com', N'830784319about-img.jpg', N'0303030303000', N'http://www.somee.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1020, N'uuuuuuuuuuuuuuu', N'shaxad.here@gmail.com', N'1753395595cause-6.jpg', N'03030303030303', N'www.hhh.org', NULL, 1, 0)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1025, N'mmmm', N'nnnnnnnn@mail.com', N'1261620986image_1.jpg', N'030303030303', N'http://giveaid.somee.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1030, N'Shaxad Walfare', N'shaxad.here@gmail.com', N'579947987061815_05.jpg', N'3032804856', N'http://giveaid.somee.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (1050, N'jkkjkj', N'hgj@mail.com', NULL, N'03030303030303030', N'http://shaxad.somee.com', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (2042, N'Check', N'cha@mail.com', N'1589096852directrelief.jpg', N'0303030303030303', N'https://www.uno.org', NULL, 0, 1)
INSERT [dbo].[tbl_NGO] ([PK_ID], [NGOName], [Email], [Logo], [Phone], [Website], [Fk_DonationCause], [Active], [Deleted]) VALUES (3042, N'hellow worldsda', N'shaxad.here@gmail.com', N'927232145ChildrensMiracleHospitalsNetwork.jpg', N'15451212121', N'http://shaxad.somee.com', NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[tbl_NGO] OFF
SET IDENTITY_INSERT [dbo].[tbl_OurAchievements] ON 

INSERT [dbo].[tbl_OurAchievements] ([PK_ID], [Name], [Picture], [Description], [DateTime], [Active], [Deleted]) VALUES (1, N'Hospice / Home Based Care', N'736464925hospiceandhomebasedcare.jpg', N'Starting off at the first ever hospice facility in Ghana, the International Health Care Centre (IHCC) chalked incredible results in assisting many PLHIV’s have a dignified death especially during the early stages of the epidemic when Anti-Retrovirals’ were non accessible.

Others too, passed through our hospice care and were able to bounce back to life and today hold positions on bodies like Nap+- Ghana and other HIV support groups. WAAF and IHCC also expanded the hospice services to PLHIV in the home setting where care and comfort were ensured to the very sick.', CAST(N'2019-05-19T14:12:03.617' AS DateTime), 1, 0)
INSERT [dbo].[tbl_OurAchievements] ([PK_ID], [Name], [Picture], [Description], [DateTime], [Active], [Deleted]) VALUES (2, N'Behaviour Change Communication', N'1173599521bbb.jpg', N'Since 1999, WAAF has reached out to  millions of individuals, through various approaches with health prevention and behavioural change messages. Some of these approaches have been the use of Peer Education, outreaches, a musical concert in 2004 that brought together over 50, 000 Ghanaians, door to door and the use of media such as radio and social media. As a result, many have therefore been able to make informed choices to ensure health and wellbeing. WAAF continues to work towards promoting Enhanced knowledge on HIV/AIDS, TB, STI’s as well as  non-communicable diseases and more
Changing attitudes and behaviours surrounding infections
Encouragement to the general population, youth, adolescents and members of key populations about adopting a healthy lifestyle for the prevention and control of Infectious Diseases.', CAST(N'2019-05-19T13:14:57.473' AS DateTime), 1, 0)
INSERT [dbo].[tbl_OurAchievements] ([PK_ID], [Name], [Picture], [Description], [DateTime], [Active], [Deleted]) VALUES (3, N'PMTCT', N'52271045ss.jpg', N'Prevention of Mother to Child Transmission started in 2007 with support from the National AIDS Control Programme. Since then, thousands of women have and continue to benefit from this intervention both at the community and the clinic level where women are taken through counselling and testing, enrolled onto medicines (ARVs) if positive ,  babies tested as early as six weeks through Early Infant Diagnosis (EIDs), promotion of  safe breast feeding options.', CAST(N'2019-05-19T13:02:27.850' AS DateTime), 1, 0)
INSERT [dbo].[tbl_OurAchievements] ([PK_ID], [Name], [Picture], [Description], [DateTime], [Active], [Deleted]) VALUES (1002, N'Access to Treatment, Care and Support', N'1993023508Untitled.png', N'Through innovative means, WAAF continues to contribute to making health care accessible to all. Some of the approaches are: Community outreaches, use of Mobile Clinic ( VAN),  Working at Drop in Centers, integration of services and strong collaborations with various stakeholders at various levels.

WAAF’s onsite clinic continues to retain a patient cohort of over 1300 HIV positive clients. In addition, over 150 TB patients have received treatment and counselling at the onsite clinic.', CAST(N'2019-05-19T14:11:31.643' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_OurAchievements] OFF
SET IDENTITY_INSERT [dbo].[tbl_Partner] ON 

INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (1, N'The Edhi Foundation', N'https://www.edhi.org', N'edhi.jpg', N'Edhi Foundation is the single best foundation across Pakistan and one of the best social welfare service providers across the world running on non-commercial, non-political, and non-communal basis, serving round-the-clock without any discrimination of color, class, and creed is enjoying exclusive credentials in the shape of awards and shields conferred upon Mr. Abdul Sattar Edhi and Mrs. Bilquis Edhi by governmental and non-governmental organizations on national and international level for rendering their exemplary services to humanity in multidimensional fields.

The diversified fields in which Abdul Sattar Edhi played his greatest role for; saving the lives of thousands of newborn babies by placing the cradles outside the Edhi centres, fostering the abandoned babies and children, free nurturing disabled and handicapped people, free caring and feeding women and elderly people who were subjected to torture or neglected by their families, free supporting to ailing patients by providing free medication and medicines through his mobile dispensaries, hospitals, and the diabetic centre at Karachi.

In addition to above, he offered his services in many other areas—like providing land, air, and marine ambulance services during accidents to shift patients to hospitals, national and international relief and aid assistance to the affectees of natural debacles, providing relief aid to refugees in various countries, providing emergency services to the sufferers of drought, fire, and flood, saving the lives of drowned people added with recovering dead bodies from the seas and floods, free rehabilitating the drug addicts, free tracing the missing people, free arranging marriages for the helpless girls and boys, providing free food, clothing, and blankets to needy people.', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (2, N'Saylani Welfare', N'http://saylaniwelfare.com/', N'saylani.jpg', N'Established in May 1999 by famous spiritual and religious scholar Maulana Bashir Ahmed Farooqui, Saylani Welfare International Trust was built on the fundamentals of breaking the cycle of poverty, alleviating the financial troubles of the poor, giving people a chance to live a dignified life and spreading happiness. 

We are an organization that believes in lighting up the lives of underprivileged people across the world. We endeavor to provide the best quality services in areas including food, education, medical and social welfare free of cost to people living in the dark. With over 60 different sectors, we feed thousands of hungry people each day, hundreds more are given the hope of life through medical health care, many are educated to become leaders of tomorrow and several are given the opportunity to stand on their feet financially. 

Today, we are proud to say that our physical presence extends throughout Pakistan with a vast network of 125 branches operating in major cities including Karachi, Lahore, Islamabad, Rawalpindi, Hyderabad and Faisalabad. Apart from Pakistan, we have overseas offices in the UK, USA and UAE as well. Our worldwide branches are operating under the guidance of a team of over 2,000 working professionals who help almost 125,000 people on a daily basis. 

We strongly believe that a little help goes a long way and our work would not be possible without the generous support of our valuable donors. Our local and international donors have graciously lent us a hand by supporting our causes and enabling us to serve the needs of people in need.', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (3, N'Direct Relief', N'https://www.directrelief.org', N'2009875855directrelief.jpg', N'Direct Relief is a humanitarian aid organization, active in all 50 states and more than 80 countries, with a mission to improve the health and lives of people affected by poverty or emergencies – without regard to politics, religion, or ability to pay. Direct Relief''s assistance programs are tailored to the particular circumstances and needs of the world''s most vulnerable and at-risk populations. This tradition of direct and targeted assistance, provided in a manner that respects and involves the people served, has been a hallmark of the organization since its founding in 1948 by refugee war immigrants to the U.S. irect Relief’s work earns wide recognition from independent charity rating agencies and watchdogs, including a 100% fundraising efficiency rating from Forbes, the No. 1 spot on Charity Navigator’s list of the “10 Best Charities Everyone’s Heard Of,” and inclusion in Fast Company’s list of “the world’s most innovative nonprofits.”  >>> awards, ratings, and recognition', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (4, N'Children’s Miracle Network Hospitals', N'https://childrensmiraclenetworkhospitals.org/', N'2035293315ChildrensMiracleHospitalsNetwork.jpg', N'More than 10 million kids enter a children’s hospital like your local children''s hospital across North America every year. To provide the best care for kids, children’s hospitals rely on donations and community support, as Medicaid and insurance programs do not fully cover the cost of care. Since 1983, Children’s Miracle Network Hospitals has helped fill those funding gaps by raising more than $5 billion, most of it $1 at a time through Miracle Balloon icon campaigns. Its various fundraising partners and programs support the nonprofit’s mission to save and improve the lives of as many children as possible.', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (5, N'UNO', N'saylani.org', N'50976838_2252632378399531_3019831977294430208_o.jpg', N'UNO', NULL, NULL)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (6, N'New York City Ballet', N'https://www.nycballet.com', N'632765032NRDC.jpg', N'New York City Ballet is one of the foremost dance companies in the world, with a roster of spectacular dancers and an unparalleled repertory. The Company was founded in 1948 by George Balanchine and Lincoln Kirstein, and it quickly became world-renowned for its athletic and contemporary style. Jerome Robbins joined NYCB the following year and, with Balanchine, helped to build the astounding repertory and firmly establish the Company in New York. 
 
New York City Ballet owes its existence to Lincoln Kirstein, who envisioned an American ballet where young dancers could be trained and schooled under the guidance of the greatest ballet masters. When he met George Balanchine in London in 1933, Kirstein knew he had found the right person for his dream. Balanchine traveled to America at Kirstein’s invitation, and in 1934 the two men opened the School of American Ballet, where Balanchine trained dancers in an innovative style and technique that matched his idea of a new, unmannered classicism.', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (1002, N'NRDC', N'https://www.nrdc.org', N'1420983852NewYorkCityBallet.jpg', N'NRDC works to safeguard the earth—its people, its plants and animals, and the natural systems on which all life depends.
We combine the power of more than three million members and online activists with the expertise of some 600 scientists, lawyers, and policy advocates across the globe to ensure the rights of all people to the air, the water, and the wild. ', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (1003, N'mom', N'omo', N'IMG-20190405-WA0026.jpg', N'mom', 1, 0)
INSERT [dbo].[tbl_Partner] ([PK_ID], [PartnerName], [Website], [Logo], [Description], [Active], [Deleted]) VALUES (2002, N'Cancer Research UK', N'https://www.cancerresearchuk.org', N'1846282518cancerresearchuk.jpg', N'Cancer Research UK is the world''s largest cancer charity dedicated to saving lives through research. Our vision is to bring forward the day when all cancers are cured, from the most common types to those that affect just a few people.

In our Annual Review, we share some of the ways our life-saving work is helping more people survive cancer than ever before.', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Partner] OFF
SET IDENTITY_INSERT [dbo].[tbl_Position] ON 

INSERT [dbo].[tbl_Position] ([PK_ID], [PositionName], [Active], [Deleted]) VALUES (1, N'CEO', 1, 0)
INSERT [dbo].[tbl_Position] ([PK_ID], [PositionName], [Active], [Deleted]) VALUES (2, N'Volunteer', 1, 0)
INSERT [dbo].[tbl_Position] ([PK_ID], [PositionName], [Active], [Deleted]) VALUES (3, N'Contributor', 1, 0)
INSERT [dbo].[tbl_Position] ([PK_ID], [PositionName], [Active], [Deleted]) VALUES (4, N'Collaborator', 1, 0)
INSERT [dbo].[tbl_Position] ([PK_ID], [PositionName], [Active], [Deleted]) VALUES (5, N'Communicator', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Position] OFF
SET IDENTITY_INSERT [dbo].[tbl_QnA] ON 

INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (1, 5, N'How long does it take to adopt a child from Pakistan?', N'If you are adopting an infant from Edhi, the whole process from the time you submit an application to when you can bring the baby home takes 10-15 months in most cases. This time is based largely on the agency from which you are adopting and their referral times. It typically takes 3-6 months for the in-country process, from the time you receive custody of the baby till you get the immigration paperwork completed and get the child’s visa.', CAST(N'2019-05-02T17:25:43.977' AS DateTime), 1, 0)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (2, 5, N'What is the purpose of GiveAid?', N'There is an urgent need to increase the organization that helps the helpers and the needy both and to help those who are experiencing poverty and education problems and many more. GiveAid plans to be a catalyst for change. Starting by bringing global Non Goveronment Organizations together to plan innovations in advanced way to get donations, and investigating how to support the needy and working on the most effective ways to build homes for homelesses.
', CAST(N'2019-05-02T17:30:21.037' AS DateTime), 1, 0)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (3, 5, N'How can I get more involved?', N'Please help us campaign for policy change and start a movement to end the problems of poor and needy by providing them good food, good shelter, well-arranged education, and many more essential stuff to live a life happily. Please donate to support our work.', CAST(N'2019-05-02T17:32:39.153' AS DateTime), 0, 1)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (11, 5, N'query check', N'nhdashn', CAST(N'2019-05-16T11:39:56.980' AS DateTime), 0, 1)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (12, 1005, N'hi', N'bbbbbb', CAST(N'2019-05-16T23:50:18.250' AS DateTime), 0, 1)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (14, 5, N'What is UNICEF''s position on international adoption?', NULL, CAST(N'2019-05-19T15:19:18.620' AS DateTime), 0, 1)
INSERT [dbo].[tbl_QnA] ([PK_ID], [FK_User], [Question], [Answer], [DateTime], [Active], [Deleted]) VALUES (15, 5, N'What is GiveAid''s position on international adoption?', N'As a global organization devoted to the survival and well-being of children, GiveAid is working to create a world in which no child is ever institutionalized, bought or sold, stolen from a family or otherwise victimized. GiveAid believes that every child deserves to grow up in a loving family and supports inter-country adoption when conducted ethically in accordance with prevailing law and best practices. At the same time, GiveAid works to support families in need so that no one ever feels forced by poverty or insecurity to give up a child. To focus on only one of those things, and not the others, is not in the best interests of children.', CAST(N'2019-05-19T15:20:06.470' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_QnA] OFF
SET IDENTITY_INSERT [dbo].[tbl_TeamMember] ON 

INSERT [dbo].[tbl_TeamMember] ([PK_ID], [Name], [FK_Position], [Picture], [Description], [Active], [Deleted]) VALUES (1, N'Andy Florence', 1, N'Andy.jpg', N'Andy Florence is one of the best volunteers', 1, 0)
INSERT [dbo].[tbl_TeamMember] ([PK_ID], [Name], [FK_Position], [Picture], [Description], [Active], [Deleted]) VALUES (2, N'Shahid Afridi', 1, N'shahidafridi.jpeg', N'Shahid Afridi is a former Pakistani cricketer', 1, 0)
INSERT [dbo].[tbl_TeamMember] ([PK_ID], [Name], [FK_Position], [Picture], [Description], [Active], [Deleted]) VALUES (3, N'Iqrar Ul Hassan', 1, N'iqrarulhassan.jpeg', N'Iqrar ul Hassan is a Jonralist at ARY', 1, 0)
INSERT [dbo].[tbl_TeamMember] ([PK_ID], [Name], [FK_Position], [Picture], [Description], [Active], [Deleted]) VALUES (4, N'Muniba Mazari', 1, N'munibamazari.jpeg', N'Muniba Mazari is a Women Ambassador at UNO', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_TeamMember] OFF
SET IDENTITY_INSERT [dbo].[tbl_User] ON 

INSERT [dbo].[tbl_User] ([PK_ID], [FullName], [Picture], [Email], [Password], [FK_UserType], [Active], [Deleted]) VALUES (4, N'Shehzad', N'Shehzad.jpg', N'Sh@mail.com', N'123', 1, 1, 0)
INSERT [dbo].[tbl_User] ([PK_ID], [FullName], [Picture], [Email], [Password], [FK_UserType], [Active], [Deleted]) VALUES (5, N'Umair', N'umair.jpg', N'umair@mail.com', N'123', 3, 1, 0)
INSERT [dbo].[tbl_User] ([PK_ID], [FullName], [Picture], [Email], [Password], [FK_UserType], [Active], [Deleted]) VALUES (1005, N'Sheh', NULL, N'hu@mail.com', N'123', 3, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_User] OFF
SET IDENTITY_INSERT [dbo].[tbl_UserType] ON 

INSERT [dbo].[tbl_UserType] ([PK_ID], [UserTypeName], [Active], [Deleted]) VALUES (1, N'Admin', 1, 0)
INSERT [dbo].[tbl_UserType] ([PK_ID], [UserTypeName], [Active], [Deleted]) VALUES (3, N'User', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_UserType] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__tbl_NGO__5C7E359E50328764]    Script Date: 20/05/2019 9:01:08 AM ******/
ALTER TABLE [dbo].[tbl_NGO] ADD UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__tbl_User__A9D10534564D980A]    Script Date: 20/05/2019 9:01:08 AM ******/
ALTER TABLE [dbo].[tbl_User] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Donation]  WITH CHECK ADD FOREIGN KEY([FK_DonationCause])
REFERENCES [dbo].[tbl_DonationCause] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_Donation]  WITH CHECK ADD FOREIGN KEY([FK_NGO])
REFERENCES [dbo].[tbl_NGO] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_Donation]  WITH CHECK ADD FOREIGN KEY([FK_User])
REFERENCES [dbo].[tbl_User] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_DonationCauseNGO]  WITH CHECK ADD FOREIGN KEY([FK_DonationCause])
REFERENCES [dbo].[tbl_DonationCause] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_DonationCauseNGO]  WITH CHECK ADD FOREIGN KEY([FK_NGO])
REFERENCES [dbo].[tbl_NGO] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_IntrestActivities]  WITH CHECK ADD FOREIGN KEY([FK_User])
REFERENCES [dbo].[tbl_User] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_NGO]  WITH CHECK ADD FOREIGN KEY([Fk_DonationCause])
REFERENCES [dbo].[tbl_DonationCause] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_QnA]  WITH CHECK ADD FOREIGN KEY([FK_User])
REFERENCES [dbo].[tbl_User] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_TeamMember]  WITH CHECK ADD FOREIGN KEY([FK_Position])
REFERENCES [dbo].[tbl_Position] ([PK_ID])
GO
ALTER TABLE [dbo].[tbl_User]  WITH CHECK ADD FOREIGN KEY([FK_UserType])
REFERENCES [dbo].[tbl_UserType] ([PK_ID])
GO
USE [master]
GO
ALTER DATABASE [db_GiveAidPro] SET  READ_WRITE 
GO
