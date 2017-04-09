using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Migrations;
namespace HelloBot.Forms
{
    public partial class SetQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var questionA = ctx.Questions.Where(q => q.id == 1).FirstOrDefault();
                questionA.questionContent = question1.Text;
                ctx.Entry(questionA).State = System.Data.Entity.EntityState.Modified;

                var questionB = ctx.Questions.Where(q => q.id == 2).FirstOrDefault();
                questionB.questionContent = question2.Text;
                ctx.Entry(questionB).State = System.Data.Entity.EntityState.Modified;

                var questionC = ctx.Questions.Where(q => q.id == 3).FirstOrDefault();
                questionC.questionContent = question3.Text;
                ctx.Entry(questionC).State = System.Data.Entity.EntityState.Modified;

                ctx.SaveChanges();

                Response.Redirect("Questions.aspx");
            }
        }
    }
}