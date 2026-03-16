Imports DevExpress.XtraEditors.Controls
Imports LMCInsight360.ClassFunction
Imports System.Data.SqlClient
Public Class CtrUserAccess

    Private WithEvents SelectTools As FrmLookup

    Private Sub CtrUserAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlFooter.Hide()

        If BtnEdtUserID.EditValue <> "" Then
            LoadMenu()
        End If
    End Sub

    Private Sub BtnEdtUserID_ButtonPressed(sender As Object, e As ButtonPressedEventArgs) Handles BtnEdtUserID.ButtonPressed
        Dim strTripSelect As String = "SELECT UserID,FullName,UserName,ShortDesc,CreatedDate,CreatedBy,IsActive,IsLoggedIn,IsResetPass FROM vw_MT_UserDepartment"

        If IsFormOpen(SelectTools) Then
            SelectTools.Close()
        End If

        SelectTools = New FrmLookup(strTripSelect, "ResetPassword")
        SelectTools.ShowDialog()
    End Sub

    Private Sub Select_Selected(Get_idNumber As String) Handles SelectTools.Selected

        BtnEdtUserID.EditValue = Get_idNumber

    End Sub

    Sub GetUserData()
        Dim dataList As List(Of Dictionary(Of String, String)) = GetMultiValues($"SELECT * FROM vw_MT_UserDepartment WHERE UserID ='{BtnEdtUserID.EditValue}'")

        For Each row In dataList
            TxtUserName.Text = row("UserName")
            TxtName.Text = row("FullName")
            TxtDept.Text = row("LongDesc")
            TxtCreatedBy.Text = row("CreatedBy")
            TxtCreatedDate.Text = row("CreatedDate")


            If row("IsActive") = True Then
                lblActive.Text = "Active"
                lblActive.ForeColor = Color.Green
                RbtnActive.Checked = True
            Else
                lblActive.Text = "Inactive"
                lblActive.ForeColor = Color.Red
                RbtnInactive.Checked = True
            End If

            If row("IsLoggedIn") = True Then
                lblActiveSession.Text = "Online"
                lblActiveSession.ForeColor = Color.Green
            Else
                lblActiveSession.Text = "Offline"
                lblActiveSession.ForeColor = Color.Red
            End If
        Next

    End Sub

    Private Sub BtnEdtUserID_EditValueChanged(sender As Object, e As EventArgs) Handles BtnEdtUserID.EditValueChanged
        GetUserData()

        If Convert.IsDBNull(BtnEdtUserID.EditValue) OrElse String.IsNullOrWhiteSpace(Convert.ToString(BtnEdtUserID.EditValue)) Then
            PnlFooter.Hide()
        Else
            PnlFooter.Show()
            LoadMenu()
        End If

    End Sub


    ' Load the TreeView from RptMenu
    Private Sub LoadMenu()

        TreeView1.CheckBoxes = True
        TreeView1.Nodes.Clear()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter($"SELECT Code, Parent, Menu, {BtnEdtUserID.EditValue} FROM MSTR_USERACCESS", SqlConnect)
        da.Fill(dt)

        ' Load root nodes (Parent = '\')
        For Each row As DataRow In dt.Select("[Parent]='\'")
            Dim node As New TreeNode
            node.Text = row("Menu").ToString
            node.Name = row("Code").ToString
            node.Checked = (Convert.ToInt32(row(BtnEdtUserID.EditValue)) = 1) ' Check if Status = 1

            TreeView1.Nodes.Add(node)

            LoadChild(node, dt)
        Next
    End Sub

    ' Recursive load of child nodes
    Private Sub LoadChild(parentNode As TreeNode, dt As DataTable)
        For Each row As DataRow In dt.Select("[Parent]='" & parentNode.Name & "'")
            Dim child As New TreeNode
            child.Text = row("Menu").ToString
            child.Name = row("Code").ToString
            child.Checked = (Convert.ToInt32(row(BtnEdtUserID.EditValue)) = 1) ' Check if Status = 1

            parentNode.Nodes.Add(child)

            ' Recursively load children of this node
            LoadChild(child, dt)
        Next
    End Sub

    ' Auto-check/uncheck child nodes when parent is checked
    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        ' Prevent infinite loop
        RemoveHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck

        For Each child As TreeNode In e.Node.Nodes
            child.Checked = e.Node.Checked
            CheckChildrenRecursive(child, e.Node.Checked)
        Next

        AddHandler TreeView1.AfterCheck, AddressOf TreeView1_AfterCheck
    End Sub

    Private Sub CheckChildrenRecursive(node As TreeNode, isChecked As Boolean)
        For Each child As TreeNode In node.Nodes
            child.Checked = isChecked
            CheckChildrenRecursive(child, isChecked)
        Next
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        If BtnEdtUserID.EditValue Is Nothing Then
            MessageBox.Show("Please select a user.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        For Each node As TreeNode In TreeView1.Nodes
            SaveNodeStatus(node)
        Next

        Dim params As New Dictionary(Of String, Object) From {
                              {"@status", If(RbtnActive.Checked, 1, 0)},
                              {"@UserID", BtnEdtUserID.EditValue}
                }

        Dim qry As String = $"Update MSTR_USERS set IsActive=@status where UserID=@UserID"

        ExecuteUpdate(qry, params)

        MessageBox.Show("User Access updated successfully")
    End Sub

    Private Sub SaveNodeStatus(node As TreeNode)
        Dim status As Integer = If(node.Checked, 1, 0)

        Dim params As New Dictionary(Of String, Object) From {
                              {"@status", status},
                              {"@code",  node.Name}
                }

        Dim qry As String = $"UPDATE MSTR_USERACCESS SET {BtnEdtUserID.EditValue}=@status WHERE Code=@code"

        ExecuteUpdate(qry, params)

        ' Recursive save for children
        For Each child As TreeNode In node.Nodes
            SaveNodeStatus(child)
        Next
    End Sub

    Private Sub SidePanel3_Click(sender As Object, e As EventArgs) Handles SidePanel3.Click

    End Sub
End Class
