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

CREATE TABLE [TourOffers] (
    [Id] int NOT NULL IDENTITY,
    [heading] nvarchar(max) NOT NULL,
    [TourImage] nvarchar(max) NOT NULL,
    [TourImages] nvarchar(max) NOT NULL,
    [RatingImage] nvarchar(max) NOT NULL,
    [LocationPng] nvarchar(max) NOT NULL,
    [CountryName] nvarchar(max) NOT NULL,
    [CountryNames] nvarchar(max) NOT NULL,
    [RatingText] nvarchar(max) NOT NULL,
    [PriceText] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TourOffers] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251125134622_Tourof', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TourOffers] DROP CONSTRAINT [PK_TourOffers];
GO

EXEC sp_rename N'[TourOffers]', N'tourOffers';
GO

ALTER TABLE [tourOffers] ADD CONSTRAINT [PK_tourOffers] PRIMARY KEY ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251204105653_FinalMigration', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251204115600_AddNewModels', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251204160251_FinalSchemaCreation', N'8.0.0');
GO

COMMIT;
GO

