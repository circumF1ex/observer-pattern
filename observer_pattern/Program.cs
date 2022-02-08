using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using observer_classes;

namespace observer_main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создать один субъект и два наблюдателя
            ConcreteSubject subject1 = new ConcreteSubject();
            ConcreteObserever obserever1 = new ConcreteObserever();
            ConcreteObserever obserever2 = new ConcreteObserever();
            //Зарегистрировать первого наблюдателя
            subject1.registryObservers(obserever1);
            //Поменять статус первого субъекта (null по умолчанию)
            subject1.setState("Наблюдатель 1 - зарегестриован пользователь 1");
            Console.WriteLine(subject1.getState());
            //Вывести состояние счётчика первого и второго наблюдателей
            Console.WriteLine(obserever1.display());
            Console.WriteLine(obserever2.display());
            //Зарегестрировать второго наблюдателя
            subject1.registryObservers(obserever2);
            //Изменить статус первого субъекта
            subject1.setState("Наблюдатель 1 - Зарегестрирован пользователь 2");
            Console.WriteLine(subject1.getState());
            //Отменить регистрацию второго наблюдателя
            subject1.removeObservers(obserever2);
            //Изменить статус субъекта
            subject1.setState("Наблюдатель 1 - Удалён пользователь 2");
            Console.WriteLine(subject1.getState());
            //Вывести информацию о счётчике первого и второго наблюдателя
            Console.WriteLine(obserever1.display());
            Console.WriteLine(obserever2.display());

            Console.ReadLine();
        }
    }
}
