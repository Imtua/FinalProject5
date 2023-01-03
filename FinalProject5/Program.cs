namespace FinalProject5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = TakeTuple();
            ShowTuple(values);

        }

        static void ShowTuple((string FirstName, string SecondName, int Age, string[] Pets, string[] Colors) User)
         {
            Console.WriteLine($"\nИмя: {User.FirstName}, фамилия: {User.SecondName}, возвраст: {User.Age}");
            if (User.Pets !=null)
            {
                Console.WriteLine("Список ваших питомцев");
                ShowArray(User.Pets); 
            }

            if (User.Colors !=null)
            {
                Console.WriteLine("Вы введи следующие цвета");
                ShowArray(User.Colors);
            }

            /* 
           Дальше идёт код вызываемых функций, сделал их внутри главного вызываемого метода ShowTuple,
           так как за его пределами они не применяются 
           */

            static void ShowArray(string[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"{i+1}-й: {arr[i]}");
                }
            }

         }




        static (string FirstName, string SecondName, int Age, string[] Pets, string[] Colors)
            TakeTuple()
        {
            (string firstName, string secondName, int Age, string[] Pets, string[] Colors) User;

            Console.WriteLine("Введите имя:");
            User.firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            User.secondName = Console.ReadLine();

            int tempAge;
            do
            {
                Console.WriteLine("Введите ваш возраст");
                tempAge = TakeNum();

            } while (tempAge <= 0);

            User.Age = tempAge;


            Console.WriteLine("Введите количество питомцев:");
            int petsLenght = TakeNum();
            User.Pets = FillArray(petsLenght);

            Console.WriteLine("Введите ваши любимые цвета,\nЕсли не хотите, введите 0:");
            int colorsSize = TakeNum();
            User.Colors = FillArray(colorsSize);

            return User;

            /* 
            Дальше идёт код вызываемых функций, сделал их внутри главного вызываемого метода TakeTuple,
            так как за его пределами они не применяются 
            */

            static int TakeNum()
            {
                string temp;
                while (true)
                {
                    temp = Console.ReadLine();

                    if (int.TryParse(temp, out int result))
                    {
                        return result;
                    }

                    Console.WriteLine("Попробуйте снова!");
                }

            }
            static string[] FillArray(int length)
            {
                if (length <= 0)
                {
                    return null;
                }

                string[] values = new string[length];
                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($"Введите {i + 1}-е значение");
                    values[i] = Console.ReadLine();
                }
                return values;
            }



        }
    }
}
