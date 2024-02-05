using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myHealth = 500;
            int spellRashamonHealth = 100;
            int spellRashamonDamage = 300;
            int spellHuganzakura = 100;
            int spellVoid = 250;
            int spellFireBall = 100;
            int mySpells = 0;
            int bossHealth = 1000;
            int bossDamage = 100;
            bool shadowSpiritSummoned = false;
            Console.WriteLine("Вы попали на арену. Приготовьтесь к битве!");
            Console.WriteLine("Изучите ваши заклинания: ");
            Console.WriteLine($"1 - заклинание Рашамон призывыает теневого духа и наносит {spellRashamonDamage} урона, но отнимает {spellRashamonHealth} здоровья");
            Console.WriteLine($"2 - заклинание Хуганзара наносит {spellHuganzakura} урона, но может применено только после теневого духа");
            Console.WriteLine($"3 - заклинание позволяет скрыться в разломе и восстановить {spellVoid} хп");
            Console.WriteLine($"4 - заклинание Огненный шар наносит {spellFireBall} урона");
            Console.WriteLine("Бой начинается!");

            while (myHealth > 0 && bossHealth > 0)
            {
                mySpells = Convert.ToInt32(Console.ReadLine());

                if (mySpells == 1)
                {
                    bossHealth -= spellRashamonDamage;
                    Console.WriteLine($"Вы использовали способность Рашамон и  нанесли {spellRashamonDamage} урона");
                    myHealth -= bossDamage;
                    myHealth -= spellRashamonHealth;
                    shadowSpiritSummoned = true;
                    Console.WriteLine($"Вы получили урон от Босса {bossDamage} и заклинания теневого духа{spellRashamonHealth}");
                    Console.WriteLine($"{myHealth} - Ваше здоровье после атаки");
                    Console.WriteLine($"{bossHealth} - Здоровья босса после атаки");
                }
                else if (mySpells == 2)
                {
                    if (shadowSpiritSummoned)
                    {
                        bossHealth -= spellHuganzakura;
                        Console.WriteLine($"Вы использовали способность Хуганзакуру и нанесли {spellHuganzakura} урона");
                        myHealth -= bossDamage; 
                        Console.WriteLine($"Вы получили {bossDamage} урона от Босса");
                        Console.WriteLine($"Ваше здоворье {myHealth} после атаки");
                        Console.WriteLine($"Здоровье Босса {bossHealth} после атаки");
                    }
                    else
                    {
                        Console.WriteLine("Сначала вы должны призвать теневого духа");
                    }
                }
                
                if (mySpells == 3)
                {
                    myHealth += spellVoid;
                    Console.WriteLine($"Вы восстановили себе {spellVoid} здоровья!");
                    Console.WriteLine("Босс не может вас атаковать пока вы в разломе!");
                }
                
                if (mySpells == 4)
                {
                    bossHealth -= spellFireBall;
                    Console.WriteLine($"Вы использовали заклинание Огненного шара и нанесли {spellFireBall} урона");
                    myHealth -= bossDamage;
                    Console.WriteLine($"Босс нанес вам {bossDamage} урона");
                    Console.WriteLine($"после атаки у вас {myHealth} здоровья");
                    Console.WriteLine($"после атаки у босса {bossHealth} здоровья");
                }
            }
            
            if (myHealth <= 0 && bossHealth <= 0)
                {
                    Console.WriteLine("Ничья, оба мертвы");
                }
            else if (bossHealth <= 0)
                {
                    Console.WriteLine("Вы победели!");
                }
            else if (myHealth <= 0)
                {
                    Console.WriteLine("Победа Босса!");
                }

            Console.ReadLine();
        }
    }
}
