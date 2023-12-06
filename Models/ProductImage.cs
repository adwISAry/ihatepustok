namespace nov30task.Models
{
    public class ProductImage
    {
       public int Id { get; set; }
        public string ProductId { get; set; }
        public string Product { get; set; }

        public string ImagePath { get; set; }
         public bool IsActive { get; set; }  
    }
}
