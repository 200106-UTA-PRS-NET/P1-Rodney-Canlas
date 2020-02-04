namespace PizzaBox.DataAccess.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}
