namespace InteriorDesign.Services.Contracts
{
    public interface IContactService
    {
        void SendMail(string mailBody, string email);
    }
}
