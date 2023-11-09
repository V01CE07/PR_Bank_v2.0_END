using PR_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace PR_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SchetVBanke[] users = new SchetVBanke[2];
            //заполнение информации о пользователях

            users[0] = new SchetVBanke(1337, "Zemchenkov Artem", 0);
            users[1] = new SchetVBanke(228, "Kuzmin Nikolay Stanislavovich", 874);
            
            //регистрация нового счета
            Console.WriteLine("Добро пожаловать в банк GOIDA.");
            Console.WriteLine($"Регистрация нового счета:\nВведите номер счета: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ФИО: ");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите сумму для начального пополнения счета: ");
            float sum = float.Parse(Console.ReadLine());
            //добавляем данные нового юзера в массив со всеми юзерами
            users = users.Append(new SchetVBanke(number, fio, sum)).ToArray();
            Console.WriteLine("Новый счет успешно зарегистрирован!");

            Console.ReadKey();
            //Console.WriteLine(users[2].Number);
            //Console.WriteLine(users[2].FIO);
            //Console.WriteLine(users[2].BankSum);

            //выбор операций для пользователя
            int TheEnd = 1;
            while (TheEnd != 0)
            {
                Console.WriteLine("Выберите пользователя (1, 2 или 3): ");
                Console.WriteLine("Чтобы выйти, выберите 5. ");
                int mainUser = (Convert.ToInt32(Console.ReadLine()) - 1);
                SchetVBanke currentUser = users[mainUser];
                switch (mainUser)
                {
                    case 4: Console.WriteLine("Вы вышли из программы"); TheEnd = 0; break;
                }

                currentUser.Operations(currentUser, users);
            }
            
           
        }
    }

}

