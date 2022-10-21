using System;

namespace JogoDaMoeda
{
    public abstract class Player
    {
        protected bool decision = true;
        public int Moedas { get; set; } = 3;
        public abstract bool Decide();
        public virtual void Reset() {}
        public virtual void Recebe(bool resposta) {}
    }  

    public class Colaborador : Player
    {   
        public override bool Decide() => true;
    }

    public class Trapaceiro : Player
    {
        public override bool Decide() => false;
    }

    public class Copiador : Player
    {
        private bool hisLastMove { get; set; } = true;

        public override bool Decide() => hisLastMove;
        public override void Recebe(bool resposta) => this.hisLastMove = resposta;
        public override void Reset() { hisLastMove = true; }
        
    }

    public class Rancoroso : Player
    {

        public override bool Decide() => this.decision;

        public override void Recebe(bool resposta)
        {
            if (!resposta) { this.decision = false; }
        }

        public override void Reset() { decision = true; }
    }

    public class World
    {
        public Player[] Jogadores = new Player[]
        { 
            new Colaborador(), new Colaborador(), new Colaborador(),
            new Trapaceiro(), new Trapaceiro(), new Trapaceiro(),
            new Rancoroso(), new Rancoroso(), new Rancoroso(),
            new Copiador(), new Copiador(), new Copiador()
        };

        public World()
        {
            this.Total = Jogadores.Length * 3;
        }

        public int Falidos { get; set; } = 0;
        public int Total { get; set; } 
        public int RoundQuant = 3;

        public void Game()
        {
            Random rnd = new Random();
            Player p1, p2;
            
            for (int i = 0; i < 50; i++)
            {
                do
                {
                    p1 = Jogadores[rnd.Next(0, Jogadores.Length)];
                    p2 = Jogadores[rnd.Next(0, Jogadores.Length)];
                } while ((p1.Moedas < 0 || p2.Moedas < 0) || p1 == p2);
                
                if (p1.Moedas > 0 && p2.Moedas > 0)
                {
                    p1.Reset();
                    p2.Reset();
                    for (int j = 0; j < RoundQuant; j++)
                    {
                        Console.WriteLine(p1 + " " + p1.Moedas);
                        Console.WriteLine(p2 + " " + p2.Moedas + "\n" + Total);
                        
                        Round(p1, p2);

                        Console.WriteLine(p1 + " " + p1.Moedas);
                        Console.WriteLine(p2 + " " + p2.Moedas+ "\n" + Total);
                    }
                }
            
            }
            Console.WriteLine("Falidos: " + Falidos);
            

        }

        public void Round(Player p1, Player p2)
        {
            var r1 = p1.Decide();
            var r2 = p2.Decide();

            if (p1.Moedas == 0 || p2.Moedas == 0) { return; }

            if (r1) { p1.Moedas--;}
            if (r2) { p2.Moedas--;}

            if (r1 && r2)
            {
                p1.Moedas += 2;
                p2.Moedas += 2;
                Total += 2;
            }
            else if (r1 || r2)
            {
                if (r1) { p2.Moedas += 3;}
                else { p1.Moedas += 3; }
                Total += 2;
            }

            if (p1.Moedas == 0) { this.Falidos++; }
            if (p2.Moedas == 0) { this.Falidos++;}

            p1.Recebe(r2);
            p2.Recebe(r1);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            World mundo = new World();
            mundo.Game();
        }
    }

}


