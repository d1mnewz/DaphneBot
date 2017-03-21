using System;
using System.Linq;
using System.Web.UI;

namespace HelloBot.Forms
{
    public partial class Users : Page
    {
        protected void Page_Load(object sender, EventArgs e) // everytime something is changing on page, Page_Load is getting called.
        {
        }
        protected void Page_Init(object sender, EventArgs e) // for updating table on search we need to use Page_Init 
                                                            //to set initial values because its getting called only one time
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                foreach (var VARIABLE in ctx.Users)
                {
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{VARIABLE.id}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.Team.teamName}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.userName}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.fullName}</td>" +
                                      $"</tr>";
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                string searchWord = txtWord.Text;
                var resultsByUsername = ctx.Users.Where(x => x.userName.Contains(searchWord));
                var resultsByFullname = ctx.Users.Where(x => x.fullName.Contains(searchWord));
                var results = resultsByUsername.Union(resultsByFullname);
                resultStr.Text = ""; // this empties our table. and if there is no items in result set, table will be empty.

                foreach (var VARIABLE in results)
                {
                    resultStr.Text += $"<tr>" +
                                      $"<td data-title='ID'>{VARIABLE.id}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.Team.teamName}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.userName}</td>" +
                                      $"<td data-title='team-name' >{VARIABLE.fullName}</td>" +
                                      $"</tr>";

                }

            }
        }


    }
}