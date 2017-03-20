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
               
                foreach (var VARIABLE in ctx.QAs)
                {

                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{VARIABLE.id}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.Question.questionContent}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.answer}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.whenCollected}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.statusId}</td>" +

                                      $"</tr>";
                }
            }
        }
    }
}