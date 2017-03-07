using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace BotApp
{
    using System.Configuration;
    using Models;

    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;


                CustomLuisModel luisResponse = await GetEntityFromLUIS(activity.Text);

                // return our reply to the user
                Activity reply = activity.CreateReply($"keyword is {luisResponse.entities[0].entity}");

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

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


        private static async Task<CustomLuisModel> GetEntityFromLUIS(string Query)
        {
            Query = Uri.EscapeDataString(Query);
            CustomLuisModel Data = new CustomLuisModel();
            using (HttpClient client = new HttpClient())
            {
                var appSettings = ConfigurationManager.AppSettings;
                string requestUri = appSettings["LuisAPI"] ?? "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/dfbb93a0-5369-4477-965f-0d57aa373771?subscription-key=029649524cea4917b39956be2648890c&verbose=true&q=";
                 requestUri = requestUri + Query;

                HttpResponseMessage msg = await client.GetAsync(requestUri);

                if (msg.IsSuccessStatusCode)
                {
                    var jsonDataResponse = await msg.Content.ReadAsStringAsync();
                    Data = JsonConvert.DeserializeObject<CustomLuisModel>(jsonDataResponse);
                }
            }
            return Data;
        }
    }
}