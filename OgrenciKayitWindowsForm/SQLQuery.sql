CREATE DATABASE taksitDatabase;

USE taksitDatabase;

CREATE TABLE taksitlendirme(
    OgrenciID varchar(255) NOT NULL PRIMARY KEY,
	TaksitId INT  NOT NULL,
	TaksitNo INT NOT NULL,
	TaksitMiktar INT NOT NULL,
	TaksitTarihi DATE NOT NULL,
	TaksitOdemeDurumu BIT NOT NULL
)
