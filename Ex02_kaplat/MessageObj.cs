
namespace Ex02_kaplat
{
    internal class MessageObj
    {
        private string message;

        public string Message { get { return message; } set { message = value; } }
        public MessageObj()
        {
        }

        public MessageObj(string message)
        {
            this.message = message;
        }
    }
}
