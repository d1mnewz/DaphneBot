using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class EditQuestions : System.Web.UI.Page
    {
        int questionId = 0;
        string newText = "";
        protected void Page_Init(object sender, EventArgs e)
        { 
            
            Int32.TryParse(Request.QueryString["qqid"], out questionId);
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var question=ctx.Questions.Where(q => q.id == questionId).FirstOrDefault();
                newText = question.questionContent;
                edittbx.Text = question.questionContent;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var question = ctx.Questions.Where(q => q.id == questionId).FirstOrDefault();
                question.questionContent = newText;
                ctx.Entry(question).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
               
            }
            Response.Redirect("Questions.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Questions.aspx");
        }

        protected void edittbx_TextChanged(object sender, EventArgs e)
        {
            newText = edittbx.Text;
        }
    }
}