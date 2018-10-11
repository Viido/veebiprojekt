
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2018 20:49:57
-- Generated from EDMX file: D:\Kool\Tartu ülikool veebirakenduste loomine\Veebiprojekt tiimiga\veebiprojekt\TeamEVotingWebSiteSolution\TeamEVotingWebSite\Models\TeamEVotingDatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TeamEVotingDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CandidateRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CandidateSet] DROP CONSTRAINT [FK_CandidateRegion];
GO
IF OBJECT_ID(N'[dbo].[FK_CandidateUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_CandidateUser];
GO
IF OBJECT_ID(N'[dbo].[FK_FactionCandidate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CandidateSet] DROP CONSTRAINT [FK_FactionCandidate];
GO
IF OBJECT_ID(N'[dbo].[FK_FactionFactionRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactionRegionSet] DROP CONSTRAINT [FK_FactionFactionRegion];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionFactionRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactionRegionSet] DROP CONSTRAINT [FK_RegionFactionRegion];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CandidateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CandidateSet];
GO
IF OBJECT_ID(N'[dbo].[FactionRegionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactionRegionSet];
GO
IF OBJECT_ID(N'[dbo].[FactionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactionSet];
GO
IF OBJECT_ID(N'[dbo].[RegionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[VisitorInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisitorInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CandidateSet'
CREATE TABLE [dbo].[CandidateSet] (
    [Candidate_Id] int IDENTITY(1,1) NOT NULL,
    [Candidate_FirstName] nvarchar(500)  NOT NULL,
    [Candidate_Age] int  NOT NULL,
    [Region_Id] int  NOT NULL,
    [Faction_Id] int  NOT NULL,
    [NumberOfVotes] int  NULL,
    [Candidate_LastName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'FactionSet'
CREATE TABLE [dbo].[FactionSet] (
    [Faction_Id] int IDENTITY(1,1) NOT NULL,
    [Faction_Name] nvarchar(max)  NOT NULL,
    [NumberOfMembers] int  NOT NULL
);
GO

-- Creating table 'RegionSet'
CREATE TABLE [dbo].[RegionSet] (
    [Region_Id] int IDENTITY(1,1) NOT NULL,
    [Region_Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [User_Id] int IDENTITY(1,1) NOT NULL,
    [User_FirstName] nvarchar(max)  NOT NULL,
    [User_LastName] nvarchar(max)  NOT NULL,
    [Candidate_Id] int  NOT NULL,
    [User_Email] nvarchar(max)  NULL
);
GO

-- Creating table 'VisitorInfo'
CREATE TABLE [dbo].[VisitorInfo] (
    [Visitor_Id] int  NOT NULL,
    [VisitorLandingPage] nvarchar(max)  NULL,
    [VisitorBrowser] nvarchar(max)  NULL,
    [VisitorIP] nvarchar(max)  NULL,
    [Visited_DateTime] datetime  NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'FactionRegionSet'
CREATE TABLE [dbo].[FactionRegionSet] (
    [FactionSet_Faction_Id] int  NOT NULL,
    [RegionSet_Region_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Candidate_Id] in table 'CandidateSet'
ALTER TABLE [dbo].[CandidateSet]
ADD CONSTRAINT [PK_CandidateSet]
    PRIMARY KEY CLUSTERED ([Candidate_Id] ASC);
GO

-- Creating primary key on [Faction_Id] in table 'FactionSet'
ALTER TABLE [dbo].[FactionSet]
ADD CONSTRAINT [PK_FactionSet]
    PRIMARY KEY CLUSTERED ([Faction_Id] ASC);
GO

-- Creating primary key on [Region_Id] in table 'RegionSet'
ALTER TABLE [dbo].[RegionSet]
ADD CONSTRAINT [PK_RegionSet]
    PRIMARY KEY CLUSTERED ([Region_Id] ASC);
GO

-- Creating primary key on [User_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([User_Id] ASC);
GO

-- Creating primary key on [Visitor_Id] in table 'VisitorInfo'
ALTER TABLE [dbo].[VisitorInfo]
ADD CONSTRAINT [PK_VisitorInfo]
    PRIMARY KEY CLUSTERED ([Visitor_Id] ASC);
GO

-- Creating primary key on [FactionSet_Faction_Id], [RegionSet_Region_Id] in table 'FactionRegionSet'
ALTER TABLE [dbo].[FactionRegionSet]
ADD CONSTRAINT [PK_FactionRegionSet]
    PRIMARY KEY CLUSTERED ([FactionSet_Faction_Id], [RegionSet_Region_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Region_Id] in table 'CandidateSet'
ALTER TABLE [dbo].[CandidateSet]
ADD CONSTRAINT [FK_CandidateRegion]
    FOREIGN KEY ([Region_Id])
    REFERENCES [dbo].[RegionSet]
        ([Region_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CandidateRegion'
CREATE INDEX [IX_FK_CandidateRegion]
ON [dbo].[CandidateSet]
    ([Region_Id]);
GO

-- Creating foreign key on [Candidate_Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_CandidateUser]
    FOREIGN KEY ([Candidate_Id])
    REFERENCES [dbo].[CandidateSet]
        ([Candidate_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CandidateUser'
CREATE INDEX [IX_FK_CandidateUser]
ON [dbo].[UserSet]
    ([Candidate_Id]);
GO

-- Creating foreign key on [Faction_Id] in table 'CandidateSet'
ALTER TABLE [dbo].[CandidateSet]
ADD CONSTRAINT [FK_FactionCandidate]
    FOREIGN KEY ([Faction_Id])
    REFERENCES [dbo].[FactionSet]
        ([Faction_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactionCandidate'
CREATE INDEX [IX_FK_FactionCandidate]
ON [dbo].[CandidateSet]
    ([Faction_Id]);
GO

-- Creating foreign key on [FactionSet_Faction_Id] in table 'FactionRegionSet'
ALTER TABLE [dbo].[FactionRegionSet]
ADD CONSTRAINT [FK_FactionRegionSet_FactionSet]
    FOREIGN KEY ([FactionSet_Faction_Id])
    REFERENCES [dbo].[FactionSet]
        ([Faction_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RegionSet_Region_Id] in table 'FactionRegionSet'
ALTER TABLE [dbo].[FactionRegionSet]
ADD CONSTRAINT [FK_FactionRegionSet_RegionSet]
    FOREIGN KEY ([RegionSet_Region_Id])
    REFERENCES [dbo].[RegionSet]
        ([Region_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactionRegionSet_RegionSet'
CREATE INDEX [IX_FK_FactionRegionSet_RegionSet]
ON [dbo].[FactionRegionSet]
    ([RegionSet_Region_Id]);
GO

-- Creating foreign key on [User_Id] in table 'VisitorInfo'
ALTER TABLE [dbo].[VisitorInfo]
ADD CONSTRAINT [FK_UserSetVisitorInfo]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([User_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSetVisitorInfo'
CREATE INDEX [IX_FK_UserSetVisitorInfo]
ON [dbo].[VisitorInfo]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------