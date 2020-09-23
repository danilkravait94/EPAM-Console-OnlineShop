namespace EShop
{
    public class Order
    {
        public enum Statuses
        {
            New,
            CanceledByAdmin,
            CanceledByUser,
            GetMoney,
            Sent,
            Recieved,
            Ended
        }
        public Product Product { get; set; }
        public Statuses Status { get; set; }
        public bool IsPaid { get; set; } = false;
        public string Country { get; set; }
        public int NumberOfPost { get; set; }
        public Order()
        { }
        public Order(Product product, string country,int number)
        {
            Product = product;
            Status = Statuses.New;
            Country = country;
            NumberOfPost = number;
        }
        public override string ToString()
        {
            string s;
            if (IsPaid)
            {
                s = "paid";
            }
            else s = "not paid";
            return $"{Product} -- status: {Status,14}, {s,8}";
        }
    }
}
