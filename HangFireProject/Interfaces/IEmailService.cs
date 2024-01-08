namespace HangFireProject.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string mensagem, string dateTime);
    }
}

