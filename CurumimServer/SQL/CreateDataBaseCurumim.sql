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
	[levelPlayer] [varchar](50) NOT NULL,
	[punctuationPlayer] [bigint] NOT NULL,
	[rankingPlayer] [int] NOT NULL,
	[victoryPlayer] [int] NOT NULL,
	[totalBatllesPlayer] [int] NOT NULL,
	[esmeraldPlayer] [bigint] NOT NULL,
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
	[idItem] [int] IDENTITY(1,1) NOT NULL,
	[nameItem] [varchar](50) NOT NULL,
	[levelItem] [int] NOT NULL,
	[valueUnitItem] [int] NOT NULL,
	[destructionAreaItem] [int] NOT NULL,
	[spaceHit][int]NOT NULL,
	[reach] [int] NOT NULL,
	[typeItem] [bit] NOT NULL, /*0 para coletor e 1 para arma*/
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
	[sideBatllePlayer] [bit] NOT NULL, /*0 para esquerda 1 para direita*/
	[winnerBatllePlayer] [bit] NOT NULL, /*0 para derrota 1 para vitória*/
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
	[totalPayablePurchase] [bigint] NOT NULL,
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
	[valueTotalItemPurchase] [bigint] NOT NULL,
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