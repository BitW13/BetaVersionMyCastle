using System.ComponentModel.DataAnnotations;

namespace Common.Entity.ShoppingPlannerService
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeOfPurchaseId { get; set; }

        [Required]
        public float Amount { get; set; }

        [Required]
        public float PriceOfOneUnit { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        public bool IsDone { get; set; }

        public int ShoppingCategoryId { get; set; }

        public int PlannerDateId { get; set; }

        [Required]
        public int BoardId { get; set; }
    }
}
