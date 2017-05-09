using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Texter.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From = "+19093216348";
        public string Body { get; set; }
        public string Status { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());
            return messageList;
        }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages", Method.POST);

            var parsedTo = To.Replace("-", "").Replace(".", "").Replace(")", "").Replace("(", "").Replace(" ", "");
            List<string> catFact = Message.GetCatFact();
            request.AddParameter("To", "+1" + parsedTo);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body + " Did you know: " + catFact[0]);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            client.ExecuteAsync(request, response => {
                Console.WriteLine(response.Content);
            });
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static List<String> GetCatFact()
        {
            //Client is the base of the api call
            var client = new RestClient("http://catfacts-api.appspot.com/api/facts");
            //Add parameters in request
            var request = new RestRequest("", Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            //Converts the json object to the return type you want
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            //Looks for the key "facts" and returns list of values associated with that key
            var messageList = JsonConvert.DeserializeObject<List<String>>(jsonResponse["facts"].ToString());
            Console.WriteLine(messageList);
            return messageList;
        }
    }
}
