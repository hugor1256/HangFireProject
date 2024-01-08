namespace HangFireProject.Interfaces
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string mensagem, string dateTime)
        {
            Console.WriteLine(mensagem + "-" + dateTime + "Email enviado com sucesso - " + DateTime.Now.ToLongTimeString());
        }
    }
}

