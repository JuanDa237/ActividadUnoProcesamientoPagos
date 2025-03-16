using System;
using ActividadUnoProcesamientoPagos;
using ActividadUnoProcesamientoPagos.Adapters;

class Program
{
    static void Main()
    {
        // Definición de los productos: nombre y precio.
        var products = new (string Name, decimal Price)[]
        {
            ("Laptop", 1000m),
            ("Smartphone", 700m),
            ("Tablet", 400m),
            ("Monitor", 200m),
            ("Teclado", 50m),
            ("Mouse", 30m),
            ("Impresora", 150m),
            ("Disco Duro", 80m),
            ("Auriculares", 100m),
            ("Webcam", 90m)
        };

        while (true)
        {
            Console.WriteLine("Seleccione un producto:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price}");
            }
            Console.WriteLine("11. Salir");

            string productChoice = Console.ReadLine();
            if (productChoice == "11")
            {
                break;
            }

            if (!int.TryParse(productChoice, out int productIndex) || productIndex < 1 || productIndex > products.Length)
            {
                Console.WriteLine("Opción de producto inválida. Intente de nuevo.");
                continue;
            }

            var selectedProduct = products[productIndex - 1];
            Console.WriteLine($"Has seleccionado: {selectedProduct.Name} por un precio de ${selectedProduct.Price}");
            Console.WriteLine("Presiona cualquier tecla para continuar al sistema de pago...");
            Console.ReadKey();
            Console.Clear();

            // Llamada al menú de pago utilizando el precio del producto seleccionado.
            PaymentMenu(selectedProduct.Price);

            Console.WriteLine("Presiona cualquier tecla para volver al menú de productos...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void PaymentMenu(decimal amount)
    {
        while (true)
        {
            Console.WriteLine("Seleccione un proveedor de pago:");
            Console.WriteLine("1. PayPal");
            Console.WriteLine("2. Stripe");
            Console.WriteLine("3. MercadoPago");
            Console.WriteLine("4. Cancelar pago");

            string choice = Console.ReadLine();
            if (choice == "4") break;

            IPaymentService paymentService = null;

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
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
            }

            paymentService.ProcessPayment(amount);
            break; // Salir del menú de pago una vez procesado el pago.
        }
    }
}