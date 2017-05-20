using System;
using System.Linq;

namespace HelloBot.Forms
{
    public partial class QAsById : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e) // for updating table on search we need to use Page_Init 
            // to set initial values because its getting called only one time
        {
            int statusId = 0;
            Int32.TryParse(Request.QueryString["sid"], out statusId);
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {

                foreach (var item in ctx.QAs.Where(x => x.statusId == statusId))
                {
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='team-name' >{item.Question.questionContent}</td>" +
                                      $"<td data-title='team-name' >{item.answer}</td>" +
                                      $"<td data-title='team-name' >{item.whenCollected}</td>" +
                                      $"<td data-title='team-name' >{item.statusId}</td>" +

                                      $"</tr>";
                }
            }
        }
    }
}