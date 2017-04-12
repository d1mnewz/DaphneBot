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
namespace HelloBot
    {



        [Serializable]
        public class DialogAnswer
        {
        // TODO:
        // write the same IForm<CompleteStatus> BuildForm() for entity class which i will get from master 
        // and fill fields from entity(or some model class* optionally) - that`s getting questions from database
        // and save changes in database context in saveState function
        //public List<string> l = new List<string>(); // TO DO from GetQuestions
        public string First { get; set; }
        public string Second { get; set; }
        public List<Question> Questions { get 
        {
                using (var ctx = new DaphneBotEntities())
                {
                    return (from temp in ctx.Questions select temp).ToList();
                }
            }
        }
        public static IForm<DialogAnswer> BuildForm()
        {
            OnCompletionAsyncDelegate<DialogAnswer> saveState = async (context, state) =>
            {
            // to implement saving state to database:
            // add fields (state) to db context and save it
            
            await context.PostAsync("some message");
            
            // throw notimplementedexception

        };
            return new FormBuilder<DialogAnswer>()
                    .Message("Welcome to the simple Status writing Daphne bot!")
                    .OnCompletion(saveState)
                    .Build();
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
                        await Conversation.SendAsync(activity, MakeRoot);
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