CREATE TRIGGER newFG
ON FairyGodmothers
FOR INSERT
AS 
INSERT [CinderellaMGS2012].[dbo].[FairyGodmotherTimestamp]
           ([fairyGodmotherID]
           ,[timestamp]
           ,[statusID])
SELECT id,GETDATE(),1
FROM inserted
    
GO
	