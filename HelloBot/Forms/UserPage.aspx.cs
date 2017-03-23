using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class UserPage : System.Web.UI.Page
    {
        int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Int32.TryParse(Request.QueryString["uid"], out userId);

            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var user = ctx.Users.Where(u => u.id == userId).FirstOrDefault();
                LoginLbl.Text = user.userName;
                FNameLbl.Text = user.fullName;

                foreach(var r in ctx.Roles)
                {
                    rolesDDl.Items.Add(r.roleName);
                }
                if (user.roleId == 1)
                    rolesDDl.SelectedIndex = 0;
                else if (user.roleId == 2)
                    rolesDDl.SelectedIndex = 1;
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var user = ctx.Users.Where(u => u.id == userId).FirstOrDefault();
                //to rework this peace of code
                /*
                if (rolesDDl.SelectedIndex==0)
                {
                    user.roleId = 1;
                }
                else
                {
                    user.roleId = 2;
                }*/

                if(user.roleId==2)
                {
                    user.roleId = 1;
                }
                else
                {
                    user.roleId = 2;
                }
                ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                Response.Redirect("Users.aspx");
            }
                
        }
    }
}