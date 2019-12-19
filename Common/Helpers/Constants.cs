using Common.Entity.NoteService;
using Common.Entity.ShoppingPlannerService;
using Common.Entity.TaskPlannerService;

namespace Common.Helpers
{
    public static class Constants
    {
        public static class DefaultTypeOfPurchase
        {
            public static readonly TypeOfPurchase TypeOfPurchase = new TypeOfPurchase
            {
                Id = 0,
                Name = "ед"
            };
        }

        public static class DefaultShoppingCategory
        {
            public static readonly ShoppingCategory ShoppingCategory = new ShoppingCategory
            {
                Id = 0,
                Name = "Новая категория",
                Color = "000",
                ImagePath = "https://st3.depositphotos.com/13821126/18366/v/1600/depositphotos_183663702-stock-illustration-sale-bags-packages-in-the.jpg",
                IsOn = true
            };
        }
        public static class DefaultNoteCategories
        {
            public static readonly NoteCategory NoteCategory = new NoteCategory
            {
                Id = 0,
                Name = "Категория",
                Color = "000",
                ImagePath = "https://st3.depositphotos.com/2903611/13027/i/950/depositphotos_130272574-stock-photo-phone-on-notepad-pen-coffee.jpg",
                IsOn = true
            };
        }

        public static class DefaultTaskCategories
        {
            public static readonly TaskCategory TaskCategory = new TaskCategory
            {
                Id = 0,
                Name = "Категория",
                Color = "000",
                ImagePath = "https://st3.depositphotos.com/2903611/13027/i/950/depositphotos_130272574-stock-photo-phone-on-notepad-pen-coffee.jpg",
                IsOn = true
            };
        }
    }
}
