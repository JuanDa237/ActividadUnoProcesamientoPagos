namespace ActividadUnoProcesamientoPagos.Api
{
    public class StripeAPI
    {
        public void Charge(decimal amount)
        {
            Console.WriteLine($"[StripeAPI] Cargo realizado por {amount:C}");
        }
    }

}
