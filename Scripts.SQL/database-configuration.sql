--DATABASE
CREATE DATABASE TicketsDB;
GO

USE TicketsDB;
GO
    --SCHEMA
CREATE SCHEMA HelpDesk;
GO

BEGIN TRY
    -- 1. Iniciar la transacción
    BEGIN TRANSACTION;

    --TABLES
    --[HelpDesk].[Teams]
    CREATE TABLE [HelpDesk].[Teams]
    (
	    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	    Code NVARCHAR(50) NOT NULL,
	    Label NVARCHAR(50) NOT NULL,
	    Name NVARCHAR(200) NOT NULL,
	    Description NVARCHAR(500) NULL,
	    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
    );
   

    --[HelpDesk].[TeamMembers]
    CREATE TABLE [HelpDesk].[TeamMembers]
    (
	    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	    Name NVARCHAR(200) NOT NULL,
	    Email NVARCHAR(320) NOT NULL UNIQUE,
	    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	    TeamId INT NOT NULL,
	    CONSTRAINT FK_TeamMember_Team
	    FOREIGN KEY (TeamId) REFERENCES [HelpDesk].[Teams] (Id) ON DELETE CASCADE
    );

    --[HelpDesk[.[Role]
    CREATE TABLE [HelpDesk].[Roles] (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        Name NVARCHAR(250) NOT NULL,
        Description NVARCHAR(256) NULL,
        Active INT NOT NULL DEFAULT 1,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    );

    --[HelpDesk].[Users]
    CREATE TABLE [HelpDesk].[Users] (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        Name NVARCHAR(250) NOT NULL,
        Email NVARCHAR(256) NOT NULL,
        Password NVARCHAR(MAX) NOT NULL,
        Active INT NOT NULL DEFAULT 1,
        CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
        LastLoginAt DATETIME2 NULL,
        RoleId INT NOT NULL,
        CONSTRAINT FK_Users_Roles_RoleId FOREIGN KEY (RoleId) 
            REFERENCES HelpDesk.Roles(Id)
    );

    --[HelpDesk].[TicketCategory]
    CREATE TABLE [HelpDesk].[TicketCategory] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(100) NOT NULL,
        [Code] NVARCHAR(50) NOT NULL,
        [Description] NVARCHAR(500) NULL,
	    [Active] INT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
    );

    --[HelpDesk].[TicketStatus]
    CREATE TABLE [HelpDesk].[TicketStatus] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(100) NOT NULL,
        [Code] NVARCHAR(50) NOT NULL,
        [Description] NVARCHAR(500) NULL,
	    [Active] INT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
    );

    --[HelpDesk].[TicketPriority]
    CREATE TABLE [HelpDesk].[TicketPriority] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Name] NVARCHAR(100) NOT NULL,
        [Code] NVARCHAR(50) NOT NULL,
        [Description] NVARCHAR(500) NULL,
	    [Active] INT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE()
    );

    --[HelpDesk].[Ticket]
    CREATE TABLE [HelpDesk].[Ticket] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Title] NVARCHAR(250) NOT NULL,
        [Description] NVARCHAR(MAX) NULL,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [StatusId] INT NOT NULL,
        [PriorityId] INT NOT NULL,
        [CategoryId] INT NOT NULL,
        [UserId] INT NOT NULL,

        CONSTRAINT [FK_Ticket_Status_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [HelpDesk].[TicketStatus] ([Id]),
        CONSTRAINT [FK_Ticket_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [HelpDesk].[TicketPriority] ([Id]),
        CONSTRAINT [FK_Ticket_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [HelpDesk].[TicketCategory] ([Id]),
        CONSTRAINT [FK_Ticket_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [HelpDesk].[Users] ([Id])
    );

    --[HelpDesk].[TicketAssignment]
    CREATE TABLE [HelpDesk].[TicketAssignment] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Active] INT NOT NULL DEFAULT 1,
        [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [TicketId] INT NOT NULL,
        [TeamMemberId] INT NOT NULL,
        CONSTRAINT [FK_Ticket_Assignment_TicketId] FOREIGN KEY ([TicketId]) REFERENCES [HelpDesk].[Ticket] ([Id]),
        CONSTRAINT [FK_Ticket_Assignment_TeamMemberId] FOREIGN KEY ([TeamMemberId]) REFERENCES [HelpDesk].[TeamMembers] ([Id])
    );

    --AUDIT

    --[HelpDesk].[TicketAuditLog]
    CREATE TABLE [HelpDesk].[TicketAuditLog] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [Date] DATETIME2 NOT NULL DEFAULT GETDATE(),
        [Operation] VARCHAR(10) NOT NULL, -- Guardará 'INSERT' o 'UPDATE'

        -- Columnas provenientes de Ticket con prefijo 'Ticket'
        [TicketId] INT NOT NULL,
        [TicketTitle] NVARCHAR(250) NULL,
        [TicketDescription] NVARCHAR(MAX) NULL,
        [TicketCreatedAt] DATETIME2 NOT NULL,
        [TicketUpdatedAt] DATETIME2 NOT NULL,
        [TicketStatusId] INT NOT NULL,
        [TicketPriorityId] INT NOT NULL,
        [TicketCategoryId] INT NOT NULL,
        [TicketUserId] INT NOT NULL
    );
   
    COMMIT TRANSACTION;
    
    PRINT 'Transacción completada con éxito.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT 'Ocurrió un error y se revirtió la creación de las tablas.';
    END;

    USE master;
    DROP DATABASE TicketsDB;

    THROW;
END CATCH;
GO
    
CREATE OR ALTER TRIGGER [HelpDesk].[TR_Ticket_Insert_AuditLog]
ON [HelpDesk].[Ticket]
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Evaluar el tipo de operación
    DECLARE @Operation VARCHAR(10);

    IF EXISTS (SELECT 1 FROM deleted)
        SET @Operation = 'UPDATE';
    ELSE
        SET @Operation = 'INSERT';

    INSERT INTO [HelpDesk].[TicketAuditLog] (
        [Operation],
        [TicketId],
        [TicketTitle],
        [TicketDescription],
        [TicketCreatedAt],
        [TicketUpdatedAt],
        [TicketStatusId],
        [TicketPriorityId],
        [TicketCategoryId],
        [TicketUserId]
    )
    SELECT 
        @Operation,
        i.[Id],
        i.[Title],
        i.[Description],
        i.[CreatedAt],
        i.[UpdatedAt],
        i.[StatusId],
        i.[PriorityId],
        i.[CategoryId],
        i.[UserId]
    FROM inserted i;
END;
GO
