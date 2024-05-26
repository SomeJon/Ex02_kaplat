
namespace Ex02_kaplat
{
    internal class Question2Body
    {
        private int id;
        private int year;
        private string requestId;


        public int Id { get { return id; } set { id = value; } }
        public int Year { get { return year; } set { year = value; } }
        public string RequestId { get { return requestId; } set { requestId = value; } }

        public Question2Body(int id, int year)
        {
            this.id = id;
            this.year = year;
        }

        public Question2Body(int id, int year, string requestId)
        {
            this.id = id;
            this.year = year;
            this.requestId = requestId;
        }
    }
}
