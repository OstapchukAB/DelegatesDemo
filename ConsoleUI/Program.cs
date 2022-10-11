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

            //Корзина №1
            decimal totalPriceWithDiscount = cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser);
            Console.WriteLine($"Итоговая сумма для корзины: {totalPriceWithDiscount:C2}");
            Console.WriteLine();
            //*********************

            //Корзина №2
            var numberCart = "№2";
            decimal total = cart.GenerateTotal(
                (subTotal) => Console.WriteLine($"В корзину {numberCart} набрано товаров на сумму: {subTotal:C2}"),  
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
                (message) => Console.WriteLine($"Для корзины {numberCart}: {message}"));

            Console.WriteLine($"Итоговая сумма для корзины {numberCart}: {total:C2}");
            Console.WriteLine();
            //*********************



            Console.WriteLine();
            Console.Write("Для выхода нажмите любую клавишу");
            Console.ReadKey();
        }

        /// <summary>
        /// Сообщаем покупателю на какую сумму он набрал товаров в корзину
        /// </summary>
        /// <param name="subTotal"></param>
        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"В корзину набрано товаров на сумму: {subTotal:C2}");
  
        }

        /// <summary>
        /// Выводим сообщение покупателю
        /// </summary>
        /// <param name="message"></param>
        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

       /// <summary>
       /// Расчитываем скидку по алгоритму и возвращаем сумму со скидкой
       /// </summary>
       /// <param name="ListProducts">Список продуктов</param>
       /// <param name="subTotal">Сумма товаров в корзине</param>
       /// <returns></returns>
        private static decimal CalculateLeveledDiscount(List<ProductModel> ListProducts, decimal subTotal)
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
        ///  наполняем корзины демонстрационными продуктами
        /// </summary>
        private static void PopulateCartWithDemoData()
        {
            cart.ListProductItem.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.ListProductItem.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.ListProductItem.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.ListProductItem.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        
        


    }
}
