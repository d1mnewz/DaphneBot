using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace HelloBot.Forms
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                string name;
                foreach (var VARIABLE in ctx.Users)
                {
                    name = getTeamName((Int32)VARIABLE.teamId);
                    resultStr.Text += $"<tr>" +
                            $"<td data-title='ID'>{VARIABLE.id}</td>" +
                            $"<td data-title='team-name' >{name}</td>" +
                            $"<td data-title='team-name' >{VARIABLE.userName}</td>" +
                            $"<td data-title='team-name' >{VARIABLE.fullName}</td>" +
                        $"</tr>";

                }
            }
        }
        protected string getTeamName(int id)
        {
            string name="";

            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var team = ctx.Teams.Where(t => t.id == id).FirstOrDefault();
                try
                {
                    name = team.teamName;
                }
                catch(Exception e)
                {
                    name = e.Message.ToString();
                }
            }

            return name;
        }
    }
}