Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports DevExpress.Web

Namespace SetEditTemplateValueInCode
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = LoadDataTable()
			ASPxGridView1.DataBind()
		End Sub
		Private Function LoadDataTable() As DataTable
			Dim table As DataTable = CType(Session("DataTable"), DataTable)
			If table Is Nothing Then
				table = CreateTable()
				SaveDataTable(table)
			End If
			Return table
		End Function
		Private Sub SaveDataTable(ByVal table As DataTable)
			Session("DataTable") = table
		End Sub
		Private Shared Function CreateTable() As DataTable
			Dim table As New DataTable()
			table.PrimaryKey = New DataColumn() { table.Columns.Add("ID", GetType(Integer)) }
			table.Columns.Add("DataColumn", GetType(String))
			For i As Integer = 0 To 4
				table.Rows.Add(i, "default")
			Next i
			table.AcceptChanges()
			Return table
		End Function

		Protected Sub ASPxGridView1_HtmlEditFormCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewEditFormEventArgs)
			Dim editor As ASPxTextEdit = CType(ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1"), ASPxTextEdit)
			' EditForm is open for editing
			If Request.Params(editor.UniqueID) Is Nothing Then
				editor.Text = DateTime.Now.ToLongTimeString()
			End If
			' else 
			' the EditForm is recreated before the Update command is processed.
		End Sub

		Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
			Dim editor As ASPxTextEdit = CType(ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1"), ASPxTextEdit)
			Dim newValue As String = editor.Text

			Dim table As DataTable = LoadDataTable()
			Dim row As DataRow = table.Rows.Find(e.Keys(0))
			row("DataColumn") = newValue
			table.AcceptChanges()
			SaveDataTable(table)

			e.Cancel = True
			ASPxGridView1.CancelEdit()
			ASPxGridView1.DataSource = table
			ASPxGridView1.DataBind()
		End Sub
	End Class
End Namespace
