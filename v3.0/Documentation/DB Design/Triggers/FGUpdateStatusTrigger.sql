CREATE TRIGGER FGstatusUpdate
ON FairyGodmotherTimestamp
FOR INSERT
AS 

declare @fgStatus int;
declare @fgID int;

select @fgStatus=inserted.statusID from inserted
select @fgID=inserted.fairyGodmotherID	from inserted

UPDATE [CinderellaMGS2012].[dbo].[FairyGodmothers]
   SET [FairyGodmothers].currentStatus = @fgStatus
 WHERE id = @fgID
    
GO
	