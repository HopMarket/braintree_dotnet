using System;
using Braintree;

namespace Demo
{
    public class DynamicPaymentMethodFactory
    {

        public MyPaymentMethod Create(dynamic braintreePaymentMethod)
        {
            if (braintreePaymentMethod.PaymentInstrumentType == PaymentInstrumentType.CREDIT_CARD)
            {
                return new MyPaymentMethod {
                                                BraintreeToken = braintreePaymentMethod.Token,
                                                CreditCardExpirationMonth = braintreePaymentMethod.ExpirationMonth,
                                                CreditCardExpirationYear = braintreePaymentMethod.ExpirationYear
                                            };
            }

            if (braintreePaymentMethod.PaymentInstrumentType == PaymentInstrumentType.PAYPAL_ACCOUNT)
            {
                return new MyPaymentMethod {
                                                BraintreeToken = braintreePaymentMethod.Token,
                                                PayPalEmailAddress = braintreePaymentMethod.Email
                                            };
                
            }
            
            throw new Exception("Invalid PaymentInstrumentType: " + braintreePaymentMethod.PaymentInstrumentType);
        }
    }
}
