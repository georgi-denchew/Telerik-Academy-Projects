
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/13/2013 02:04:16
-- Generated from EDMX file: E:\GitHub\Telerik-Academy-Projects\ASP.Net WebForms\06.DataSourceControls\PlanetWebApplication\PlanetModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PlanetDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Countries_Continents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Countries] DROP CONSTRAINT [FK_Countries_Continents];
GO
IF OBJECT_ID(N'[dbo].[FK_Countries_Languages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Countries] DROP CONSTRAINT [FK_Countries_Languages];
GO
IF OBJECT_ID(N'[dbo].[FK_Towns_Countries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Towns] DROP CONSTRAINT [FK_Towns_Countries];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Continents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Continents];
GO
IF OBJECT_ID(N'[dbo].[Countries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Countries];
GO
IF OBJECT_ID(N'[dbo].[Languages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Languages];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Towns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Towns];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Continents'
CREATE TABLE [dbo].[Continents] (
    [ContinentID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [LanguageId] int  NULL,
    [Population] int  NULL,
    [ContinentID] int  NULL,
    [Flag] varbinary(max)  NULL
);
GO

-- Creating table 'Languages'
CREATE TABLE [dbo].[Languages] (
    [LanguageID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Towns'
CREATE TABLE [dbo].[Towns] (
    [TownID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Population] int  NULL,
    [CountryID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ContinentID] in table 'Continents'
ALTER TABLE [dbo].[Continents]
ADD CONSTRAINT [PK_Continents]
    PRIMARY KEY CLUSTERED ([ContinentID] ASC);
GO

-- Creating primary key on [CountryID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryID] ASC);
GO

-- Creating primary key on [LanguageID] in table 'Languages'
ALTER TABLE [dbo].[Languages]
ADD CONSTRAINT [PK_Languages]
    PRIMARY KEY CLUSTERED ([LanguageID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TownID] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [PK_Towns]
    PRIMARY KEY CLUSTERED ([TownID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContinentID] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [FK_Countries_Continents]
    FOREIGN KEY ([ContinentID])
    REFERENCES [dbo].[Continents]
        ([ContinentID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Countries_Continents'
CREATE INDEX [IX_FK_Countries_Continents]
ON [dbo].[Countries]
    ([ContinentID]);
GO

-- Creating foreign key on [LanguageId] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [FK_Countries_Languages]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[Languages]
        ([LanguageID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Countries_Languages'
CREATE INDEX [IX_FK_Countries_Languages]
ON [dbo].[Countries]
    ([LanguageId]);
GO

-- Creating foreign key on [CountryID] in table 'Towns'
ALTER TABLE [dbo].[Towns]
ADD CONSTRAINT [FK_Towns_Countries]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[Countries]
        ([CountryID])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Towns_Countries'
CREATE INDEX [IX_FK_Towns_Countries]
ON [dbo].[Towns]
    ([CountryID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------