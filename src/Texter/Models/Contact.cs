using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Texter.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }

        public Contact() { }

        public Contact(string name, string address, string imageUrl, string notes, int id = 0)
        {
            Name = name;
            Address = address;
            ImageUrl = imageUrl;
            Notes = notes;
            Rating = 0;
            ContactId = id;
        }





        //public async static void GetContacts()
        //{
        //    var http = new HttpClient();
        //    http.DefaultRequestHeaders.Authorization =
        //new AuthenticationHeaderValue("Basic", EnvironmentVariables.MailChimpApi);
        //    string content = await http.GetStringAsync(@"https://us1.api.mailchimp.com/3.0/lists");
        //    Console.WriteLine(content);
        //}

        //public void Send()
        //{
        //    var client = new RestClient("https://us15.api.mailchimp.com/3.0/");
        //    var request = new RestRequest("https://us15.api.mailchimp.com/3.0/lists", Method.POST);


        //    request.AddParameter("name", Name);
        //    request.AddParameter("address1", Address);
        //    client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
        //    client.ExecuteAsync(request, response => {
        //        Console.WriteLine(response.Content);
        //    });
        //}

        //public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        //{
        //    var tcs = new TaskCompletionSource<IRestResponse>();
        //    theClient.ExecuteAsync(theRequest, response => {
        //        tcs.SetResult(response);
        //    });
        //    return tcs.Task;
        //}

    }
}
