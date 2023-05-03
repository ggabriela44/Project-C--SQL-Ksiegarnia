BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230124170617_Test', N'6.0.12');
GO

COMMIT;
GO

