
using ActividadUnoProcesamientoPagos.Api;

namespace ActividadUnoProcesamientoPagos.Adapters
{
    public class PayPalAdapter : IPaymentService
    {
        private PayPalAPI _payPalAPI = new PayPalAPI();

        public void ProcessPayment(decimal amount)
        {
            _payPalAPI.MakePayment(amount);
        }
    }
}
