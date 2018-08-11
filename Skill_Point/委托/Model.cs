using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skill_Point
{
    public class Model
    {
    }

   public class Person
   {
       public Person(int id, string name, int age)
       {
           ID = id;
           Name = name;
           Age = age;
       }

       public int ID
       { get; set; }
       public string Name
       { get; set; }
       public int Age
       { get; set; }
   }
}
