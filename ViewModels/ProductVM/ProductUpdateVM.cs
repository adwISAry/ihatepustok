namespace nov30task.ViewModels.ProductVM
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Avability { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        public decimal CostPrice { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public decimal ExTax { get; set; }
        public object ProductCode { get; set; }
        public ushort Quantity { get; set; }
        public string RewardPoints { get; set; }
        public decimal SellPrice { get; set; }
    }
}