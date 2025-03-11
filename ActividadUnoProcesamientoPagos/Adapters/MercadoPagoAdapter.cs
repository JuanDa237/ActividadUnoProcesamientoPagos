using ActividadUnoProcesamientoPagos.Api;

namespace ActividadUnoProcesamientoPagos.Adapters
{
    public class MercadoPagoAdapter : IPaymentService
    {
        private MercadoPagoAPI _mercadoPagoAPI = new MercadoPagoAPI();

        public void ProcessPayment(decimal amount)
        {
            _mercadoPagoAPI.Pagar(amount);
        }
    }
}
