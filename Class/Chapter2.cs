using System;
namespace Chapter2
{
    delegate void StringProcessor(string input);

    public class StaticMethods
    {
        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
    public class InstanceMethods
    {
        StringProcessor proc1;
        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public InstanceMethods()
        {
            proc1 = new StringProcessor(this.Print);
        }
    }

    public class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public void Say(string message)
        {
            Console.WriteLine($"{this.name} says: {message}");
        }
    }

    public class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine($"({note})");
        } 
    }
    
    public class Chapter2
    {
        public static void Main1()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor proc1, proc2, proc3;
            proc1 = jon.Say;
            proc2 = tom.Say;
            proc3 = Background.Note;
            proc1.Invoke("Hello,son");
            proc2.Invoke("Hello,daddy");
            proc3.Invoke("An airplane files past.");
            //boxing
            object o = jon;
            Person j = (Person)o;
            Console.WriteLine(o.GetType());
        }
    }
}