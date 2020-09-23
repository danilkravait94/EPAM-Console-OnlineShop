namespace EShop.Roles.Interfaces
{
    interface IRegisteredUser
    {
        void SetGetToOrder(Order order);
        void CancelOrder(Order order);
        void ChangeInfo(string name,string lastname);
        void ChangeInfo(string password);
        void ChangeInfo(decimal money);
        void ChangeEmail(string email);

    }
}
