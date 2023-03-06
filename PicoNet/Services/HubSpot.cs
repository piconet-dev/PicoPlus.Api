using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using FormAfzarHandler.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace FormAfzarHandler.Services
{
#nullable disable
    public class HubSpot

    {
      
        public   string Token { get; set; }

      
        public class Objects
        {
            public class Contact
            {

                public async Task<Models.Hubspot.Contact.Create.Resp> Create(Hubspot.Contact.Create.Req ContactProperties)
                {
                
                    var client = new RestClient("https://api.hubapi.com/crm/v3/objects/contacts");
                    var request = new RestRequest();
                    request.AddHeader("accept", "application/json");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("authorization", $"Bearer pat-na1-d31e1209-2f8d-4cde-af00-89113f888372 ");
                    request.AddJsonBody(ContactProperties ,ContentType.Json);
                   
                    var   response = await client.ExecutePostAsync<Models.Hubspot.Contact.Create.Resp>(request);

                    return response.Data;
                }
            }
            public class Deal {

                public async Task<Models.Hubspot.Deal.Create.Resp> Create(Hubspot.Deal.Create.Req DealProperties) {

                    var client = new RestClient("https://api.hubapi.com/crm/v3/objects/deals");
                    var request = new RestRequest();
                    request.AddHeader("accept", "application/json");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("authorization", $"Bearer pat-na1-d31e1209-2f8d-4cde-af00-89113f888372 ");
                    request.AddJsonBody(DealProperties, ContentType.Json);

                    var response = await client.ExecutePostAsync<Models.Hubspot.Deal.Create.Resp>(request);

                    return response.Data;
                }
            }

            public class Assoc {

                public  async  Task<string> Create(string dealid ,string  contactid) {

                    var client = new RestClient($"https://api.hubapi.com/crm/v4/objects/contacts/{contactid}/associations/deals/{dealid}");
                    var request = new RestRequest();
                    request.AddHeader("accept", "application/json");
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("authorization", $"Bearer pat-na1-d31e1209-2f8d-4cde-af00-89113f888372 ");
                    request.AddJsonBody("[{\"associationCategory\":\"HUBSPOT_DEFINED\",\"associationTypeId\":4}]", ContentType.Json);
                    var response = await client.ExecutePutAsync(request);

                    return response.Content;
                }
            }
        }
    }
}
