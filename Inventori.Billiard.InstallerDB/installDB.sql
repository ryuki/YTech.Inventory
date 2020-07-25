USE [INVENTORI]


--
-- Definition for user INVENTORI :
--
if exists (select * from dbo.sysusers where name = N'INVENTORI')
exec sp_dropuser 'INVENTORI'


/****** Object:  Login INVENTORI    Script Date: 1/8/2007 7:17:38 PM ******/
if exists (select * from master.dbo.syslogins where name = N'INVENTORI')
exec sp_droplogin N'INVENTORI'


if not exists (select * from master.dbo.syslogins where loginname = N'INVENTORI')
BEGIN
	declare @logindb nvarchar(132), @loginlang nvarchar(132) select @logindb = N'INVENTORI', @loginlang = N'us_english'
	if @logindb is null or not exists (select * from master.dbo.sysdatabases where name = @logindb)
		select @logindb = N'master'
	if @loginlang is null or (not exists (select * from master.dbo.syslanguages where name = @loginlang) and @loginlang <> N'us_english')
		select @loginlang = @@language
	exec sp_addlogin N'INVENTORI', 'INVENTORI$', @logindb, @loginlang
END


/****** Object:  User INVENTORI    Script Date: 1/8/2007 7:18:07 PM ******/
if exists (select * from dbo.sysusers where name = N'INVENTORI')
exec sp_revokedbaccess N'INVENTORI'


if not exists (select * from dbo.sysusers where name = N'INVENTORI')
BEGIN	
	EXEC sp_grantdbaccess N'INVENTORI', N'INVENTORI'
exec sp_addrolemember N'db_owner', N'INVENTORI'
END