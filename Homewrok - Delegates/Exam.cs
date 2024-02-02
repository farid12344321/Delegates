using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homewrok___Delegates
{
    internal class Exam
    {
        public string Subject;
        public DateTime DateTime;

        public override string ToString()
        {
            return $"{Subject} - {DateTime.ToString("dd.MM.yyyy")}";
        }
        public List<Exam> Exams = new List<Exam>();

        public IEnumerable<Exam> Search(Predicate<Exam> check)
        {
            foreach (var item in Exams)
            {
                if (check(item)) yield return item;
            }
        }
        public bool Find(Func<Exam,bool> check)
        {
            foreach (var item in Exams)
            {
                if (check(item)) return true;
            }
            return false;
        }
    }
}
