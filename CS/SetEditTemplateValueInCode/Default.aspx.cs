using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DevExpress.Web;

namespace SetEditTemplateValueInCode {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = LoadDataTable();
            ASPxGridView1.DataBind();
        }
        private DataTable LoadDataTable() {
            DataTable table = (DataTable)Session["DataTable"];
            if(table == null) {
                table = CreateTable();
                SaveDataTable(table);
            }
            return table;
        }
        private void SaveDataTable(DataTable table) {
            Session["DataTable"] = table;
        }
        private static DataTable CreateTable() {
            DataTable table = new DataTable();
            table.PrimaryKey = new DataColumn[] { table.Columns.Add("ID", typeof(int)) };
            table.Columns.Add("DataColumn", typeof(string));
            for(int i = 0; i < 5; i++)
                table.Rows.Add(i, "default");
            table.AcceptChanges();
            return table;
        }

        protected void ASPxGridView1_HtmlEditFormCreated(object sender, DevExpress.Web.ASPxGridViewEditFormEventArgs e) {
            ASPxTextEdit editor = (ASPxTextEdit)ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1");
            // EditForm is open for editing
            if(Request.Params[editor.UniqueID] == null) {
                editor.Text = DateTime.Now.ToLongTimeString();
            }
            // else 
            // the EditForm is recreated before the Update command is processed.
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e) {
            ASPxTextEdit editor = (ASPxTextEdit)ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1");
            string newValue = editor.Text;

            DataTable table = LoadDataTable();
            DataRow row = table.Rows.Find(e.Keys[0]);
            row["DataColumn"] = newValue;
            table.AcceptChanges();
            SaveDataTable(table);

            e.Cancel = true;
            ASPxGridView1.CancelEdit();
            ASPxGridView1.DataSource = table;
            ASPxGridView1.DataBind();
        }
    }
}
