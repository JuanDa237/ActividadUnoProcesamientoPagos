using ActividadUnoProcesamientoPagos;
using ActividadUnoProcesamientoPagos.Adapters;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Seleccione un proveedor de pago:");
            Console.WriteLine("1. PayPal");
            Console.WriteLine("2. Stripe");
            Console.WriteLine("3. MercadoPago");
            Console.WriteLine("4. Salir");

            string choice = Console.ReadLine();
            if (choice == "4") break;

            Console.Write("Ingrese el monto a pagar: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Monto inválido. Intente de nuevo.");
                continue;
            }

            IPaymentService paymentService;

            switch (choice)
            {
                case "1":
                    paymentService = new PayPalAdapter();
                    break;
                case "2":
                    paymentService = new StripeAdapter();
                    break;
                case "3":
                    paymentService = new MercadoPagoAdapter();
                    break;
                default:
                    paymentService = null;
                    break;
            }

            if (paymentService != null)
            {
                paymentService.ProcessPayment(amount);
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.WriteLine();
        }
    }
}