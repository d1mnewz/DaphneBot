﻿using System;
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
            
            using (DaphneBaseEntities ctx = new DaphneBaseEntities())
            {
                var team=ctx.Teams.Where(t=>t.id==teamId).FirstOrDefault();
                try
                {
                    NameLbl.Text = team.teamName;
                }
                catch
                {
                    NameLbl.Text = "Such team not found";
                }
                
                foreach(var u in ctx.Users)
                {
                    if(u.teamId==team.id)
                    {
                        resultStr.Text += $"<tr>" +
                            $"<td data-title='ID'>{u.id}</td>"+
                            $"<td data-title='ID'>{u.userName}</td>" +
                            $"<td data-title='ID'>{u.fullName}</td>" +
                            $"<td>{getRoleName(u.roleId??default(int))}</td> </tr>";
                    }
                }

            }
        }
        private string getRoleName(int roleId)
        {
            string rname;

            using (DaphneBaseEntities ctx = new DaphneBaseEntities())
            {
                var role = ctx.Roles.Where(r => r.id == roleId).FirstOrDefault();
                rname = role.roleName;
            }

            return rname;
        }
    }
}