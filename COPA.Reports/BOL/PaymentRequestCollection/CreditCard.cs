using Newtonsoft.Json;

namespace COPA.Debug.BOL
{
    /// <summary>
    /// Contains the values for a credit card.
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// The number on the credit card, depending on the issuer, the format may change (ie, the number of digits may vary)
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// The 1-2 digit month the card expires
        /// </summary>
        public string ExpirationMonth { get; set; }
        /// <summary>
        /// The 4-digit year the card expires
        /// </summary>
        public string ExpirationYear { get; set; }
        /// <summary>
        /// The security code on the card, depending on the issuer, the format may change (ie, the number of digits may vary)
        /// </summary>
        public string CVV { get; set; }
        /// <summary>
        /// The first name of the card holder
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the card holder
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The address of the card holder
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// The second line address, for things like apartment number etc.
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// The city of the card holder
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The state of the card holder, short format
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// The 5-digit zip code of the card holder
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// The phone number to use with the card
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The email to use with the card
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Converts the CreditCard object into a Models.PaymentInformation object.
        /// </summary>
        /// <returns></returns>
        public Models.PaymentInformation ConvertToPaymentInformation() => new Models.PaymentInformation()
        {
            CardNumber = CardNumber,
            SecurityCode = CVV,
            ExpirationMonth = ExpirationMonth,
            ExpirationYear = ExpirationYear,

            AddressLine1 = AddressLine1,
            AddressLine2 = AddressLine2,
            City = City,
            State = State,
            ZipCode = ZipCode,

            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
        };
    }
}
