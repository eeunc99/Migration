' Global 변수 설정
Imports System.IO
Imports System.Configuration

Module mod_Global
    Public LogDirectory As String = ConfigurationManager.AppSettings("LogDirectory")
    Public ApplicationName As String = System.Environment.GetCommandLineArgs(0).Replace(Application.StartupPath, "").Replace("\", "").ToUpper.Replace(".EXE", "").Replace(".VSHOST", "")
    Public TempDirectory As String = Application.StartupPath & "\temp"

    Public Sub Common_Insert_Log(Log As String, Optional lstLog As ListBox = Nothing) '로그 파일 만듬 .txt 파일로 생성
        Dim objStreamWriter As StreamWriter

        Dim LogFile As String = Path.Combine(LogDirectory, Format(Now, "yyyyMMdd") & ".txt")

        If Not System.IO.Directory.Exists(LogDirectory) Then
            System.IO.Directory.CreateDirectory(LogDirectory)
        End If
        objStreamWriter = New StreamWriter(LogFile, True)
        objStreamWriter.WriteLine(Log)
        objStreamWriter.Close()

        If lstLog IsNot Nothing Then
            If lstLog.Items.Count > 100 Then
                lstLog.Items.Clear()
                Application.DoEvents()
            End If
            lstLog.Items.Add(Log)
            lstLog.SelectedIndex = lstLog.Items.Count - 1
        End If

    End Sub

    Public Sub Common_Insert_Log_NoTime(Ext As String, Log As String) ' 성공한 쿼리문 .log파일로 생성
        Dim objStreamWriter As StreamWriter

        Dim LogFile As String = Path.Combine(LogDirectory, Format(Now, "yyyyMMdd") & ".log") ' 확장자명 .log

        If Not System.IO.Directory.Exists(LogDirectory) Then
            System.IO.Directory.CreateDirectory(LogDirectory)
        End If
        objStreamWriter = New StreamWriter(LogFile, True)
        objStreamWriter.WriteLine(Log)
        objStreamWriter.Close()
    End Sub

    Public Sub Common_Query_Log(Log As String, Optional insertBox As ListBox = Nothing) ' 읽을 파일
        Dim folderPath As String = ConfigurationManager.AppSettings("SourceCsvDirectory") '파일이 저장된 폴더 경로
        Dim selectedDate As DateTime = Migration.fileDate1.Value '날짜값
        Dim formattedDate As String = selectedDate.ToString("yyyyMMdd") '파일명과 동일하게 날짜 형식을 맞춰준다
        Dim filePath As String = Path.Combine(folderPath, formattedDate & ".csv") ' 저장된 폴더 경로에 있는 .csv 파일을 찾는다

        Dim fileContent As String
        Try
            fileContent = File.ReadAllText(filePath) ' .csv 파일의 모든 텍스트를 읽은 후 닫는다.
        Catch ex As Exception
            Console.WriteLine("파일을 읽어오는 동안 예외가 발생했습니다: 생성 :  " & ex.Message)
        End Try
    End Sub

End Module
