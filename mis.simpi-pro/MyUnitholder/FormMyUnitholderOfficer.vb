Imports C1.Win.C1TrueDBGrid
Imports simpi.GlobalUtilities.GlobalString
Imports simpi.MasterClient
Imports simpi.ParameterClient

Public Class FormMyUnitholderOfficer
    Public objClient As MasterClient
    Dim objOfficer As New ClientOfficer
    Dim objReligion As New ParameterReligion

    Dim dtOfficer As New DataTable
    Dim i As Integer = 0

    Public Sub FormLoad()
        If objClient.GetClientID > 0 Then
            objOfficer.UserAccess = objAccess
            objReligion.UserAccess = objAccess
            DBGOfficer.FetchRowStyles = True
            lblCIF.Text = objClient.GetClientCode
            lblName.Text = objClient.GetClientName
            dtOfficer = objOfficer.Search(objClient, "")
            i = 0
            Dim query = From o In dtOfficer.AsEnumerable
                        Select No = increment(), Officer = o.Field(Of String)("OfficerName")

            With DBGOfficer
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = query.ToList
                .Splits(0).DisplayColumns("No").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Officer").HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("No").Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Officer").Style.HorizontalAlignment = AlignHorzEnum.Near
                For Each column As C1DisplayColumn In DBGOfficer.Splits(0).DisplayColumns
                    column.AutoSize()
                Next
            End With

        Else
            Close()
        End If
    End Sub

    Private Function increment() As Integer
        i += 1
        Return i
    End Function

    Private Sub DBGOfficer_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGOfficer.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub DBGOfficer_RowColChange(sender As Object, e As RowColChangeEventArgs) Handles DBGOfficer.RowColChange
        OfficerSelected()
    End Sub

    Private Sub DBGOfficer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBGOfficer.Click
        OfficerSelected()
    End Sub

    Private Sub OfficerSelected()
        With DBGOfficer
            If .RowCount > 0 And .Row > 0 Then
                .MarqueeStyle = MarqueeEnum.HighlightRow
                Dim officer() As DataRow = dtOfficer.Select("OfficerName = '" & SQLFix(.Columns("Officer").Text.Trim) & "'")
                If officer.Length > 0 Then
                    lblOfficerName.Text = .Columns("Officer").Text
                    lblOfficerTitle.Text = officer(0)("OfficerTitle")
                    txtOfficerPhone.Text = officer(0)("OfficerPhone")
                    txtOfficerEmail.Text = officer(0)("OfficerEmail")
                    objReligion.Clear()
                    objReligion.LoadID(officer(0)("OfficerReligionID"))
                    lblOfficeReligion.Text = objReligion.GetReligionCode
                    lblOfficerSpouseName.Text = officer(0)("OfficerSpouseName")
                    If IsDate(officer(0)("OfficerBirthDate")) Then
                        lblDayBirth.Text = checkDate(CDate(officer(0)("OfficerBirthDate")))
                        lblOfficerBirthDate.Text = CDate(officer(0)("OfficerBirthDate")).ToString("dd-MMM-yyyy")
                    End If
                    If IsDate(officer(0)("OfficerSpouseBirthDate")) Then
                        lblDaySpouse.Text = checkDate(CDate(officer(0)("OfficerSpouseBirthDate")))
                        lblOfficerSpouseBirth.Text = CDate(officer(0)("OfficerSpouseBirthDate")).ToString("dd-MMM-yyyy")
                    End If
                    If IsDate(officer(0)("OfficerSpouseAnniversary")) Then
                        lblDayAnniversary.Text = checkDate(CDate(officer(0)("OfficerSpouseAnniversary")))
                        lblOfficerSpouseAnniversarry.Text = CDate(officer(0)("OfficerSpouseAnniversary")).ToString("dd-MMM-yyyy")
                    End If
                End If
            End If
        End With
    End Sub

    Private Function checkDate(ByVal dtDate As Date) As String
        Dim dtNow As Date
        dtNow = New Date(Now.Year, dtDate.Month, dtDate.Day)
        Dim d As Integer = DateDiff(DateInterval.Day, dtNow, Now)
        Dim s As String = ""
        If d < 0 Then d = d * -1
        If d = 0 Then
            s = "IT'S TODAY"
        ElseIf d < 7 Then
            s = "IT'S CLOSE"
        Else
            If Now.Date < dtNow.Date Then
                s = d & " days"
            Else
                dtNow = New Date(Now.Year + 1, dtDate.Month, dtDate.Day)
                s = DateDiff(DateInterval.Day, Now, dtNow) & " days"
            End If
        End If
        Return s
    End Function


End Class