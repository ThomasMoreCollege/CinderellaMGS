CREATE TRIGGER newCinderella
ON Cinderellas
FOR INSERT
AS 
INSERT [CinderellaMGS2012].[dbo].[CinderellaTimestamp]
           ([statusID]
           ,[timestamp]
           ,[cinderellaID])
SELECT 1,GETDATE(),id
FROM inserted
    
GO
	