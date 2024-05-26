
namespace Ex02_kaplat
{
    internal class Question3Body
    {
        private int id;
        private int year;


        public int Id { get { return id; } set { id = value; } }
        public int Year { get { return year; } set { year = value; } }

        public Question3Body(int id, int year)
        {
            this.id = id;
            this.year = year;
        }
    }
}
