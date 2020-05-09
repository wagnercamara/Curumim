USE [curumimGame]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetPlayer]

@login varchar(50),
@password varchar(50)

AS
SELECT 

[idPlayer],
[fullNamePlayer],
[loginPlayer],
[passwordPlayer],
[secretPhresePlayer],
[punctuationPlayer],
[rankingPlayer],
[levelPlayer],
[victoryPlayer],
[totalBatllesPlayer],
[esmeraldPlayer]

FROM [dbo].[tbPlayer]

WHERE loginPlayer = @login and passwordPlayer = @password;
 
GO

CREATE PROCEDURE [dbo].[SetNewPlayer] 

@fullNamePlayer varchar(100),
@loginPlayer varchar(50),
@passwordPlayer varchar(50),
@secretPhresePlayer varchar(200),
@avatarPlayer varchar(50),
@levelPlayer varchar(50),

@punctuationPlayer bigint,
@rankingPlayer int,
@victoryPlayer int,
@totalBatllesPlayer int,
@esmeraldPlayer bigint

AS
BEGIN

INSERT INTO [dbo].[tbPlayer]
(
fullNamePlayer,
loginPlayer,
passwordPlayer,
secretPhresePlayer,
avatarPlayer,
levelPlayer,

punctuationPlayer,
rankingPlayer,
victoryPlayer,
totalBatllesPlayer,
esmeraldPlayer)

VALUES
(
@fullNamePlayer,
@loginPlayer,
@passwordPlayer,
@secretPhresePlayer,
@avatarPlayer,
@levelPlayer,

@punctuationPlayer,
@rankingPlayer,
@victoryPlayer,
@totalBatllesPlayer,
@esmeraldPlayer)

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
	
END
GO

CREATE PROC [dbo].[GetMessage]

@sender varchar(50),
@receiver varchar(50)

AS
SELECT [idMessage]
      ,[sender_id_tbPlayer]
      ,[receiver_id_tbPlayer]
      ,[messageMessage]
      ,[dateTimeMessage]

FROM [dbo].[tbMessage]

WHERE sender_id_tbPlayer = @sender and receiver_id_tbPlayer = @receiver;
 
GO


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