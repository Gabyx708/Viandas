﻿using Viandas.Infrastructure.Data.EntityModel;

namespace Viandas.Infrastructure.Data.EntityModels
{
    public class OrderItemModel
    {
        public required string OrderID { get; set; }

        public required string MenuID { get; set; }
        public required string DishID { get; set; }

        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }

        public required OrderModel OrderModel { get; set; }
        public required MenuOptionModel MenuOptionModel { get; set; }

    }
}
