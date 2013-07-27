-- TASK 01
-- Creating ATM Database and some samples

CREATE DATABASE ATM

USE ATM 
GO

CREATE TABLE CardAccounts(
CardAccountsID int NOT NULL IDENTITY,
CardNumber char(10) NOT NULL,
CardPIN char(4) NOT NULL,
CardCash money NOT NULL
CONSTRAINT PK_CardAccounts PRIMARY KEY(CardAccountsID),
CONSTRAINT uc_CardNumber UNIQUE (CardNumber)
)
GO

INSERT INTO CardAccounts (CardNumber, CardPIN, CardCash) VALUES
('1111111111', '1234', 1000), ('2222222222', '6567', 2290),
('4444444444', '5432', 90000), ('3333333333', '9876', 1220)

