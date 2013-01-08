CREATE TRIGGER CinDeleteStatusUpdate
ON CinderellaTimestamp
FOR DELETE
AS 


declare @cinID int;
declare @cinStatus int;

select @cinID=deleted.cinderellaID	from deleted
select @cinStatus=statusID from CinderellaTimestamp Where cinderellaID = @cinID ORDER BY timestamp DESC

UPDATE Cinderellas
SET currentStatus = @cinStatus
WHERE id = @cinID
    
GO
	