CREATE TABLE [dbo].[Soru] (
    [soruId]     NVARCHAR (50) NOT NULL,
    [sorular]    NVARCHAR (50) NOT NULL,
    [soruCevap]  NVARCHAR (50) NOT NULL,
    [soruSayisi] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([soruId] ASC)
);

