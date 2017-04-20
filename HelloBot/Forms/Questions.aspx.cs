using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class Questions : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        // everytime something is changing on page, Page_Load is getting called.
        {
        }

        protected void Page_Init(object sender, EventArgs e) // for updating table on search we need to use Page_Init 
                                                             // to set initial values because its getting called only one time
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach (var item in ctx.Questions)
                {
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{item.id}</td>" +
                                      $"<td data-title='team-name' >{item.questionContent}</td>" +
                                      $"<td class='btn btn-dagner'><a href='EditQuestions.aspx?qqid={item.id}'>Edit</a></td>"+
                                      $"<td class='btn btn-dagner'><a href='Delete.aspx?dqid={item.id}'>Delete</a></td>"+
                                      $"</tr>";
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            addQuestion.Visible = true;
            addBtn.Visible = true;
            cancelBtn.Visible = true;
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                if (addQuestion.Text != "")
                {
                    var question = ctx.Questions.Where(q => q.id == 1).FirstOrDefault();
                    question.questionContent = addQuestion.Text;
                    ctx.Questions.Add(question);
                    ctx.SaveChanges();
                }
            }
            addQuestion.Visible = false;
            addQuestion.Text = "";
            addBtn.Visible = false;
            cancelBtn.Visible = false;
            Response.Redirect(Request.RawUrl);
        }
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            addQuestion.Visible = false;
            addQuestion.Text = "";
            addBtn.Visible = false;
            cancelBtn.Visible = false;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditQuestions.aspx");
        }
    }
}