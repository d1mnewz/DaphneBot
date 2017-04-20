using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloBot.Forms
{
    public partial class QAs : System.Web.UI.Page
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

                foreach (var item in ctx.QAs)
                {

                    resultStr.Text += $"<div style='margin: 1%'>" +
                        $"<table id='table' class='table table-hover table - mc - light - blue' style='margin: 1%'> "+
                        $"<td data-title='ID'>{item.id}</td>" +
                        $"<td data-title='team-name' >{item.Question.questionContent}</td>" +
                        $"<td data-title='team-name' >{item.answer}</td>" +
                        $"<td data-title='team-name' >{item.whenCollected}</td>" +
                        $"<td data-title='team-name' >{item.statusId}</td>" +
                        $"</tbody></ table ></tr></div>";
                }
            }
        }
        public string GetStatusData(int id)
        { 
            using (DaphneBotEntities ctx = new DaphneBotEntities())
            {
                var status = ctx.Statuses.Where(s => s.userId == id).FirstOrDefault();
                return status.User.userName+"     "+status.whenToCollect;
            }
            
        }
    }
}