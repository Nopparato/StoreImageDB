using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace StoreImageDB
{
    public partial class ListPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                readPictureList();
            }
        }

        protected void readPictureList()
        {
            string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ToString();
            using (SqlConnection sqlconnection = new SqlConnection(connstring))
            {
                sqlconnection.Open();

                string selectQuery = string.Format(@"Select [Id] From [Images]");

                // Read Image Value from Sql Table 
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlconnection);
                SqlDataAdapter ad = new SqlDataAdapter(selectCommand);

                DataTable table = new DataTable();
                ad.Fill(table);
                DropDownList1.DataSource = table;
                DropDownList1.DataTextField = "Id";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();

                if (table.Rows.Count > 0)
                {
                    Image1.ImageUrl = string.Format("Image.aspx?id={0}&db={1}", DropDownList1.SelectedValue, "true");
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = string.Format("Image.aspx?id={0}&db={1}", DropDownList1.SelectedValue, "true");
        }
    }
}