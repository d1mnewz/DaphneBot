using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class TeamPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int teamId = 0;
            Int32.TryParse(Request.QueryString["tid"],out teamId);

            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach(var v in ctx.Users)
                {
                    
                }
            }
        }
    }
}