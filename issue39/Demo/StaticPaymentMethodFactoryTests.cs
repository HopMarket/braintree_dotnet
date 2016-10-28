using Braintree;
using NUnit.Framework;

namespace Demo
{
    [TestFixture]
    public class StaticPaymentMethodFactoryTests
    {
        // These tests fail because the types do not match the expected types
        [Test]
        public void CreateCreditCardPaymentMethodWithFakeCreditCard()
        {
            var factory = new StaticPaymentMethodFactory();
            var model = new FakeCreditCard {Token = "test token", ExpirationMonth = "10", ExpirationYear = "2017"};
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("10", result.CreditCardExpirationMonth);
            Assert.AreEqual("2017", result.CreditCardExpirationYear);
        }

        [Test]
        public void CreatePayPalPaymentMethodWithFakePayPal()
        {
            var factory = new StaticPaymentMethodFactory();
            var model = new FakePayPal {Token = "test token", Email = "test@test.com"};
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("test@test.com", result.PayPalEmailAddress);
        }

        public class FakeCreditCard : PaymentMethod
        {
            public string ExpirationMonth { get; set; }
            public string ExpirationYear { get; set; }
            public string LastFour { get; set; }
            public string Token { get; set; }
            public bool? IsDefault { get; }
            public string ImageUrl { get; }
            public string CustomerId { get; }
            public PaymentInstrumentType PaymentInstrumentType { get; }
            public CreditCardCardType CardType { get; set; }
            public string IssuingBank { get; set; }
            public string ProductId { get; set; }
        }

        public class FakePayPal : PaymentMethod
        {
            public string Email { get; set; }
            public string Token { get; set; }
            public bool? IsDefault { get; }
            public string ImageUrl { get; }
            public string CustomerId { get; }
            public PaymentInstrumentType PaymentInstrumentType { get; }
        }

        //// Cannot use Braintree models because the constructors are protected internal
        //[Test]
        //public void CreateCreditCardPaymentMethodWithBraintreeCreditCardModel()
        //{
        //    var factory = new StaticPaymentMethodFactory();
        //    var model = new CreditCard { Token = "test token", ExpirationMonth = "10", ExpirationYear = "2017" };
        //    var result = factory.Create(model);

        //    Assert.AreEqual("test token", result.BraintreeToken);
        //    Assert.AreEqual("10", result.CreditCardExpirationMonth);
        //    Assert.AreEqual("2017", result.CreditCardExpirationYear);
        //}

        //[Test]
        //public void CreatePayPalPaymentMethodWithBraintreePayPalModel()
        //{
        //    var factory = new StaticPaymentMethodFactory();
        //    var model = new PayPalAccount { Token = "test token", Email = "test@test.com" };
        //    var result = factory.Create(model);

        //    Assert.AreEqual("test token", result.BraintreeToken);
        //    Assert.AreEqual("test@test.com", result.PayPalEmailAddress);
        //}



        //// Cannot extend the Braintree models because the setters are protected
        //[Test]
        //public void CreateCreditCardPaymentMethodWithFakeCreditCard2()
        //{
        //    var factory = new StaticPaymentMethodFactory();
        //    var model = new FakeCreditCard2 {Token = "test token", ExpirationMonth = "10", ExpirationYear = "2017"};
        //    var result = factory.Create(model);

        //    Assert.AreEqual("test token", result.BraintreeToken);
        //    Assert.AreEqual("10", result.CreditCardExpirationMonth);
        //    Assert.AreEqual("2017", result.CreditCardExpirationYear);
        //}

        //[Test]
        //public void CreatePayPalPaymentMethodWithFakeBraintreePayPal2()
        //{
        //    var factory = new StaticPaymentMethodFactory();
        //    var model = new FakePayPal2 {Token = "test token", Email = "test@test.com"};
        //    var result = factory.Create(model);

        //    Assert.AreEqual("test token", result.BraintreeToken);
        //    Assert.AreEqual("test@test.com", result.PayPalEmailAddress);
        //}

        //public class FakeCreditCard2 : CreditCard { }
        //public class FakePayPal2 : PayPalAccount { }        

        // Cannot extend the Braintree models because the setters are protected
        [Test]
        public void CreateCreditCardPaymentMethodWithFakeCreditCard3()
        {
            var factory = new StaticPaymentMethodFactory();
            var model = new FakeCreditCard3(token: "test token", expirationMonth: "10", expirationYear: "2017");
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("10", result.CreditCardExpirationMonth);
            Assert.AreEqual("2017", result.CreditCardExpirationYear);
        }

        [Test]
        public void CreatePayPalPaymentMethodWithFakeBraintreePayPal3()
        {
            var factory = new StaticPaymentMethodFactory();
            var model = new FakePayPal3(token: "test token", email: "test@test.com");
            var result = factory.Create(model);

            Assert.AreEqual("test token", result.BraintreeToken);
            Assert.AreEqual("test@test.com", result.PayPalEmailAddress);
        }
        
        #pragma warning disable 612, 618
        public class FakeCreditCard3 : CreditCard
        {
            public FakeCreditCard3(string token, string expirationMonth, string expirationYear)
            {
                Token = token;
                ExpirationMonth = expirationMonth;
                ExpirationYear = expirationYear;
            }
        }

        public class FakePayPal3 : PayPalAccount
        {
            public FakePayPal3(string token, string email)
            {
                Token = token;
                Email = email;
            }
        }
        #pragma warning restore 612, 618
    }
}