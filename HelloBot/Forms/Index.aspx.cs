using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Controllers
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


                foreach (var VARIABLE in ctx.Users)
                {
                    resultStr.Text += $"{VARIABLE.id} {VARIABLE.userName} {VARIABLE.fullName} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var VARIABLE in ctx.Questions)
                {
                    resultStr.Text += $"{VARIABLE.id} {VARIABLE.questionContent} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var VARIABLE in ctx.Teams)
                {
                    resultStr.Text += $"{VARIABLE.id} {VARIABLE.teamName} <br>";

                }
                resultStr.Text += "<br>";
                foreach (var VARIABLE in ctx.QAs)
                {
                    resultStr.Text += $"{VARIABLE.id} {VARIABLE.questionId} {VARIABLE.statusId} {VARIABLE.answer} {VARIABLE.whenCollected} <br>";

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

