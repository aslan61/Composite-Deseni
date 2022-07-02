using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee ahmet=new Employee { Name="Ahmet Aslan"};
            Employee muhammet=new Employee { Name="Muhammet Aslan"};
            ahmet.AddSubordinate(muhammet);
            Employee mustafa = new Employee { Name = "Mustafa Aslan" };
            ahmet.AddSubordinate(mustafa);
            Contractor ali = new Contractor { Name="Ali Arslan"};
            mustafa.AddSubordinate(ali);
            Employee ayşegül = new Employee { Name = "Ayşegül Aslan" };
            muhammet.AddSubordinate(ayşegül);

            Console.WriteLine(ahmet.Name);
            foreach (Employee manager in ahmet)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach(IPerson employe in manager)
                {
                    Console.WriteLine("    {0}", employe.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }   
    }
    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
           return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
