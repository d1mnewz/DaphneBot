using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class Teams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach (var VARIABLE in ctx.Teams)
                {
                    resultStr.Text += $"<tr><td>{VARIABLE.id}" +
                        $"</td><td ><a href='TeamPage.aspx?tid={VARIABLE.id}'>{VARIABLE.teamName}</a><td></tr>";
                }
            }
        }
    }
}