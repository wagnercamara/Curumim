USE [master] 
GO
USE [curumimGame]
GO

Insert Into [dbo].[tbItem] 
(nameItem, levelItem, valueUnitItem, spaceHit,destructionAreaItem, reach, typeItem)
values
('stone',0,0,1,1,20,1),

('bow1',1,2,2,9,5,1), 
('bow2',2,5,2,25,7,1), 
('bow3',3,10,4,49,10,1),

('crossbow1',1,20,5,5,10,1),
('crossbow2',2,30,6,6,15,1),
('crossbow3',3,40,8,8,20,1),

('catapult1',1,50,9,9,20,1), 
('catapult2',2,60,25,25,20,1), 
('catapult3',3,70,49,49,20,1), 

('rope',0,0,1,1,20,0),

('hookRope1',1,20,1,1,7,0),
('hookRope2',2,25,1,1,15,0),
('hookRope3',3,30,1,1,20,0),

('fishingNet1',1,50,25,25,15,0),
('fishingNet2',2,100,64,64,20,0)

GO