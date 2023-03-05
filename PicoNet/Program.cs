
using FormAfzarHandler.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Logging;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.RegularExpressions;
using Telegram.Bot;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PicoNet {


    public class Program {
#nullable disable
        public static void Main(string[] args) {
          
            var builder = WebApplication.CreateBuilder(args);
          
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapPost("/CRM", async  context => {
                try {
                    #region Details Registeration 
                    string FullName = string.Empty;
                    string Phone = string.Empty;
                    string DealTitle = string.Empty;
                    string DealAmount = string.Empty;
                    string Description = string.Empty;
                    string Discount = string.Empty;
                    #endregion

                    TelegramBotClient bot = new TelegramBotClient("6086012221:AAELPYgt1pLJnEUJeTqQ3godA2eAWvC-DCg");
                    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    var webhookData = JsonSerializer.Deserialize<FormAfzarHandler.Models.FormAfzarHandler>(requestBody);
                    FormAfzarHandler.Services.HubSpot.Objects.Contact contact = new FormAfzarHandler.Services.HubSpot.Objects.Contact();
                    FormAfzarHandler.Services.HubSpot.Objects.Deal Deal = new FormAfzarHandler.Services.HubSpot.Objects.Deal();

                    FormAfzarHandler.Services.HubSpot.Objects.Assoc Assoc = new FormAfzarHandler.Services.HubSpot.Objects.Assoc();

                    foreach (var items in webhookData.form._params) {

                        if (items.fieldId == 5) {
                            FullName = items.value;
                        }
                        if (items.fieldId == 6) {
                            Phone = items.value;
                        }
                        if (items.fieldId == 3) {

                            DealTitle = items.value;
                        }
                        if (items.fieldId == 56) {

                            DealAmount = items.value;
                        }



                    }


                    var data = await contact.Create(new Hubspot.Contact.Create.Req {
                        properties = new Hubspot.Contact.Create.Req.Properties {

                            phone = Phone,
                            firstname = FullName,
                            email = Phone + "@picocrm.ir"
                        }
                    });

                    if (data.category == "CONFLICT") {

                        // Define the regular expression pattern to match all numbers
                        string pattern = @"\d+";

                        // Create a regular expression object
                        Regex regex = new Regex(pattern);

                        // Use the Matches method to find all matches in the input string
                        MatchCollection matches = regex.Matches(data.message);

                        // Iterate over the matches and print out the numbers
                        foreach (Match match in matches) {

                            await bot.SendTextMessageAsync(1057871814, "Contact Found With: " + match.Value);

                            var DealInfo = await Deal.Create(new Hubspot.Deal.Create.Req {

                                properties = new Hubspot.Deal.Create.Req.Properties {

                                    amount = DealAmount,
                                    dealname = DealTitle,
                                    dealstage = "closedwon",
                                    pipeline = "default"
                                }
                            });
                            await bot.SendTextMessageAsync(1057871814, "Deal Created  With: " + DealInfo.id);
                            var Assocres = await Assoc.Create(DealInfo.id, match.Value);

                            await bot.SendTextMessageAsync(1057871814, "Assoc : " + Assocres);


                        }

                    }
                    else {

                        await bot.SendTextMessageAsync(1057871814, "Contact Created With: " + data.id);

                        var DealInfo = await Deal.Create(new Hubspot.Deal.Create.Req {

                            properties = new Hubspot.Deal.Create.Req.Properties {

                                amount = DealAmount,
                                dealname = DealTitle,
                                dealstage = "closedwon",
                                pipeline = "default"
                            }
                        });
                        var Assocres = await Assoc.Create(DealInfo.id, data.id);

                        await bot.SendTextMessageAsync(1057871814, "Assoc : " + Assocres);

                    }
                }

                catch (Exception ex) {

                    TelegramBotClient bot = new TelegramBotClient("6086012221:AAELPYgt1pLJnEUJeTqQ3godA2eAWvC-DCg");

                    await bot.SendTextMessageAsync(1057871814, "Error: " +ex.Message);

                }



            })
                .WithName("CRM");

            

            app.Run();
        }
    }
}