Imports System.ComponentModel
Imports System.IO
Imports System.Configuration

Public Class Migration
    Public Delegate Sub Insert_Log_Callback(ByVal Log As String)
    Private Sub Migration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ProcessStart()
        Process(fileDate1.Value.ToShortDateString)
    End Sub

    Private Sub Insert_Log(Log As String)
        If Me.insertBox.InvokeRequired Then
            Dim d As New Insert_Log_Callback(AddressOf Insert_Log)
            Me.Invoke(d, New Object() {Log})
        Else
            If insertBox IsNot Nothing Then
                insertBox.Items.Add(Log)
            End If
            Common_Query_Log(Log, insertBox)
        End If
    End Sub

    '마이그레이션 파일 읽은 후 쿼리문 생성
    Private Sub Process(SearchDate As String)
        Try
            Dim folderPath As String = ConfigurationManager.AppSettings("SourceCsvDirectory") ' CSV 파일 폴더 경로
            Dim csvFile As String = $"{folderPath}\{SearchDate}.csv"

            Dim copyPath As String = ConfigurationManager.AppSettings("SourceFileDirectory") '복사할 원본 경로
            Dim targetPath As String = ConfigurationManager.AppSettings("TargetFileDirectory") '복사 대상 경로

            If File.Exists(csvFile) Then ' 파일 유무 검사
                Using reader As StreamReader = New StreamReader(csvFile) ' 파일로부터 데이터를 읽기 위한 StreamReader 객체를 생성, Using 블록 안에서 작업을 마친 후 자동으로 해당 객체를 제거
                    Dim line As String = reader.ReadLine()
                    Do

                        Dim fields As String() = line.Split(","c) ' ,를 기준으로 String 배열에 담음
                        Dim rec_datm As String = fields(0)
                        Dim rec_date As String = fields(1)
                        Dim rec_fileupload As String = fields(3)

                        Dim filePath As String = Path.GetDirectoryName(rec_fileupload) ' rec_fileupload에서 filePath만 추출
                        Dim fileName As String = Path.GetFileName(rec_fileupload) ' rec_fileupload에서 fileName만 추출

                        If line IsNot Nothing Then ' 라인이 있는지 확인
                            Dim query As String = ""
                            If Not String.IsNullOrEmpty(filePath) AndAlso Not String.IsNullOrEmpty(fileName) Then
                                If Not File.Exists(Path.Combine(filePath, fileName)) Then ' filePath 경로에 fileName이 존재하는지 확인
                                    Common_Insert_Log($"파일없음 : {rec_fileupload}")
                                    line = reader.ReadLine()
                                ElseIf File.Exists(Path.Combine(copyPath + fileName, targetPath + fileName)) Then ' 복사하고 싶은 경로에 복사할 파일이 중복이 되는지 확인
                                    Common_Insert_Log($"중복파일 : {rec_fileupload}")
                                    line = reader.ReadLine()
                                ElseIf rec_date.Contains("null") Then ' rec_fileupload에서 rec_date를 추출하지 못했을 경우
                                    Dim tempFileName As String = rec_fileupload ' rec_fileupload를 가져와 tempFileName에 저장한다.
                                    Dim temp As String = tempFileName.Split("_")(8) ' 8번째 저장

                                    Dim create As String = fileNameCreate(temp, "MMM dd yyy hh mmtt", "yyyy-MM-dd HH:mm:ss")
                                    Dim create2 As String = fileNameCreate(temp, "MMM dd yyy hh mmtt", "yyyyMMdd")

                                    ' ponytail: 문자열 결합 쿼리는 로그 출력용. 실제 DB 실행 시 파라미터 바인딩(SqlParameter 등)으로 교체 필요 (SQL Injection 방지)
                                    query += $"INSERT INTO tbl_record(rec_datm, rec_date, rec_start_time, rec_end_time, rec_call_time, rec_fileupload) VALUES({create2}, {create}, {create}, {create}, '1900-01-01 00:00:00.000', '{rec_fileupload}');"
                                    ' Log 생성
                                    Common_Insert_Log_NoTime("log", $"{query}")
                                    ' 쿼리 누적 후 파일 복사 작업
                                    File.Copy(copyPath + fileName, targetPath + fileName)
                                    ' 다음 라인으로 이동
                                    line = reader.ReadLine()
                                Else
                                    ' 성공시 쿼리 누적
                                    query += $"INSERT INTO tbl_record(rec_datm, rec_date, rec_start_time, rec_end_time, rec_call_time, rec_fileupload) VALUES({rec_datm}, {rec_date}, {rec_date}, {rec_date}, '1900-01-01 00:00:00.000', '{rec_fileupload}');"
                                    ' Log 생성
                                    Common_Insert_Log_NoTime("log", $"{query}")
                                    ' 쿼리 누적 후 파일 복사 작업
                                    File.Copy(copyPath + fileName, targetPath + fileName)
                                    ' 다음 라인으로 이동
                                    line = reader.ReadLine()
                                End If
                            End If
                        Else
                            Common_Insert_Log($"파일 경로 또는 파일 이름이 잘못되었습니다. 파일 경로: {filePath}, 파일 이름: {fileName}", insertBox)
                        End If
                    Loop Until line Is Nothing
                End Using
                Common_Insert_Log($"작업을 완료하였습니다 :  {SearchDate}", insertBox)
            End If
            Common_Insert_Log($"작업을 완료하였습니다 :  {SearchDate}", insertBox)
        Catch ex As Exception
            Common_Insert_Log("파일을 읽어오는 동안 예외가 발생했습니다", insertBox)
        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    ' 예시: sc_1_00000000_000000_00000_00000_00000000_000_Aug 12 2011 10 17AM_0000000000000_000000_0000000000_00000.nmf
    ' 날짜를 추출하기 힘든 파일명일 경우 '_'를 기준으로 배열에 담아 파싱한다.

    Private Sub btnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click
        Do
            Process(fileDate1.Value.ToString("yyyyMMdd"))
            fileDate1.Value = fileDate1.Value.AddDays(1)
            Console.WriteLine($"{fileDate1.Value} + 시작날짜, {fileDate2.Value} + 끝날짜")
            Application.DoEvents()
        Loop While fileDate1.Value <= fileDate2.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tempFileName As String = "sc_1_00000000_000000_00000_00000_00000000_000_Aug 12 2011 10 17AM_0000000000000_000000_0000000000_00000.nmf"
        Dim temp As String = tempFileName.Split("_")(8)

        Debug.Print(fileNameCreate(temp, "MMM dd yyy hh mmtt", "yyyy-MM-dd HH:mm:ss"))

    End Sub

    Private Function fileNameCreate(datetimestring As String, inputtimeformat As String, outputtimeformat As String) As String
        Dim returnvalue As String = ""
        Dim parseddatetime As DateTime
        If DateTime.TryParseExact(datetimestring, inputtimeformat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, parseddatetime) Then
            returnvalue = parseddatetime.ToString(outputtimeformat)
        End If
        Return returnvalue
    End Function

End Class
