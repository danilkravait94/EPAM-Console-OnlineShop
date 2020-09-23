namespace EShop.Roles.Interfaces
{
    interface IUser
    {
        void ShowBasket();
        void AddorNoToBasket();
        void CreateOrder();
        void EditOrder(Order order, string country);
        void EditOrder(Order order, int number);
        void EditOrder(Order order, string country,int number);
        void ShowOrders();
        Guest Exit();

    }
}
