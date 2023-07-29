using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoOnline.Dominio.Enums;
using CursoOnline.DominioTest.Utils;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática",
                CagaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)980.50,
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CagaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = nomeInvalido,
                CagaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)980.50,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CagaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informática",
                CagaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)980.50,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CagaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-200)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática",
                CagaHoraria = (double)80,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = valorInvalido,
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CagaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Valor inválido");
        }
    }
}
