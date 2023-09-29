
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/26/2021 15:41:04
-- Generated from EDMX file: C:\Users\ivana\Desktop\MVVM-Clinic\MVVM-Clinic-master\ClinicApp\Model\ClinicModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_Klinika_DepartmanDepartman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klinika_Departman] DROP CONSTRAINT [FK_Klinika_DepartmanDepartman];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_specijalista_UputDijagnoza_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_specijalista_Uput] DROP CONSTRAINT [FK_Doktor_specijalista_UputDijagnoza_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_DepartmanKlinika_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_Departman] DROP CONSTRAINT [FK_Doktor_DepartmanKlinika_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_DepartmanUgovor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_Departman] DROP CONSTRAINT [FK_Doktor_DepartmanUgovor];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_opste_prakse_PregledDoktor_op_pr_Pregled_Pacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent] DROP CONSTRAINT [FK_Doktor_opste_prakse_PregledDoktor_op_pr_Pregled_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_pregled_PacijentIshod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda] DROP CONSTRAINT [FK_Doktor_pregled_PacijentIshod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_PregledDoktor_opste_prakse_Pregled]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregleds] DROP CONSTRAINT [FK_PregledDoktor_opste_prakse_Pregled];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_specijalista_UputUput]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_specijalista_Uput] DROP CONSTRAINT [FK_Doktor_specijalista_UputUput];
GO
IF OBJECT_ID(N'[dbo].[FK_Dijagnoza_inherits_Ishod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza] DROP CONSTRAINT [FK_Dijagnoza_inherits_Ishod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_Uput_inherits_Ishod_Pregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda_Uput] DROP CONSTRAINT [FK_Uput_inherits_Ishod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_DijagnozaTerapija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza] DROP CONSTRAINT [FK_DijagnozaTerapija];
GO
IF OBJECT_ID(N'[dbo].[FK_Klinika_DepartmanPacijent_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacijent_Departman] DROP CONSTRAINT [FK_Klinika_DepartmanPacijent_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_KlinikaKlinika_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klinika_Departman] DROP CONSTRAINT [FK_KlinikaKlinika_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_Zdravstveni_KartonPacijent_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zdravstveni_Karton] DROP CONSTRAINT [FK_Zdravstveni_KartonPacijent_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Dijagnoza_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste] DROP CONSTRAINT [FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Dijagnoza_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Terapija_Specijaliste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste] DROP CONSTRAINT [FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Terapija_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentDoktor_op_pr_Pregled_Pacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent] DROP CONSTRAINT [FK_PacijentDoktor_op_pr_Pregled_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorDoktor_opste_prakse_Pregled1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_opste_prakse_Pregled1] DROP CONSTRAINT [FK_DoktorDoktor_opste_prakse_Pregled1];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorDoktor_specijalista_Uput]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_specijalista_Uput] DROP CONSTRAINT [FK_DoktorDoktor_specijalista_Uput];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPacijent_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacijent_Departman] DROP CONSTRAINT [FK_PacijentPacijent_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorDoktor_Departman]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Doktor_Departman] DROP CONSTRAINT [FK_DoktorDoktor_Departman];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_inherits_Korisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Doktor] DROP CONSTRAINT [FK_Doktor_inherits_Korisnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Pacijent_inherits_Korisnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Korisniks_Pacijent] DROP CONSTRAINT [FK_Pacijent_inherits_Korisnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Departmen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departmen];
GO
IF OBJECT_ID(N'[dbo].[Dijagnoza_Specijaliste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dijagnoza_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[Doktor_Departman]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doktor_Departman];
GO
IF OBJECT_ID(N'[dbo].[Doktor_op_pr_Pregled_Pacijent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[Doktor_opste_prakse_Pregled1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doktor_opste_prakse_Pregled1];
GO
IF OBJECT_ID(N'[dbo].[Doktor_specijalista_Uput]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doktor_specijalista_Uput];
GO
IF OBJECT_ID(N'[dbo].[Korisniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks];
GO
IF OBJECT_ID(N'[dbo].[Korisniks_Doktor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks_Doktor];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda_Dijagnoza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda_Dijagnoza];
GO
IF OBJECT_ID(N'[dbo].[Ishod_Pregleda_Uput]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ishod_Pregleda_Uput];
GO
IF OBJECT_ID(N'[dbo].[Klinika_Departman]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klinika_Departman];
GO
IF OBJECT_ID(N'[dbo].[Klinikas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klinikas];
GO
IF OBJECT_ID(N'[dbo].[Pacijent_Departman]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacijent_Departman];
GO
IF OBJECT_ID(N'[dbo].[Korisniks_Pacijent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korisniks_Pacijent];
GO
IF OBJECT_ID(N'[dbo].[Pregleds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregleds];
GO
IF OBJECT_ID(N'[dbo].[Terapija_Specijaliste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terapija_Specijaliste];
GO
IF OBJECT_ID(N'[dbo].[Terapijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terapijas];
GO
IF OBJECT_ID(N'[dbo].[Ugovors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ugovors];
GO
IF OBJECT_ID(N'[dbo].[Zdravstveni_Karton]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zdravstveni_Karton];
GO
IF OBJECT_ID(N'[dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departmen'
CREATE TABLE [dbo].[Departmen] (
    [Departman_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Sprat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dijagnoza_Specijaliste'
CREATE TABLE [dbo].[Dijagnoza_Specijaliste] (
    [Dijagnoza_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Doktor_Departman'
CREATE TABLE [dbo].[Doktor_Departman] (
    [DoktorDoktor_Id] int  NOT NULL,
    [Klinika_DepartmanKlinikaKlinika_Id] int  NOT NULL,
    [Klinika_DepartmanDepartmanDepartman_Id] int  NOT NULL,
    [Doktor_Doktor_Id] bigint  NOT NULL,
    [Ugovor_Ugovor_Id] int  NOT NULL,
    [Doktor_Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Doktor_op_pr_Pregled_Pacijent'
CREATE TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent] (
    [PacijentPacijent_Id] int  NOT NULL,
    [PacijentPacijent_Id1] int  NOT NULL,
    [Doktor_opste_prakse_Pregled_Doktor_opste_prakseDoktor_Id] int  NOT NULL,
    [Pacijent_Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Doktor_opste_prakse_Pregled1'
CREATE TABLE [dbo].[Doktor_opste_prakse_Pregled1] (
    [Doktor_opste_prakseDoktor_Id] int  NOT NULL,
    [DoktorDoktor_Id] int  NOT NULL,
    [Doktor_Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Doktor_specijalista_Uput'
CREATE TABLE [dbo].[Doktor_specijalista_Uput] (
    [Doktor_specijalistaDoktor_Id] int  NOT NULL,
    [Dijagnoza_SpecijalisteDijagnoza_Id] int  NULL,
    [UputIshod_Id] int  NULL,
    [DoktorDoktor_Id] int  NOT NULL,
    [TerminUput] bit  NULL,
    [Doktor_Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Korisniks'
CREATE TABLE [dbo].[Korisniks] (
    [Korisnik_Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Kontakt] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] nvarchar(max)  NOT NULL,
    [Grad] nvarchar(max)  NOT NULL,
    [Korisnicko_Ime] nvarchar(max)  NOT NULL,
    [Lozinka] nvarchar(max)  NOT NULL,
    [Uloga] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Korisniks_Doktor'
CREATE TABLE [dbo].[Korisniks_Doktor] (
    [Doktor_Id] int IDENTITY(1,1) NOT NULL,
    [Specijalizacija] nvarchar(max)  NOT NULL,
    [Klinika_Id] int  NOT NULL,
    [Departman_Id] int  NOT NULL,
    [Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Ishod_Pregleda'
CREATE TABLE [dbo].[Ishod_Pregleda] (
    [Ishod_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Doktor_pregled_Pacijent_PacijentPacijent_Id] int  NOT NULL
);
GO

-- Creating table 'Ishod_Pregleda_Dijagnoza'
CREATE TABLE [dbo].[Ishod_Pregleda_Dijagnoza] (
    [TerapijaTerapija_Id] int  NULL,
    [Ishod_Id] int  NOT NULL
);
GO

-- Creating table 'Ishod_Pregleda_Uput'
CREATE TABLE [dbo].[Ishod_Pregleda_Uput] (
    [Ishod_Id] int  NOT NULL
);
GO

-- Creating table 'Klinika_Departman'
CREATE TABLE [dbo].[Klinika_Departman] (
    [KlinikaKlinika_Id] int  NOT NULL,
    [DepartmanDepartman_Id] int  NOT NULL
);
GO

-- Creating table 'Klinikas'
CREATE TABLE [dbo].[Klinikas] (
    [Klinika_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Grad] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Broj] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pacijent_Departman'
CREATE TABLE [dbo].[Pacijent_Departman] (
    [Datum_Prijave] nvarchar(max)  NOT NULL,
    [Datum_Odjave] nvarchar(max)  NOT NULL,
    [Soba] nvarchar(max)  NOT NULL,
    [PacijentPacijent_Id] int  NOT NULL,
    [Klinika_DepartmanKlinikaKlinika_Id] int  NOT NULL,
    [Klinika_DepartmanDepartmanDepartman_Id] int  NOT NULL,
    [Pacijent_Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Korisniks_Pacijent'
CREATE TABLE [dbo].[Korisniks_Pacijent] (
    [Pacijent_Id] int IDENTITY(1,1) NOT NULL,
    [Korisnik_Id] int  NOT NULL
);
GO

-- Creating table 'Pregleds'
CREATE TABLE [dbo].[Pregleds] (
    [Pregled_Id] int IDENTITY(1,1) NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Termin] datetime  NOT NULL,
    [Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id] int  NOT NULL,
    [Obavljen] bit  NOT NULL
);
GO

-- Creating table 'Terapija_Specijaliste'
CREATE TABLE [dbo].[Terapija_Specijaliste] (
    [Terapija_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Vrsta_Terapije] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Terapijas'
CREATE TABLE [dbo].[Terapijas] (
    [Terapija_Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Opis] nvarchar(max)  NOT NULL,
    [Vrsta_Terapije] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ugovors'
CREATE TABLE [dbo].[Ugovors] (
    [Ugovor_Id] int IDENTITY(1,1) NOT NULL,
    [Vrsta_Ugovora] nvarchar(max)  NOT NULL,
    [Datum_Vazenja] datetime  NOT NULL,
    [Specijalizacija] bit  NOT NULL,
    [Doktor] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zdravstveni_Karton'
CREATE TABLE [dbo].[Zdravstveni_Karton] (
    [Karton_Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL,
    [Evidencija] nvarchar(max)  NOT NULL,
    [Pacijent_Departman_PacijentPacijent_Id] int  NOT NULL,
    [Pacijent_Departman_Klinika_DepartmanKlinikaKlinika_Id] int  NOT NULL,
    [Pacijent_Departman_Klinika_DepartmanDepartmanDepartman_Id] int  NOT NULL
);
GO

-- Creating table 'Dijagnoza_SpecijalisteTerapija_Specijaliste'
CREATE TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste] (
    [Dijagnoza_Specijaliste_Dijagnoza_Id] int  NOT NULL,
    [Terapija_Specijaliste_Terapija_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Departman_Id] in table 'Departmen'
ALTER TABLE [dbo].[Departmen]
ADD CONSTRAINT [PK_Departmen]
    PRIMARY KEY CLUSTERED ([Departman_Id] ASC);
GO

-- Creating primary key on [Dijagnoza_Id] in table 'Dijagnoza_Specijaliste'
ALTER TABLE [dbo].[Dijagnoza_Specijaliste]
ADD CONSTRAINT [PK_Dijagnoza_Specijaliste]
    PRIMARY KEY CLUSTERED ([Dijagnoza_Id] ASC);
GO

-- Creating primary key on [DoktorDoktor_Id], [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] in table 'Doktor_Departman'
ALTER TABLE [dbo].[Doktor_Departman]
ADD CONSTRAINT [PK_Doktor_Departman]
    PRIMARY KEY CLUSTERED ([DoktorDoktor_Id], [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] ASC);
GO

-- Creating primary key on [PacijentPacijent_Id] in table 'Doktor_op_pr_Pregled_Pacijent'
ALTER TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent]
ADD CONSTRAINT [PK_Doktor_op_pr_Pregled_Pacijent]
    PRIMARY KEY CLUSTERED ([PacijentPacijent_Id] ASC);
GO

-- Creating primary key on [Doktor_opste_prakseDoktor_Id] in table 'Doktor_opste_prakse_Pregled1'
ALTER TABLE [dbo].[Doktor_opste_prakse_Pregled1]
ADD CONSTRAINT [PK_Doktor_opste_prakse_Pregled1]
    PRIMARY KEY CLUSTERED ([Doktor_opste_prakseDoktor_Id] ASC);
GO

-- Creating primary key on [Doktor_specijalistaDoktor_Id] in table 'Doktor_specijalista_Uput'
ALTER TABLE [dbo].[Doktor_specijalista_Uput]
ADD CONSTRAINT [PK_Doktor_specijalista_Uput]
    PRIMARY KEY CLUSTERED ([Doktor_specijalistaDoktor_Id] ASC);
GO

-- Creating primary key on [Korisnik_Id] in table 'Korisniks'
ALTER TABLE [dbo].[Korisniks]
ADD CONSTRAINT [PK_Korisniks]
    PRIMARY KEY CLUSTERED ([Korisnik_Id] ASC);
GO

-- Creating primary key on [Korisnik_Id] in table 'Korisniks_Doktor'
ALTER TABLE [dbo].[Korisniks_Doktor]
ADD CONSTRAINT [PK_Korisniks_Doktor]
    PRIMARY KEY CLUSTERED ([Korisnik_Id] ASC);
GO

-- Creating primary key on [Ishod_Id] in table 'Ishod_Pregleda'
ALTER TABLE [dbo].[Ishod_Pregleda]
ADD CONSTRAINT [PK_Ishod_Pregleda]
    PRIMARY KEY CLUSTERED ([Ishod_Id] ASC);
GO

-- Creating primary key on [Ishod_Id] in table 'Ishod_Pregleda_Dijagnoza'
ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza]
ADD CONSTRAINT [PK_Ishod_Pregleda_Dijagnoza]
    PRIMARY KEY CLUSTERED ([Ishod_Id] ASC);
GO

-- Creating primary key on [Ishod_Id] in table 'Ishod_Pregleda_Uput'
ALTER TABLE [dbo].[Ishod_Pregleda_Uput]
ADD CONSTRAINT [PK_Ishod_Pregleda_Uput]
    PRIMARY KEY CLUSTERED ([Ishod_Id] ASC);
GO

-- Creating primary key on [KlinikaKlinika_Id], [DepartmanDepartman_Id] in table 'Klinika_Departman'
ALTER TABLE [dbo].[Klinika_Departman]
ADD CONSTRAINT [PK_Klinika_Departman]
    PRIMARY KEY CLUSTERED ([KlinikaKlinika_Id], [DepartmanDepartman_Id] ASC);
GO

-- Creating primary key on [Klinika_Id] in table 'Klinikas'
ALTER TABLE [dbo].[Klinikas]
ADD CONSTRAINT [PK_Klinikas]
    PRIMARY KEY CLUSTERED ([Klinika_Id] ASC);
GO

-- Creating primary key on [PacijentPacijent_Id], [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] in table 'Pacijent_Departman'
ALTER TABLE [dbo].[Pacijent_Departman]
ADD CONSTRAINT [PK_Pacijent_Departman]
    PRIMARY KEY CLUSTERED ([PacijentPacijent_Id], [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] ASC);
GO

-- Creating primary key on [Korisnik_Id] in table 'Korisniks_Pacijent'
ALTER TABLE [dbo].[Korisniks_Pacijent]
ADD CONSTRAINT [PK_Korisniks_Pacijent]
    PRIMARY KEY CLUSTERED ([Korisnik_Id] ASC);
GO

-- Creating primary key on [Pregled_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [PK_Pregleds]
    PRIMARY KEY CLUSTERED ([Pregled_Id] ASC);
GO

-- Creating primary key on [Terapija_Id] in table 'Terapija_Specijaliste'
ALTER TABLE [dbo].[Terapija_Specijaliste]
ADD CONSTRAINT [PK_Terapija_Specijaliste]
    PRIMARY KEY CLUSTERED ([Terapija_Id] ASC);
GO

-- Creating primary key on [Terapija_Id] in table 'Terapijas'
ALTER TABLE [dbo].[Terapijas]
ADD CONSTRAINT [PK_Terapijas]
    PRIMARY KEY CLUSTERED ([Terapija_Id] ASC);
GO

-- Creating primary key on [Ugovor_Id] in table 'Ugovors'
ALTER TABLE [dbo].[Ugovors]
ADD CONSTRAINT [PK_Ugovors]
    PRIMARY KEY CLUSTERED ([Ugovor_Id] ASC);
GO

-- Creating primary key on [Karton_Id] in table 'Zdravstveni_Karton'
ALTER TABLE [dbo].[Zdravstveni_Karton]
ADD CONSTRAINT [PK_Zdravstveni_Karton]
    PRIMARY KEY CLUSTERED ([Karton_Id] ASC);
GO

-- Creating primary key on [Dijagnoza_Specijaliste_Dijagnoza_Id], [Terapija_Specijaliste_Terapija_Id] in table 'Dijagnoza_SpecijalisteTerapija_Specijaliste'
ALTER TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste]
ADD CONSTRAINT [PK_Dijagnoza_SpecijalisteTerapija_Specijaliste]
    PRIMARY KEY CLUSTERED ([Dijagnoza_Specijaliste_Dijagnoza_Id], [Terapija_Specijaliste_Terapija_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmanDepartman_Id] in table 'Klinika_Departman'
ALTER TABLE [dbo].[Klinika_Departman]
ADD CONSTRAINT [FK_Klinika_DepartmanDepartman]
    FOREIGN KEY ([DepartmanDepartman_Id])
    REFERENCES [dbo].[Departmen]
        ([Departman_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Klinika_DepartmanDepartman'
CREATE INDEX [IX_FK_Klinika_DepartmanDepartman]
ON [dbo].[Klinika_Departman]
    ([DepartmanDepartman_Id]);
GO

-- Creating foreign key on [Dijagnoza_SpecijalisteDijagnoza_Id] in table 'Doktor_specijalista_Uput'
ALTER TABLE [dbo].[Doktor_specijalista_Uput]
ADD CONSTRAINT [FK_Doktor_specijalista_UputDijagnoza_Specijaliste]
    FOREIGN KEY ([Dijagnoza_SpecijalisteDijagnoza_Id])
    REFERENCES [dbo].[Dijagnoza_Specijaliste]
        ([Dijagnoza_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_specijalista_UputDijagnoza_Specijaliste'
CREATE INDEX [IX_FK_Doktor_specijalista_UputDijagnoza_Specijaliste]
ON [dbo].[Doktor_specijalista_Uput]
    ([Dijagnoza_SpecijalisteDijagnoza_Id]);
GO

-- Creating foreign key on [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] in table 'Doktor_Departman'
ALTER TABLE [dbo].[Doktor_Departman]
ADD CONSTRAINT [FK_Doktor_DepartmanKlinika_Departman]
    FOREIGN KEY ([Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id])
    REFERENCES [dbo].[Klinika_Departman]
        ([KlinikaKlinika_Id], [DepartmanDepartman_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_DepartmanKlinika_Departman'
CREATE INDEX [IX_FK_Doktor_DepartmanKlinika_Departman]
ON [dbo].[Doktor_Departman]
    ([Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id]);
GO

-- Creating foreign key on [Ugovor_Ugovor_Id] in table 'Doktor_Departman'
ALTER TABLE [dbo].[Doktor_Departman]
ADD CONSTRAINT [FK_Doktor_DepartmanUgovor]
    FOREIGN KEY ([Ugovor_Ugovor_Id])
    REFERENCES [dbo].[Ugovors]
        ([Ugovor_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_DepartmanUgovor'
CREATE INDEX [IX_FK_Doktor_DepartmanUgovor]
ON [dbo].[Doktor_Departman]
    ([Ugovor_Ugovor_Id]);
GO

-- Creating foreign key on [Doktor_opste_prakse_Pregled_Doktor_opste_prakseDoktor_Id] in table 'Doktor_op_pr_Pregled_Pacijent'
ALTER TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent]
ADD CONSTRAINT [FK_Doktor_opste_prakse_PregledDoktor_op_pr_Pregled_Pacijent]
    FOREIGN KEY ([Doktor_opste_prakse_Pregled_Doktor_opste_prakseDoktor_Id])
    REFERENCES [dbo].[Doktor_opste_prakse_Pregled1]
        ([Doktor_opste_prakseDoktor_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_opste_prakse_PregledDoktor_op_pr_Pregled_Pacijent'
CREATE INDEX [IX_FK_Doktor_opste_prakse_PregledDoktor_op_pr_Pregled_Pacijent]
ON [dbo].[Doktor_op_pr_Pregled_Pacijent]
    ([Doktor_opste_prakse_Pregled_Doktor_opste_prakseDoktor_Id]);
GO

-- Creating foreign key on [Doktor_pregled_Pacijent_PacijentPacijent_Id] in table 'Ishod_Pregleda'
ALTER TABLE [dbo].[Ishod_Pregleda]
ADD CONSTRAINT [FK_Doktor_pregled_PacijentIshod_Pregleda]
    FOREIGN KEY ([Doktor_pregled_Pacijent_PacijentPacijent_Id])
    REFERENCES [dbo].[Doktor_op_pr_Pregled_Pacijent]
        ([PacijentPacijent_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_pregled_PacijentIshod_Pregleda'
CREATE INDEX [IX_FK_Doktor_pregled_PacijentIshod_Pregleda]
ON [dbo].[Ishod_Pregleda]
    ([Doktor_pregled_Pacijent_PacijentPacijent_Id]);
GO

-- Creating foreign key on [Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id] in table 'Pregleds'
ALTER TABLE [dbo].[Pregleds]
ADD CONSTRAINT [FK_PregledDoktor_opste_prakse_Pregled]
    FOREIGN KEY ([Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id])
    REFERENCES [dbo].[Doktor_opste_prakse_Pregled1]
        ([Doktor_opste_prakseDoktor_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PregledDoktor_opste_prakse_Pregled'
CREATE INDEX [IX_FK_PregledDoktor_opste_prakse_Pregled]
ON [dbo].[Pregleds]
    ([Doktor_opste_prakse_PregledDoktor_opste_prakseDoktor_Id]);
GO

-- Creating foreign key on [UputIshod_Id] in table 'Doktor_specijalista_Uput'
ALTER TABLE [dbo].[Doktor_specijalista_Uput]
ADD CONSTRAINT [FK_Doktor_specijalista_UputUput]
    FOREIGN KEY ([UputIshod_Id])
    REFERENCES [dbo].[Ishod_Pregleda_Uput]
        ([Ishod_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Doktor_specijalista_UputUput'
CREATE INDEX [IX_FK_Doktor_specijalista_UputUput]
ON [dbo].[Doktor_specijalista_Uput]
    ([UputIshod_Id]);
GO

-- Creating foreign key on [Ishod_Id] in table 'Ishod_Pregleda_Dijagnoza'
ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza]
ADD CONSTRAINT [FK_Dijagnoza_inherits_Ishod_Pregleda]
    FOREIGN KEY ([Ishod_Id])
    REFERENCES [dbo].[Ishod_Pregleda]
        ([Ishod_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Ishod_Id] in table 'Ishod_Pregleda_Uput'
ALTER TABLE [dbo].[Ishod_Pregleda_Uput]
ADD CONSTRAINT [FK_Uput_inherits_Ishod_Pregleda]
    FOREIGN KEY ([Ishod_Id])
    REFERENCES [dbo].[Ishod_Pregleda]
        ([Ishod_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TerapijaTerapija_Id] in table 'Ishod_Pregleda_Dijagnoza'
ALTER TABLE [dbo].[Ishod_Pregleda_Dijagnoza]
ADD CONSTRAINT [FK_DijagnozaTerapija]
    FOREIGN KEY ([TerapijaTerapija_Id])
    REFERENCES [dbo].[Terapijas]
        ([Terapija_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DijagnozaTerapija'
CREATE INDEX [IX_FK_DijagnozaTerapija]
ON [dbo].[Ishod_Pregleda_Dijagnoza]
    ([TerapijaTerapija_Id]);
GO

-- Creating foreign key on [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id] in table 'Pacijent_Departman'
ALTER TABLE [dbo].[Pacijent_Departman]
ADD CONSTRAINT [FK_Klinika_DepartmanPacijent_Departman]
    FOREIGN KEY ([Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id])
    REFERENCES [dbo].[Klinika_Departman]
        ([KlinikaKlinika_Id], [DepartmanDepartman_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Klinika_DepartmanPacijent_Departman'
CREATE INDEX [IX_FK_Klinika_DepartmanPacijent_Departman]
ON [dbo].[Pacijent_Departman]
    ([Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id]);
GO

-- Creating foreign key on [KlinikaKlinika_Id] in table 'Klinika_Departman'
ALTER TABLE [dbo].[Klinika_Departman]
ADD CONSTRAINT [FK_KlinikaKlinika_Departman]
    FOREIGN KEY ([KlinikaKlinika_Id])
    REFERENCES [dbo].[Klinikas]
        ([Klinika_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pacijent_Departman_PacijentPacijent_Id], [Pacijent_Departman_Klinika_DepartmanKlinikaKlinika_Id], [Pacijent_Departman_Klinika_DepartmanDepartmanDepartman_Id] in table 'Zdravstveni_Karton'
ALTER TABLE [dbo].[Zdravstveni_Karton]
ADD CONSTRAINT [FK_Zdravstveni_KartonPacijent_Departman]
    FOREIGN KEY ([Pacijent_Departman_PacijentPacijent_Id], [Pacijent_Departman_Klinika_DepartmanKlinikaKlinika_Id], [Pacijent_Departman_Klinika_DepartmanDepartmanDepartman_Id])
    REFERENCES [dbo].[Pacijent_Departman]
        ([PacijentPacijent_Id], [Klinika_DepartmanKlinikaKlinika_Id], [Klinika_DepartmanDepartmanDepartman_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Zdravstveni_KartonPacijent_Departman'
CREATE INDEX [IX_FK_Zdravstveni_KartonPacijent_Departman]
ON [dbo].[Zdravstveni_Karton]
    ([Pacijent_Departman_PacijentPacijent_Id], [Pacijent_Departman_Klinika_DepartmanKlinikaKlinika_Id], [Pacijent_Departman_Klinika_DepartmanDepartmanDepartman_Id]);
GO

-- Creating foreign key on [Dijagnoza_Specijaliste_Dijagnoza_Id] in table 'Dijagnoza_SpecijalisteTerapija_Specijaliste'
ALTER TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste]
ADD CONSTRAINT [FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Dijagnoza_Specijaliste]
    FOREIGN KEY ([Dijagnoza_Specijaliste_Dijagnoza_Id])
    REFERENCES [dbo].[Dijagnoza_Specijaliste]
        ([Dijagnoza_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Terapija_Specijaliste_Terapija_Id] in table 'Dijagnoza_SpecijalisteTerapija_Specijaliste'
ALTER TABLE [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste]
ADD CONSTRAINT [FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Terapija_Specijaliste]
    FOREIGN KEY ([Terapija_Specijaliste_Terapija_Id])
    REFERENCES [dbo].[Terapija_Specijaliste]
        ([Terapija_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Terapija_Specijaliste'
CREATE INDEX [IX_FK_Dijagnoza_SpecijalisteTerapija_Specijaliste_Terapija_Specijaliste]
ON [dbo].[Dijagnoza_SpecijalisteTerapija_Specijaliste]
    ([Terapija_Specijaliste_Terapija_Id]);
GO

-- Creating foreign key on [Pacijent_Korisnik_Id] in table 'Doktor_op_pr_Pregled_Pacijent'
ALTER TABLE [dbo].[Doktor_op_pr_Pregled_Pacijent]
ADD CONSTRAINT [FK_PacijentDoktor_op_pr_Pregled_Pacijent]
    FOREIGN KEY ([Pacijent_Korisnik_Id])
    REFERENCES [dbo].[Korisniks_Pacijent]
        ([Korisnik_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentDoktor_op_pr_Pregled_Pacijent'
CREATE INDEX [IX_FK_PacijentDoktor_op_pr_Pregled_Pacijent]
ON [dbo].[Doktor_op_pr_Pregled_Pacijent]
    ([Pacijent_Korisnik_Id]);
GO

-- Creating foreign key on [Doktor_Korisnik_Id] in table 'Doktor_opste_prakse_Pregled1'
ALTER TABLE [dbo].[Doktor_opste_prakse_Pregled1]
ADD CONSTRAINT [FK_DoktorDoktor_opste_prakse_Pregled1]
    FOREIGN KEY ([Doktor_Korisnik_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Korisnik_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorDoktor_opste_prakse_Pregled1'
CREATE INDEX [IX_FK_DoktorDoktor_opste_prakse_Pregled1]
ON [dbo].[Doktor_opste_prakse_Pregled1]
    ([Doktor_Korisnik_Id]);
GO

-- Creating foreign key on [Doktor_Korisnik_Id] in table 'Doktor_specijalista_Uput'
ALTER TABLE [dbo].[Doktor_specijalista_Uput]
ADD CONSTRAINT [FK_DoktorDoktor_specijalista_Uput]
    FOREIGN KEY ([Doktor_Korisnik_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Korisnik_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorDoktor_specijalista_Uput'
CREATE INDEX [IX_FK_DoktorDoktor_specijalista_Uput]
ON [dbo].[Doktor_specijalista_Uput]
    ([Doktor_Korisnik_Id]);
GO

-- Creating foreign key on [Pacijent_Korisnik_Id] in table 'Pacijent_Departman'
ALTER TABLE [dbo].[Pacijent_Departman]
ADD CONSTRAINT [FK_PacijentPacijent_Departman]
    FOREIGN KEY ([Pacijent_Korisnik_Id])
    REFERENCES [dbo].[Korisniks_Pacijent]
        ([Korisnik_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentPacijent_Departman'
CREATE INDEX [IX_FK_PacijentPacijent_Departman]
ON [dbo].[Pacijent_Departman]
    ([Pacijent_Korisnik_Id]);
GO

-- Creating foreign key on [Doktor_Korisnik_Id] in table 'Doktor_Departman'
ALTER TABLE [dbo].[Doktor_Departman]
ADD CONSTRAINT [FK_DoktorDoktor_Departman]
    FOREIGN KEY ([Doktor_Korisnik_Id])
    REFERENCES [dbo].[Korisniks_Doktor]
        ([Korisnik_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorDoktor_Departman'
CREATE INDEX [IX_FK_DoktorDoktor_Departman]
ON [dbo].[Doktor_Departman]
    ([Doktor_Korisnik_Id]);
GO

-- Creating foreign key on [Korisnik_Id] in table 'Korisniks_Doktor'
ALTER TABLE [dbo].[Korisniks_Doktor]
ADD CONSTRAINT [FK_Doktor_inherits_Korisnik]
    FOREIGN KEY ([Korisnik_Id])
    REFERENCES [dbo].[Korisniks]
        ([Korisnik_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Korisnik_Id] in table 'Korisniks_Pacijent'
ALTER TABLE [dbo].[Korisniks_Pacijent]
ADD CONSTRAINT [FK_Pacijent_inherits_Korisnik]
    FOREIGN KEY ([Korisnik_Id])
    REFERENCES [dbo].[Korisniks]
        ([Korisnik_Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------