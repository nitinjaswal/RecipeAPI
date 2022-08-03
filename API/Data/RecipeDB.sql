USE [RecipeDb_D1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26-07-2022 17:15:57 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 26-07-2022 17:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[IngredientName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 26-07-2022 17:15:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) NOT NULL,
	[IsVeg] [bit] NOT NULL,
	[Servings] [int] NOT NULL,
	[Instructions] [nvarchar](500) NOT NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdatedDateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220721033643_initial', N'6.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220721122752_addeddatecolumns', N'6.0.7')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220721161322_datecolumnsrequired', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[Ingredient] ON 
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2002, 2005, N'beef roast with olive oil')
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2003, 2005, N'dried Italian salad dressing mix')
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2004, 2005, N'Dry fruits')
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2005, 2006, N'olive oil')
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2006, 2006, N'asparagus')
GO
INSERT [dbo].[Ingredient] ([Id], [RecipeID], [IngredientName]) VALUES (2007, 2006, N'kosher salt')
GO
SET IDENTITY_INSERT [dbo].[Ingredient] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipe] ON 
GO
INSERT [dbo].[Recipe] ([Id], [RecipeName], [IsVeg], [Servings], [Instructions], [CreatedDateTime], [IsActive], [UpdatedDateTime]) VALUES (2005, N'Crock Pot Roast', 0, 1, N'Place beef roast in the crock pot. Mix the dried mixes together in a bowl and sprinkle over the roast', CAST(N'2022-07-26T15:20:23.3370218' AS DateTime2), 1, CAST(N'2022-07-26T15:25:09.9198930' AS DateTime2))
GO
INSERT [dbo].[Recipe] ([Id], [RecipeName], [IsVeg], [Servings], [Instructions], [CreatedDateTime], [IsActive], [UpdatedDateTime]) VALUES (2006, N'Roasted Asparagus', 1, 4, N'Preheat oven to 425°F.Cut off the woody bottom part of the asparagus spears and discard. With a vegetable peeler, peel off the skin on the bottom 2-3 inches of the spears', CAST(N'2022-07-26T15:31:17.4772956' AS DateTime2), 1, CAST(N'2022-07-26T15:31:17.4772987' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Recipe] OFF
GO
ALTER TABLE [dbo].[Recipe] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Recipe] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Recipe] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_Ingredient_Recipe_RecipeID] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_Ingredient_Recipe_RecipeID]
GO
