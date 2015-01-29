CREATE TRIGGER FGDeleteStatusUpdate
ON FairyGodmotherTimestamp
FOR DELETE
AS 


declare @fgID int;
declare @fgStatus int;

select @fgID=deleted.fairyGodmotherID	from deleted
select @fgStatus=statusID from FairyGodmotherTimestamp Where fairyGodmotherID = @fgID ORDER BY timestamp DESC

UPDATE FairyGodmothers
SET currentStatus = @fgStatus
WHERE id = @fgID
    
GO
	