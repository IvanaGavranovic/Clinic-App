
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/01/2022 21:43:07
-- Generated from EDMX file: C:\Users\ivana\Desktop\MVVM-Clinic\MVVM-Clinic-master\ConsoleApp2\ClinicModelV2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ClinicDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KlinikaDepartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Departmen] DROP CONSTRAINT [FK_KlinikaDepartman];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorDepartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Doktor] DROP CONSTRAINT [FK_DoktorDepartman];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentDepartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Pacijent] DROP CONSTRAINT [FK_PacijentDepartman];
GO
IF OBJECT_ID(N'[dbo].[FK_PregledTermin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleds] DROP CONSTRAINT [FK_PregledTermin];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleds] DROP CONSTRAINT [FK_PacijentPregled];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorPregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleds] DROP CONSTRAINT [FK_DoktorPregled];
GO
IF OBJECT_ID(N'[dbo].[FK_Ishod_PregledaPregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleds] DROP CONSTRAINT [FK_Ishod_PregledaPregled];
GO
IF OBJECT_ID(N'[dbo].[FK_DijagnozaTerapija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Terapijas] DROP CONSTRAINT [FK_DijagnozaTerapija];
GO
IF OBJECT_ID(N'[dbo].[FK_UputPregled_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregled_Specijaliste] DROP CONSTRAINT [FK_UputPregled_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorPregled_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregled_Specijaliste] DROP CONSTRAINT [FK_DoktorPregled_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorPregled_Specijaliste1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregled_Specijaliste] DROP CONSTRAINT [FK_DoktorPregled_Specijaliste1];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPregled_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregled_Specijaliste] DROP CONSTRAINT [FK_PacijentPregled_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_Pregled_SpecijalisteIshod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda] DROP CONSTRAINT [FK_Pregled_SpecijalisteIshod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_Termin_SpecijalistePregled_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregled_Specijaliste] DROP CONSTRAINT [FK_Termin_SpecijalistePregled_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_inherits_Korisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Doktor] DROP CONSTRAINT [FK_Doktor_inherits_Korisnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Pacijent_inherits_Korisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Pacijent] DROP CONSTRAINT [FK_Pacijent_inherits_Korisnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Dijagnoza_inherits_Ishod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza] DROP CONSTRAINT [FK_Dijagnoza_inherits_Ishod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_Uput_inherits_Ishod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda_Uput] DROP CONSTRAINT [FK_Uput_inherits_Ishod_Pregleda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Korisniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks];
GO
IF OBJECT_ID(N'[dbo].[Klinikas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klinikas];
GO
IF OBJECT_ID(N'[dbo].[Departmen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departmen];
GO
IF OBJECT_ID(N'[dbo].[Termins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Termins];
GO
IF OBJECT_ID(N'[dbo].[Pregleds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregleds];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[Terapijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terapijas];
GO
IF OBJECT_ID(N'[dbo].[Pregled_Specijaliste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregled_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[Termin_Specijaliste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Termin_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[Korisniks_Doktor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks_Doktor];
GO
IF OBJECT_ID(N'[dbo].[Korisniks_Pacijent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda_Dijagnoza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda_Dijagnoza];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda_Uput]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda_Uput];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Korisniks'
CREATE TABLE [dbo].[Korisniks] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Klinikas'
CREATE TABLE [dbo].[Klinikas] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Departmen'
CREATE TABLE [dbo].[Departmen] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Klinika_Id] int  NULL
);
GO

-- Creating table 'Termins'
CREATE TABLE [dbo].[Termins] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Pregleds'
CREATE TABLE [dbo].[Pregleds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Termins_Id] int  NULL,
    [Pacijent_Id] int  NULL,
    [Doktor_Id] int  NOT NULL,
    [Ishod_Pregleda_Id] int  NULL
);
GO

-- Creating table 'Ishod_Pregleda'
CREATE TABLE [dbo].[Ishod_Pregleda] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pregled_Specijaliste1_Id] int  NULL
);
GO

-- Creating table 'Terapijas'
CREATE TABLE [dbo].[Terapijas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Dijagnoza_Id] int  NULL
);
GO

-- Creating table 'Pregled_Specijaliste'
CREATE TABLE [dbo].[Pregled_Specijaliste] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Uput_Id] int  NOT NULL,
    [Doktor_Specijalista_Id] int  NULL,
    [Doktor_Opste_Prakse_Id] int  NULL,
    [Pacijent_Id] int  NULL,
    [Termin_Specijaliste_Id] int  NULL
);
GO

-- Creating table 'Termin_Specijaliste'
CREATE TABLE [dbo].[Termin_Specijaliste] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Korisniks_Doktor'
CREATE TABLE [dbo].[Korisniks_Doktor] (
    [Specijalizacija] nvarchar(max)  NULL,
    [Id] int  NOT NULL,
    [Departmen_Id] int  NULL
);
GO

-- Creating table 'Korisniks_Pacijent'
CREATE TABLE [dbo].[Korisniks_Pacijent] (
    [Id] int  NOT NULL,
    [Departmen_Id] int  NULL
);
GO

-- Creating table 'Ishod_Pregleda_Dijagnoza'
CREATE TABLE [dbo].[Ishod_Pregleda_Dijagnoza] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Ishod_Pregleda_Uput'
CREATE TABLE [dbo].[Ishod_Pregleda_Uput] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Korisniks'
ALTER TABLE [dbo].[Korisniks]
ADD CONSTRAINT [PK_Korisniks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Klinikas'
ALTER TABLE [dbo].[Klinikas]
ADD CONSTRAINT [PK_Klinikas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Departmen'
ALTER TABLE [dbo].[Departmen]
ADD CONSTRAINT [PK_Departmen]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Termins'
ALTER TABLE [dbo].[Termins]
ADD CONSTRAINT [PK_Termins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [PK_Pregleds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ishod_Pregleda'
ALTER TABLE [dbo].[Ishod_Pregleda]
ADD CONSTRAINT [PK_Ishod_Pregleda]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Terapijas'
ALTER TABLE [dbo].[Terapijas]
ADD CONSTRAINT [PK_Terapijas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [PK_Pregled_Specijaliste]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Termin_Specijaliste'
ALTER TABLE [dbo].[Termin_Specijaliste]
ADD CONSTRAINT [PK_Termin_Specijaliste]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Korisniks_Doktor'
ALTER TABLE [dbo].[Korisniks_Doktor]
ADD CONSTRAINT [PK_Korisniks_Doktor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Korisniks_Pacijent'
ALTER TABLE [dbo].[Korisniks_Pacijent]
ADD CONSTRAINT [PK_Korisniks_Pacijent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ishod_Pregleda_Dijagnoza'
ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza]
ADD CONSTRAINT [PK_Ishod_Pregleda_Dijagnoza]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ishod_Pregleda_Uput'
ALTER TABLE [dbo].[Ishod_Pregleda_Uput]
ADD CONSTRAINT [PK_Ishod_Pregleda_Uput]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Klinika_Id] in table 'Departmen'
ALTER TABLE [dbo].[Departmen]
ADD CONSTRAINT [FK_KlinikaDepartman]
    FOREIGN KEY ([Klinika_Id])
    REFERENCES [dbo].[Klinikas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlinikaDepartman'
CREATE INDEX [IX_FK_KlinikaDepartman]
ON [dbo].[Departmen]
    ([Klinika_Id]);
GO

-- Creating foreign key on [Departmen_Id] in table 'Korisniks_Doktor'
ALTER TABLE [dbo].[Korisniks_Doktor]
ADD CONSTRAINT [FK_DoktorDepartman]
    FOREIGN KEY ([Departmen_Id])
    REFERENCES [dbo].[Departmen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorDepartman'
CREATE INDEX [IX_FK_DoktorDepartman]
ON [dbo].[Korisniks_Doktor]
    ([Departmen_Id]);
GO

-- Creating foreign key on [Departmen_Id] in table 'Korisniks_Pacijent'
ALTER TABLE [dbo].[Korisniks_Pacijent]
ADD CONSTRAINT [FK_PacijentDepartman]
    FOREIGN KEY ([Departmen_Id])
    REFERENCES [dbo].[Departmen]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentDepartman'
CREATE INDEX [IX_FK_PacijentDepartman]
ON [dbo].[Korisniks_Pacijent]
    ([Departmen_Id]);
GO

-- Creating foreign key on [Termins_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [FK_PregledTermin]
    FOREIGN KEY ([Termins_Id])
    REFERENCES [dbo].[Termins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PregledTermin'
CREATE INDEX [IX_FK_PregledTermin]
ON [dbo].[Pregleds]
    ([Termins_Id]);
GO

-- Creating foreign key on [Pacijent_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [FK_PacijentPregled]
    FOREIGN KEY ([Pacijent_Id])
    REFERENCES [dbo].[Korisniks_Pacijent]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentPregled'
CREATE INDEX [IX_FK_PacijentPregled]
ON [dbo].[Pregleds]
    ([Pacijent_Id]);
GO

-- Creating foreign key on [Doktor_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [FK_DoktorPregled]
    FOREIGN KEY ([Doktor_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorPregled'
CREATE INDEX [IX_FK_DoktorPregled]
ON [dbo].[Pregleds]
    ([Doktor_Id]);
GO

-- Creating foreign key on [Ishod_Pregleda_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [FK_Ishod_PregledaPregled]
    FOREIGN KEY ([Ishod_Pregleda_Id])
    REFERENCES [dbo].[Ishod_Pregleda]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Ishod_PregledaPregled'
CREATE INDEX [IX_FK_Ishod_PregledaPregled]
ON [dbo].[Pregleds]
    ([Ishod_Pregleda_Id]);
GO

-- Creating foreign key on [Dijagnoza_Id] in table 'Terapijas'
ALTER TABLE [dbo].[Terapijas]
ADD CONSTRAINT [FK_DijagnozaTerapija]
    FOREIGN KEY ([Dijagnoza_Id])
    REFERENCES [dbo].[Ishod_Pregleda_Dijagnoza]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DijagnozaTerapija'
CREATE INDEX [IX_FK_DijagnozaTerapija]
ON [dbo].[Terapijas]
    ([Dijagnoza_Id]);
GO

-- Creating foreign key on [Uput_Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [FK_UputPregled_Specijaliste]
    FOREIGN KEY ([Uput_Id])
    REFERENCES [dbo].[Ishod_Pregleda_Uput]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UputPregled_Specijaliste'
CREATE INDEX [IX_FK_UputPregled_Specijaliste]
ON [dbo].[Pregled_Specijaliste]
    ([Uput_Id]);
GO

-- Creating foreign key on [Doktor_Specijalista_Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [FK_DoktorPregled_Specijaliste]
    FOREIGN KEY ([Doktor_Specijalista_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorPregled_Specijaliste'
CREATE INDEX [IX_FK_DoktorPregled_Specijaliste]
ON [dbo].[Pregled_Specijaliste]
    ([Doktor_Specijalista_Id]);
GO

-- Creating foreign key on [Doktor_Opste_Prakse_Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [FK_DoktorPregled_Specijaliste1]
    FOREIGN KEY ([Doktor_Opste_Prakse_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorPregled_Specijaliste1'
CREATE INDEX [IX_FK_DoktorPregled_Specijaliste1]
ON [dbo].[Pregled_Specijaliste]
    ([Doktor_Opste_Prakse_Id]);
GO

-- Creating foreign key on [Pacijent_Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [FK_PacijentPregled_Specijaliste]
    FOREIGN KEY ([Pacijent_Id])
    REFERENCES [dbo].[Korisniks_Pacijent]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentPregled_Specijaliste'
CREATE INDEX [IX_FK_PacijentPregled_Specijaliste]
ON [dbo].[Pregled_Specijaliste]
    ([Pacijent_Id]);
GO

-- Creating foreign key on [Pregled_Specijaliste1_Id] in table 'Ishod_Pregleda'
ALTER TABLE [dbo].[Ishod_Pregleda]
ADD CONSTRAINT [FK_Pregled_SpecijalisteIshod_Pregleda]
    FOREIGN KEY ([Pregled_Specijaliste1_Id])
    REFERENCES [dbo].[Pregled_Specijaliste]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pregled_SpecijalisteIshod_Pregleda'
CREATE INDEX [IX_FK_Pregled_SpecijalisteIshod_Pregleda]
ON [dbo].[Ishod_Pregleda]
    ([Pregled_Specijaliste1_Id]);
GO

-- Creating foreign key on [Termin_Specijaliste_Id] in table 'Pregled_Specijaliste'
ALTER TABLE [dbo].[Pregled_Specijaliste]
ADD CONSTRAINT [FK_Termin_SpecijalistePregled_Specijaliste]
    FOREIGN KEY ([Termin_Specijaliste_Id])
    REFERENCES [dbo].[Termin_Specijaliste]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Termin_SpecijalistePregled_Specijaliste'
CREATE INDEX [IX_FK_Termin_SpecijalistePregled_Specijaliste]
ON [dbo].[Pregled_Specijaliste]
    ([Termin_Specijaliste_Id]);
GO

-- Creating foreign key on [Id] in table 'Korisniks_Doktor'
ALTER TABLE [dbo].[Korisniks_Doktor]
ADD CONSTRAINT [FK_Doktor_inherits_Korisnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Korisniks]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Korisniks_Pacijent'
ALTER TABLE [dbo].[Korisniks_Pacijent]
ADD CONSTRAINT [FK_Pacijent_inherits_Korisnik]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Korisniks]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Ishod_Pregleda_Dijagnoza'
ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza]
ADD CONSTRAINT [FK_Dijagnoza_inherits_Ishod_Pregleda]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Ishod_Pregleda]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Ishod_Pregleda_Uput'
ALTER TABLE [dbo].[Ishod_Pregleda_Uput]
ADD CONSTRAINT [FK_Uput_inherits_Ishod_Pregleda]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Ishod_Pregleda]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------