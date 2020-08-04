using System;
using System.Collections.Generic;
using System.Text;

namespace P03._Database_After.Contracts
{
    public interface ICourseData
    {
        public IEnumerable<int> CourseIds();

        public IEnumerable<string> CourseNames();

        public IEnumerable<string> Search(string substring);

        public string GetCourseById(int id);
        
    }
}
