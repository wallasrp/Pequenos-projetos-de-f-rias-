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
        get { return NDM; }
        set { NDM = value; }
    }
    private string Nome;
    public string nome
    {
        get { return Nome; }
        set { Nome = value; }
    }
    private int Idade;
    public int idade
    {
        get { return Idade; }
        set { Idade = value; }
    }
    private double Nota;
    public double nota
    {
        get { return Nota; }
        set { Nota = value; }
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

        NDM = new Guid();
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
        Dictionary<Guid, Aluno> Listadechamada = new Dictionary<Guid, Aluno>();
        /* ponto importante!com dictionary não e necessario percorrer todo aquele processo de percorrer
        a lista e etc,o proprio dictionary ja tem seus comando que vão direto no que se esta procurando*/
        public void AdicionaAluno(Guid id,Aluno aluno)
        {
            Listadechamada.Add(id,aluno);
        }

        public void AdicionaRemove(Guid Al)
        {
            if (Listadechamada.ContainsKey(Al))
            {
                Console.WriteLine("Aluno removido com sucesso!");
                Listadechamada.Remove(Al);
            }
            else
            {
                Console.WriteLine("Aluno não encontrado para executar remoção");
            }
        }

        public bool VerificaAluno(Guid x)
        {
            Console.WriteLine("Faz chamada");

            if (Listadechamada.Count == 0)
            {
                Console.WriteLine("Não ha nenhum aluno nesta lista ainda");
                return false;
            }
            else if (Listadechamada.ContainsKey(x))
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

        public void controle()
        {
            int na, opcao;
            Escola.ControledeAlunos xaluno = new Escola.ControledeAlunos();
            Escola.SaladeAula sala = new Escola.SaladeAula();
            Aluno aluno = new Aluno();

            Console.WriteLine("Digite o numero atual de alunos da Escola Municipla Antonio Tereza:");
            na = int.Parse(Console.ReadLine());
            do
            {

                Console.WriteLine("Controle de alunos da Escola Antonio Tereza");
                Console.WriteLine("Escolha uma das opções para poder fazer o controle de alunos da escola:");
                Console.WriteLine("1:Adição de um novo aluno a Escola");
                Console.WriteLine("2:Remoção de um aluno antigo");
                opcao = int.Parse(Console.ReadLine());

                OpcaoEscolha op = (OpcaoEscolha)opcao;

                if (op == OpcaoEscolha.Ad)
                {
                    aluno.InsereDado();
                    xaluno.AdicionaAluno(aluno.ndm, aluno);
                    sala.AdicionaAluno(aluno.ndm, aluno);
                    Console.WriteLine("Aluno adicionado com sucesso!");
                    Escola.QADA++;
                }
                else if (op == OpcaoEscolha.Rm)
                {
                    xaluno.RemoveAluno(aluno.ndm);
                    sala.AdicionaRemove(aluno.ndm);
                    Escola.QADA--;
                }
                if (Escola.QMDA < Escola.QADA)
                {
                    Console.WriteLine("não e possivel adicionar mais nenhum aluno");
                }
            } while (Escola.QMDA > Escola.QADA);
            xaluno.LeTodosAlunos();
        }

        public void AdicionaAluno(Guid id,Aluno N)
        {
            alunos.Add(id,N);
        }

        public void RemoveAluno(Guid identificador)
        {
            if (alunos.ContainsKey(identificador))
            {
                Console.WriteLine("Aluno removido com sucesso!");
                alunos.Remove(identificador);
            }

            else
            {
                Console.WriteLine("aluno não encontrado");
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
        int na, opcao;
        Escola.ControledeAlunos xaluno = new Escola.ControledeAlunos();
        Escola.SaladeAula sala = new Escola.SaladeAula();

        xaluno.controle();

    }
}
