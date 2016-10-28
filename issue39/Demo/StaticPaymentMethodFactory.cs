using System;
using Braintree;

namespace Demo
{
    public class StaticPaymentMethodFactory
    {

        public MyPaymentMethod Create(PaymentMethod braintreePaymentMethod)
        {
            var creditCard = braintreePaymentMethod as CreditCard;
            if (creditCard != null)
            {
                return new MyPaymentMethod {
                                                BraintreeToken = creditCard.Token,
                                                CreditCardExpirationMonth = creditCard.ExpirationMonth,
                                                CreditCardExpirationYear = creditCard.ExpirationYear
                                            };
            }

            var payPal = braintreePaymentMethod as PayPalAccount;
            if (payPal != null)
            {
                return new MyPaymentMethod {
                                                BraintreeToken = payPal.Token,
                                                PayPalEmailAddress = payPal.Email
                                            };
                
            }
            
            throw new Exception("Invalid PaymentInstrumentType: " + braintreePaymentMethod.GetType().Name);
        }
    }
}