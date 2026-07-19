using System;

abstract class Personagem
{
    protected string Nome { get; set; }
    protected string Especie { get; set; }
    protected int Idade { get; set; }
    protected double Altura { get; set; }

    public abstract void Caracteristicas();
}

class Warrior : Personagem
{
    private string ADTP { get; set; }// armadura do tipo pesada
    private string ADTL { get; set; }// armadura do tipo Leve

    private List<Arma> armas;

    class Arma
    {
        public string Qiang { get; set; }//(槍 - Lança): Considerada o "Rei das Armas", era a arma principal de militares e rebeldes,
                                         //ideal para estocadas e com um alcance formidável.
        public string Dao { get; set; }//Dao (刀 - Sabre/Facão): Uma espada curva de um só gume, muito mais fácil de dominar do que espadas retas.
                                       //Era a arma de combate corpo a corpo mais comum entre os soldados, semelhante a uma katana primitiva.

        public string Ji { get; set; } //Ji (戟 - Alabarda): Uma evolução da lança, possuía uma cabeça em formato de adaga com lâminas laterais.
                                       //Era excelente para perfurar e desarmar inimigos no meio do caos.

        public string Mushuo { get; set; }//Mashuo (馬槊): Lança gigante e espessa de cavalaria,
                                          //com pontas cônicas extralongas (chegando a 50 cm) capazes de perfurar múltiplas camadas de armadura.
    }

    public override void Caracteristicas()
    {

    }
}

class program
{
    static void Main(string[] args)
    {

    }
}
