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


namespace HelloBot
{
    internal static IDialog<CompleteStatus> MakeRootDialog()
    {
        return Chain.From(() => FormDialog.FromForm(CompleteStatus.BuildForm));
    }
    [ResponseType(typeof(void))]
    public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
    {
        if (activity != null)
        {
            // one of these will have an interface and process it
            switch (activity.GetActivityType())
            {
                case ActivityTypes.Message:
                    await Conversation.SendAsync(activity, MakeRootDialog);
                    break;
                case ActivityTypes.ConversationUpdate:
                case ActivityTypes.ContactRelationUpdate:
                case ActivityTypes.Typing:
                case ActivityTypes.DeleteUserData:
                default:
                    Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
            }
        }
    }


                    //[BotAuthentication]
                    //public class MessagesController : ApiController
                    //{
                    //    /// <summary>
                    //    /// POST: api/Messages
                    //    /// Receive a message from a user and reply to it
                    //    /// </summary>
                    //    /// 
                    //    /// 
                    //    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
                    //    {
                    //        if (activity.Type == ActivityTypes.Message)
                    //        {
                    //            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                    //            var now = DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss");

                    //            // return our reply to the user
                    //            Activity reply = activity.CreateReply($"Hello, IoT! " +
                    //                                                  $"I am Daphne and I will collect your statuses someday. But for now take this kitty. "
                    //                                                  + $"http://thecatapi.com/api/images/get?format=src&type=png&timestamp=" + $"{now}");


                    //            await connector.Conversations.ReplyToActivityAsync(reply);
                    //        }
                    //        else
                    //        {
                    //            HandleSystemMessage(activity);
                    //        }
                    //        var response = Request.CreateResponse(HttpStatusCode.OK);
                    //        return response;
                    //    }

                    //    private Activity HandleSystemMessage(Activity message)
                    //    {
                    //        if (message.Type == ActivityTypes.DeleteUserData)
                    //        {
                    //            // Implement user deletion here
                    //            // If we handle user deletion, return a real message
                    //        }
                    //        else if (message.Type == ActivityTypes.ConversationUpdate)
                    //        {
                    //            // Handle conversation state changes, like members being added and removed
                    //            // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                    //            // Not available in all channels
                    //        }
                    //        else if (message.Type == ActivityTypes.ContactRelationUpdate)
                    //        {
                    //            // Handle add/remove from contact lists
                    //            // Activity.From + Activity.Action represent what happened
                    //        }
                    //        else if (message.Type == ActivityTypes.Typing)
                    //        {
                    //            // Handle knowing tha the user is typing
                    //        }
                    //        else if (message.Type == ActivityTypes.Ping)
                    //        {
                    //        }

                    //        return null;
                    //    }
                    //}
            }