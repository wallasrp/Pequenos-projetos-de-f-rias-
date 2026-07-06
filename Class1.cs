using System.Collections;
using System.Runtime.Intrinsics.Arm;

class Aluno
{
    public int NDM { get; set; }//numero de matricula
    public char[] Nome { get; set; }
    public int Idade { get; set; }

    public double Nota { get; set; }


    public Aluno(int ndm, char[] nome, int idade, double nota)
    {
        this.NDM = ndm;
        this.Nome = nome;
        this.Idade = idade;
        this.Nota = nota;
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
        List<Aluno> Listadechamada = new List<Aluno>();

        public void AdicionaAluno(Aluno alun)
        {
            Listadechamada.Add(alun);
        }
    }
    public class ControledeAlunos
    {

        private Hashtable alunos = new Hashtable();

        public void AdicionaAluno(Aluno alun)
        {
            alunos.Add(alun.NDM, "nome");
        }

        public void RemoveAluno(int ndm)
        {
            alunos.Remove(ndm);
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



class Program
{
    public static void Main(string[] args)
    {
        int na;
        Escola.ControledeAlunos xaluno = new Escola.ControledeAlunos();

        /*perguntar a quantidade maxima de alunos permitida na escola fazendo um while que enquato o numero maximo for menor que 
         a quantidade a atual se pode entrar mais alunos,a partir da idade saber quantas sala estão disponiveis e se ainda a vaga para ele,
         e usar tratamenro de erro ao usar numero,
        onder so deve escrever o nome dele e onde so se pode usar numero não puder usar letras
        cria o objeto escola e seu numero de sala com x quantidade de sala para cada semestre
        */

        Console.WriteLine("Digite o numero atual de alunos da Escola Municipla Antonio Tereza:");
        na = int.Parse(Console.ReadLine());
        do
        {

            Console.WriteLine("Controle de alunos da Escola Antonio Tereza");
            Console.WriteLine("Escolha uma das opções para poder fazer o controle de alunos da escola:");
            Console.WriteLine("1:Adição de um novo aluno a Escola");
            Console.WriteLine("2:Remoção de um aluno antigo");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {

                Console.WriteLine("Digite o numero de identificação do aluno:");
                int NDM = int.Parse(Console.ReadLine());
                Console.WriteLine("O seu nome:");
                char[] Nome = Console.ReadLine().ToCharArray();
                foreach (char letra in Nome)
                {
                    if (char.IsDigit(letra))
                    {
                        Console.WriteLine("tipo de caracter invalido!");
                    }
                    Console.WriteLine(letra);
                }
                Console.WriteLine("Idade:");
                int Idade = int.Parse(Console.ReadLine());
                if (Idade == 10)
                {
                    //adicionar o aluno em X sala perante sua idade
                }
                Console.WriteLine("e nota:");
                double Nota = double.Parse(Console.ReadLine());

                Aluno x = new Aluno(NDM, Nome, Idade, Nota);
                Escola.ControledeAlunos aluno = new Escola.ControledeAlunos();
                aluno.AdicionaAluno(x);
                Console.WriteLine("Aluno adicionado com sucesso!");
                Escola.QADA++;
            }
            else if (opcao == 2)
            {
                Console.WriteLine("informe o numero de indentificação do aluno que vc deseja remover");
                int ndm = int.Parse(Console.ReadLine());
                xaluno.RemoveAluno(ndm);
                Console.WriteLine("Aluno removido com sucesso!");
                Escola.QADA--;
            }
            if (Escola.QMDA < Escola.QADA)
            {
                Console.WriteLine("não e possivel adicionar mais nenhum aluno");
            }
        } while (Escola.QMDA > Escola.QADA);

        Escola.ControledeAlunos n = new Escola.ControledeAlunos();
        n.LeTodosAlunos();
    }
}