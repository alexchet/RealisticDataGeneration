using Bogus;
using Bogus.Extensions.Extras;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealisticDataGeneration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var paymentDetailsFaker = new Faker<PaymentDetails>()
                .RuleFor(x => x.Amount, x => x.Finance.Amount())
                .RuleFor(x => x.Currency, x => x.Finance.Currency().Code)
                .RuleFor(x => x.CreditCardNumber, x => x.Finance.CreditCardNumberObfuscated());

            var userFaker = new Faker<User>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.Phone, x => x.Person.Phone)
                .RuleFor(x => x.Address, x => x.Address.StreetAddress())
                .RuleFor(x => x.City, x => x.Address.City())
                .RuleFor(x => x.PostCode, x => x.Address.ZipCode())
                .RuleFor(x => x.Country, x => x.Address.Country())
                .RuleFor(x => x.PaymentDetails, x => paymentDetailsFaker);

            foreach(var user in userFaker.GenerateForever())
            {

                var json = JsonSerializer.Serialize(user);
                Console.WriteLine(json);
                await Task.Delay(1000);
            }
            Console.ReadLine();
        }
    }
}
