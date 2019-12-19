namespace Common.Entity.ShoppingPlannerService
{
    public static class ShoppingPlannerDefaultValues
    {
        public static class DefaultShoppingCategory
        {
            public static readonly ShoppingCategory ShoppingCategory = new ShoppingCategory
            {
                Id = 0,
                Name = "Новая категория",
                Color = "000",
                ImagePath = "https://st3.depositphotos.com/13821126/18366/v/1600/depositphotos_183663702-stock-illustration-sale-bags-packages-in-the.jpg",
                IsOn = true,
                BoardId = 0
            };

            public static ShoppingCategory VerificationAndCorrectionDataForCreating(ShoppingCategory item)
            {
                if (item.Id != 0) { item.Id = ShoppingCategory.Id; }

                if (string.IsNullOrEmpty(item.Name)) { item.Name = ShoppingCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = ShoppingCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.ImagePath = ShoppingCategory.ImagePath; }

                if (item.IsOn == false) { item.IsOn = ShoppingCategory.IsOn; }

                if(item.BoardId <= 0) { return null; }

                return item;
            }

            public static ShoppingCategory VerificationAndCorrectionDataForEdit(ShoppingCategory item)
            {
                if (string.IsNullOrEmpty(item.Name)) { item.Name = ShoppingCategory.Name; }

                if (string.IsNullOrEmpty(item.Color)) { item.Color = ShoppingCategory.Color; }

                if (string.IsNullOrEmpty(item.ImagePath)) { item.ImagePath = ShoppingCategory.ImagePath; }

                if (item.BoardId <= 0) { return null; }

                return item;
            }
        }

        public static class DefaultTypeOfPurchase
        {
            public static TypeOfPurchase TypeOfPurchase
            {
                get
                {
                    return new TypeOfPurchase
                    {
                        Id = 0,
                        Name = "ед",
                        BoardId = 0
                    };
                }
            }

            public static TypeOfPurchase VerificationAndCorrectionDataForCreating(TypeOfPurchase item)
            {
                if (item.Id != 0) { item.Id = TypeOfPurchase.Id; }

                if (string.IsNullOrEmpty(item.Name)) { item.Name = TypeOfPurchase.Name; }

                if (item.BoardId <= 0) { return null; }

                return item;
            }

            public static TypeOfPurchase VerificationAndCorrectionDataForEdit(TypeOfPurchase item)
            {
                if (string.IsNullOrEmpty(item.Name)) { item.Name = TypeOfPurchase.Name; }

                if (item.BoardId <= 0) { return null; }

                return item;
            }
        }

        public static class DefaultPurchase
        {
            public static Purchase Purchase
            {
                get
                {
                    return new Purchase
                    {
                        Id = 0,
                        Name = "",
                        Description = "",
                        ShoppingCategoryId = 0,
                        TypeOfPurchaseId = 0,
                        PlannerDateId = 0,
                        PriceOfOneUnit = 1,
                        Amount = 1,
                        TotalPrice = 1,
                        IsDone = false,
                        BoardId = 0
                    };
                }
            }

            public static Purchase VerificationAndCorrectionDataForCreating(Purchase item)
            {
                if (item.Id != 0) { item.Id = Purchase.Id; }

                if (string.IsNullOrEmpty(item.Name)) { item.Name = Purchase.Name; }

                if (string.IsNullOrEmpty(item.Description)) { item.Description = Purchase.Description; }

                if (item.ShoppingCategoryId < 0) { item.ShoppingCategoryId = Purchase.ShoppingCategoryId; }

                if (item.TypeOfPurchaseId < 0) { item.TypeOfPurchaseId = Purchase.TypeOfPurchaseId; }

                if (item.PlannerDateId < 0) { item.PlannerDateId = Purchase.PlannerDateId; }

                if (item.PriceOfOneUnit < 0) { item.PriceOfOneUnit = Purchase.PriceOfOneUnit; }

                if (item.Amount < 1) { item.Amount = Purchase.Amount; }

                if (item.TotalPrice < 0) { item.TotalPrice = Purchase.TotalPrice; }

                if (item.IsDone != false) { item.IsDone = Purchase.IsDone; }

                if (item.BoardId <= 0) { return null; }

                return item;
            }

            public static Purchase VerificationAndCorrectionDataForEdit(Purchase item)
            {
                if (item.Amount < 1) { item.Amount = Purchase.Amount; }

                if (item.PriceOfOneUnit < 0) { item.PriceOfOneUnit = Purchase.PriceOfOneUnit; }

                if (item.TotalPrice != item.Amount * item.PriceOfOneUnit) { item.TotalPrice = item.Amount * item.PriceOfOneUnit; }

                if (item.ShoppingCategoryId < 0) { item.ShoppingCategoryId = Purchase.ShoppingCategoryId; }

                if (item.TypeOfPurchaseId < 0) { item.TypeOfPurchaseId = Purchase.TypeOfPurchaseId; }

                if (item.PlannerDateId < 0) { item.PlannerDateId = Purchase.PlannerDateId; }

                if (item.BoardId <= 0) { return null; }

                return item;
            }
        }
    }
}
