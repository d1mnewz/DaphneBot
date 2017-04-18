using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionId;
            Int32.TryParse(Request.QueryString["dqid"], out questionId);
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var question = ctx.Questions.FirstOrDefault(q => q.id == questionId);
                try
                {
                    ctx.Questions.Remove(question);
                    ctx.SaveChanges();
                }
                catch (SqlException ex)
                {
                    return;
                    // how do we handle this exception? 
                    // it occurs when you delete question that is referenced by other QAs
                    // we should notify our user about unallowed action somehow.
                }
                finally
                {
                    
                    Response.Redirect("Questions.aspx");
                }
                

            }
        }
    }
}