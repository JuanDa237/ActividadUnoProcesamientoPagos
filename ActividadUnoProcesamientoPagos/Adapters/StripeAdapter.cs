using ActividadUnoProcesamientoPagos.Api;

namespace ActividadUnoProcesamientoPagos.Adapters
{
    public class StripeAdapter : IPaymentService
    {
        private StripeAPI _stripeAPI = new StripeAPI();

        public void ProcessPayment(decimal amount)
        {
            _stripeAPI.Charge(amount);
        }
    }
}
