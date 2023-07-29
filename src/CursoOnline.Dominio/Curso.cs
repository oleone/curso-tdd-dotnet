using CursoOnline.Dominio.Enums;

namespace CursoOnline.DominioTest.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CagaHoraria { get; private set; }
        public PublicoAlvoEnum PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvoEnum publicoAlvo, double valor)
        {

            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome inválido");

            if(cargaHoraria < 1) throw new ArgumentException("Carga horária inválida");

            if (valor < 1) throw new ArgumentException("Valor inválido");

            Nome = nome;
            CagaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }
    }
}