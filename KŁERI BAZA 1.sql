CREATE TABLE [dbo].[Osoba] (
    [OsobaId]                 INT IDENTITY (1,1) NOT NULL,
    [Imie]		      VARCHAR (64) NOT NULL,
    [Nazwisko]		      VARCHAR (64) NOT NULL,
    [DataUrodzenia]           DATE         NOT NULL,
    [Adres]                   VARCHAR (64) NOT NULL,
    [KodPocztowy]             VARCHAR (32) NOT NULL,
    [Kraj]                    VARCHAR (32) NOT NULL,
    [NrTelefonu]              VARCHAR (32) NOT NULL,
    [Miasto]                  VARCHAR (32) NOT NULL,
    CONSTRAINT [Osoba_PK] PRIMARY KEY CLUSTERED ([OsobaId] ASC),
);

CREATE TABLE [dbo].[Opis] (
    [OpisId]               INT  IDENTITY (1,1) NOT NULL,
    [OpisOgolny]           VARCHAR (MAX) NOT NULL,
    [Wyposazenie]          VARCHAR (MAX) NOT NULL,
    CONSTRAINT [Opis_PK] PRIMARY KEY CLUSTERED ([OpisId] ASC)
);

CREATE TABLE [dbo].[KlientIndywidualny] (
    [KlientIndywidualnyId]   INT IDENTITY (1,1) NOT NULL,
    [Rabat]                INT NULL,
    [OsobaId] INT UNIQUE FOREIGN KEY REFERENCES dbo.Osoba(OsobaId),
    CONSTRAINT [KlientIndywidualny_PK] PRIMARY KEY CLUSTERED ([KlientIndywidualnyId] ASC)
);

CREATE TABLE [dbo].[KlientFirma] (
    [KlientFirmaId]           INT IDENTITY(1,1) NOT NULL,
    [NazwaFrimy]              VARCHAR (32) NOT NULL,
    [NIP]                     VARCHAR (64) NOT NULL,
    [RabatFirma]              INT          NULL,
    [AdresFirmy]              VARCHAR (64) NULL,
    [KodPocztowy]             VARCHAR (16) NULL,
    [Miasto]                  VARCHAR (16) NULL,
    [OsobaId] INT UNIQUE FOREIGN KEY REFERENCES dbo.Osoba(OsobaId),
    CONSTRAINT [KlientFirma_PK] PRIMARY KEY CLUSTERED ([KlientFirmaId] ASC)
);

CREATE TABLE [dbo].[DowodRejestracyjny] (
    [DowodRejId]           INT IDENTITY(1,1) NOT NULL,
    [VIN]                  VARCHAR (32) NOT NULL,
    [Seria]                INT          NOT NULL,
    [NrRejestracyjny]      VARCHAR (32) NOT NULL,
    CONSTRAINT [DowodRejestracyjny_PK] PRIMARY KEY CLUSTERED ([DowodRejId] ASC),
);

CREATE TABLE [dbo].[DowodOsobisty] (
    [PESEL]          INT IDENTITY(1,1)       NOT NULL,
    [NrDowodu]       VARCHAR (32) NOT NULL,
    [TerminWaznosci] DATE         NOT NULL,
    CONSTRAINT [DowodOsobisty_PK] PRIMARY KEY CLUSTERED ([PESEL] ASC)
);

CREATE TABLE [dbo].[Dostepnosc] (
    [DostepnoscId]         INT IDENTITY(1,1)     NOT NULL,
    [NiedostepnyOd]        DATETIME NULL,
    [NiedostepnyDo]        DATETIME NOT NULL,
    CONSTRAINT [Dostepnosc_PK] PRIMARY KEY CLUSTERED ([DostepnoscId] ASC)
);

CREATE TABLE [dbo].[Cennik] (
    [CennikId]         INT  IDENTITY(1,1)      NOT NULL,
    [Opis]			   VARCHAR(64),
    [Cena]             FLOAT (53) NOT NULL,
    [Samochod_IdSamochodu] INT        NOT NULL,
    CONSTRAINT [Cennik_PK] PRIMARY KEY CLUSTERED ([CennikId] ASC)
);

CREATE TABLE [dbo].[Akcesoria] (
    [IdAkcesoria]                 INT IDENTITY(1,1)          NOT NULL,
    [Nazwa]						  VARCHAR (MAX) NOT NULL,
	[Opis]						  VARCHAR (MAX) NOT NULL,
    [Cena]                        FLOAT (53)    NOT NULL,
    CONSTRAINT [Akcesoria_PK] PRIMARY KEY CLUSTERED ([IdAkcesoria] ASC)
);

CREATE TABLE [dbo].[Paszport] (
	[PaszportId]	INT IDENTITY(1,1) NOT NULL,
    [NrPaszportu]    VARCHAR (64) NOT NULL,
    [TerminWaznosci] DATE         NULL,
    CONSTRAINT [Paszport_PK] PRIMARY KEY CLUSTERED ([NrPaszportu] ASC)
);

CREATE TABLE [dbo].[PrawoJazdy] (
    [PrawoJazdyId]                            INT IDENTITY(1,1) NOT NULL,
    [NrPrawaJazdy]                            VARCHAR (32) NOT NULL,
    [KrajWydania]                             VARCHAR (32) NOT NULL,
    [Kategoria]                               VARCHAR (2)  NOT NULL,
    CONSTRAINT [PrawoJazdy_PK] PRIMARY KEY CLUSTERED ([PrawoJazdyId] ASC)
);

CREATE TABLE [dbo].[Przeglad] (
    [PrzegladId]             INT  IDENTITY(1,1) NOT NULL,
    [DataPrzegladu]          DATE          NOT NULL,
    [DataKolejnegoPrzegladu] DATE          NOT NULL,
    [Uwagi]                  VARCHAR (MAX) NULL,
    CONSTRAINT [Przeglad_PK] PRIMARY KEY CLUSTERED ([PrzegladId] ASC),
);

CREATE TABLE [dbo].[Rozliczenie] (
    [RozliczenieId]               INT IDENTITY(1,1)     NOT NULL,
    [DodatkoweOplaty]             FLOAT (53) NULL,
    [Zaliczka]                    FLOAT (53) NOT NULL,
    [DodatkowyRabat]              FLOAT (53) NULL,
    [CalkowityKoszt]              FLOAT (53) NOT NULL,
    CONSTRAINT [Rozliczenie_PK] PRIMARY KEY CLUSTERED ([RozliczenieId] ASC)
);

CREATE TABLE [dbo].[Samochod] (
    [SamochodId]                    INT IDENTITY(1,1) NOT NULL,
    [Marka]                         VARCHAR (32) NOT NULL,
    [Model]                         VARCHAR (32) NOT NULL,
    [Wersja]                        VARCHAR (64) NOT NULL,
    [RokProdukcji]                  DATE         NOT NULL,
    [RodzajSilnika]                 VARCHAR (16) NOT NULL,
    [PojemnoscSilnika]              VARCHAR (16) NOT NULL,
    [SkrzyniaBiegow]                VARCHAR (16) NOT NULL,
    [LiczbaDrzwi]                   VARCHAR (32) NOT NULL,
    [Kolor]                         VARCHAR (16) NOT NULL,
    [Przebieg]                      INT          NOT NULL,
    CONSTRAINT [Samochod_PK] PRIMARY KEY CLUSTERED ([SamochodId] ASC),
);

CREATE TABLE [dbo].[Serwis] (
    [SerwisId]             INT IDENTITY(1,1) NOT NULL,
    [DataOddania]          DATE          NOT NULL,
    [DataOdbioru]          DATE          NOT NULL,
    [Koszt]                FLOAT (53)    NOT NULL,
    [Uwagi]                VARCHAR (MAX) NULL,
    CONSTRAINT [Serwis_PK] PRIMARY KEY CLUSTERED ([SerwisId] ASC)
);

CREATE TABLE [dbo].[Ubezpieczenie] (
    [UbezpieczenieId]      INT IDENTITY(1,1) NOT NULL,
    [NumerPolisy]          VARCHAR (32) NOT NULL,
    [WazneOd]              DATE         NOT NULL,
    [WazneDo]              DATE         NOT NULL,
    CONSTRAINT [Ubezpieczenie_PK] PRIMARY KEY CLUSTERED ([UbezpieczenieId] ASC)
);

CREATE TABLE [dbo].[Wydarzenie] (
    [WydarzenieId]    INT   IDENTITY(1,1)        NOT NULL,
    [NazwaWydarzenia] VARCHAR (32)  NOT NULL,
    [Opis]            VARCHAR (MAX) NULL,
    CONSTRAINT [Wydarzenie_PK] PRIMARY KEY CLUSTERED ([WydarzenieId] ASC)
);

CREATE TABLE [dbo].[Wypozyczenie] (
    [WypozyczenieId]            INT IDENTITY(1,1) NOT NULL,
    [DataWypozyczenia]          DATE         NOT NULL,
    [DataZwrotu]                DATE         NOT NULL,
    [CzyDostarczany]            BIT          NOT NULL,
    [CzyKierowca]               BIT          NOT NULL,
    [AdresDojazdu]              VARCHAR (64) NULL,
    CONSTRAINT [Wypozyczenie_PK] PRIMARY KEY CLUSTERED ([WypozyczenieId] ASC)
);

CREATE TABLE [dbo].[WypSam] (
[WypSamId] INT IDENTITY(1,1) NOT NULL,
CONSTRAINT [WypSam_PK] PRIMARY KEY CLUSTERED ([WypSamId] ASC)
);