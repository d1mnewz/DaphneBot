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
        List<int> memberIds = new List<int>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int teamId = 0;
            Int32.TryParse(Request.QueryString["tid"], out teamId);
            FillTeamMembersTable(teamId);
            fillStatusesTable();
        }


        public void FillTeamMembersTable(int id)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var team = ctx.Teams.Where(t => t.id == id).FirstOrDefault();
                try
                {
                    NameLbl.Text = team.teamName;
                }
                catch
                {
                    NameLbl.Text = "Such team not found";
                }

                foreach (var u in ctx.Users)
                {
                    if (u.teamId == team.id)
                    {
                      
                        memberIds.Add(u.id);
                        resultStr.Text += $"<tr>" +
                                          $"<td data-title='ID'>{u.id}</td>" +
                                          $"<td data-title='ID'><a href='UserPage.aspx?uid={u.id}'>{u.userName}</a></td>" +
                                          $"<td data-title='ID'>{u.fullName}</td>"; //+
                        // $"<td>{getRoleName(u.roleId)}</td> </tr>";
                    }

                }



            }
        }


        private void fillStatusesTable()
        {

            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                int tmp;
                for (int i=0;i<memberIds.Count;i++)
                {
                    tmp = memberIds[i];

                    var status = ctx.Statuses.Where(s => s.userId == 1).FirstOrDefault();
                    Label2.Text = $"<tr><td>{status.id}</td>" +
                        $"<td>{getUserName(1)}</td>" +
                        $"<td>{status.whenToCollect}</td></tr>";
                    foreach(var q in ctx.QAs)
                    {
                        if(q.statusId==1)
                        {
                            Label2.Text += $"<td>{q.whenCollected}</td><td>{q.answer}</td>";
                        }
                    }
                }
            }
        }

        private string getUserName(int userId)
        {
            string uName;
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var user = ctx.Users.Where(u => u.id == userId).FirstOrDefault();
                uName = user.userName;
            }
            return uName;
        }
        private string getRoleName(int roleId)
        {
            string rname;

            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var role = ctx.Roles.Where(r => r.id == roleId).FirstOrDefault();
                rname = role.roleName;
            }

            return rname;
        }

      
    }
}
