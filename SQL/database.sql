IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [tb_AnuncioWebmotors] (
    [ID] int NOT NULL IDENTITY,
    [marca] varchar(45) NOT NULL,
    [modelo] varchar(45) NOT NULL,
    [versao] int NOT NULL,
    [ano] int NOT NULL,
    [quilometragem] int NOT NULL,
    [observacao] text NOT NULL,
    CONSTRAINT [PK_tb_AnuncioWebmotors] PRIMARY KEY ([ID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220301194454_InitAnuncios', N'5.0.14');
GO

COMMIT;
GO