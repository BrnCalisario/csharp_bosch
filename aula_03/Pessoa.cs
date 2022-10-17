using System;

public struct Pessoa
{
    public Pessoa(string nome, string senha)
    {
        this.Nome = nome;
        this.Senha = senha;
        this.Saldo = 0;
        this.DataNascimento = DateTime.Now;
        this.cpf = 10;
    }


    //getter e setter enxutos
    public string Nome { get; set; }

    public decimal Saldo { get; set;}

    public DateTime DataNascimento { get; set; }

    public string Senha{ get; set;}

    // getters e setters com métodos úteis
    private long cpf; //campo
    public string CPF  //propriedade
    {
        get { 
            return cpf.ToString("000.000.000-00"); 
            }
        set { 
            cpf = long.Parse(
                value.Replace(".", "")
                    .Replace("-", ""));
        }
    }


}