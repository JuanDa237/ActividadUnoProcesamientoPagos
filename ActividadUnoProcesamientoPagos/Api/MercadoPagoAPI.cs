namespace ActividadUnoProcesamientoPagos.Api
{
    public class MercadoPagoAPI
    {
        public void Pagar(decimal amount)
        {
            Console.WriteLine($"[MercadoPagoAPI] Pago realizado por {amount:C}");
        }
    }
}
