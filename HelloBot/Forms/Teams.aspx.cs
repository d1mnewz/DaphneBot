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
            // everytime something is changing on page, Page_Load is getting called.
        {
        }

        protected void Page_Init(object sender, EventArgs e) // for updating table on search we need to use Page_Init 
            // to set initial values because its getting called only one time
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach (var item in ctx.Teams)
                {
                    resultStr.Text += $"<tr><td>{item.id}" +
                                      $"</td><td ><a href='TeamPage.aspx?tid={item.id}'>{item.teamName}</a><td></tr>";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                string searchWord = txtWord.Text;
                var results = ctx.Teams.Where(x => x.teamName.Contains(searchWord));
                resultStr.Text = "";
                    // this empties our table. and if there is no items in result set, table will be empty.
                foreach (var item in results)
                {
                    resultStr.Text += $"<tr><td>{item.id}" +
                                      $"</td><td ><a href='TeamPage.aspx?tid={item.id}'>{item.teamName}</a><td></tr>";
                }
            }
        }
    }
}