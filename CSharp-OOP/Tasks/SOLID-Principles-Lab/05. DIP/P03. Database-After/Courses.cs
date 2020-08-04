using P03._Database_After.Contracts;

namespace P03._Database_After
{
    public class Courses
    {
        private ICourseData database;

        public Courses(ICourseData database)
        {
            this.database = database;
        }
        public void PrintAll()
        {
            var courses = database.CourseNames();
            //print courses
        }

        public void PrintIds()
        {
            var courseIds = database.CourseIds();
            //print course ids
        }

        public void PrintById(int id)
        {
            var course = database.GetCourseById(id);
            // print course
        }

        public void Search(string substring)
        {
            var courses = database.Search(substring);
            // print courses
        }
    }
}
