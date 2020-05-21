USE [master]
GO


CREATE DATABASE [curumimGame]
GO

USE [curumimGame]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE TABLE [dbo].[tbPlayer](
	[idPlayer] [int] IDENTITY(1,1) NOT NULL,
	[fullNamePlayer] [varchar](100) NOT NULL,
	[loginPlayer] [varchar](50) NOT NULL,
	[passwordPlayer] [varchar](50) NOT NULL,
	[secretPhresePlayer] [varchar](200) NOT NULL,
	[avatarPlayer] [varchar](50) NOT NULL,
	[punctuationPlayer] [bigint] NOT NULL,
	[rankingPlayer] [int] NOT NULL,
	[victoryPlayer] [int] NOT NULL,
	[totalBatllesPlayer] [int] NOT NULL,
	[esmeraldPlayer] [bigint] NOT NULL,
	[playerOnOrOff][int] NOT NULL,
 CONSTRAINT [PK_tbPlayer] PRIMARY KEY CLUSTERED 
(
	[idPlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_tbPlayer_loginPlayer] UNIQUE NONCLUSTERED 
(
	[loginPlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tbItem](
	[idItem] [int] NOT NULL,
	[nameItem] [varchar](50) NOT NULL,
	[levelItem] [int] NOT NULL,
	[valueUnitItem] [int] NOT NULL,
	[destructionAreaItem] [int] NOT NULL,
	[spaceHit][int]NOT NULL,
	[reach] [int] NOT NULL,
	[typeItem] [int] NOT NULL, /*0 para coletor e 1 para arma*/
CONSTRAINT [PK_tbItem] PRIMARY KEY CLUSTERED 
(
	[idItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[tbTypeBatlle](
	[idTypeBatlle] [int] IDENTITY(1,1) NOT NULL,
	[chestBatlle] [int] NOT NULL,
	[betBatlle] [int] NOT NULL,
	[punctuationBatlle] [int] NOT NULL,
	[fieldWidthBatlle] [int] NOT NULL,
	[fieldHeigthBatlle] [int] NOT NULL,
	[lifeBatlle] [int] NOT NULL,
CONSTRAINT [PK_tbTypeBatlle] PRIMARY KEY CLUSTERED 
(
	[idTypeBatlle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO






CREATE TABLE [dbo].[tbArsenalPlayer](
	[idArsenalPlayer] [int] IDENTITY(1,1) NOT NULL,
	[id_tbPlayer] [int] NOT NULL,
	[id_tbItem] [int] NOT NULL,
	[amountArsenal] [int] NOT NULL,
 CONSTRAINT [PK_tbArsenalPlayer] PRIMARY KEY CLUSTERED 
(
	[idArsenalPlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbArsenalPlayer]  WITH CHECK ADD  CONSTRAINT [FK_tbArsenalPlayer_tbPlayer] FOREIGN KEY([id_tbPlayer])
REFERENCES [dbo].[tbPlayer] ([idPlayer])
GO

ALTER TABLE [dbo].[tbArsenalPlayer] CHECK CONSTRAINT [FK_tbArsenalPlayer_tbPlayer]
GO





CREATE TABLE [dbo].[tbBatlle](
	[idBatlle] [int] IDENTITY(1,1) NOT NULL,
	[dateBatlle] [datetime] NOT NULL,
	[id_tbTypeBatlle] [int] NOT NULL,
 CONSTRAINT [PK_tbBatlle] PRIMARY KEY CLUSTERED 
(
	[idBatlle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbBatlle]  WITH CHECK ADD  CONSTRAINT [FK_tbBatlle_tbTypeBatlle] FOREIGN KEY([id_tbTypeBatlle])
REFERENCES [dbo].[tbTypeBatlle] ([idTypeBatlle])
GO

ALTER TABLE [dbo].[tbBatlle] CHECK CONSTRAINT [FK_tbBatlle_tbTypeBatlle]
GO





CREATE TABLE [dbo].[tbBatllePlayer](
	[idBatllePlayer] [int] IDENTITY(1,1) NOT NULL,
	[id_tbPlayer] [int] NOT NULL,
	[id_tbBatlle] [int] NOT NULL,
	[sideBatllePlayer] [int] NOT NULL, /*0 para esquerda 1 para direita*/
	[winnerBatllePlayer] [int] NOT NULL, /*0 para derrota 1 para vitória*/
 CONSTRAINT [PK_tbBatllePlayer] PRIMARY KEY CLUSTERED 
(
	[idBatllePlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbBatllePlayer]  WITH CHECK ADD  CONSTRAINT [FK_tbBatllePlayer_tbPlayer] FOREIGN KEY([id_tbPlayer])
REFERENCES [dbo].[tbPlayer] ([idPlayer])
GO

ALTER TABLE [dbo].[tbBatllePlayer] CHECK CONSTRAINT [FK_tbBatllePlayer_tbPlayer]
GO

ALTER TABLE [dbo].[tbBatllePlayer]  WITH CHECK ADD  CONSTRAINT [FK_tbBatllePlayer_tbBatlle] FOREIGN KEY([id_tbBatlle])
REFERENCES [dbo].[tbBatlle] ([idBatlle])
GO

ALTER TABLE [dbo].[tbBatllePlayer] CHECK CONSTRAINT [FK_tbBatllePlayer_tbBatlle]
GO





CREATE TABLE [dbo].[tbBatlleArsenal](
	[idBatlleArsenal] [int] IDENTITY(1,1) NOT NULL,
	[id_tbArsenalPlayer] [int] NOT NULL,
	[id_tbBatllePlayer] [int] NOT NULL,
	[amountBatlleArsenal] [int] NOT NULL,
 CONSTRAINT [PK_tbBatlleArsenal] PRIMARY KEY CLUSTERED 
(
	[idBatlleArsenal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbBatlleArsenal]  WITH CHECK ADD  CONSTRAINT [FK_tbBatlleArsenal_tbBatllePlayer] FOREIGN KEY([id_tbBatllePlayer])
REFERENCES [dbo].[tbBatllePlayer] ([idBatllePlayer])
GO

ALTER TABLE [dbo].[tbBatlleArsenal] CHECK CONSTRAINT [FK_tbBatlleArsenal_tbBatllePlayer]
GO

ALTER TABLE [dbo].[tbBatlleArsenal]  WITH CHECK ADD  CONSTRAINT [FK_tbBatlleArsenal_tbArsenalPlayer] FOREIGN KEY([id_tbArsenalPlayer])
REFERENCES [dbo].[tbArsenalPlayer] ([idArsenalPlayer])
GO

ALTER TABLE [dbo].[tbBatlleArsenal] CHECK CONSTRAINT [FK_tbBatlleArsenal_tbArsenalPlayer]
GO





CREATE TABLE [dbo].[tbMessage](
	[idMessage] [int] IDENTITY(1,1) NOT NULL,
	[sender_id_tbPlayer] [int] NOT NULL,
	[receiver_id_tbPlayer] [int] NOT NULL,
	[messageMessage] [text] NOT NULL,
	[dateTimeMessage] [datetime] NOT NULL,
 CONSTRAINT [PK_tbMessage] PRIMARY KEY CLUSTERED 
(
	[idMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbMessage]  WITH CHECK ADD  CONSTRAINT [FK_tbMessage_tbPlayer_receiver] FOREIGN KEY([receiver_id_tbPlayer])
REFERENCES [dbo].[tbPlayer] ([idPlayer])
GO

ALTER TABLE [dbo].[tbMessage] CHECK CONSTRAINT [FK_tbMessage_tbPlayer_receiver]
GO

ALTER TABLE [dbo].[tbMessage]  WITH CHECK ADD  CONSTRAINT [FK_tbMessage_tbPlayer_sender] FOREIGN KEY([sender_id_tbPlayer])
REFERENCES [dbo].[tbPlayer] ([idPlayer])
GO

ALTER TABLE [dbo].[tbMessage] CHECK CONSTRAINT [FK_tbMessage_tbPlayer_sender]
GO




CREATE TABLE [dbo].[tbPurchase](
	[idPurchase] [int] IDENTITY(1,1) NOT NULL,
	[id_tbPlayer] [int] NOT NULL,
	[dateTimePurchase] [datetime] NOT NULL,
 CONSTRAINT [PK_tbPurchase] PRIMARY KEY CLUSTERED 
(
	[idPurchase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tbPurchase_tbPlayer] FOREIGN KEY([id_tbPlayer])
REFERENCES [dbo].[tbPlayer] ([idPlayer])
GO

ALTER TABLE [dbo].[tbPurchase] CHECK CONSTRAINT [FK_tbPurchase_tbPlayer]
GO





CREATE TABLE [dbo].[tbItemPurchase](
	[idItemPurchase] [int] IDENTITY(1,1) NOT NULL,
	[id_tbPurchase] [int] NOT NULL,
	[id_tbItem] [int] NOT NULL,
	[amountItemPurchase] [int] NOT NULL,
	[valueUnitItemPurchase] [int] NOT NULL,
	[valueTotalItemPurchase] [int] NOT NULL,
 CONSTRAINT [PK_tbItemPurchase] PRIMARY KEY CLUSTERED 
(
	[idItemPurchase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbItemPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tbItemPurchase_tbItem] FOREIGN KEY([id_tbItem])
REFERENCES [dbo].[tbItem] ([idItem])
GO

ALTER TABLE [dbo].[tbItemPurchase] CHECK CONSTRAINT [FK_tbItemPurchase_tbItem]
GO

ALTER TABLE [dbo].[tbItemPurchase]  WITH CHECK ADD  CONSTRAINT [FK_tbItemPurchase_tbPurchase] FOREIGN KEY([id_tbPurchase])
REFERENCES [dbo].[tbPurchase] ([idPurchase])
GO

ALTER TABLE [dbo].[tbItemPurchase] CHECK CONSTRAINT [FK_tbItemPurchase_tbPurchase]
GO

---=====================================================================
---Insert Arms
---=====================================================================
Insert Into [dbo].[tbItem] 
(idItem, nameItem, levelItem, valueUnitItem, spaceHit,destructionAreaItem, reach, typeItem)
values
(1001,'stone',0,0,1,1,20,1),

(1002,'bow1',1,2,2,9,5,1), 
(1003,'bow2',2,5,2,25,7,1), 
(1004,'bow3',3,10,4,49,10,1),

(1005,'crossbow1',1,20,5,5,10,1),
(1006,'crossbow2',2,30,6,6,15,1),
(1007,'crossbow3',3,40,8,8,20,1),

(1008,'catapult1',1,50,9,9,20,1), 
(1009,'catapult2',2,60,25,25,20,1), 
(1010,'catapult3',3,70,49,49,20,1), 

(1011,'rope',0,0,1,1,20,0),

(1012,'hookRope1',1,20,1,1,7,0),
(1013,'hookRope2',2,25,1,1,15,0),
(1014,'hookRope3',3,30,1,1,20,0),

(1015,'fishingNet1',1,50,25,25,15,0),
(1016,'fishingNet2',2,100,64,64,20,0)

GO
---=====================================================================
---Procedimento
---=====================================================================
CREATE PROCEDURE [dbo].[SetMessage] 

@sender_id_tbPlayer varchar(50),
@receiver_id_tbPlayer varchar(50),
@messageMessage text,
@dateTimeMessage datetime

AS
BEGIN

INSERT INTO [dbo].[tbMessage](

[sender_id_tbPlayer],
[receiver_id_tbPlayer],
[messageMessage],
[dateTimeMessage]

)
VALUES
(
@sender_id_tbPlayer,
@receiver_id_tbPlayer,
@messageMessage,
@dateTimeMessage 
)

END
GO

USE [curumimGame]
GO


CREATE PROCEDURE [dbo].[SetNewPlayer] 

@fullNamePlayer varchar(100),
@loginPlayer varchar(50),
@passwordPlayer varchar(50),
@secretPhresePlayer varchar(200),
@avatarPlayer varchar(50),


@punctuationPlayer bigint,
@rankingPlayer int,
@victoryPlayer int,
@totalBatllesPlayer int,
@esmeraldPlayer bigint,
@playerOnOrOff int

AS
BEGIN

INSERT INTO [dbo].[tbPlayer]
(
       [fullNamePlayer]
      ,[loginPlayer]
      ,[passwordPlayer]
      ,[secretPhresePlayer]
      ,[avatarPlayer]
      ,[punctuationPlayer]
      ,[rankingPlayer]
      ,[victoryPlayer]
      ,[totalBatllesPlayer]
      ,[esmeraldPlayer]
      ,[playerOnOrOff]
)

VALUES
(
@fullNamePlayer,
@loginPlayer,
@passwordPlayer,
@secretPhresePlayer,
@avatarPlayer,

@punctuationPlayer,
@rankingPlayer,
@victoryPlayer,
@totalBatllesPlayer,
@esmeraldPlayer,
@playerOnOrOff)

END
GO

Create PROCEDURE [dbo].[UpdatePasswordPlayer]

@fullNamePlayer varchar(100),
@loginPlayer varchar(50),
@passwordPlayer varchar(50),
@secretPhresePlayer varchar(200)

AS
BEGIN
     
    UPDATE [dbo].[tbPlayer] 
	set  
	passwordPlayer = @passwordPlayer
    where 
	fullNamePlayer = @fullNamePlayer and 
	loginPlayer = @loginPlayer and 
	secretPhresePlayer = @secretPhresePlayer;
	IF @@ROWCOUNT = 0  
	return 'false'
END
GO
---
Create PROCEDURE [dbo].[UpdateOffOrOnPlayer]

@idPlayer int,
@OffOrOn int
AS
BEGIN
     
    UPDATE [dbo].[tbPlayer] 
	set  
	[playerOnOrOff] = @OffOrOn
    where 
	idPlayer = @idPlayer
	IF @@ROWCOUNT = 0  
	return 'false'
END
GO

-------------
Create PROCEDURE [dbo].[UpdateEmeraldPlayer]

@idPlayer int,
@esmerald int
AS
BEGIN
     
    UPDATE [dbo].[tbPlayer] 
	set  
	[esmeraldPlayer] = @esmerald
    where 
	idPlayer = @idPlayer
	IF @@ROWCOUNT = 0  
	return 'false'
END
GO
--------------
CREATE PROCEDURE [dbo].[SetItemPurchase] -- new
           (@id_tbPurchase int
           ,@id_tbItem int
           ,@amountItemPurchase int
           ,@valueUnitItemPurchase int
           ,@valueTotalItemPurchase int)
AS
BEGIN
INSERT INTO [dbo].[tbItemPurchase]
           ([id_tbPurchase]
           ,[id_tbItem]
           ,[amountItemPurchase]
           ,[valueUnitItemPurchase]
           ,[valueTotalItemPurchase])
     VALUES
           (@id_tbPurchase
           ,@id_tbItem
           ,@amountItemPurchase
           ,@valueUnitItemPurchase
           ,@valueTotalItemPurchase)
END
GO

CREATE PROCEDURE [dbo].[SetPurchase] --new
	(@idPlayer int, @dataTime dateTime)
AS
BEGIN
INSERT INTO [dbo].[tbPurchase]
           ([id_tbPlayer]
           ,[dateTimePurchase])
     VALUES
           (@idPlayer,
            @dataTime)
			SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [dbo].[SqlSetArsenalPlayer]
(
@idArsenal int = null,
@amountArsenal int = null,
@idItem int,
@idPlayer int,
@amount int
)
AS
BEGIN
	SET @idArsenal = (SELECT idArsenalPlayer FROM [dbo].[tbArsenalPlayer] WHERE id_tbItem = @idItem and id_tbPlayer = @idPlayer)
if(@idArsenal > 0)
	Begin
	SET @amountArsenal = (SELECT amountArsenal FROM [dbo].[tbArsenalPlayer] WHERE idArsenalPlayer = @idArsenal )
	SET @amount = @amount + @amountArsenal
	
	UPDATE [dbo].[tbArsenalPlayer] 
	set  
	amountArsenal = @amount
    where 
	idArsenalPlayer = @idArsenal

	End
else
	Begin
		INSERT INTO [dbo].[tbArsenalPlayer]
           ([id_tbPlayer]
           ,[id_tbItem]
           ,[amountArsenal])
     VALUES
           (@idPlayer
           ,@idItem
		   ,@amount)
	end

END
GO
---=====================================================================
---Funções
---=====================================================================
CREATE FUNCTION [dbo].[GetPlayer] ---
(	
@login varchar(50),
@password varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT 
	
	[idPlayer],
	[fullNamePlayer],
	[loginPlayer],
	[avatarPlayer],
	[passwordPlayer],
	[secretPhresePlayer],
	[punctuationPlayer],
	[rankingPlayer],
	[victoryPlayer],
	[totalBatllesPlayer],
	[esmeraldPlayer]
	
	FROM [dbo].[tbPlayer]
	
	WHERE loginPlayer = @login and passwordPlayer = @password

)
GO

---
CREATE FUNCTION [dbo].[GetMessagePlayerChat] ---
(	
@idSender varchar(50),
@idReceiver varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
SELECT 
	p.loginPlayer as sender
      ,messageMessage
      ,dateTimeMessage
  FROM [dbo].[tbMessage] as m
  INNER JOIN [dbo].[tbPlayer] as p on p.idPlayer = m.sender_id_tbPlayer
  INNER JOIN [dbo].[tbPlayer] as t on t.idPlayer = m.receiver_id_tbPlayer

  WHERE ((m.sender_id_tbPlayer = @idSender and m.receiver_id_tbPlayer = @idReceiver)or(m.sender_id_tbPlayer = @idReceiver and m.receiver_id_tbPlayer = @idSender)) 

)
GO


---
CREATE FUNCTION [dbo].[GetMessagePlayerContacts] ---
(	
@idPlayer varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
SELECT 
      m.[sender_id_tbPlayer] as sender
	,p.loginPlayer as loginSender
	    ,p.playerOnOrOff as statusSender

      ,m.[receiver_id_tbPlayer] as receiver
	,t.loginPlayer as loginReceiver
	     ,t.playerOnOrOff as statusReceiver

  FROM [dbo].[tbMessage] as m
  INNER JOIN [dbo].[tbPlayer] as p on p.idPlayer = m.sender_id_tbPlayer
  INNER JOIN [dbo].[tbPlayer] as t on t.idPlayer = m.receiver_id_tbPlayer

  WHERE ((m.sender_id_tbPlayer = @idPlayer )or( m.receiver_id_tbPlayer = @idPlayer))  

)
GO
---

CREATE FUNCTION [dbo].[GetSearchPlayerChat] ---
(	
@login varchar(50)
)
RETURNS TABLE 
AS
RETURN 
(
SELECT [idPlayer]
      ,[loginPlayer]
      ,[playerOnOrOff]
  FROM [dbo].[tbPlayer]
  WHERE [loginPlayer] = @login
)
GO

CREATE FUNCTION [dbo].[GetItem] ---
()
RETURNS TABLE 
AS
RETURN 
(
SELECT [idItem]
      ,[nameItem]
      ,[levelItem]
      ,[valueUnitItem]
      ,[destructionAreaItem]
      ,[spaceHit]
      ,[reach]
      ,[typeItem]
  FROM [dbo].[tbItem]
)
GO

CREATE FUNCTION [dbo].[GetItemArsenal]
(@idPlayer int)
RETURNS TABLE 
AS
RETURN 
(
SELECT 
	  i.[nameItem]
      ,a.[amountArsenal]
  FROM [dbo].[tbArsenalPlayer]as a
  INNER JOIN [dbo].[tbItem] as i on i.idItem = a.[id_tbItem]
  WHERE a.[id_tbPlayer] = @idPlayer
)
GO