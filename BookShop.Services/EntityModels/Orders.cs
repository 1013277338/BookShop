//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShop.Services.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public Orders()
        {
            this.OrderBook = new HashSet<OrderBook>();
        }
    
        public int orderid { get; set; }
        public System.DateTime orderdate { get; set; }
        public int state { get; set; }
        public string postAddress { get; set; }
        public float totalprice { get; set; }
        public int userid { get; set; }
    
        public virtual ICollection<OrderBook> OrderBook { get; set; }
        public virtual Users Users { get; set; }
    }
}
