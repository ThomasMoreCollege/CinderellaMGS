CREATE TRIGGER statusUpdate
ON CinderellaTimestamp
FOR INSERT
AS 

declare @cinStatus int;
declare @cinID int;

select @cinStatus=inserted.statusID from inserted
select @cinID=inserted.cinderellaID	from inserted

UPDATE [CinderellaMGS2012].[dbo].[Cinderellas]
   SET [Cinderellas].currentStatus = @cinStatus
 WHERE id = @cinID
    
GO
	