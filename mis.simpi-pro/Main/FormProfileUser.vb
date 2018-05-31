Imports C1.Win.C1TrueDBGrid
Imports simpi.SystemLog
Imports simpi.GlobalUtilities
Imports simpi.MasterSimpi

Public Class FormProfileUser
    Dim objUser As New SimpiUser
    Dim objLog As New SystemLog

    Private Sub FormProfileUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objLog.UserAccess = objAccess
        objUser.UserAccess = objAccess
        objUser.Load(objAccess.GetUserLogin)
        dtFrom.Value = Now.AddDays(-30)
        dtTo.Value = Now
        UserLoad()
        DBGLog.FetchRowStyles = True
    End Sub

    Private Sub UserLoad()
        lblUserLogin.Text = objAccess.GetUserLogin
        lblUserID.Text = objAccess.GetUserID
        lblUserInitial.Text = objAccess.GetUserInitial
        lblUserName.Text = objAccess.GetUserName
        lblUserTitle.Text = objAccess.GetUserTitle
        lblSimpiName.Text = objAccess.GetSimpiName
        GetMasterSimpi()
        If objSimpi.GetSimpiID > 0 Then
            lblSimpiID.Text = objSimpi.GetSimpiID
            lblSimpiType.Text = objSimpi.GetSimpiType.GetTypeCode
            lblSalesOfficer.Text = objSimpi.GetSalesName & " [" & objSimpi.GetSalesOfficer & "]"
            lblSimpiShortname.Text = objSimpi.GetSimpiNameshort
            lblSimpiAddress.Text = objSimpi.GetSimpiAddress
            lblSimpiContact.Text = objSimpi.GetSimpiContact
            lblSimpiEmail.Text = objSimpi.GetSimpiEmail
            lblSimpiPhone.Text = objSimpi.GetSimpiPhone
            lblAdminName.Text = objSimpi.GetAdminName
            lblAdminEmail.Text = objSimpi.GetAdminLogin
        Else
            ExceptionMessage.Show(objSimpi.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If
    End Sub

    Private Sub DBGLog_FetchRowStyle(sender As Object, e As FetchRowStyleEventArgs) Handles DBGLog.FetchRowStyle
        If e.Row Mod 2 = 0 Then
            e.CellStyle.BackColor = Color.LemonChiffon
        End If
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        EmailCall()
    End Sub

    Private Sub EmailCall()
        Try
            Process.Start(String.Format("mailto:{0}", lblAdminEmail.Text))
        Catch ex As Exception
            ExceptionMessage.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnPassword_Click(sender As Object, e As EventArgs) Handles btnPassword.Click
        Dim frm As New FormPassword
        frm.Left = 0
        frm.Top = 30
        frm.MdiParent = MDIMIS
        frm.Show()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SystemLog()
    End Sub

    Private Sub SystemLog()
        Dim tbl As New DataTable
        Dim tbl2 As New DataTable
        objLog.Clear()
        tbl = objLog.LogSearch(objUser, 0, "", dtFrom.Value, dtTo.Value, "", "", "")
        If objLog.ErrID = 0 Then
            tbl2 = tbl.DefaultView.ToTable("log", True, "LogID", "LogDate", "UserLogin",
                                           "LogDescription", "AppsCode", "AppsTerminal", "AppsDate")
            With tbl2
                .Columns("LogDate").ColumnName = "Date"
                .Columns.Add("No")
                .Columns.Add("Activity")
                For i As Integer = 0 To .Rows.Count - 1
                    .Rows(i)("No") = i + 1
                    .Rows(i)("Activity") = "DESCRIPTION: " & .Rows(i)("LogDescription") & Environment.NewLine &
                                           "APPLICATION: " & .Rows(i)("AppsCode") & Environment.NewLine &
                                           "TERMINAL: " & .Rows(i)("AppsTerminal") & Environment.NewLine & "-"
                Next
                .Columns.Remove("LogID")
                .Columns.Remove("UserLogin")
                .Columns.Remove("LogDescription")
                .Columns.Remove("AppsCode")
                .Columns.Remove("AppsTerminal")
                .Columns.Remove("AppsDate")

                .Columns("No").SetOrdinal(0)
                .Columns("Date").SetOrdinal(1)
                .Columns("Activity").SetOrdinal(2)

            End With

            With DBGLog
                .AllowAddNew = False
                .AllowDelete = False
                .AllowUpdate = False
                .Style.WrapText = False
                .Columns.Clear()
                .DataSource = tbl2

                Dim no, dt, aktivitas As C1DisplayColumn
                no = .Splits(0).DisplayColumns("No")
                dt = .Splits(0).DisplayColumns("Date")
                aktivitas = .Splits(0).DisplayColumns("Activity")

                no.Width = 35
                dt.Width = 120
                aktivitas.Width = 560

                .Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns(1).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns(2).HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center

                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = AlignHorzEnum.Far
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = AlignHorzEnum.Center
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = AlignHorzEnum.Near

                .Columns("Date").NumberFormat = "dd-MMM-yyyy hh:mm"

                DBGLog.SuspendLayout()
                For i As Integer = 0 To DBGLog.Splits(0).Rows.Count - 1
                    DBGLog.Splits(0).Rows(i).AutoSize()
                Next
                DBGLog.ResumeLayout(True)

            End With
        Else
            DBGLog.Columns.Clear()
            ExceptionMessage.Show(objLog.ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class