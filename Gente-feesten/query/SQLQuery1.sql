CREATE TABLE [dbo].[Personen] 
(     
	[Id]  INT IDENTITY(1, 1) NOT NULL,     
	[Naam] TEXT NOT NULL    ,
	[Email] TEXT NULL,     
	[Geboortedatum] DATETIME NULL,  
	PRIMARY KEY CLUSTERED([Id] ASC)   
);  

INSERT INTO Personen (Naam, Email, Geboortedatum) VALUES ('Jan','jan@hotmail.com', '2001-01-27'); 
INSERT INTO Personen (Naam, Email, Geboortedatum) VALUES ('Pol', 'pol@gmail.com','2002-02-28');
