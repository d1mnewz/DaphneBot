using System;
using System.Linq;

namespace HelloBot.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                resultStr.Text +=
                    $"We have {ctx.Users.Count()} users," +
                    $" {ctx.Teams.Count()} teams," +
                    $" {ctx.QAs.Count()} QA combinations," +
                    $" {ctx.Questions.Count()} questions," +
                    $" {ctx.Statuses.Count()} statuses. <br><br>";


                foreach (var variable in ctx.Users)
                {
                    resultStr.Text += $"{variable.id} {variable.userName} {variable.fullName} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var variable in ctx.Questions)
                {
                    resultStr.Text += $"{variable.id} {variable.questionContent} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var variable in ctx.Teams)
                {
                    resultStr.Text += $"{variable.id} {variable.teamName} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var variable in ctx.QAs)
                {
                    resultStr.Text += $"{variable.id} {variable.questionId} {variable.statusId} {variable.answer} {variable.whenCollected} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var VARIABLE in ctx.Statuses)
                {
                    resultStr.Text += $"{VARIABLE.id} {VARIABLE.userId} {VARIABLE.whenToCollect} <br>";

                }
                resultStr.Text += "<br>";
            }
        }
    }
}

