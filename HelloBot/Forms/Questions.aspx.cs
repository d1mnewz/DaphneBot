using System;
using System.Web.UI;

namespace HelloBot.Forms
{
    public partial class Questions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                
                foreach (var VARIABLE in ctx.Questions)
                {
                   
                       

                }
            }
        }

    }
}
