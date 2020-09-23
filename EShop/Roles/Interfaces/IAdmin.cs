using static EShop.Order;

namespace EShop.Roles
{
    interface IAdmin 
    {
        void AddProduct();
        void ShowInfoAboutUsers();
        void ChangeUsersInfo(User user, string name, string lastname);
        void ChangeUsersInfo(User user, string password);
        void ChangeUsersInfo(User user, decimal money);
        void ChangeUsersEmail(User user, string email);
        void ChangeProduct(Product product, string name, string category);
        void ChangeProduct(Product product, decimal price);
        void ChangeStatus(Order order, Statuses status);
    }
}
