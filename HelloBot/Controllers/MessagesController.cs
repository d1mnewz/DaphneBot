using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System.Web.Http.Description;


namespace HelloBot
{
    [Serializable]
    public class UserStatus
    {
        public Dictionary<int ,string> questions;
        public Dictionary<int, string> answers;

        public void fillQuestions()
        {
            questions.Add(1, "what you gonna do when they come for you?");
            questions.Add(2, "bad boyz, bad boyz");
            questions.Add(3, "what you gonna do when they come for you?");
        }

        public static IForm<UserStatus> BuildStatus()
        {
            return new FormBuilder<UserStatus>().Message("Ok, now you need to ask some questions :)").Build();
        }
    }

    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<UserStatus> MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(UserStatus.BuildStatus));
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 
        ///
        [ResponseType(typeof(void))]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, MakeRootDialog);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        #region system messages
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
#endregion
    }
}