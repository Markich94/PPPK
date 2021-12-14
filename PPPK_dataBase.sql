CREATE DATABASE PPPK_Projekt
GO

USE PPPK_Projekt
GO

CREATE TABLE Vozac
(
	IDVozac int primary key identity,
	Ime nvarchar(50) not null,
	Prezime nvarchar(50) not null,
	BrojMobitela nvarchar(50) not null,
	BrojVozacke nvarchar(50) not null
)
GO

CREATE TABLE Vozilo
(
	IDVozilo int primary key identity,
	Marka nvarchar(50) not null,
	Tip nvarchar(50) not null,
	GodinaProizvodnje nvarchar(50) not null,
	InicijalnoStanjeKilometara nvarchar(50) not null
)
GO

CREATE TABLE PutniNalog
(
	IDPutniNalog int primary key identity,
	VozacID int not null,
	VoziloID int not null,
	Datum date not null,
	Tip nvarchar(1) not null,
	KoordinataA nvarchar(50) not null,
	KoordinataB nvarchar(50) not null,
	PrijedeniKilometri int null,
	ProsjecnaBrzina int null,
	PotrosenoGorivo int null
)
GO

CREATE TABLE Servis
(
	IDServis int primary key identity,
	Vozilo int not null,
	StanjeKilometara int not null,
	Napomena nvarchar(max),
	IduciServis int not null,
	Cijena int not null
)
GO

CREATE TABLE Grad
(
	IDGrad int primary key identity,
	Naziv nvarchar(50) not null,
	GeoSirina nvarchar(50) not null,
	GeoVisina nvarchar(50) not null
)
GO

CREATE PROC GetVozac
	@idVozac int
AS
SELECT * FROM Vozac WHERE IDVozac = @idVozac
GO

CREATE PROC GetVozaci
AS
SELECT * FROM Vozac
GO

CREATE PROC AddVozac
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@brojMobitela nvarchar(50),
	@brojVozacke nvarchar(50)
AS
INSERT INTO Vozac VALUES (@ime, @prezime, @brojMobitela, @brojVozacke)
GO

CREATE PROC UpdateVozac
	@idVozac int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@brojMobitela nvarchar(50),
	@brojVozacke nvarchar(50)
AS
UPDATE Vozac
SET Ime = @ime, Prezime = @prezime, BrojMobitela = @brojMobitela, BrojVozacke = @brojVozacke
WHERE IDVozac = @idVozac
GO

CREATE PROC DeleteVozac
	@idVozac int
AS
DELETE FROM Vozac WHERE IDVozac = @idVozac
GO

CREATE PROC GetVozilo
	@idVozilo int
AS
SELECT * FROM Vozilo WHERE IDVozilo = @idVozilo
GO

CREATE PROC GetVozila
AS
SELECT * FROM Vozilo
GO

CREATE PROC AddVozilo
	@marka nvarchar(50),
	@tip nvarchar(50),
	@godinaProizvodnje nvarchar(50),
	@stanjeKilometara nvarchar(50)
AS
INSERT INTO Vozilo VALUES (@marka, @tip, @godinaProizvodnje, @stanjeKilometara)
GO

CREATE PROC UpdateVozilo
	@idVozilo int,
	@marka nvarchar(50),
	@tip nvarchar(50),
	@stanjeKilometara nvarchar(50),
	@godinaProizvodnje nvarchar(50)
AS
UPDATE Vozilo
SET Marka = @marka, Tip = @tip, InicijalnoStanjeKilometara = @stanjeKilometara, GodinaProizvodnje = @godinaProizvodnje
WHERE IDVozilo = @idVozilo
GO

CREATE PROC DeleteVozilo
	@idVozilo int
AS
DELETE FROM Vozilo WHERE IDVozilo = @idVozilo
GO

CREATE PROC GetPutniNalozi
AS
SELECT * FROM PutniNalog
GO

CREATE PROC AddPutniNalog
	@vozacID int,
	@voziloID int,
	@datum date,
	@koordinataA nvarchar(50),
	@koordinataB nvarchar(50)
AS
INSERT INTO PutniNalog VALUES (@vozacID, @voziloID, @datum, '1', @koordinataA, @koordinataB, 0, 0, 0)
GO

CREATE PROC UpdatePutniNalog
	@idPutniNalog int,
	@vozacID int,
	@voziloID int,
	@datum date,
	@tip nvarchar(1),
	@koordinataA nvarchar(50),
	@koordinataB nvarchar(50),
	@prijedeniKilometri int,
	@prosjecnaBrzina int,
	@potrosenoGorivo int
AS
UPDATE PutniNalog
SET VozacID = @vozacID, VoziloID = @voziloID, Datum = @datum, Tip = @tip, KoordinataA = @koordinataA, KoordinataB = @koordinataB, PrijedeniKilometri = @prijedeniKilometri, ProsjecnaBrzina = @prosjecnaBrzina, PotrosenoGorivo = @potrosenoGorivo
WHERE IDPutniNalog = @idPutniNalog
GO

CREATE PROC DeletePutniNalog
	@idPutniNalog int
AS
DELETE FROM PutniNalog WHERE IDPutniNalog = @idPutniNalog
GO

CREATE PROC GetPutniNalog
	@idNalog int
AS
SELECT * FROM PutniNalog WHERE IDPutniNalog = @idNalog
GO

CREATE PROC AddServis
	@vozilo int,
	@stanjeKilometara int,
	@napomena nvarchar(max),
	@iduciServis int,
	@cijena int
AS
INSERT INTO Servis VALUES (@vozilo, @stanjeKilometara, @napomena, @iduciServis, @cijena)
GO

CREATE PROC GetServis
	@voziloId int
AS
SELECT TOP 1 * FROM Servis WHERE Vozilo = @voziloId
GO

CREATE PROC GetServisiVozilo
	@voziloId int
AS
SELECT Marka, Tip, GodinaProizvodnje, Napomena, StanjeKilometara, IduciServis, Cijena
FROM Servis INNER JOIN Vozilo ON Vozilo.IDVozilo = Servis.Vozilo
WHERE IDVozilo = @voziloId
GO

CREATE PROC NapuniBazu
AS
INSERT INTO Vozac VALUES ('Marko', 'Manjerović', '0911114994', '83652438')
INSERT INTO Vozac VALUES ('Maja', 'Puškarić', '0996451418', '429476352')
INSERT INTO Vozac VALUES ('Ante', 'Manjerović', '0912605996', '73427345')
INSERT INTO Vozac VALUES ('Ivan', 'Manjerović', '0912707999', '29736484')
INSERT INTO Vozac VALUES ('Roberta', 'Čurilović', '0911402999', '65497321')

INSERT INTO Vozilo VALUES ('Audi', 'A3', '2005', '186500')
INSERT INTO Vozilo VALUES ('VW', 'Passat', '2016', '102000')
INSERT INTO Vozilo VALUES ('Audi', 'A4', '2009', '212000')
INSERT INTO Vozilo VALUES ('BMW', '320d', '2006', '195000')
INSERT INTO Vozilo VALUES ('Seat', 'Alhambra', '2005', '230000')
INSERT INTO Vozilo VALUES ('Škoda', 'Octavia', '2019', '23000')
GO

CREATE PROC OcistiBazu
AS
DELETE FROM Servis
DELETE FROM PutniNalog
DELETE FROM Vozilo
DELETE FROM Vozac
GO

CREATE PROC SELECT_PUTNE_NALOGE
AS
SELECT * FROM PutniNalog
GO

CREATE PROC SELECT_ALL
AS
SELECT * FROM Vozac
SELECT * FROM Vozilo
SELECT * FROM PutniNalog
SELECT * FROM Servis
GO

SELECT * FROM Vozac
SELECT * FROM Vozilo
SELECT * FROM Grad
SELECT * FROM PutniNalog
SELECT * FROM Servis

SELECT Marka, Tip, GodinaProizvodnje, Napomena, StanjeKilometara, IduciServis, Cijena
FROM Servis INNER JOIN Vozilo ON Vozilo.IDVozilo = Servis.Vozilo
WHERE IDVozilo = 1046