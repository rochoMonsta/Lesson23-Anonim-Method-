using System;
using System.Collections.Generic;

namespace AnonimMethod
{
    class Program
    {
        //делегат для анонімного методу.
        public delegate int MyDelegate(int i);
        static void Main(string[] args)
        {
            var person = new Person("Roman", "Cholkan", 19);
            //Підписуємось на подію і одразу прописуємо його обробник за допомогою лямбда виразів.
            person.Started += (sender, data) =>
            {
                Console.WriteLine(sender + "\n\nStarted work at: " + data);
            };
            person.DoWork();

            
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                //Анонімний метод (працює при виклику делегата).
                MyDelegate hendler = delegate (int i)
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };
                //підписуємо наш не анонімний метод на наш делегат.
                hendler += GetQuadro;
                hendler(result);
            }
            
            //В даному випадку реалізація lambdaHendler можна записати двома рівносильними способами.
            MyDelegate lambdaHendler = (i) => /*i * i;*/
            {
                var res = i * i;
                Console.WriteLine("Lambda hendler: " + res);
                return res;
            };
            lambdaHendler(10);


            var lst = new List<int>();
            InputDataToList(lst, 100);

            //передали метод з назвою замість делегату.
            var result1 = Arg(lst, GetQuadro);
            Console.WriteLine("Get Quadro (i * i * i) = " + result1);
            //Передали анонімний метод замість делегату.
            var result2 = Arg(lst, delegate (int i)
            {
                //var r = i * i;
                //Console.WriteLine(r);
                return i * i;
            });
            Console.WriteLine("Get (i * i) = " + result2);
            //Передали лямбда вираз замість делегату.
            var result3 = Arg(lst, x => x + x + x + x);
            Console.WriteLine("Get sum (i + i + i + i) = " + result3);
            Console.ReadLine();
        }
        public static int Arg(List<int> list, MyDelegate myDelegate)
        {
            int result = 0;
            foreach (var item in list)
                result += myDelegate(item);
            return result;
        }
        public static void InputDataToList(List<int> list, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                list.Add(i);
            }
        }
        public static int GetQuadro(int i)
        {
            return i * i * i;
            //var result = i * i * i;
            //Console.WriteLine(result);
            //return result;
        }
    }
}
