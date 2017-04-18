using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Linq;
using SlackAPI;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace HelloBot
    {



    [Serializable]
    public class DialogAnswer
    {
        [Prompt("What have you already done?")]
        public string Done { get; set; }
        [Prompt("What will you do?")]
        public string WillDo { get; set; }
        [Prompt("What problems do you have?")]
        public string Problems { get; set; }

        public static IForm<DialogAnswer> BuildForm()
        {
            
            

            return new FormBuilder<DialogAnswer>()
                    .Message("Welcome to the simple Status writing Daphne bot!")
                    .OnCompletion(saveState)
                    .Build();
        }
        async Task<bool> SaveToDb(IDialogContext ctx, DialogAnswer state)
        {
            using (DaphneBotEntities db = new DaphneBotEntities())
            {
                // if status has no answers, then do 
                db.QAs.Add(new QA() { answer = state.Done, questionId = 1, whenCollected = DateTime.Now, statusId = 1/* to define to what status is this answer*/ });
                db.QAs.Add(new QA() { answer = state.WillDo, questionId = 2, whenCollected = DateTime.Now, statusId = 1/* to define to what status is this answer*/ });
                db.QAs.Add(new QA() { answer = state.Problems, questionId = 3, whenCollected = DateTime.Now, statusId = 1/* to define to what status is this answer*/ });
                db.SaveChanges();

                return true;
                // else return false;
            }
        }

        static OnCompletionAsyncDelegate<DialogAnswer> saveState;

        public DialogAnswer()
        {
            saveState = async (context, state) =>
            {
                if (await SaveToDb(context, state))
                    await context.PostAsync("Your status was saved");
                else await context.PostAsync("Something went wrong and your status wasn't saved :(");
            };
        }
    }

        public class MessagesController : ApiController
        {
            public static IDialog<DialogAnswer> MakeRoot()
            {
                return Chain.From(() => FormDialog.FromForm(DialogAnswer.BuildForm));
            }

            [BotAuthentication]
            public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
            {
                {
                    if (activity.Type == ActivityTypes.Message)
                    {
                        await Microsoft.Bot.Builder.Dialogs.Conversation.SendAsync(activity, MakeRoot);
                    }
                    else
                    {

                        // HandleSystemMessage(activity);
                    }
                    var response = Request.CreateResponse(HttpStatusCode.OK);
                    return response;
                }
            }
        }
}