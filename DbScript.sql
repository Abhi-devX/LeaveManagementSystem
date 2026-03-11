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

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Department] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [LeaveRequests] (
    [Id] int NOT NULL IDENTITY,
    [EmployeeId] int NOT NULL,
    [FromDate] datetime2 NOT NULL,
    [ToDate] datetime2 NOT NULL,
    [Reason] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_LeaveRequests] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Role] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260311101519_InitialCreate', N'8.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Department', N'Email', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([Id], [Department], [Email], [IsActive], [Name])
VALUES (1, N'IT', N'rahul@test.com', CAST(1 AS bit), N'Rahul Patil'),
(2, N'HR', N'sneha@test.com', CAST(1 AS bit), N'Sneha Sharma'),
(3, N'Finance', N'amit@test.com', CAST(1 AS bit), N'Amit Kulkarni'),
(4, N'IT', N'priya@test.com', CAST(1 AS bit), N'Priya Deshmukh'),
(5, N'Sales', N'rohit@test.com', CAST(1 AS bit), N'Rohit Singh'),
(6, N'HR', N'neha@test.com', CAST(1 AS bit), N'Neha Joshi'),
(7, N'Marketing', N'karan@test.com', CAST(1 AS bit), N'Karan Mehta'),
(8, N'Support', N'pooja@test.com', CAST(1 AS bit), N'Pooja Verma'),
(9, N'IT', N'aditya@test.com', CAST(1 AS bit), N'Aditya Patil'),
(10, N'Finance', N'simran@test.com', CAST(1 AS bit), N'Simran Kaur');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Department', N'Email', N'IsActive', N'Name') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Email], [Name], [Password], [Role])
VALUES (1, N'admin@example.com', N'Admin', N'admin123', N'Admin'),
(2, N'employee@example.com', N'Employee', N'emp123', N'Employee');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password', N'Role') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EmployeeId', N'FromDate', N'Reason', N'Status', N'ToDate') AND [object_id] = OBJECT_ID(N'[LeaveRequests]'))
    SET IDENTITY_INSERT [LeaveRequests] ON;
INSERT INTO [LeaveRequests] ([Id], [EmployeeId], [FromDate], [Reason], [Status], [ToDate])
VALUES (1, 1, '2026-03-10T00:00:00.0000000', N'Personal Work', N'Approved', '2026-03-12T00:00:00.0000000'),
(2, 2, '2026-03-14T00:00:00.0000000', N'Medical Leave', N'Pending', '2026-03-15T00:00:00.0000000'),
(3, 3, '2026-03-20T00:00:00.0000000', N'Family Function', N'Approved', '2026-03-22T00:00:00.0000000');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'EmployeeId', N'FromDate', N'Reason', N'Status', N'ToDate') AND [object_id] = OBJECT_ID(N'[LeaveRequests]'))
    SET IDENTITY_INSERT [LeaveRequests] OFF;
GO

CREATE INDEX [IX_LeaveRequests_EmployeeId] ON [LeaveRequests] ([EmployeeId]);
GO

ALTER TABLE [LeaveRequests] ADD CONSTRAINT [FK_LeaveRequests_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260311111930_SeedInitialData', N'8.0.25');
GO

COMMIT;
GO

