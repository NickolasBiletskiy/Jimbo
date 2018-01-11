Create table [User](
	UserId uniqueidentifier not null,
	FirstName nvarchar (32) not null,
	LastName nvarchar (32) not null,
	[Login] nvarchar (32) not null,
	[Password] nvarchar (32) not null,
	SessionId uniqueidentifier not null,
	SessionExpireDate Datetime,
	LastLoginTs datetime,

	Constraint userId_PK primary key (UserId)
)

Create table [Contact](
	ContactId uniqueidentifier not null,
	HostUserId uniqueidentifier not null,
	ContactUserId uniqueidentifier not null,

	Constraint contactId_PK primary key (ContactId),
	Constraint hostUserId_UserId foreign key (HostUserId) references [User](UserId),
	Constraint contactUserId_UserId foreign key (ContactUserId) references [User](UserId)
)

Create table [Message](
	MessageId uniqueidentifier not null,
	UserFromId uniqueidentifier not null,
	UserToId uniqueidentifier not null,
	MessageText nvarchar(max),
	SentTS datetime not null,
	LastSyncBySenderTS datetime,
	LastSyncByReceiverTS datetime,

	Constraint  messageId_PK primary key (MessageId),
	Constraint userFrom_FK foreign key (UserFromId) references [User](UserId),
	Constraint useTo_FK foreign key (UserToId) references [User](UserId)
)