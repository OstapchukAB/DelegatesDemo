using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();

        static void Main(string[] args)
        {

            //Установка русской глобализации для нормального вывода вместо кракозябр и подключаем Unicode(UTF-8)
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("ru-RU"); 
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            PopulateCartWithDemoData();

            Console.WriteLine($"Итоговая сумма со скидкой: {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
            Console.WriteLine();

            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subtotal for cart 2 is {subTotal:C2}"),
                (products, subTotal) =>
                {
                    if (products.Count > 3)
                    {
                        return subTotal * 0.5M;
                    }
                    else
                    {
                        return subTotal;
                    }
                },
                (message) => Console.WriteLine($"Cart 2 Alert: {message}"));

            Console.WriteLine($"The total for cart 2 is {total:C2}");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        /// <summary>
        /// Показываем сумму набранных товаров в корзине и сообщаем об этом
        /// </summary>
        /// <param name="subTotal"></param>
        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"В корзине товаров на сумму: {subTotal:C2}");
  
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

       /// <summary>
       /// Расчитываем скидку по алгоритму и возвращаем сумму со скидкой
       /// </summary>
       /// <param name="items"></param>
       /// <param name="subTotal"></param>
       /// <returns></returns>
        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.95M;
            }
            else
            {
                return subTotal;
            }
        }

        /// <summary>
        ///  наполнение корзины демонстрационными продуктами с ценами
        /// </summary>
        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        
        


    }
}
