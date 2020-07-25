net start "SQL Server (SQLEXPRESS)" >> log.txt

isql -S (local)\SQLEXPRESS -E -d "MASTER" -Q "EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2" >> log.txt

net stop "SQL Server (SQLEXPRESS)" >> log.txt
net start "SQL Server (SQLEXPRESS)" >> log.txt