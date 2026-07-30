using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections;
using System.ComponentModel.Design;


//Ideia pricipal desse codigo aplicar classes aninhadas para aprendizado,não so classe aninhada com tambem todo o que foi estudado em POO
class Aluno
{
    private Guid NDM;
    public Guid ndm
    {
        set { ndm = new Guid(); }
    }
    public string Nome;
    public string nome
    {
        get { return nome; }
        set { nome = value; }
    }
    public int Idade;
    public int idade
    {
        get { return idade; }
        set { idade = value; }
    }
    public double Nota;
    public double nota
    {
        get { return nota; }
        set { nota = value; }
    }

    public void InsereDado()
    {
        do
        {
            Console.WriteLine("Digite o nome do aluno");
            Nome = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(Nome));

        bool v = false;

        do
        {
            Console.WriteLine("Digite a idade do aluno:");
            v = int.TryParse(Console.ReadLine(), out Idade);

            if (v)
            {
                Console.WriteLine("Idade valida.");
            }
            else
            {
                Console.WriteLine("Idade invalida");
            }
        } while (!v);
    }

    public void MostraAluno()
    {
        Console.WriteLine($"o Nome do aluno e {Nome},seu numero de matricula e {NDM} e sua idade e {Idade} e sua nota {Nota}");
    }
}

class Escola
{
    public static int QMDA = 700;// quantidade maxima de alunos que a escola suporta
    public static int QADA = 0;

    public class SaladeAula
    {
        public Aluno Aluno { get; set; }
        public int QDNS = 35;// Qauntidade de carteiras disponiveis por sala
        Dictionary<string, int> Listadechamada = new Dictionary<string, int>();
        public void AdicionaAluno(string nome,int idade)
        {
            Listadechamada.Add(nome,idade);
        }

        public void AdicionaRemove(string x,int n)
        {
            Listadechamada.Remove(x,out n);
        }

        public bool VerificaAluno(int x)
        {
            Console.WriteLine("Faz chamada");

            if (Listadechamada.Count == 0)
            {
                Console.WriteLine("Não ha nenhum aluno nesta lista ainda");
                return false;
            }
            else if (Listadechamada.ContainsValue(x))
            {
                Console.WriteLine("O aluno veio a aula");
                return true;
            }
            else
            {
                Console.WriteLine("O aluno falou a aula");
                return false;
            }
        }
    }
    public class ControledeAlunos
    {

        Hashtable alunos = new Hashtable();

        public void AdicionaAluno(string n,int idade)
        {
            alunos.Add(n,idade);
        }

        public void RemoveAluno(string nome)
        {
            foreach(string n in alunos.Keys)
            {
                if (n == nome)
                {
                    alunos.Remove(nome);
                    break;
                }
                else
                {
                    Console.WriteLine("aluno não encontrado");
                }
            }
        }

        public void LeTodosAlunos()
        {
            foreach (Aluno naluno in alunos)
            {
                naluno.MostraAluno();
            }
        }
    }
}

enum OpcaoEscolha
{
    Ad = 1,
    Rm = 2
}



class Program
{
    public static void Main(string[] args)
    {
        int na,opcao;
        Escola.ControledeAlunos xaluno = new Escola.ControledeAlunos();
        Escola.SaladeAula sala = new Escola.SaladeAula();

        Console.WriteLine("Digite o numero atual de alunos da Escola Municipla Antonio Tereza:");
        na = int.Parse(Console.ReadLine());
        do
        {

            Console.WriteLine("Controle de alunos da Escola Antonio Tereza");
            Console.WriteLine("Escolha uma das opções para poder fazer o controle de alunos da escola:");
            Console.WriteLine("1:Adição de um novo aluno a Escola");
            Console.WriteLine("2:Remoção de um aluno antigo");
            opcao = int.Parse(Console.ReadLine());

            OpcaoEscolha op = (OpcaoEscolha) opcao;

            if (op == OpcaoEscolha.Ad)
            {
                Aluno x = new Aluno();
                x.InsereDado();
                xaluno.AdicionaAluno(x.Nome,x.Idade);
                sala.AdicionaAluno(x.Nome, x.Idade);
                Console.WriteLine("Aluno adicionado com sucesso!");
                Escola.QADA++;
            }
            else if (op == OpcaoEscolha.Rm)
            {
                Console.WriteLine("informe o nome do aluno que vc deseja remover");
                string nome = Console.ReadLine();
                Console.WriteLine("informe o nome do aluno que vc deseja remover");
                int idade = int.Parse(Console.ReadLine());
                xaluno.RemoveAluno(nome);
                sala.AdicionaRemove(nome,idade);
                Console.WriteLine("Aluno removido com sucesso!");
                Escola.QADA--;
            }
            if (Escola.QMDA < Escola.QADA)
            {
                Console.WriteLine("não e possivel adicionar mais nenhum aluno");
            }
        } while (Escola.QMDA > Escola.QADA);
        xaluno.LeTodosAlunos();
    }
}
