-- Get user name
SELECT @@SERVERNAME;

-- Change Authentication form window authentication  to User name/password;
ALTER LOGIN sa ENABLE;
GO
ALTER LOGIN sa WITH PASSWORD = '123456789';
GO;

SELECT *
FROM Account;
