
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2019 18:16:46
-- Generated from EDMX file: C:\Users\MarcinChajewski\Source\Repos\Wypozyczalnia_samochodow_premium\WypożyczalniaSamochodówPremium\Models\WypozyczenieModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [inzWyp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Akcesoria__Wypoz__7E02B4CC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Akcesoria] DROP CONSTRAINT [FK__Akcesoria__Wypoz__7E02B4CC];
GO
IF OBJECT_ID(N'[dbo].[FK__Cennik__Samochod__6AEFE058]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cennik] DROP CONSTRAINT [FK__Cennik__Samochod__6AEFE058];
GO
IF OBJECT_ID(N'[dbo].[FK__Dostepnos__Samoc__69FBBC1F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostepnosc] DROP CONSTRAINT [FK__Dostepnos__Samoc__69FBBC1F];
GO
IF OBJECT_ID(N'[dbo].[FK__DowodOsob__Osoba__7B264821]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DowodOsobisty] DROP CONSTRAINT [FK__DowodOsob__Osoba__7B264821];
GO
IF OBJECT_ID(N'[dbo].[FK__DowodReje__Samoc__671F4F74]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DowodRejestracyjny] DROP CONSTRAINT [FK__DowodReje__Samoc__671F4F74];
GO
IF OBJECT_ID(N'[dbo].[FK__KlientFir__Osoba__3D2915A8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlientFirma] DROP CONSTRAINT [FK__KlientFir__Osoba__3D2915A8];
GO
IF OBJECT_ID(N'[dbo].[FK__KlientInd__Osoba__395884C4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KlientIndywidualny] DROP CONSTRAINT [FK__KlientInd__Osoba__395884C4];
GO
IF OBJECT_ID(N'[dbo].[FK__Opis__SamochodId__662B2B3B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Opis] DROP CONSTRAINT [FK__Opis__SamochodId__662B2B3B];
GO
IF OBJECT_ID(N'[dbo].[FK__Paszport__OsobaI__65370702]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paszport] DROP CONSTRAINT [FK__Paszport__OsobaI__65370702];
GO
IF OBJECT_ID(N'[dbo].[FK__Pracownik__Osoba__72910220]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pracownik] DROP CONSTRAINT [FK__Pracownik__Osoba__72910220];
GO
IF OBJECT_ID(N'[dbo].[FK__Pracownik__Praco__76619304]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PracownikWypozyczenie] DROP CONSTRAINT [FK__Pracownik__Praco__76619304];
GO
IF OBJECT_ID(N'[dbo].[FK__Pracownik__Wypoz__7755B73D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PracownikWypozyczenie] DROP CONSTRAINT [FK__Pracownik__Wypoz__7755B73D];
GO
IF OBJECT_ID(N'[dbo].[FK__PrawoJazd__Osoba__634EBE90]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrawoJazdy] DROP CONSTRAINT [FK__PrawoJazd__Osoba__634EBE90];
GO
IF OBJECT_ID(N'[dbo].[FK__Przeglad__Samoch__6166761E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Przeglad] DROP CONSTRAINT [FK__Przeglad__Samoch__6166761E];
GO
IF OBJECT_ID(N'[dbo].[FK__Rozliczen__Wypoz__607251E5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rozliczenie] DROP CONSTRAINT [FK__Rozliczen__Wypoz__607251E5];
GO
IF OBJECT_ID(N'[dbo].[FK__Serwis__Samochod__5E8A0973]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Serwis] DROP CONSTRAINT [FK__Serwis__Samochod__5E8A0973];
GO
IF OBJECT_ID(N'[dbo].[FK__Ubezpiecz__Samoc__5D95E53A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ubezpieczenie] DROP CONSTRAINT [FK__Ubezpiecz__Samoc__5D95E53A];
GO
IF OBJECT_ID(N'[dbo].[FK__Wypozycze__Osoba__6CD828CA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wypozyczenie] DROP CONSTRAINT [FK__Wypozycze__Osoba__6CD828CA];
GO
IF OBJECT_ID(N'[dbo].[FK__Wypozycze__Wydar__5CA1C101]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wypozyczenie] DROP CONSTRAINT [FK__Wypozycze__Wydar__5CA1C101];
GO
IF OBJECT_ID(N'[dbo].[FK__WypSam__Samochod__5AB9788F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WypSam] DROP CONSTRAINT [FK__WypSam__Samochod__5AB9788F];
GO
IF OBJECT_ID(N'[dbo].[FK__WypSam__Wypozycz__5BAD9CC8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WypSam] DROP CONSTRAINT [FK__WypSam__Wypozycz__5BAD9CC8];
GO
IF OBJECT_ID(N'[dbo].[FK_Dowod_ImageDowod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageDowodOsobisty] DROP CONSTRAINT [FK_Dowod_ImageDowod];
GO
IF OBJECT_ID(N'[dbo].[FK_Dowod_ImageSamochod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageSamochod] DROP CONSTRAINT [FK_Dowod_ImageSamochod];
GO
IF OBJECT_ID(N'[dbo].[FK_DowodRejestracyjny_ImageDowodRejestracyjny]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageDowodRejestracyjny] DROP CONSTRAINT [FK_DowodRejestracyjny_ImageDowodRejestracyjny];
GO
IF OBJECT_ID(N'[dbo].[FK_Image_ImageDowod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageDowodOsobisty] DROP CONSTRAINT [FK_Image_ImageDowod];
GO
IF OBJECT_ID(N'[dbo].[FK_Image_ImageDowodRejestracyjny]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageDowodRejestracyjny] DROP CONSTRAINT [FK_Image_ImageDowodRejestracyjny];
GO
IF OBJECT_ID(N'[dbo].[FK_Image_ImagePaszport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagePaszport] DROP CONSTRAINT [FK_Image_ImagePaszport];
GO
IF OBJECT_ID(N'[dbo].[FK_Image_ImageSamochod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImageSamochod] DROP CONSTRAINT [FK_Image_ImageSamochod];
GO
IF OBJECT_ID(N'[dbo].[FK_Paszport_ImagePaszport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagePaszport] DROP CONSTRAINT [FK_Paszport_ImagePaszport];
GO
IF OBJECT_ID(N'[dbo].[FK_WypozyczenieTemp_Osoba]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WypozyczenieTemp] DROP CONSTRAINT [FK_WypozyczenieTemp_Osoba];
GO
IF OBJECT_ID(N'[dbo].[FK_WypozyczenieTemp_Samochod]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WypozyczenieTemp] DROP CONSTRAINT [FK_WypozyczenieTemp_Samochod];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Akcesoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Akcesoria];
GO
IF OBJECT_ID(N'[dbo].[AutaBaza]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutaBaza];
GO
IF OBJECT_ID(N'[dbo].[Cennik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cennik];
GO
IF OBJECT_ID(N'[dbo].[Dostepnosc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dostepnosc];
GO
IF OBJECT_ID(N'[dbo].[DowodOsobisty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DowodOsobisty];
GO
IF OBJECT_ID(N'[dbo].[DowodRejestracyjny]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DowodRejestracyjny];
GO
IF OBJECT_ID(N'[dbo].[Image]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Image];
GO
IF OBJECT_ID(N'[dbo].[ImageDowodOsobisty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageDowodOsobisty];
GO
IF OBJECT_ID(N'[dbo].[ImageDowodRejestracyjny]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageDowodRejestracyjny];
GO
IF OBJECT_ID(N'[dbo].[ImagePaszport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImagePaszport];
GO
IF OBJECT_ID(N'[dbo].[ImageSamochod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageSamochod];
GO
IF OBJECT_ID(N'[dbo].[KlientFirma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlientFirma];
GO
IF OBJECT_ID(N'[dbo].[KlientIndywidualny]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlientIndywidualny];
GO
IF OBJECT_ID(N'[dbo].[Opis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Opis];
GO
IF OBJECT_ID(N'[dbo].[Osoba]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osoba];
GO
IF OBJECT_ID(N'[dbo].[Paszport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paszport];
GO
IF OBJECT_ID(N'[dbo].[Pracownik]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pracownik];
GO
IF OBJECT_ID(N'[dbo].[PracownikWypozyczenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PracownikWypozyczenie];
GO
IF OBJECT_ID(N'[dbo].[PrawoJazdy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrawoJazdy];
GO
IF OBJECT_ID(N'[dbo].[Przeglad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Przeglad];
GO
IF OBJECT_ID(N'[dbo].[Rozliczenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rozliczenie];
GO
IF OBJECT_ID(N'[dbo].[Samochod]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Samochod];
GO
IF OBJECT_ID(N'[dbo].[Serwis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Serwis];
GO
IF OBJECT_ID(N'[dbo].[Ubezpieczenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ubezpieczenie];
GO
IF OBJECT_ID(N'[dbo].[Wydarzenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wydarzenie];
GO
IF OBJECT_ID(N'[dbo].[Wypozyczenie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wypozyczenie];
GO
IF OBJECT_ID(N'[dbo].[WypozyczenieTemp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WypozyczenieTemp];
GO
IF OBJECT_ID(N'[dbo].[WypSam]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WypSam];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Akcesoria'
CREATE TABLE [dbo].[Akcesoria] (
    [AkcesoriaId] int IDENTITY(1,1) NOT NULL,
    [Nazwa] varchar(max)  NOT NULL,
    [Opis] varchar(max)  NOT NULL,
    [Cena] float  NOT NULL,
    [WypozyczenieId] int  NOT NULL
);
GO

-- Creating table 'AutaBaza'
CREATE TABLE [dbo].[AutaBaza] (
    [AutoId] int IDENTITY(1,1) NOT NULL,
    [Marka] varchar(max)  NOT NULL,
    [Model] varchar(max)  NOT NULL
);
GO

-- Creating table 'Cennik'
CREATE TABLE [dbo].[Cennik] (
    [CennikId] int IDENTITY(1,1) NOT NULL,
    [Opis] varchar(64)  NULL,
    [Cena] float  NOT NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Dostepnosc'
CREATE TABLE [dbo].[Dostepnosc] (
    [DostepnoscId] int IDENTITY(1,1) NOT NULL,
    [NiedostepnyOd] datetime  NULL,
    [NiedostepnyDo] datetime  NOT NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'DowodOsobisty'
CREATE TABLE [dbo].[DowodOsobisty] (
    [DowodOsobistyId] int IDENTITY(1,1) NOT NULL,
    [PESEL] int  NOT NULL,
    [NrDowodu] varchar(32)  NOT NULL,
    [TerminWaznosci] datetime  NOT NULL,
    [OsobaId] int  NOT NULL
);
GO

-- Creating table 'DowodRejestracyjny'
CREATE TABLE [dbo].[DowodRejestracyjny] (
    [DowodRejId] int IDENTITY(1,1) NOT NULL,
    [VIN] varchar(32)  NOT NULL,
    [Seria] int  NOT NULL,
    [NrRejestracyjny] varchar(32)  NOT NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Image'
CREATE TABLE [dbo].[Image] (
    [ImageId] int IDENTITY(1,1) NOT NULL,
    [ImageName] varchar(50)  NOT NULL,
    [ImageAlt] varchar(50)  NULL,
    [ImageData] varbinary(max)  NOT NULL,
    [ContentType] nvarchar(50)  NULL
);
GO

-- Creating table 'ImageDowodOsobisty'
CREATE TABLE [dbo].[ImageDowodOsobisty] (
    [ImageDowodId] int IDENTITY(1,1) NOT NULL,
    [ImageId] int  NOT NULL,
    [DowodOsobistyId] int  NOT NULL,
    [Opis] varchar(50)  NULL
);
GO

-- Creating table 'ImageDowodRejestracyjny'
CREATE TABLE [dbo].[ImageDowodRejestracyjny] (
    [ImageDowodRejestracyjnyId] int IDENTITY(1,1) NOT NULL,
    [ImageId] int  NOT NULL,
    [DowodRejestracyjnyId] int  NOT NULL,
    [Opis] varchar(50)  NULL
);
GO

-- Creating table 'ImagePaszport'
CREATE TABLE [dbo].[ImagePaszport] (
    [ImagePaszportId] int IDENTITY(1,1) NOT NULL,
    [ImageId] int  NOT NULL,
    [PaszportId] int  NOT NULL,
    [Opis] varchar(50)  NULL
);
GO

-- Creating table 'ImageSamochod'
CREATE TABLE [dbo].[ImageSamochod] (
    [ImageSamochodId] int IDENTITY(1,1) NOT NULL,
    [ImageId] int  NOT NULL,
    [SamochodId] int  NOT NULL,
    [Opis] varchar(50)  NULL
);
GO

-- Creating table 'KlientIndywidualny'
CREATE TABLE [dbo].[KlientIndywidualny] (
    [KlientIndywidualnyId] int IDENTITY(1,1) NOT NULL,
    [Rabat] int  NULL,
    [OsobaId] int  NULL
);
GO

-- Creating table 'Opis'
CREATE TABLE [dbo].[Opis] (
    [OpisId] int IDENTITY(1,1) NOT NULL,
    [OpisOgolny] varchar(max)  NOT NULL,
    [Wyposazenie] varchar(max)  NOT NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Paszport'
CREATE TABLE [dbo].[Paszport] (
    [PaszportId] int IDENTITY(1,1) NOT NULL,
    [NrPaszportu] varchar(64)  NOT NULL,
    [TerminWaznosci] datetime  NULL,
    [OsobaId] int  NOT NULL
);
GO

-- Creating table 'Pracownik'
CREATE TABLE [dbo].[Pracownik] (
    [PracownikId] int IDENTITY(1,1) NOT NULL,
    [DataZatrudnienia] datetime  NOT NULL,
    [DataZwolnienia] datetime  NULL,
    [Pensja] float  NOT NULL,
    [Premia] float  NULL,
    [Stanowisko] varchar(max)  NOT NULL,
    [OsobaId] int  NOT NULL
);
GO

-- Creating table 'PracownikWypozyczenie'
CREATE TABLE [dbo].[PracownikWypozyczenie] (
    [PracownikWypozyczenieId] int IDENTITY(1,1) NOT NULL,
    [PracownikId] int  NOT NULL,
    [WypozyczenieId] int  NOT NULL
);
GO

-- Creating table 'PrawoJazdy'
CREATE TABLE [dbo].[PrawoJazdy] (
    [PrawoJazdyId] int IDENTITY(1,1) NOT NULL,
    [NrPrawaJazdy] varchar(32)  NOT NULL,
    [KrajWydania] varchar(32)  NOT NULL,
    [Kategoria] varchar(2)  NOT NULL,
    [OsobaId] int  NOT NULL
);
GO

-- Creating table 'Przeglad'
CREATE TABLE [dbo].[Przeglad] (
    [PrzegladId] int IDENTITY(1,1) NOT NULL,
    [DataPrzegladu] datetime  NOT NULL,
    [DataKolejnegoPrzegladu] datetime  NOT NULL,
    [Uwagi] varchar(max)  NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Rozliczenie'
CREATE TABLE [dbo].[Rozliczenie] (
    [RozliczenieId] int IDENTITY(1,1) NOT NULL,
    [DodatkoweOplaty] float  NULL,
    [Zaliczka] float  NOT NULL,
    [DodatkowyRabat] float  NULL,
    [CalkowityKoszt] float  NOT NULL,
    [WypozyczenieId] int  NOT NULL
);
GO

-- Creating table 'Samochod'
CREATE TABLE [dbo].[Samochod] (
    [SamochodId] int IDENTITY(1,1) NOT NULL,
    [Marka] varchar(32)  NOT NULL,
    [Model] varchar(32)  NOT NULL,
    [Wersja] varchar(64)  NOT NULL,
    [RokProdukcji] datetime  NOT NULL,
    [RodzajSilnika] varchar(16)  NOT NULL,
    [PojemnoscSilnika] varchar(16)  NOT NULL,
    [SkrzyniaBiegow] varchar(16)  NOT NULL,
    [LiczbaDrzwi] varchar(32)  NOT NULL,
    [Kolor] varchar(16)  NOT NULL,
    [Przebieg] int  NOT NULL,
    [Status] varchar(200)  NOT NULL
);
GO

-- Creating table 'Serwis'
CREATE TABLE [dbo].[Serwis] (
    [SerwisId] int IDENTITY(1,1) NOT NULL,
    [DataOddania] datetime  NOT NULL,
    [DataOdbioru] datetime  NOT NULL,
    [Koszt] float  NOT NULL,
    [Uwagi] varchar(max)  NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Ubezpieczenie'
CREATE TABLE [dbo].[Ubezpieczenie] (
    [UbezpieczenieId] int IDENTITY(1,1) NOT NULL,
    [NumerPolisy] varchar(32)  NOT NULL,
    [WazneOd] datetime  NOT NULL,
    [WazneDo] datetime  NOT NULL,
    [SamochodId] int  NOT NULL
);
GO

-- Creating table 'Wydarzenie'
CREATE TABLE [dbo].[Wydarzenie] (
    [WydarzenieId] int IDENTITY(1,1) NOT NULL,
    [NazwaWydarzenia] varchar(32)  NOT NULL,
    [Opis] varchar(max)  NULL
);
GO

-- Creating table 'Wypozyczenie'
CREATE TABLE [dbo].[Wypozyczenie] (
    [WypozyczenieId] int IDENTITY(1,1) NOT NULL,
    [DataWypozyczenia] datetime  NOT NULL,
    [DataZwrotu] datetime  NOT NULL,
    [CzyDostarczany] bit  NOT NULL,
    [CzyKierowca] bit  NOT NULL,
    [AdresDojazdu] varchar(64)  NULL,
    [WydarzenieId] int  NOT NULL,
    [OsobaId] int  NOT NULL
);
GO

-- Creating table 'WypSam'
CREATE TABLE [dbo].[WypSam] (
    [WypSamId] int IDENTITY(1,1) NOT NULL,
    [SamochodId] int  NOT NULL,
    [WypozyczenieId] int  NOT NULL
);
GO

-- Creating table 'KlientFirma'
CREATE TABLE [dbo].[KlientFirma] (
    [KlientFirmaId] int IDENTITY(1,1) NOT NULL,
    [NazwaFirmy] varchar(32)  NOT NULL,
    [NIP] varchar(64)  NOT NULL,
    [RabatFirma] int  NULL,
    [AdresFirmy] varchar(64)  NULL,
    [KodPocztowy] varchar(16)  NULL,
    [Miasto] varchar(16)  NULL,
    [OsobaId] int  NULL
);
GO

-- Creating table 'Osoba'
CREATE TABLE [dbo].[Osoba] (
    [OsobaId] int IDENTITY(1,1) NOT NULL,
    [Imie] varchar(64)  NOT NULL,
    [Nazwisko] varchar(64)  NOT NULL,
    [DataUrodzenia] datetime  NULL,
    [Adres] varchar(64)  NULL,
    [KodPocztowy] varchar(32)  NULL,
    [Kraj] varchar(32)  NULL,
    [NrTelefonu] varchar(32)  NULL,
    [Miasto] varchar(32)  NULL,
    [Hash] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'WypozyczenieTemp'
CREATE TABLE [dbo].[WypozyczenieTemp] (
    [WypozyczenieTempId] int IDENTITY(1,1) NOT NULL,
    [OsobaId] int  NOT NULL,
    [SamochodId] int  NOT NULL,
    [DataWypozyczenia] datetime  NOT NULL,
    [DataZwrotu] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AkcesoriaId] in table 'Akcesoria'
ALTER TABLE [dbo].[Akcesoria]
ADD CONSTRAINT [PK_Akcesoria]
    PRIMARY KEY CLUSTERED ([AkcesoriaId] ASC);
GO

-- Creating primary key on [AutoId] in table 'AutaBaza'
ALTER TABLE [dbo].[AutaBaza]
ADD CONSTRAINT [PK_AutaBaza]
    PRIMARY KEY CLUSTERED ([AutoId] ASC);
GO

-- Creating primary key on [CennikId] in table 'Cennik'
ALTER TABLE [dbo].[Cennik]
ADD CONSTRAINT [PK_Cennik]
    PRIMARY KEY CLUSTERED ([CennikId] ASC);
GO

-- Creating primary key on [DostepnoscId] in table 'Dostepnosc'
ALTER TABLE [dbo].[Dostepnosc]
ADD CONSTRAINT [PK_Dostepnosc]
    PRIMARY KEY CLUSTERED ([DostepnoscId] ASC);
GO

-- Creating primary key on [DowodOsobistyId] in table 'DowodOsobisty'
ALTER TABLE [dbo].[DowodOsobisty]
ADD CONSTRAINT [PK_DowodOsobisty]
    PRIMARY KEY CLUSTERED ([DowodOsobistyId] ASC);
GO

-- Creating primary key on [DowodRejId] in table 'DowodRejestracyjny'
ALTER TABLE [dbo].[DowodRejestracyjny]
ADD CONSTRAINT [PK_DowodRejestracyjny]
    PRIMARY KEY CLUSTERED ([DowodRejId] ASC);
GO

-- Creating primary key on [ImageId] in table 'Image'
ALTER TABLE [dbo].[Image]
ADD CONSTRAINT [PK_Image]
    PRIMARY KEY CLUSTERED ([ImageId] ASC);
GO

-- Creating primary key on [ImageDowodId] in table 'ImageDowodOsobisty'
ALTER TABLE [dbo].[ImageDowodOsobisty]
ADD CONSTRAINT [PK_ImageDowodOsobisty]
    PRIMARY KEY CLUSTERED ([ImageDowodId] ASC);
GO

-- Creating primary key on [ImageDowodRejestracyjnyId] in table 'ImageDowodRejestracyjny'
ALTER TABLE [dbo].[ImageDowodRejestracyjny]
ADD CONSTRAINT [PK_ImageDowodRejestracyjny]
    PRIMARY KEY CLUSTERED ([ImageDowodRejestracyjnyId] ASC);
GO

-- Creating primary key on [ImagePaszportId] in table 'ImagePaszport'
ALTER TABLE [dbo].[ImagePaszport]
ADD CONSTRAINT [PK_ImagePaszport]
    PRIMARY KEY CLUSTERED ([ImagePaszportId] ASC);
GO

-- Creating primary key on [ImageSamochodId] in table 'ImageSamochod'
ALTER TABLE [dbo].[ImageSamochod]
ADD CONSTRAINT [PK_ImageSamochod]
    PRIMARY KEY CLUSTERED ([ImageSamochodId] ASC);
GO

-- Creating primary key on [KlientIndywidualnyId] in table 'KlientIndywidualny'
ALTER TABLE [dbo].[KlientIndywidualny]
ADD CONSTRAINT [PK_KlientIndywidualny]
    PRIMARY KEY CLUSTERED ([KlientIndywidualnyId] ASC);
GO

-- Creating primary key on [OpisId] in table 'Opis'
ALTER TABLE [dbo].[Opis]
ADD CONSTRAINT [PK_Opis]
    PRIMARY KEY CLUSTERED ([OpisId] ASC);
GO

-- Creating primary key on [PaszportId] in table 'Paszport'
ALTER TABLE [dbo].[Paszport]
ADD CONSTRAINT [PK_Paszport]
    PRIMARY KEY CLUSTERED ([PaszportId] ASC);
GO

-- Creating primary key on [PracownikId] in table 'Pracownik'
ALTER TABLE [dbo].[Pracownik]
ADD CONSTRAINT [PK_Pracownik]
    PRIMARY KEY CLUSTERED ([PracownikId] ASC);
GO

-- Creating primary key on [PracownikWypozyczenieId] in table 'PracownikWypozyczenie'
ALTER TABLE [dbo].[PracownikWypozyczenie]
ADD CONSTRAINT [PK_PracownikWypozyczenie]
    PRIMARY KEY CLUSTERED ([PracownikWypozyczenieId] ASC);
GO

-- Creating primary key on [PrawoJazdyId] in table 'PrawoJazdy'
ALTER TABLE [dbo].[PrawoJazdy]
ADD CONSTRAINT [PK_PrawoJazdy]
    PRIMARY KEY CLUSTERED ([PrawoJazdyId] ASC);
GO

-- Creating primary key on [PrzegladId] in table 'Przeglad'
ALTER TABLE [dbo].[Przeglad]
ADD CONSTRAINT [PK_Przeglad]
    PRIMARY KEY CLUSTERED ([PrzegladId] ASC);
GO

-- Creating primary key on [RozliczenieId] in table 'Rozliczenie'
ALTER TABLE [dbo].[Rozliczenie]
ADD CONSTRAINT [PK_Rozliczenie]
    PRIMARY KEY CLUSTERED ([RozliczenieId] ASC);
GO

-- Creating primary key on [SamochodId] in table 'Samochod'
ALTER TABLE [dbo].[Samochod]
ADD CONSTRAINT [PK_Samochod]
    PRIMARY KEY CLUSTERED ([SamochodId] ASC);
GO

-- Creating primary key on [SerwisId] in table 'Serwis'
ALTER TABLE [dbo].[Serwis]
ADD CONSTRAINT [PK_Serwis]
    PRIMARY KEY CLUSTERED ([SerwisId] ASC);
GO

-- Creating primary key on [UbezpieczenieId] in table 'Ubezpieczenie'
ALTER TABLE [dbo].[Ubezpieczenie]
ADD CONSTRAINT [PK_Ubezpieczenie]
    PRIMARY KEY CLUSTERED ([UbezpieczenieId] ASC);
GO

-- Creating primary key on [WydarzenieId] in table 'Wydarzenie'
ALTER TABLE [dbo].[Wydarzenie]
ADD CONSTRAINT [PK_Wydarzenie]
    PRIMARY KEY CLUSTERED ([WydarzenieId] ASC);
GO

-- Creating primary key on [WypozyczenieId] in table 'Wypozyczenie'
ALTER TABLE [dbo].[Wypozyczenie]
ADD CONSTRAINT [PK_Wypozyczenie]
    PRIMARY KEY CLUSTERED ([WypozyczenieId] ASC);
GO

-- Creating primary key on [WypSamId] in table 'WypSam'
ALTER TABLE [dbo].[WypSam]
ADD CONSTRAINT [PK_WypSam]
    PRIMARY KEY CLUSTERED ([WypSamId] ASC);
GO

-- Creating primary key on [KlientFirmaId] in table 'KlientFirma'
ALTER TABLE [dbo].[KlientFirma]
ADD CONSTRAINT [PK_KlientFirma]
    PRIMARY KEY CLUSTERED ([KlientFirmaId] ASC);
GO

-- Creating primary key on [OsobaId] in table 'Osoba'
ALTER TABLE [dbo].[Osoba]
ADD CONSTRAINT [PK_Osoba]
    PRIMARY KEY CLUSTERED ([OsobaId] ASC);
GO

-- Creating primary key on [WypozyczenieTempId] in table 'WypozyczenieTemp'
ALTER TABLE [dbo].[WypozyczenieTemp]
ADD CONSTRAINT [PK_WypozyczenieTemp]
    PRIMARY KEY CLUSTERED ([WypozyczenieTempId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WypozyczenieId] in table 'Akcesoria'
ALTER TABLE [dbo].[Akcesoria]
ADD CONSTRAINT [FK__Akcesoria__Wypoz__7E02B4CC]
    FOREIGN KEY ([WypozyczenieId])
    REFERENCES [dbo].[Wypozyczenie]
        ([WypozyczenieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Akcesoria__Wypoz__7E02B4CC'
CREATE INDEX [IX_FK__Akcesoria__Wypoz__7E02B4CC]
ON [dbo].[Akcesoria]
    ([WypozyczenieId]);
GO

-- Creating foreign key on [SamochodId] in table 'Cennik'
ALTER TABLE [dbo].[Cennik]
ADD CONSTRAINT [FK__Cennik__Samochod__6AEFE058]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Cennik__Samochod__6AEFE058'
CREATE INDEX [IX_FK__Cennik__Samochod__6AEFE058]
ON [dbo].[Cennik]
    ([SamochodId]);
GO

-- Creating foreign key on [SamochodId] in table 'Dostepnosc'
ALTER TABLE [dbo].[Dostepnosc]
ADD CONSTRAINT [FK__Dostepnos__Samoc__69FBBC1F]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Dostepnos__Samoc__69FBBC1F'
CREATE INDEX [IX_FK__Dostepnos__Samoc__69FBBC1F]
ON [dbo].[Dostepnosc]
    ([SamochodId]);
GO

-- Creating foreign key on [DowodOsobistyId] in table 'ImageDowodOsobisty'
ALTER TABLE [dbo].[ImageDowodOsobisty]
ADD CONSTRAINT [FK_Dowod_ImageDowod]
    FOREIGN KEY ([DowodOsobistyId])
    REFERENCES [dbo].[DowodOsobisty]
        ([DowodOsobistyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dowod_ImageDowod'
CREATE INDEX [IX_FK_Dowod_ImageDowod]
ON [dbo].[ImageDowodOsobisty]
    ([DowodOsobistyId]);
GO

-- Creating foreign key on [SamochodId] in table 'DowodRejestracyjny'
ALTER TABLE [dbo].[DowodRejestracyjny]
ADD CONSTRAINT [FK__DowodReje__Samoc__671F4F74]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DowodReje__Samoc__671F4F74'
CREATE INDEX [IX_FK__DowodReje__Samoc__671F4F74]
ON [dbo].[DowodRejestracyjny]
    ([SamochodId]);
GO

-- Creating foreign key on [DowodRejestracyjnyId] in table 'ImageDowodRejestracyjny'
ALTER TABLE [dbo].[ImageDowodRejestracyjny]
ADD CONSTRAINT [FK_DowodRejestracyjny_ImageDowodRejestracyjny]
    FOREIGN KEY ([DowodRejestracyjnyId])
    REFERENCES [dbo].[DowodRejestracyjny]
        ([DowodRejId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DowodRejestracyjny_ImageDowodRejestracyjny'
CREATE INDEX [IX_FK_DowodRejestracyjny_ImageDowodRejestracyjny]
ON [dbo].[ImageDowodRejestracyjny]
    ([DowodRejestracyjnyId]);
GO

-- Creating foreign key on [ImageId] in table 'ImageDowodOsobisty'
ALTER TABLE [dbo].[ImageDowodOsobisty]
ADD CONSTRAINT [FK_Image_ImageDowod]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Image]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Image_ImageDowod'
CREATE INDEX [IX_FK_Image_ImageDowod]
ON [dbo].[ImageDowodOsobisty]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'ImageDowodRejestracyjny'
ALTER TABLE [dbo].[ImageDowodRejestracyjny]
ADD CONSTRAINT [FK_Image_ImageDowodRejestracyjny]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Image]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Image_ImageDowodRejestracyjny'
CREATE INDEX [IX_FK_Image_ImageDowodRejestracyjny]
ON [dbo].[ImageDowodRejestracyjny]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'ImagePaszport'
ALTER TABLE [dbo].[ImagePaszport]
ADD CONSTRAINT [FK_Image_ImagePaszport]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Image]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Image_ImagePaszport'
CREATE INDEX [IX_FK_Image_ImagePaszport]
ON [dbo].[ImagePaszport]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'ImageSamochod'
ALTER TABLE [dbo].[ImageSamochod]
ADD CONSTRAINT [FK_Image_ImageSamochod]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Image]
        ([ImageId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Image_ImageSamochod'
CREATE INDEX [IX_FK_Image_ImageSamochod]
ON [dbo].[ImageSamochod]
    ([ImageId]);
GO

-- Creating foreign key on [PaszportId] in table 'ImagePaszport'
ALTER TABLE [dbo].[ImagePaszport]
ADD CONSTRAINT [FK_Paszport_ImagePaszport]
    FOREIGN KEY ([PaszportId])
    REFERENCES [dbo].[Paszport]
        ([PaszportId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Paszport_ImagePaszport'
CREATE INDEX [IX_FK_Paszport_ImagePaszport]
ON [dbo].[ImagePaszport]
    ([PaszportId]);
GO

-- Creating foreign key on [SamochodId] in table 'ImageSamochod'
ALTER TABLE [dbo].[ImageSamochod]
ADD CONSTRAINT [FK_Dowod_ImageSamochod]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dowod_ImageSamochod'
CREATE INDEX [IX_FK_Dowod_ImageSamochod]
ON [dbo].[ImageSamochod]
    ([SamochodId]);
GO

-- Creating foreign key on [SamochodId] in table 'Opis'
ALTER TABLE [dbo].[Opis]
ADD CONSTRAINT [FK__Opis__SamochodId__662B2B3B]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Opis__SamochodId__662B2B3B'
CREATE INDEX [IX_FK__Opis__SamochodId__662B2B3B]
ON [dbo].[Opis]
    ([SamochodId]);
GO

-- Creating foreign key on [PracownikId] in table 'PracownikWypozyczenie'
ALTER TABLE [dbo].[PracownikWypozyczenie]
ADD CONSTRAINT [FK__Pracownik__Praco__76619304]
    FOREIGN KEY ([PracownikId])
    REFERENCES [dbo].[Pracownik]
        ([PracownikId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pracownik__Praco__76619304'
CREATE INDEX [IX_FK__Pracownik__Praco__76619304]
ON [dbo].[PracownikWypozyczenie]
    ([PracownikId]);
GO

-- Creating foreign key on [WypozyczenieId] in table 'PracownikWypozyczenie'
ALTER TABLE [dbo].[PracownikWypozyczenie]
ADD CONSTRAINT [FK__Pracownik__Wypoz__7755B73D]
    FOREIGN KEY ([WypozyczenieId])
    REFERENCES [dbo].[Wypozyczenie]
        ([WypozyczenieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pracownik__Wypoz__7755B73D'
CREATE INDEX [IX_FK__Pracownik__Wypoz__7755B73D]
ON [dbo].[PracownikWypozyczenie]
    ([WypozyczenieId]);
GO

-- Creating foreign key on [SamochodId] in table 'Przeglad'
ALTER TABLE [dbo].[Przeglad]
ADD CONSTRAINT [FK__Przeglad__Samoch__6166761E]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Przeglad__Samoch__6166761E'
CREATE INDEX [IX_FK__Przeglad__Samoch__6166761E]
ON [dbo].[Przeglad]
    ([SamochodId]);
GO

-- Creating foreign key on [WypozyczenieId] in table 'Rozliczenie'
ALTER TABLE [dbo].[Rozliczenie]
ADD CONSTRAINT [FK__Rozliczen__Wypoz__607251E5]
    FOREIGN KEY ([WypozyczenieId])
    REFERENCES [dbo].[Wypozyczenie]
        ([WypozyczenieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Rozliczen__Wypoz__607251E5'
CREATE INDEX [IX_FK__Rozliczen__Wypoz__607251E5]
ON [dbo].[Rozliczenie]
    ([WypozyczenieId]);
GO

-- Creating foreign key on [SamochodId] in table 'Serwis'
ALTER TABLE [dbo].[Serwis]
ADD CONSTRAINT [FK__Serwis__Samochod__5E8A0973]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Serwis__Samochod__5E8A0973'
CREATE INDEX [IX_FK__Serwis__Samochod__5E8A0973]
ON [dbo].[Serwis]
    ([SamochodId]);
GO

-- Creating foreign key on [SamochodId] in table 'Ubezpieczenie'
ALTER TABLE [dbo].[Ubezpieczenie]
ADD CONSTRAINT [FK__Ubezpiecz__Samoc__5D95E53A]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Ubezpiecz__Samoc__5D95E53A'
CREATE INDEX [IX_FK__Ubezpiecz__Samoc__5D95E53A]
ON [dbo].[Ubezpieczenie]
    ([SamochodId]);
GO

-- Creating foreign key on [SamochodId] in table 'WypSam'
ALTER TABLE [dbo].[WypSam]
ADD CONSTRAINT [FK__WypSam__Samochod__5AB9788F]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__WypSam__Samochod__5AB9788F'
CREATE INDEX [IX_FK__WypSam__Samochod__5AB9788F]
ON [dbo].[WypSam]
    ([SamochodId]);
GO

-- Creating foreign key on [WydarzenieId] in table 'Wypozyczenie'
ALTER TABLE [dbo].[Wypozyczenie]
ADD CONSTRAINT [FK__Wypozycze__Wydar__5CA1C101]
    FOREIGN KEY ([WydarzenieId])
    REFERENCES [dbo].[Wydarzenie]
        ([WydarzenieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Wypozycze__Wydar__5CA1C101'
CREATE INDEX [IX_FK__Wypozycze__Wydar__5CA1C101]
ON [dbo].[Wypozyczenie]
    ([WydarzenieId]);
GO

-- Creating foreign key on [WypozyczenieId] in table 'WypSam'
ALTER TABLE [dbo].[WypSam]
ADD CONSTRAINT [FK__WypSam__Wypozycz__5BAD9CC8]
    FOREIGN KEY ([WypozyczenieId])
    REFERENCES [dbo].[Wypozyczenie]
        ([WypozyczenieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__WypSam__Wypozycz__5BAD9CC8'
CREATE INDEX [IX_FK__WypSam__Wypozycz__5BAD9CC8]
ON [dbo].[WypSam]
    ([WypozyczenieId]);
GO

-- Creating foreign key on [OsobaId] in table 'DowodOsobisty'
ALTER TABLE [dbo].[DowodOsobisty]
ADD CONSTRAINT [FK__DowodOsob__Osoba__7B264821]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DowodOsob__Osoba__7B264821'
CREATE INDEX [IX_FK__DowodOsob__Osoba__7B264821]
ON [dbo].[DowodOsobisty]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'KlientFirma'
ALTER TABLE [dbo].[KlientFirma]
ADD CONSTRAINT [FK__KlientFir__Osoba__3D2915A8]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__KlientFir__Osoba__3D2915A8'
CREATE INDEX [IX_FK__KlientFir__Osoba__3D2915A8]
ON [dbo].[KlientFirma]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'KlientIndywidualny'
ALTER TABLE [dbo].[KlientIndywidualny]
ADD CONSTRAINT [FK__KlientInd__Osoba__395884C4]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__KlientInd__Osoba__395884C4'
CREATE INDEX [IX_FK__KlientInd__Osoba__395884C4]
ON [dbo].[KlientIndywidualny]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'Paszport'
ALTER TABLE [dbo].[Paszport]
ADD CONSTRAINT [FK__Paszport__OsobaI__65370702]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Paszport__OsobaI__65370702'
CREATE INDEX [IX_FK__Paszport__OsobaI__65370702]
ON [dbo].[Paszport]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'Pracownik'
ALTER TABLE [dbo].[Pracownik]
ADD CONSTRAINT [FK__Pracownik__Osoba__72910220]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pracownik__Osoba__72910220'
CREATE INDEX [IX_FK__Pracownik__Osoba__72910220]
ON [dbo].[Pracownik]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'PrawoJazdy'
ALTER TABLE [dbo].[PrawoJazdy]
ADD CONSTRAINT [FK__PrawoJazd__Osoba__634EBE90]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PrawoJazd__Osoba__634EBE90'
CREATE INDEX [IX_FK__PrawoJazd__Osoba__634EBE90]
ON [dbo].[PrawoJazdy]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'Wypozyczenie'
ALTER TABLE [dbo].[Wypozyczenie]
ADD CONSTRAINT [FK__Wypozycze__Osoba__6CD828CA]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Wypozycze__Osoba__6CD828CA'
CREATE INDEX [IX_FK__Wypozycze__Osoba__6CD828CA]
ON [dbo].[Wypozyczenie]
    ([OsobaId]);
GO

-- Creating foreign key on [OsobaId] in table 'WypozyczenieTemp'
ALTER TABLE [dbo].[WypozyczenieTemp]
ADD CONSTRAINT [FK_WypozyczenieTemp_Osoba]
    FOREIGN KEY ([OsobaId])
    REFERENCES [dbo].[Osoba]
        ([OsobaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WypozyczenieTemp_Osoba'
CREATE INDEX [IX_FK_WypozyczenieTemp_Osoba]
ON [dbo].[WypozyczenieTemp]
    ([OsobaId]);
GO

-- Creating foreign key on [SamochodId] in table 'WypozyczenieTemp'
ALTER TABLE [dbo].[WypozyczenieTemp]
ADD CONSTRAINT [FK_WypozyczenieTemp_Samochod]
    FOREIGN KEY ([SamochodId])
    REFERENCES [dbo].[Samochod]
        ([SamochodId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WypozyczenieTemp_Samochod'
CREATE INDEX [IX_FK_WypozyczenieTemp_Samochod]
ON [dbo].[WypozyczenieTemp]
    ([SamochodId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------