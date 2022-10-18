using System;

namespace Jogo
{
    public abstract class Entity
    {
        public string Name { get; protected set; }
        public int Life { get; protected set; }
        public int Damage { get; protected set; }
        public Weapon Weapon { get; set; }

        public abstract void Attack(Entity target);
        public abstract void ReciveDamage(int damage);
    }


    public abstract class Weapon
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; } 
    }


    public class Edjalma : Entity
    {
        
        public int Shield { get; private set;}

        public Edjalma()
        {
            this.Life = 180;
            this.Damage = 10;
            this.Shield = 40;
        }

        public override void Attack(Entity target)
        {
            int damage = this.Damage / 2 
                + this.Weapon.Damage * 2;

            target.ReciveDamage(damage);
        }

        public override void ReciveDamage(int damage)
        {
            if (this.Shield > 0)
            {
                if (this.Shield > damage)
                {
                    this.Shield = 0;
                    return;
                }
                else
                {
                    damage -= this.Shield;
                    this.Shield = 0;
                }
            }
            this.Life -= damage;
        }
    }


    public class Gustavo : Entity
    {
        public Gustavo()
        {
            this.Damage = 20;
            this.Life = 80;
        }

        public override void Attack(Entity target)
        {
            int damage = 2 * (Weapon?.Damage ?? 0) + 2 * this.Damage;
            target.ReciveDamage(damage);
        }

        public override void ReciveDamage(int damage)
        {
            this.Life -= 2 * damage;
        }
    }


    public class Sword : Weapon
    {
        public Sword()
        {
            this.Name = "Espada";
            this.Damage = 5;
        }
    }

    public class LongSword : Weapon
    {
        public LongSword()
        {
            this.Name = "Espada Longa";
            this.Damage = 10;
        }
    }
}


//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             Edjalma ed = new Edjalma();
//             Gustavo gust= new Gustavo();

//             Sword sword = new Sword();
//             gust.Weapon = sword;

//             gust.Attack(ed);

//             Console.Write(ed.Life);

//         }
//     }