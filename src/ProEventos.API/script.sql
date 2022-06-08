CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "auditorios" (
    "IdAuditorio" INTEGER NOT NULL CONSTRAINT "PK_auditorios" PRIMARY KEY AUTOINCREMENT,
    "Nome" TEXT NULL,
    "Logradouro" TEXT NULL,
    "Telefone" TEXT NULL,
    "Email" TEXT NULL,
    "qdtAssentos" TEXT NULL,
    "possuiOnibusParaTransporte" INTEGER NOT NULL DEFAULT '0'
);

CREATE TABLE "eventos" (
    "EventoId" INTEGER NOT NULL CONSTRAINT "PK_eventos" PRIMARY KEY AUTOINCREMENT,
    "Local" TEXT NULL,
    "DataEvento" TEXT NULL,
    "Tema" TEXT NULL,
    "QtdPessoas" INTEGER NOT NULL,
    "Lote" TEXT NULL,
    "ImagemURL" TEXT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220607235910_InitialLite', '5.0.17');

COMMIT;

