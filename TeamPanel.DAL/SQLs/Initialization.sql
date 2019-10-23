use TeamPanel

CREATE TABLE Gallery
(
	Id bigint identity(1,1) NOT NULL,
	ImageName varchar(100) NOT NULL,
	ImagePath varchar(MAX) NOT NULL,
	CONSTRAINT PK_Gallery_Id PRIMARY KEY (Id),
	CONSTRAINT UX_Gallery_ImageName_ImagePath UNIQUE (ImageName, ImagePath)
)

CREATE TABLE GENDER
(
	Id tinyint identity(1,1),
	Name varchar(50),
	CONSTRAINT PK_Gender_Id PRIMARY KEY (Id),
	CONSTRAINT UX_Gender_Name UNIQUE (Name)
)

CREATE TABLE Activity
(
	Id int identity(1,1) NOT NULL,
	Name varchar(36) NOT NULL,
	Description varchar(512) NULL,
	ImageId bigint NULL,
	CreationTime datetime NOT NULL,
	LastModificationTime datetime NULL,
	CreatedBy int NOT NULL,
	ModifiedBy int NULL,
	CONSTRAINT PK_Activity_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Activity_Images_ImageId FOREIGN KEY (ImageId) REFERENCES Gallery(Id),
	CONSTRAINT UX_Activity_Name UNIQUE (Name)
)

CREATE TABLE Player
(
	Id bigint identity(1,1) NOT NULL,
	FirstName varchar(100) NULL,
	LastName varchar(100) NULL,
	Nickname varchar(100) NULL,
	Username varchar(36) NOT NULL,
	Email varchar(255) NOT NULL,
	PhoneNumber varchar(25) NULL,
	GenderId tinyint NULL,
	ImageId bigint NULL,
	CreationTime datetime NOT NULL,
	LastModificationTime datetime NULL,
	CONSTRAINT PK_Player_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Player_Gender_GenderId FOREIGN KEY (GenderId) REFERENCES Gender(Id),
	CONSTRAINT FK_Player_Images_ImageId FOREIGN KEY (ImageId) REFERENCES Gallery(Id),
	CONSTRAINT UX_Player_Username_Email_PhoneNumber UNIQUE (Username, Email, PhoneNumber)
)

CREATE TABLE Team
(
	Id int identity(1,1) NOT NULL,
	Name varchar(36) NOT NULL,
	Identifier varchar(100) NOT NULL,
	ActivityId int NULL,
	CaptainId bigint NOT NULL,
	ImageId bigint NULL,
	CONSTRAINT PK_Team_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Team_Player_CaptainId FOREIGN KEY (CaptainId) REFERENCES Player(Id),
	CONSTRAINT FK_Team_Images_ImageId FOREIGN KEY (ImageId) REFERENCES Gallery(Id),
	CONSTRAINT UX_Team_Identifier UNIQUE (Identifier)
)

CREATE TABLE Participation
(
	Id int identity(1,1) NOT NULL,
	PlayerId bigint NOT NULL,
	ActivityId int NOT NULL,
	CONSTRAINT PK_Participation_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Participation_Player_PlayerId FOREIGN KEY (PlayerId) REFERENCES Player(Id),
	CONSTRAINT FK_Participation_Activity_ActivityId FOREIGN KEY (ActivityId) REFERENCES Activity(Id) 
)