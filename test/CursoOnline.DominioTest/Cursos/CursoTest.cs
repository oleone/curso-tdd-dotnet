using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoOnline.Dominio.Enums;
using CursoOnline.DominioTest.Utils;
using Xunit.Abstractions;
using System.Drawing;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvoEnum _publicoAlvo;
        private readonly double _valor;

        public CursoTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Constructor is running...");

            _nome = "Informática";
            _cargaHoraria = (double)80;
            _publicoAlvo = PublicoAlvoEnum.Estudante;
            _valor = (double)980.50;
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CagaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
            };

            var curso = new Curso(_nome, _cargaHoraria, _publicoAlvo, _valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, _cargaHoraria, _publicoAlvo, _valor))
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => new Curso(_nome, cargaHorariaInvalida, _publicoAlvo, _valor))
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-200)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _cargaHoraria, _publicoAlvo, valorInvalido))
                .ComMensagem("Valor inválido");
        }
    }
}
