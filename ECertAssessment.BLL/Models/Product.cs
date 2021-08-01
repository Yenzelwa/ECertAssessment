namespace ECertAssessment.BLL.Models
{
    public class Product : Entity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}