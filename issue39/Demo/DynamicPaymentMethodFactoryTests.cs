using Braintree;
using NUnit.Framework;

namespace Demo
{
    [TestFixture]
    public class DynamicPaymentMethodFactoryTests
    {
        [Test]
        public void CreateCreditCardPaymentMethod()
        {
            var factory = new DynamicPaymentMethodFactory();
            var model = new FakeBraintreeCreditCard {Token = "test token", ExpirationMonth = "10", ExpirationYear = "2017"};
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("10", result.CreditCardExpirationMonth);
            Assert.AreEqual("2017", result.CreditCardExpirationYear);
        }

        [Test]
        public void CreatePayPalPaymentMethod()
        {
            var factory = new DynamicPaymentMethodFactory();
            var model = new FakeBraintreePayPal {Token = "test token", Email = "test@test.com"};
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("test@test.com", result.PayPalEmailAddress);
        }

        public class FakeBraintreeCreditCard
        {
            public PaymentInstrumentType PaymentInstrumentType { get { return PaymentInstrumentType.CREDIT_CARD; } }
            public string ExpirationMonth { get; set; }
            public string ExpirationYear { get; set; }
            public string LastFour { get; set; }
            public string Token { get; set; }
            public CreditCardCardType CardType { get; set; }
            public string IssuingBank { get; set; }
            public string ProductId { get; set; }
        }

        public class FakeBraintreePayPal
        {
            public PaymentInstrumentType PaymentInstrumentType { get { return PaymentInstrumentType.PAYPAL_ACCOUNT; } }
            public string Email { get; set; }
            public string Token { get; set; }
        }
    }
}