using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace StoreImageDB
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            bool db = Convert.ToBoolean(Request.QueryString["db"]);
            if (id != 0)
            {
                byte[] img;
                if (db)
                {
                    img = ReadImageAsBinary(id);

                }
                else
                {
                    img = (byte[])(Session[id.ToString()]);

                }

                MemoryStream ms = new MemoryStream(img);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                Response.ContentType = "image/jpeg";
                returnImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                returnImage.Dispose();

            }
        }

        protected byte[] ReadImageAsBinary(int image_id)
        {string connstring = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ToString();
                using (SqlConnection sqlconnection = new SqlConnection(connstring))
            {
                sqlconnection.Open();

                string selectQuery = string.Format(@"Select [Image] From [Images] Where id={0}", image_id);

                // Read Image Value from Sql Table 
                SqlCommand selectCommand = new SqlCommand(selectQuery, sqlconnection);
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    byte[] imgData = (byte[])reader[0];

                    return imgData;
                }
            }

            return null;
        }
    }
}