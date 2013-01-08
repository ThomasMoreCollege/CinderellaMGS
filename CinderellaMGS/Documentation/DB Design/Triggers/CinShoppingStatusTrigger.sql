CREATE TRIGGER CinShoppingStatusUpdate
ON FairyGodmotherTimestamp
FOR INSERT
AS 

declare @fgStatus int;
declare @fgID int;
declare @cinID int;

select @fgStatus=inserted.statusID from inserted
select @fgID=inserted.fairyGodmotherID	from inserted
select @cinID = id from inserted INNER JOIN (SELECT id, fairyGodmotherID FROM Cinderellas WHERE cinderellas.fairyGodmotherID = @fgID AND Cinderellas.id NOT IN (SELECT cinderellaID from CinderellaTimestamp WHERE CinderellaTimestamp.statusID = 4)) as CIN ON cin.fairyGodmotherID = inserted.fairyGodmotherID WHERE inserted.statusID = 3
IF @fgStatus = 3
INSERT INTO [CinderellaMGS2012].[dbo].[CinderellaTimestamp] (statusID,timestamp,cinderellaID)
VALUES (4,GETDATE(), @cinID)
    
GO
	