namespace ActividadUnoProcesamientoPagos.Api
{
    public class PayPalAPI
    {
        public void MakePayment(decimal amount)
        {
            Console.WriteLine($"[PayPalAPI] Procesando pago de {amount:C}");
        }
    }
}
