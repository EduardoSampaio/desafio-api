DROP TABLE [USERS]
DROP TABLE [Role]
DROP TABLE [Address]
DROP TABLE [Profile]
DROP TABLE [ProfileRole]


CREATE TABLE [Users](
	ID UNIQUEIDENTIFIER NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL, 
	Email NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	Nationality NVARCHAR(30) NOT NULL,
	CPF NVARCHAR(15) NOT NULL,
	[Login] NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(36) NOT NULL,
	Phone NVARCHAR(20) NULL,
	CellPhone NVARCHAR(20) NULL,
	IsActive BIT NOT NULL,
	CreatedAt DATETIME NOT NULL,
	DeletedAt DATETIME NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	DeletedBy UNIQUEIDENTIFIER NULL,
	AddressId UNIQUEIDENTIFIER NULL,
	[ProfileId] UNIQUEIDENTIFIER NULL
)

ALTER TABLE [Users]
ADD CONSTRAINT PK_USERs PRIMARY KEY(ID)


CREATE TABLE [Address] (
	Id UNIQUEIDENTIFIER NOT NULL,
	Number int NULL,
	Complement NVARCHAR(100) NULL,
	Neighborhood NVARCHAR(30) NULL,
	City NVARCHAR(30) NULL,
	[State] char(2) NULL,
	ZipCode NVARCHAR(10) NULL
)


ALTER TABLE [Address] 
ADD CONSTRAINT PK_ADDRESS PRIMARY KEY(Id)

CREATE TABLE [Profile](
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
)


ALTER TABLE [Profile]
ADD CONSTRAINT PK_PROFILE PRIMARY KEY(Id)

CREATE TABLE ProfileRole(
	Id UNIQUEIDENTIFIER NOT NULL,
	ProfileId UNIQUEIDENTIFIER NOT NULL,
	RoleId UNIQUEIDENTIFIER NOT NULL
)


ALTER TABLE ProfileRole 
ADD CONSTRAINT PK_ProfileRole PRIMARY KEY(Id)

CREATE TABLE [Role] (
	Id UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL
)


ALTER TABLE [Role] 
ADD CONSTRAINT PK_Role PRIMARY KEY(Id)

ALTER TABLE [Users]
ADD CONSTRAINT FK_USER_ADDRESS FOREIGN KEY(AddressId)
REFERENCES [Address](Id)

ALTER TABLE [Users]
ADD CONSTRAINT FK_USER_PROFILE FOREIGN KEY(ProfileId)
REFERENCES [Profile](Id)

ALTER TABLE ProfileRole
ADD CONSTRAINT FK_Role_ProfileRole FOREIGN KEY(RoleId)
REFERENCES [Role](Id)

ALTER TABLE ProfileRole
ADD CONSTRAINT FK_Profile_ProfileRole FOREIGN KEY(ProfileId)
REFERENCES [Profile](Id)

CREATE UNIQUE INDEX IX_EMAIL ON [Users](EMAIL)

CREATE INDEX IX_AddressId ON [Users](AddressId)

CREATE INDEX IX_Profile on ProfileRole(ProfileId)

CREATE INDEX IX_RoleId on ProfileRole(RoleId)

CREATE INDEX IX_CEP ON [Address](ZipCode)


--Inserindo Perfis
INSERT INTO [Profile] (Id,[Name]) VALUES ('259b66fa-d008-4f1f-8623-303d1c19b189','GOD')
INSERT INTO [Profile] (Id,[Name]) VALUES ('02a29721-7305-40e2-b30b-2f96442e715f','Administrador')
INSERT INTO [Profile] (Id,[Name]) VALUES ('68c88f65-13a6-4fbb-bfdf-edebb246c37f','Usuario')
INSERT INTO [Profile] (Id,[Name]) VALUES ('0c16cbf4-7c61-4826-ac6a-73d65052449c','Espectador')


--Inserindo Funcoes
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('41c43c8a-1e0e-4ac9-a65d-3dfd7119ae44','user-created','pode criar usuarios')
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('9116d726-2427-4703-be26-8f6d98875b25','user-status','pode alterar status entre ativo e inativo')
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('4b9865e2-0d48-41e7-bb24-7885ac7f2e0e','user-edited','pode alterar dados do usuario')
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('780f349f-e6d5-4ba3-abec-9d12f237c370','user-deleted','pode excluir usuario somente god pode fazer')
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('4a0c860e-fd4e-4d7f-bf86-4e1d0b71bdf2','user-view','pode visualizar')
INSERT INTO [Role] (Id,[Name],[Description]) VALUES ('0705a103-1205-4890-a006-99c59a56aa52','profile-edit','pode editar profile')



--vincular perfis funcoes
--Perfil GOD
--permissao criar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','41c43c8a-1e0e-4ac9-a65d-3dfd7119ae44')
--permissao alterar status
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','9116d726-2427-4703-be26-8f6d98875b25')
--permissao editar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','4b9865e2-0d48-41e7-bb24-7885ac7f2e0e')
--permissao deletar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','780f349f-e6d5-4ba3-abec-9d12f237c370')
--permissao visualisar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','4a0c860e-fd4e-4d7f-bf86-4e1d0b71bdf2')
--permissao editar profile
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'259b66fa-d008-4f1f-8623-303d1c19b189','0705a103-1205-4890-a006-99c59a56aa52')



--Perfil Administrador
--permissao criar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'02a29721-7305-40e2-b30b-2f96442e715f','41c43c8a-1e0e-4ac9-a65d-3dfd7119ae44')
--permissao alterar status
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'02a29721-7305-40e2-b30b-2f96442e715f','9116d726-2427-4703-be26-8f6d98875b25')
--permissao editar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'02a29721-7305-40e2-b30b-2f96442e715f','4b9865e2-0d48-41e7-bb24-7885ac7f2e0e')
--permissao visualisar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'02a29721-7305-40e2-b30b-2f96442e715f','4a0c860e-fd4e-4d7f-bf86-4e1d0b71bdf2')
--permissao editar profile
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'02a29721-7305-40e2-b30b-2f96442e715f','0705a103-1205-4890-a006-99c59a56aa52')




--Usuario
--permissao editar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'68c88f65-13a6-4fbb-bfdf-edebb246c37f','4b9865e2-0d48-41e7-bb24-7885ac7f2e0e')


--Espectador
--permissao visualisar usuario
INSERT INTO ProfileRole (Id,ProfileId,RoleId) VALUES (NEWID(),'0c16cbf4-7c61-4826-ac6a-73d65052449c','4a0c860e-fd4e-4d7f-bf86-4e1d0b71bdf2')

--GOD Default user
declare @GodId uniqueIdentifier = NEWID() 
INSERT INTO [Users] (ID,FirstName,LastName,Email,Age,Nationality,CPF,[Login],[Password],isActive,CreatedAt,CreatedBy,ProfileId)
			VALUES (@GodId,'root','root','root@god.com',100,'BR','12345678912','root',CONVERT(VARCHAR(32), HashBytes('MD5', '1234'), 2),1,GETDATE(),@GodId,'259b66fa-d008-4f1f-8623-303d1c19b189')
