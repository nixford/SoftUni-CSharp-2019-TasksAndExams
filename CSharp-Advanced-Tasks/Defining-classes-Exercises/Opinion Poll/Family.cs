using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.Immutable;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public HashSet<Person> GetOverThirty()
        {
            return this.members
                .OrderBy(p => p.Name)
                .Where(a => a.Age > 30)
                .ToHashSet();           
        }
    }
}
