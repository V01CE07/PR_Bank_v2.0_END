using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PR_2
{
    internal class SchetVBanke
    {   //объявляем наименование переменных
        public int Number { get; set; }
        public string FIO { get; set; }
        public float BankSum { get; set; }

        public SchetVBanke(int number, string fio, float banksum)
        {
            this.Number = number;
            this.FIO = fio;
            this.BankSum = banksum;
        }
        //создаем метод, куда вводим информацию

        //создаем метод для вывода информации пользователю
        public void Out()
        {
            Console.WriteLine($"- - - - - - - - - - - -\nНомер счета: {Number}\n- - - - - - - - - - - -\nФИО клиента: {FIO}\n- - - - - - - - - - - -\nСумма на счету: {BankSum}\n- - - - - - - - - - - -");
        }
        //создаем метод для пополнения счета
        public void Dob()
        {
            Console.WriteLine($" \nВведите сумму, которую вы хотите положить на счет:");
            float SumDob = float.Parse(Console.ReadLine());
            if (SumDob < 0) //проверка на отрицательное число
            {
                Console.WriteLine("Введено неверное значение");
            }
            else
            {
                BankSum += SumDob;
                Console.WriteLine($"- - - - - - - - - - - -\nВы положили на счет {SumDob}\n- - - - - - - - - - - -\n ");
            }


        }
        //метод для снятия денег со счета
        public void Umen()
        {
            Console.WriteLine($" \nВведите сумму, которую вы хотите снять со счета: \n");
            float SumUmen = float.Parse(Console.ReadLine());
            if (SumUmen < 0) //проверка на отрицательное число
            {
                Console.WriteLine("Введено неверное значение");
            }
            else if (SumUmen > BankSum) //проверка на превышение баланса для снятия
            {
                Console.WriteLine("Вы не можете снять количество денег, превыщающие значение вашего счета");

            }
            else
            {
                BankSum -= SumUmen;
                Console.WriteLine($"- - - - - - - - - - - -\nВы сняли со счета {SumUmen}\n- - - - - - - - - - - -\n ");
            }
        }
        //метод для обнуления баланса счета
        public void Obnul()
        {
            BankSum -= BankSum;
            Console.WriteLine($"- - - - - - - - - - - -\nВы сняли все деньги с вашего счета\n- - - - - - - - - - - -\n ");
        }
        //метод перевода от одного счета до другого
        public void Perevod(SchetVBanke currentUser, SchetVBanke[] users)
        {
            Console.WriteLine($" \n- - - - - - - - - - - -\nВведите сумму для перевода: ");
            float PerevodSum = float.Parse(Console.ReadLine());
            Console.WriteLine($"- - - - - - - - - - - -\n ");
            Console.WriteLine($" \n- - - - - - - - - - - -\nВведите номер счета для перевода: ");
            int perevodNumber = Convert.ToInt32(Console.ReadLine());

            SchetVBanke perevodUser = null;
            foreach (SchetVBanke user in users)
            {
                if (user.Number == perevodNumber)
                {
                    perevodUser = user;
                    break;
                }
            }

            if (perevodUser == null) //проверка на нахождения номера счета для перевода
            {
                Console.WriteLine("Получатель с таким номером счета не найден или вы переводите деньги самому себе.");
                return;
            }

            if (BankSum < PerevodSum) //проверка на превышение баланса
            {
                Console.WriteLine("Вы не можете перевести сумму, которая превышает ваш баланс на счету");
                return;
            }
            if (PerevodSum < 0) //проверка на отрицательное число
            {
                Console.WriteLine("Вы не можете перевести отрицательную сумму");
                return;
            }
            currentUser.BankSum -= PerevodSum;
            perevodUser.BankSum += PerevodSum;
            Console.WriteLine($"Вы перевели на счет {perevodNumber} сумму: {PerevodSum}");
        }
        //главный метод для взаимодействия пользователя с другими функциями программы
        public void Operations(SchetVBanke currentUser, SchetVBanke[] users)
        {
            int TheEnd = 1; //переменная для верной работы цикла, чтобы он не заканчивался каждый раз и пользователь мог выполнить бесконечное множество операций
            while (TheEnd != 0)
            {
                //цикл для работы с другими методами программы
                Console.WriteLine($"Приветствую тебя, {FIO}\n0 - Выход\n1 - Вывести информацию о вашем счете\n2 - Положить деньги на счет\n3 - Снять деньги со счета\n4 - Обнулить счет\n5 - Перевод на другой счет");
                string UserAnswer = Console.ReadLine(); //переменная бля выбора пользователем нужной функции. используется тип string, чтобы при неверном запросе программа не вылетала с ошибкой
                switch (UserAnswer)
                {
                    //"переключатель" между методами, в зависимости от запроса пользователя
                    case "0": Console.WriteLine("Вы вышли из программы"); TheEnd = 0; break;
                    case "1": Out(); break;
                    case "2": Dob(); break;
                    case "3": Umen(); break;
                    case "4": Obnul(); break;
                    case "5": Perevod(currentUser, users); break;
                    default: Console.WriteLine("ОШИБКА"); break;
                }
            }
        }
    }
}
