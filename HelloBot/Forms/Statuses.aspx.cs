using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class Statuses : System.Web.UI.Page
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
                foreach (var item in ctx.Statuses)
                {
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{item.id}</td>" +
                                      $"<td data-title='team-name' >{item.User.userName}</td>" +
                                      $"<td data-title='team-name' >{item.whenToCollect}</td>" +
                                      $"</tr>";

                }
            }
        }
    }
}