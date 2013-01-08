CREATE TRIGGER CinCheckOutStatusUpdate
ON CinderellaTimestamp
FOR INSERT
AS 


declare @fgID int;
declare @cinID int;
declare @cinStatus int;

select @cinID=inserted.cinderellaID	from inserted
select @cinStatus=inserted.statusID from inserted
select @fgID = fairyGodmotherID from Cinderellas WHERE Cinderellas.id = @cinID
IF (@cinStatus = 6 OR @cinStatus = 7)
INSERT INTO [CinderellaMGS2012].[dbo].[FairyGodmotherTimestamp] (statusID,timestamp,fairyGodmotherID)
VALUES (1,GETDATE(), @fgID)
    
GO
	