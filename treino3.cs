using System;
using System.Security.AccessControl;


class program
{
    static void Main(string[] args)
    {
        decimal Valor, resultado, quantidadedenotas;

        Console.WriteLine("Digite o um valor que você tem no seu pix para eu dizer o valor em moedas e notas");
        Console.WriteLine("Valor:");
        Valor = int.Parse(Console.ReadLine());



        resultado = Valor % 200;
        quantidadedenotas = Valor / 200;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 200");
        quantidadedenotas = resultado / 100;
        resultado = resultado % 100;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 100");
        quantidadedenotas = resultado / 50;
        resultado = resultado % 50;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 50");
        quantidadedenotas = resultado / 20;
        resultado = resultado % 20;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 20");
        quantidadedenotas = resultado / 10;
        resultado = resultado % 10;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 10");
        quantidadedenotas = resultado / 5;
        resultado = resultado % 5;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 5");
        quantidadedenotas = resultado / 2;
        resultado = resultado % 2;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 2");
        quantidadedenotas = resultado / 1;
        resultado = resultado % 1;
        Console.WriteLine($"Voce tem {quantidadedenotas} notas de 1");

    }
}
