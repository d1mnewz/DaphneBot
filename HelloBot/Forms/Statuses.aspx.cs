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
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach (var VARIABLE in ctx.Statuses)
                {
                    resultStr.Text += $"<tr>" +
                            $"<td data-title='ID'>{VARIABLE.id}</td>" +
                            $"<td data-title='team-name' >{VARIABLE.User.userName}</td>" +
                            $"<td data-title='team-name' >{VARIABLE.whenToCollect}</td>" +
                        $"</tr>";

                }
            }
        }
    }
}