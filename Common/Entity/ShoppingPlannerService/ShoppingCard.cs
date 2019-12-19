namespace Common.Entity.ShoppingPlannerService
{
    public class ShoppingCard
    {
        public Purchase Purchase { get; set; }

        public TypeOfPurchase TypeOfPurchase { get; set; }

        public ShoppingCategory ShoppingCategory { get; set; }
    }
}
