USE master
CREATE TABLE bitacora
(loginName varchar(50)
,Tipo varchar (50)
,Fecha datetime
,ClientHost varchar (50)); 

--Trigger
CREATE TRIGGER tg_login
ON ALL SERVER WITH EXECUTE AS 'sa'
FOR LOGON
AS
BEGIN

DECLARE @LogonData XML;
SET @LogonData = EVENTDATA();
INSERT INTO master.dbo.bitacora
SELECT @LogonData.value('(/EVENT_INSTANCE/LoginName)[1]','varchar(50)')
,@LogonData.value('(/EVENT_INSTANCE/LoginType)[1]','varchar(50)')
,@LogonData.value('(/EVENT_INSTANCE/PostTime)[1]','datetime')
,@LogonData.value('(/EVENT_INSTANCE/ClientHost)[1]','varchar(50)')

END

--SELECT * from bitacora