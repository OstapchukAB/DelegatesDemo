using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    /// <summary>
    /// Бизнес-модель корзины покупателя 
    /// </summary>
    public class ShoppingCartModel
    {

        public delegate void MentionDiscount(decimal subTotal);

        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        /// <summary>
        /// Считаем сумму товаров в корзине и выводим итоговую скидку, подтверждаем скидку
        /// </summary>
        /// <param name="mentionSubtotal"> Показываем покупателю на какую сумму он набрал товаров и сообщаем ему об этом </param>
        /// <param name="calculateDiscountedTotal">Расчет итоговой суммы со скидкой</param>
        /// <param name="tellUserWeAreDiscounting">Сообщение пользователю о применении скидки</param>
        /// <returns></returns>
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>,decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            
            tellUserWeAreDiscounting("Вам применена скидка!");

            decimal total = calculateDiscountedTotal(Items, subTotal);

            return total;
        }
    }
}
