CREATE TABLE [dbo].[Buecher]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Titel] VARCHAR(50) NULL, 
    [Author] VARCHAR(50) NULL, 
    [Kurzbeschreibung] VARCHAR(50) NULL, 
    [Kategorie] VARCHAR(20) NULL, 
    [Verlag] VARCHAR(30) NULL
)
