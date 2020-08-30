using System;

namespace RealisticDataGeneration
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }

    public class PaymentDetails
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
