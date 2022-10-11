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
        public List<ProductModel> ListProductItem { get; set; } = new List<ProductModel>();

        /// <summary>
        /// Расчет итоговой суммы со скидкой
        /// </summary>
        /// <param name="mentionSubtotal"> Сообщаем покупателю на какую сумму он набрал товаров в корзину</param>
        /// <param name="calculateDiscountedTotal">здесь итоговая сумма со скидкой</param>
        /// <param name="tellUserWeAreDiscounting">Сообщение пользователю о применении скидки</param>
        /// <returns></returns>
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>,decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = ListProductItem.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            
            tellUserWeAreDiscounting("Скидка применена!");

            decimal total = calculateDiscountedTotal(ListProductItem, subTotal);

            return total;
        }
    }
}
