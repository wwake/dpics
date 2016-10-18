CREATE DATABASE oozinoz;

CREATE TABLE [Firework]
 (
	[Name]			Text (100), 
	[Price]			Currency, 
	[Mass]			Double
);

CREATE TABLE [RocketDetail]
 (
	[Name]			Text (100), 
	[Apogee]			Double, 
	[Thrust]			Double
);

CREATE TABLE [CellMachine]
 (
	[Type]			Text (100), 
	[ID]			Long Integer
);


CREATE VIEW Rocket
AS SELECT f.Name, Price, Mass, Apogee, Thrust
FROM Firework f, RocketDetail rd
WHERE f.name = rd.name
;

GO