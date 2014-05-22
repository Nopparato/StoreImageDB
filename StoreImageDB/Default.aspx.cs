using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace StoreImageDB
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ToString();
                using (SqlConnection sqlconnection = new SqlConnection(connstring))
                {
                    sqlconnection.Open();

                    byte[] imgData = FileUpload1.FileBytes; 

                    string insertXmlQuery = @"Insert Into [Images] ([Image]) OUTPUT INSERTED.ID Values(@Image)";

                    // Insert Image Value into Sql Table by SqlParameter
                    SqlCommand insertCommand = new SqlCommand(insertXmlQuery, sqlconnection);
                    SqlParameter sqlParam = insertCommand.Parameters.AddWithValue("@Image", imgData);
                    sqlParam.DbType = DbType.Binary;
                    int id = (int)insertCommand.ExecuteScalar();

                    Image1.ImageUrl = string.Format("Image.aspx?id={0}&db={1}", id.ToString(), "true");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(FileUpload1.FileName));

                FileStream fiStream = new FileStream(Server.MapPath(FileUpload1.FileName), FileMode.Open);

                BinaryReader binReader = new BinaryReader(fiStream);

                byte[] pic = binReader.ReadBytes(Convert.ToInt32(fiStream.Length));

                int id = Guid.NewGuid().GetHashCode();

                Session[id.ToString()] = pic;
                Image1.ImageUrl = string.Format("Image.aspx?id={0}&db={1}", id.ToString(), "false");

            }
        }
    }
}
