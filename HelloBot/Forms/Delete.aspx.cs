using System;
using System.Collections.Generic;
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
            int.TryParse(Request.QueryString["dqid"], out int questionId);
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var question = ctx.Questions.Where(q => q.id == questionId).FirstOrDefault();
                ctx.Questions.Remove(question);
                ctx.SaveChanges();
                Response.Redirect("Questions.aspx");
            }
        }
    }
}