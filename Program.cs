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
            int playerHealth = 500;
            int spellRashamonHealth = 100;
            int spellRashamonDamage = 300;
            int spellHuganzakura = 200;
            int spellVoid = 250;
            int spellFireBall = 100;
            int playerSpells = 0;
            int bossHealth = 1000;
            int bossDamage = 100;
            int numberSpellRashamon = 1;
            int numberSpellHuganzakura = 2;
            int numberSpellVoid = 3;
            int numberSpellFireball = 4;
            bool shadowSpiritSummoned = false;
            bool spellVoidUsed = false;
            Console.WriteLine("Вы попали на арену. Приготовьтесь к битве!");
            Console.WriteLine("Изучите ваши заклинания: ");
            Console.WriteLine($"{numberSpellRashamon} - заклинание Рашамон призывыает теневого духа и наносит {spellRashamonDamage} урона, но отнимает {spellRashamonHealth} здоровья");
            Console.WriteLine($"{numberSpellHuganzakura} - заклинание Хуганзара наносит {spellHuganzakura} урона, но может применено только после теневого духа");
            Console.WriteLine($"{numberSpellVoid} - заклинание позволяет скрыться в разломе и восстановить {spellVoid} хп. Можно использовать один раз за бой");
            Console.WriteLine($"{numberSpellFireball} - заклинание Огненный шар наносит {spellFireBall} урона");
            Console.WriteLine("Бой начинается!");

            while (playerHealth > 0 && bossHealth > 0)
            {
                playerSpells = Convert.ToInt32(Console.ReadLine());

                if (playerSpells == numberSpellRashamon)
                {
                    bossHealth -= spellRashamonDamage;
                    Console.WriteLine($"Вы использовали способность Рашамон и  нанесли {spellRashamonDamage} урона");
                    playerHealth -= bossDamage;
                    playerHealth -= spellRashamonHealth;
                    shadowSpiritSummoned = true;
                    Console.WriteLine($"Вы получили урон от Босса {bossDamage} и заклинания теневого духа{spellRashamonHealth}");
                    Console.WriteLine($"{playerHealth} - Ваше здоровье после атаки");
                    Console.WriteLine($"{bossHealth} - Здоровья босса после атаки");
                }
                else if (playerSpells == numberSpellHuganzakura)
                {
                    if (shadowSpiritSummoned)
                    {
                        bossHealth -= spellHuganzakura;
                        Console.WriteLine($"Вы использовали способность Хуганзакуру и нанесли {spellHuganzakura} урона");
                        playerHealth -= bossDamage;
                        Console.WriteLine($"Вы получили {bossDamage} урона от Босса");
                        Console.WriteLine($"Ваше здоворье {playerHealth} после атаки");
                        Console.WriteLine($"Здоровье Босса {bossHealth} после атаки");
                    }
                    else
                    {
                        Console.WriteLine("Сначала вы должны призвать теневого духа");
                    }
                }

                if (playerSpells == numberSpellVoid)
                {
                    if (spellVoidUsed != true)
                    {
                        playerHealth += spellVoid;
                        Console.WriteLine($"Вы восстановили себе {spellVoid} здоровья!");
                        Console.WriteLine("Босс не может вас атаковать пока вы в разломе!");
                        Console.WriteLine($"Ваше здоровье {playerHealth}");
                        Console.WriteLine($"Здоровье босса {bossHealth}");
                        spellVoidUsed = true;
                    }
                    else if (spellVoidUsed == true)
                    {
                        Console.WriteLine("Вы уже использовали это заклинание! Попробуйте другое");
                    }
                }
                
                if (playerSpells == numberSpellFireball)
                {
                    bossHealth -= spellFireBall;
                    Console.WriteLine($"Вы использовали заклинание Огненного шара и нанесли {spellFireBall} урона");
                    playerHealth -= bossDamage;
                    Console.WriteLine($"Босс нанес вам {bossDamage} урона");
                    Console.WriteLine($"после атаки у вас {playerHealth} здоровья");
                    Console.WriteLine($"после атаки у босса {bossHealth} здоровья");
                }
            }

            if (playerHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ничья, оба мертвы");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("Вы победели!");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("Победа Босса!");
            }

            Console.ReadLine();
        }
    }
}
