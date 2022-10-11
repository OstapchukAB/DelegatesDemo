using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    /// <summary>
    /// Описываем модель продукта  
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Название продукта
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Цена продукта
        /// </summary>
        public decimal Price { get; set; }
    }
}
