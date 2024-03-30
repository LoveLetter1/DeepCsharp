using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Chapter3
{
    public interface IPrint
    {
        void Print();
    }
    public class MyPrint : IPrint
    {
        public void Print()
        {
            Console.WriteLine("it's my print.");
        }

        public static List<T> MakeList<T>(T first, T end)
        {
            return new List<T>();
        }

        public static int CompareToDefault<T>(T value) 
            where T:IComparable<T>
        {
            return value.CompareTo(default(T));
        }
    }
    public class Sample<T>where T:IPrint
    {
    }
    public class Gene
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            string[] wrods = Regex.Split(text, @"\W+");
            foreach (string word in wrods)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;;
                }
                else
                {
                    frequencies[word] = 1;
                }
            }

            return frequencies;
        }

        public static double TakeSquareRoot(int x)
        {
            return Math.Sqrt(x);
        }
    }

    public class TypeWithField<T>
    {
        public static string field;

        public static void Print()
        {
            Console.WriteLine(field + ": " + typeof(T).Name);
        }
    }

    public class Outer<T>
    {
        public class Inner<U, V>
        {
            static Inner()
            {
                Console.WriteLine("Outer<{0}>.Inner<{1},{2}>",typeof(T).Name,typeof(U).Name,typeof(V).Name);
            }
            public static void DummyMethod(){}
        }
    }
    public class CountingEnumerable:IEnumerable<int>{
        public IEnumerator<int> GetEnumerator()
        {
            return new CountingEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class CountingEnumerator : IEnumerator<int>
    {
        private int current = -1;
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            current++;
            return current < 10;
        }

        public void Reset()
        {
            current = -1;
        }

        public int Current
        {
            get { return current; }
        }

        object IEnumerator.Current => Current;
    }
    
    public class Program
    {
        public static void Main1()
        {
            string text = "Do you like eggs and ham?I do not like them,Sam-I-am.";
            Dictionary<string, int> result = Gene.CountWords(text);
            foreach (var entry in result)
            {
                Console.WriteLine($"{entry.Key} {entry.Value}");
            }
        }
        public static void Main2()
        {
            List<int> integers = new List<int>();
            integers.Add(1);
            integers.Add(2);
            integers.Add(3);
            integers.Add(4);
            Converter<int, double> converter = Gene.TakeSquareRoot;
            List<double> doubles = new List<double>();
            doubles = integers.ConvertAll<double>(converter);
            foreach (var i in doubles)
            {
                Console.WriteLine(i);
            }
        }
        public static void Main3()
        {
            Sample<MyPrint> sample = new Sample<MyPrint>();
            List<string> list1 = MyPrint.MakeList("a", "b");
            //下面可以推断，忽略<string>
            List<string> list2 = MyPrint.MakeList<string>("a", "b");
            Console.WriteLine(MyPrint.CompareToDefault(10));
        }
        public static void Main4()
        {
            Console.WriteLine(MyPrint.CompareToDefault(10));
            Console.WriteLine(MyPrint.CompareToDefault(-10));
            Console.WriteLine(MyPrint.CompareToDefault("x"));
        }
        public static void Main5()
        {
            //每个封闭类型有一个静态字段
            TypeWithField<int>.field = "First";
            TypeWithField<int>.Print();
            TypeWithField<string>.field = "Second";
            TypeWithField<string>.Print();
            TypeWithField<DateTime>.field = "Thrid";
            TypeWithField<DateTime>.Print();
        }

        public static void Main6()
        {
            Outer<int>.Inner<string,DateTime>.DummyMethod();
            Outer<int>.Inner<int,int>.DummyMethod();
        }

        public static void Main7()
        {
            CountingEnumerable counter = new CountingEnumerable();
            foreach (var x in counter)
            {
                Console.WriteLine(x);
            }
        }
    }
}