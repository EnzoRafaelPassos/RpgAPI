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

CREATE TABLE [Personagens] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [PontosVida] int NOT NULL,
    [Forca] int NOT NULL,
    [Defesa] int NOT NULL,
    [Inteligencia] int NOT NULL,
    [Classe] int NOT NULL,
    CONSTRAINT [PK_Personagens] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] ON;
INSERT INTO [Personagens] ([Id], [Classe], [Defesa], [Forca], [Inteligencia], [Nome], [PontosVida])
VALUES (1, 1, 23, 17, 33, N'Frodo', 100),
(2, 1, 25, 15, 30, N'Sam', 100),
(3, 3, 21, 18, 35, N'Galadriel', 100),
(4, 2, 18, 18, 37, N'Gandalf', 100),
(5, 1, 17, 20, 31, N'Hobbit', 100),
(6, 3, 13, 21, 34, N'Celeborn', 100),
(7, 2, 11, 25, 35, N'Radagast', 100);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'Inteligencia', N'Nome', N'PontosVida') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220324143634_InitialCreate', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] ADD [FotoPersonagem] varbinary(max) NULL;
GO

ALTER TABLE [Personagens] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] nvarchar(max) NULL,
    [Longitude] nvarchar(max) NULL,
    [DataAcesso] datetime2 NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [DataAcesso], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Username])
VALUES (1, NULL, NULL, NULL, NULL, 0xFAEBAAE612A0277D07A9ED5057BF8017C48759FEB0AFE7EE079737237E0C09D23DEB1DDE4B6282942DA42BC9D0B67D9D9D62BB1CE05E7F393C5AF9DDA3E68CD6, 0x08F337A648FEFF42C2498A248853B9FF1C4B71220803C0492C892C7D50DBF1A58D97697238352DEDC7426B324098F2BC52F8FEAEE078A29F88CCAAD1129FE3AE83B31E34012F99A0207C6A53FD7D463672DA4A5F6F594744D6A7C183447C9875ACD9C7EB30703FF7BD265EE28FB9661418A1BD95F227CD035FDAD4E0D2504414, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Username') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_Personagens_UsuarioId] ON [Personagens] ([UsuarioId]);
GO

ALTER TABLE [Personagens] ADD CONSTRAINT [FK_Personagens_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406150622_MigracaoUsuario', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome], [PersonagemId])
VALUES (1, 35, N'Arco e Flecha', 1),
(2, 33, N'Espada', 2),
(3, 31, N'Machado', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x521A4CB3C0388335B443D3B9B971E96404A1D0D86A0FDBF9E4CA797401ADA6ADB13A361288088267AD4944F11C6B5CB0CE4292C601488F38510F0D2DC2E8EF08, [PasswordSalt] = 0xDEB557F6D6AE4BBF5F8CA232F027141CE9373A47F4925BF966CDCD0D5D1B18E1DE1351B1BA685330B0E956E976C38AE8082324D63D30B6C51C5030A3AD25DC7FB43A827BE42DFD66981030C62F6645E4A7D4957A89EEBE1B651B557C3785C58EA9B57E4248E37F26A2BC81A3A906BD994C6934610AB2095966B0EEE16581EACA
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406153523_MigracaoUmParaUm', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x03A13A9439F323129EBF06D95F77725A61FADF269072FE8D9C8957D600D501A76879C3F8CCDDFBD8CD275F189092B95E0FD9E69EC45D788DD168378F7D28FAF5, [PasswordSalt] = 0xB9627F17E220479077ACBBA68BE1D5C4488F112D0C2B7FB928D369B95B9191E540AE3005129F5C306E5DAA2343107872E470919736BFC27C17B074B7F31C1B04341B79F0F6E3FB185F74C0B4C95622CA5EE10A521F3A4D2BDF082996357C3270956DAA02F42AF608119BBB0B5B7AA33E81CCA28016A7CD3983B471ED6888388B
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(1, 5),
(2, 1),
(2, 2),
(2, 3),
(2, 6),
(3, 3),
(3, 4),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220406155242_MigracaoMuitosParaMuitos', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x0C16053A761E5C21E9FD1A6121631FD87907588221598AE80C1DB96C401BB50984153181506477864DC3BFD8FAF474C635387C6CCF73FE65F23A38FE79ECA70B, [PasswordSalt] = 0x5F6EA1985DEB96D19BC5EF685C8CCB60E4797511D3DB894DBE066002A8122E18F4F27E8F190A418A96BBB92BDCC5F5C80AD1EA109FACC8DF927B53207D00E52843E3983059C19C9FD334F5C11D31B3A7538A4DB853F2F575CBB37AB2D47D8C989E7C930E0DA239D02B68EF52577C9824291A2468A3B4F46357C8369C3D4CB136
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220506012451_MigracaoPerfil', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Usuarios]') AND [c].[name] = N'Perfil');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Usuarios] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Usuarios] ALTER COLUMN [Perfil] nvarchar(max) NULL;
ALTER TABLE [Usuarios] ADD DEFAULT N'Jogador' FOR [Perfil];
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x37772644D2076D5D160018A191252FA921A32CFF06D0E382B78739B307E313BDF5578CA7209FE3D23A94282BDF2E5326BD49523A1F0322A790B16597A3DA40E4, [PasswordSalt] = 0x9ACA6C7A986ABDDD5DDF0B451B66AA93DFFFDF4BF28871D6F60310714C2B2CADCE722902FB0A397CB08F09C76C7B780B215B99D11A0BC4EC0C32D2C9CA35DB8C61E45C8039C2C93413E66BC4E2728E1B98D81B14F672F045290A8D5087724FAE5C8933738C7A48CBB3B1B01A310628F7EA4C5617E148C3D43C3C7B5E64483692
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220512232137_12052022', N'5.0.15');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Usuarios] ADD [Email] nvarchar(max) NULL;
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Disputas] (
    [Id] int NOT NULL IDENTITY,
    [DataDisputa] datetime2 NULL,
    [AtacanteId] int NOT NULL,
    [OponenteId] int NOT NULL,
    [Narracao] int NOT NULL,
    CONSTRAINT [PK_Disputas] PRIMARY KEY ([Id])
);
GO

UPDATE [Usuarios] SET [PasswordHash] = 0x2EB25376406E747305F0F72E36EA3B80ED161EB18A89118E2328F08B45C6F7074F5788908AFA0832CBFF7355B56B304DF531B45B8C77D17A0CB853C986ABC331, [PasswordSalt] = 0x031DAD84CE28319DF7D355DC2AC8ECE5E775E250C989395F788D75B0228C3227D48CC61CAE33CB0B73AADF21B1913955A8E833766E2FCFE54A514663462FB0CA99D0E213E0FE3B87606A4B11CF6C0E67E183FDD4F29CC43C09DB27F0669145E8BCC6D405801B9B98652A3F1A7DE245C353F1A62A7324E9EA64E635C9021DB7DE
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220512235242_MigracaoDisputas', N'5.0.15');
GO

COMMIT;
GO

