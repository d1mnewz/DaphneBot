using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class QAs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                string question = "undefined question";
                foreach (var VARIABLE in ctx.QAs)
                {
                    var firstOrDefault = ctx.Questions.FirstOrDefault(x => x.id == VARIABLE.questionId);
                    if (firstOrDefault != null)
                        question = firstOrDefault.questionContent;
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{VARIABLE.id}</td>" +
                                      $"<td data-title='team-name' >{question}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.answer}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.whenCollected}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.statusId}</td>" +

                                      $"</tr>";
                }
            }
        }
    }
}