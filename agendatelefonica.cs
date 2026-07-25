using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
class Pessoa
{
    private string Nome;

    public string nome
    {
        get { return Nome; }
        set { Nome = value; }
    }
    private Guid Id { get; set; } = Guid.NewGuid();

    public Guid id
    {
        get { return Id; }
        set { Id = value; }
    }
    private int Telefone;

    public int telefone
    {
        get { return Telefone; }
        set { Telefone = value; }
    }

    public void InsereDados()
 {

     bool DIC = false;//Dados Iseridos corretamente
     do
     {
         Console.WriteLine("Digite algo para preencher o campo pessoa:");
         Console.WriteLine("Digite o nome da Pessoa:");
         Nome = Console.ReadLine();
     } while (string.IsNullOrWhiteSpace(Nome));
     do
     {
         Console.WriteLine("Digite o numero de telefone da pessoa:");
         DIC = int.TryParse(Console.ReadLine(), out Telefone);

         if (DIC)
         {
             Console.WriteLine($"Telefone cadastrado com sucesso");
         }
         else
         {
             Console.WriteLine("para digitar o telefone por favor insira penas numeros");
         }
     } while (!DIC);
 }

    public void ExibirInformaçao()
    {
        Console.WriteLine($"A pessoa {Nome} com ID {Id} possui o numero de telefone {Telefone}");
    }
}

    class AgendaTelefonica
{
    public List<Pessoa> pessoas = new List<Pessoa>();
    public void AdcionarContato(Pessoa P)
    {
        pessoas.Add(P);
    }
    public void RemoveContato(Pessoa P)
    {
        pessoas.Remove(P);
    }

    public void VerificaContato(Pessoa p, string nome)//serve para verificar se este contao ja existe na agenda telefonica
    {
        foreach (Pessoa x in pessoas)
        {
            if (p.nome == x.nome)
            {
                Console.WriteLine("Pessoa encontrada na lista!");
                break;
            }
            else
            {
                Console.WriteLine("Esta pessoa ainda não existe na lista");
            }
        }
    }
}

enum Num
{
    AdicionarContato = 1,
    RemoverContato = 2,
    VerificaContato = 3,
    Sair = 4
}

class program
{

    static void Main(string[] args)
    {
        int n;
        AgendaTelefonica agenda = new AgendaTelefonica();

        do
        {

            Console.WriteLine("Escolha uma opção para poder fazer modificações na sua agenda telefoinca:");
            Console.WriteLine("1 - Adicionar contato");
            Console.WriteLine("2 - remover contato");
            Console.WriteLine("3 - verificar se contato ja existe na lista atual");
            Console.WriteLine("4 - Sair do programa");
            n = int.Parse(Console.ReadLine());

            Num op = (Num)n;

            if (op == Num.AdicionarContato)
            {
                Pessoa p = new Pessoa();
                p.InsereDados();
                agenda.AdcionarContato(p);
                p.ExibirInformaçao();
                Console.WriteLine("Pessoa adicionada com sucesso!");
            }
            else if (op == Num.RemoverContato)
            {
                if (agenda.pessoas.Count == 0)
                {
                    Console.WriteLine("não foi possivel remover pois não existe nenhuma pessoa na agenda telefonica");
                }
                else
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.InsereDados();
                    Pessoa x = null;
                    foreach (Pessoa p in agenda.pessoas)
                    {
                        if (p.nome == pessoa.nome)
                        {
                            x = p;
                            pessoa.ExibirInformaçao();
                            Console.WriteLine("Pessoa removida com sucesso!");
                            break;//serve para sair da qualquer execução imediatamente
                        }
                        else if (p.nome == null)
                        {
                            Console.WriteLine("A pessoa pela qual você procura não existe na lista!");
                        }

                    }
                    agenda.RemoveContato(x);
                }

            }
            else if (op == Num.VerificaContato)
            {
                if (agenda.pessoas.Count == 0)
                {
                    Console.WriteLine("Não existe pessoa para ser encontrada pois a agenda esta vazia");
                }
                else
                {
                    Pessoa p = new Pessoa();
                    p.InsereDados();
                    agenda.VerificaContato(p, p.nome);
                    p.ExibirInformaçao();
                }
            }
            else if (n != 1 && n != 2 && n != 3 && n != 4)
            {
                Console.WriteLine("Esta opção não existe para ser efetuada");
            }
            else
            {
                Console.WriteLine("você saiu do programa!");
            }
        } while (n != 4);
    }
}
