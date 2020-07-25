Imports SQLDMO
Imports System.Windows.Forms

Public Class clsScript
    Dim i As Integer
    Dim oServer As New SQLServer2
    Dim db As SQLDMO.Database2
    Dim objBCP As New SQLDMO.BulkCopy2

    'This procedure will get all table names from a database
    Public Sub ConnectDatabaseWithRefresh(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String)
        Try
            oServer = New SQLServer2
            oServer.EnableBcp = True
            oServer.Connect(pServer, pUserName, pPassword)
            db = oServer.Databases.Item(pDatabase)
            'db.DBOption.SelectIntoBulkCopy = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Sub ConnectDatabase(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String)
        Try
            If oServer.ConnectionID <= 0 Then
            End If
        Catch
            oServer.EnableBcp = True
            oServer.Connect(pServer, pUserName, pPassword)
        End Try
        If IsNothing(db) Then
            db = oServer.Databases.Item(pDatabase)
            'db.DBOption.SelectIntoBulkCopy = True
        End If
    End Sub
    Sub ConnectServer(ByVal pServer As String, ByVal pUserName As String, ByVal pPassword As String)
        Try
            If oServer.ConnectionID <= 0 Then
            End If
        Catch
            oServer.EnableBcp = True
            oServer.Connect(pServer, pUserName, pPassword)
        End Try
    End Sub
    Function IsServerExists(ByVal pServer As String, ByVal pUser As String, ByVal pPassword As String) As Boolean
        Try
            oServer.DisConnect()
        Catch ex As Exception
        End Try
        Try
            'oServer = Nothing
            oServer.Connect(pServer, pUser, pPassword)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function IsDatabaseExists(ByVal pDBName As String) As Boolean
        Try
            db = oServer.Databases.Item(pDBName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub CreateNewDatabase(ByVal pDBName As String)
        Try
            oServer.ExecuteImmediate("create database " + pDBName, SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
            oServer.Databases.Refresh()
            db = oServer.Databases.Item(pDBName)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Sub DropDatabase(ByVal pDBName As String)
        Try
            db = Nothing
            oServer.ExecuteImmediate("drop database " + pDBName, SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
        Catch
        End Try
    End Sub
    Function ExportData(ByVal sServerName As String, ByVal sDatabaseName As String, ByVal sUserName As String, ByVal sPassword As String, ByVal sTableName As String, ByVal sCondition As String, ByVal sTotalRows As String, ByVal sBackUpDir As String) As String
        Try
            'ConnectDatabase(sServerName, sDatabaseName, sUserName, sPassword)
            objBCP.IncludeIdentityValues = True
            objBCP.DataFilePath = sBackUpDir + sTableName + ".dat"
            objBCP.DataFileType = SQLDMO_DATAFILE_TYPE.SQLDMODataFile_NativeFormat
            objBCP.UseExistingConnection = True
            'objBCP.DataFileType = SQLDMO_DATAFILE_TYPE.SQLDMODataFile_SpecialDelimitedChar
            'objBCP.ColumnDelimiter = vbTab
            'objBCP.RowDelimiter = vbCrLf
            'objBCP.MaximumErrorsBeforeAbort = 1
            'objBCP.UseBulkCopyOption = True
            'objBCP.ServerBCPKeepIdentity = True
            'objBCP.ServerBCPDataFileType = SQLDMO_SERVERBCP_DATAFILE_TYPE.SQLDMOBCPDataFile_WideNative
            'objBCP.ExportWideChar = True
            'objBCP.TableLock = True

            If InStr(sTotalRows, "TOP 100 PERCENT *", CompareMethod.Text) > 0 And Trim(sCondition = "") Then
                'If db.Tables.Item(sTableName).Rows > 0 Then
                db.Tables.Item(sTableName).ExportData(objBCP)
                'End If
            Else
                Dim sSelectCommand As String = "select " + sTotalRows + " from " + sDatabaseName + ".." + sTableName
                If Trim(sCondition) <> "" Then
                    sSelectCommand += " WHERE " + sCondition
                End If
                Try
                    db.ExecuteImmediate("drop view Temp_View_For_Backup_001", SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
                Catch
                End Try
                db.ExecuteImmediate("create view Temp_View_For_Backup_001 as " + sSelectCommand, SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
                db.Views.Refresh()
                'db.Views.Item("Temp_View_For_Backup_001").ExportData(objBCP)
                db.Views.Item("Temp_View_For_Backup_001").ExportData(objBCP)
                Try
                    db.ExecuteImmediate("drop view Temp_View_For_Backup_001", SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
                Catch
                End Try
            End If
            If My.Computer.FileSystem.GetFileInfo(objBCP.DataFilePath).Length <= 0 Then
                'Delete 0 byte size files, to remove error when unzipping
                My.Computer.FileSystem.DeleteFile(objBCP.DataFilePath)
                ' Debug.Write("Length=0")
            End If
            Return "Done"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Function ImportData(ByVal sTableName As String, ByVal sFilePath As String, ByVal bDeleteExistingData As Boolean) As String
        Try
            objBCP.DataFilePath = sFilePath + sTableName + ".dat"
            If My.Computer.FileSystem.FileExists(objBCP.DataFilePath) Then
                'objBCP.ColumnDelimiter = vbTab
                objBCP.DataFileType = SQLDMO_DATAFILE_TYPE.SQLDMODataFile_NativeFormat
                'objBCP.RowDelimiter = vbCrLf
                objBCP.UseExistingConnection = True
                objBCP.ServerBCPKeepIdentity = True
                objBCP.IncludeIdentityValues = True
                'objBCP.ExportWideChar = True
                'objBCP.TableLock = True
                'objBCP.UseBulkCopyOption = True
                'objBCP.ServerBCPDataFileType = SQLDMO_SERVERBCP_DATAFILE_TYPE.SQLDMOBCPDataFile_WideNative
                'objBCP.SetCodePage()
                If bDeleteExistingData Then
                    db.ExecuteImmediate("delete from " + sTableName)
                End If
                db.Tables.Refresh()
                db.Tables.Item(sTableName).ImportData(objBCP)
                Return "Done"
            Else
                'Throw New Exception("File '" + objBCP.DataFilePath + "' does not exists")
                Return "Created. No data found for this table."
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            Return (ex.Message)
        End Try
    End Function

    Function GetTableNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String, ByVal pNoOfRows As String) As DataTable
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("TableName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("TotalRows", "".GetType)
        DT.Columns.Add("Condition", "".GetType)
        DT.Columns.Add("BCPCommand", "".GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.Tables.Count
            If Not db.Tables.Item(i).SystemObject Then
                Dim sBCPCommand As String = "" 'Generate_BCPCommand(pServer, pDatabase, pUserName, pPassword, db.Tables.Item(i).Name, "", pNoOfRows)
                DT.Rows.Add(New Object() {db.Tables.Item(i).Name, True, pNoOfRows, "", sBCPCommand})
            End If
        Next
        DT.TableName = "Tables"
        Return DT
    End Function
    'Function Generate_BCPImportCommand(ByVal sServerName As String, ByVal sDatabaseName As String, ByVal sUserName As String, ByVal sPassword As String, ByVal sTableName As String, ByVal sCondition As String, ByVal sTotalRows As String,byval )
    'Dim sCommand As String = " bcp ""select " + sTotalRows + " from " + sDatabaseName + ".dbo." + sTableName + """ queryout """ + txtBackupDir.Text + sTableName + ".dat"" -S " + sServerName + " -U " + sUserName + " -P " + sPassword + " " + txtBCPOptions.Text
    'Return sCommand
    'End Function
    Function GetViewNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String) As DataTable
        ''Dim oServer As New SQLServer2
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("ViewName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.Views.Count
            If Not db.Views.Item(i).SystemObject Then
                DT.Rows.Add(New Object() {db.Views.Item(i).Name, True})
            End If
        Next
        DT.TableName = "Views"
        Return DT
    End Function
    Function GetUDFNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String) As DataTable
        'Dim oServer As New SQLServer2
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("UDFName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.UserDefinedFunctions.Count
            If Not db.UserDefinedFunctions.Item(i).SystemObject Then
                DT.Rows.Add(New Object() {db.UserDefinedFunctions.Item(i).Name, True})
            End If
        Next
        Return DT
    End Function
    Function GetSPNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String) As DataTable
        'Dim oServer As New SQLServer2
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("SPName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.StoredProcedures.Count
            If Not db.StoredProcedures.Item(i).SystemObject Then
                DT.Rows.Add(New Object() {db.StoredProcedures.Item(i).Name, True})
            End If
        Next
        Return DT
    End Function
    Function GetUDDNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String) As DataTable
        'Dim oServer As New SQLServer2
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("UDDName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.UserDefinedDatatypes.Count
            DT.Rows.Add(New Object() {db.StoredProcedures.Item(i).Name, True})
        Next
        Return DT
    End Function
    Function GetUserNames(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String) As DataTable
        'Dim oServer As New SQLServer2
        ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        Dim DT As New DataTable
        DT.Columns.Add("UserName", "".GetType)
        DT.Columns.Add("Select", True.GetType)
        DT.Columns.Add("Status", "".GetType)
        For i = 1 To db.Users.Count
            If Not db.Users.Item(i).SystemObject Then
                DT.Rows.Add(New Object() {db.Users.Item(i).Name, False})
            End If
        Next
        Return DT
    End Function
    Function Generate_BCPBackupCommand(ByVal sServerName As String, ByVal sDatabaseName As String, ByVal sUserName As String, ByVal sPassword As String, ByVal sTableName As String, ByVal sCondition As String, ByVal sTotalRows As String, ByVal sBackUpDir As String, ByVal sBCPPath As String, ByVal sBCPOptions As String)
        Dim sCommand As String = "BCP ""select " + sTotalRows + " from " + sDatabaseName + ".dbo." + sTableName + """ queryout """ + sBackUpDir + sTableName + ".dat"" -S " + sServerName + " -U " + sUserName + " -P " + sPassword + " " + sBCPOptions
        Return sCommand
    End Function
    ',byref pObjectDropScript as String
    Function GenerateScript(ByVal pServer As String, ByVal pDatabase As String, ByVal pUserName As String, ByVal pPassword As String, ByVal pObjectType As String, ByVal pObjectName As String) As String
        Dim sSQL As String = ""
        If Not IsNothing(db.GetObjectByName(pObjectName)) Then
            sSQL = db.GetObjectByName(pObjectName).Script(SQLDMO_SCRIPT_TYPE.SQLDMOScript_Drops)
            sSQL = sSQL + db.GetObjectByName(pObjectName).Script()
        End If
        'ConnectDatabase(pServer, pDatabase, pUserName, pPassword)
        'Select Case pObjectType.ToLower
        '    Case "table"
        '        'db.Tables.Item(1).Script()
        '        sSQL = db.Tables.Item(pObjectName).Script(SQLDMO_SCRIPT_TYPE.SQLDMOScript_Drops)
        '        sSQL = sSQL + db.Tables.Item(pObjectName).Script()
        '    Case "view"
        '        'db.Tables.Item(1).Script()
        '        sSQL = db.Views.Item(pObjectName).Script(SQLDMO_SCRIPT_TYPE.SQLDMOScript_Drops)
        '        sSQL = sSQL + db.Views.Item(pObjectName).Script()
        '    Case "user"
        '        sSQL = sSQL + db.Users.Item(pObjectName).Script()
        '    Case "sp"
        '        sSQL = sSQL + db.StoredProcedures.Item(pObjectName).Script()
        '    Case "udf"
        '        sSQL = sSQL + db.UserDefinedFunctions.Item(pObjectName).Script()
        '    Case "udd"
        '        sSQL = sSQL + db.UserDefinedDatatypes.Item(pObjectName).Script()
        'End Select
        Return sSQL
    End Function
    'Function ExecuteScript(ByVal pScript As String) As String
    '    Try
    '        If Trim(pScript) <> "" Then
    '            db.ExecuteImmediate(pScript, SQLDMO_EXEC_TYPE.SQLDMOExec_ContinueOnError)
    '        End If
    '    Catch ex As Exception
    '        Return Find_DependantObject(ex.ToString)
    '    End Try
    '    Return ""
    'End Function
    Function ExecuteScriptWithDependency(ByRef DTObjects As DataTable) As Boolean
        Dim sScript As String = ""
        Dim sObjectName As String = ""
        For i = 0 To DTObjects.Rows.Count - 1
            sObjectName = DTObjects.Rows(i)("ObjectName")
            sScript = DTObjects.Rows(i)("ScriptSQL")
            If sScript <> "" Then
                Try
                    db.ExecuteImmediate(sScript)
                    DTObjects.Rows(i)("Executed") = True
                    DTObjects.Rows(i)("Status") = "Created"
                Catch ex As Exception
                    DTObjects.Rows(i)("Executed") = False
                    DTObjects.Rows(i)("Status") = ex.Message
                End Try
            End If
        Next
        Dim repeat As Integer
        For repeat = 0 To 10
            'Execute again with failed objects, this to ensure dependency. Repeat 10 times to include all dependency
            'DTObjects.DefaultView.RowFilter = "Executed=False"
            For i = 0 To DTObjects.Rows.Count - 1
                If DTObjects.Rows(i)("Executed") = False Then
                    sObjectName = DTObjects.Rows(i)("ObjectName")
                    sScript = DTObjects.Rows(i)("ScriptSQL")
                    If sScript <> "" Then
                        Try
                            db.ExecuteImmediate(sScript, SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
                            DTObjects.Rows(i)("Executed") = True
                            DTObjects.Rows(i)("Status") = "Created"
                        Catch ex As Exception
                            DTObjects.Rows(i)("Executed") = False
                            DTObjects.Rows(i)("Status") = ex.Message
                        End Try
                    End If
                End If
            Next
        Next
        Return True
    End Function
    'Sub Find_Script_And_Object_Name(ByRef pScript As String, ByRef pObjectName As String, ByRef DTObjects As DataTable)
    '    If pObjectName <> "" Then
    '        'If exception occurs in ExecuteScriptForObject and exception was about dependent object, execution will come here
    '        DTObjects.DefaultView.RowFilter = "ObjectName='" + pObjectName + "' and Executed=False and ScriptSQL<>''"
    '        If DTObjects.DefaultView.Count <= 0 Then
    '            Throw New Exception("Script for dependent object '" + pObjectName + "' not found in backup.")
    '        End If
    '    Else
    '        DTObjects.DefaultView.RowFilter = "ObjectName<>'' and Executed=False and ScriptSQL<>''"
    '    End If
    '    If DTObjects.DefaultView.Count > 0 Then
    '        pObjectName = DTObjects.DefaultView(0)("ObjectName")
    '        pScript = DTObjects.DefaultView(0)("ScriptSQL")
    '    End If
    'End Sub
    'Sub ExecuteScriptForObject(ByVal pScript As String, ByVal pObjectName As String, ByRef DTObjects As DataTable)
    '    Try
    '        If pScript <> "" Then
    '            db.ExecuteImmediate(pScript, SQLDMO_EXEC_TYPE.SQLDMOExec_Default)
    '        End If
    '        pObjectName = ""
    '        pScript = ""
    '        'If DTObjects.DefaultView.Count > 0 Then
    '        ExecuteScriptWithDependency(DTObjects)
    '        'End If
    '    Catch ex As Exception
    '        'If InStr(ex.ToString, "Script for Dependent", CompareMethod.Text) > 0 Then
    '        '    Exit Sub
    '        'End If
    '        'Dim DependentObject As String = Find_DependantObject(ex.ToString)
    '        'If Trim(DependentObject) <> "" Then
    '        '    Find_Script_And_Object_Name(pScript, DependentObject, DTObjects)
    '        '    ExecuteScriptForObject(pScript, DependentObject, DTObjects)
    '        'Else
    '        '    pObjectName = ""
    '        '    pScript = ""
    '        '    If DTObjects.DefaultView.Count > 0 Then
    '        '        DTObjects.DefaultView(0)("Executed") = True
    '        '    End If
    '        '    ExecuteScriptWithDependency(DTObjects)
    '        '    End If
    '    End Try
    '    DTObjects.DefaultView(0)("Executed") = True
    'End Sub
    'Function Find_DependantObject(ByVal ex As String) As String
    '    Dim sObj As String = ""
    '    Dim errmsg As String = "invalid object name '"
    '    Dim n As Integer = InStr(ex.ToUpper, errmsg.ToUpper)
    '    If n > 0 Then
    '        Dim stpos = n + Len(errmsg)
    '        n = InStr(stpos + 1, ex.ToUpper, ".")
    '        If n > 0 Then
    '            stpos = n + 1
    '        End If
    '        n = InStr(stpos + 2, ex.ToUpper, "'")
    '        If n > 0 Then
    '            sObj = Mid(ex.ToUpper, stpos, n - stpos)
    '        End If
    '    End If
    '    Return sObj
    'End Function
End Class
