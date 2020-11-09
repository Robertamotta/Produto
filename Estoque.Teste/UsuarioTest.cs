using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Estoque.WebAPI.Models;

namespace UsuarioTest
{
    [TestClass]
    public class UsuarioTest
    {
        private const String V = "Ab";
        // [metodo]_[condicao]_[resultadoEsperado]

        Usuario GetDemoUser()
        {
            return new Usuario() { IdUsuario = 65, NomeUsuario = "Demo name", SenhaUsuario = "TesteSenha", StatusUsuario = 1 };
        }

        //Em Models.Usuario foi definido que a string para Nome de Usuario deveria ter um tamanho mínimo de 3 e maximo de 40.
        [TestMethod]
        public void NomeUusuario_EnviarStringTamanhoMaiorQueTres_ok()
        {
            //Arrange
            Usuario usuario = GetDemoUser();
            string ResultadoEsperado = "Roberta";
            usuario.NomeUsuario = ResultadoEsperado;
            //Act
            string ResultadoAtual = usuario.NomeValido;
            //Assert
            Assert.AreEqual(ResultadoAtual, ResultadoEsperado);

        }
        //Em Models.Usuario foi definido que o Status deveria pertecencer a um range de 0 a 1.

        [TestMethod]
        public void StatusUusuario_Enviar6_ErroValidacao()
        {
            //Arrange
            Usuario usuario = new Usuario();

             usuario.StatusUsuario = 6;
            //Act
           
            //Assert
            Assert.IsTrue(usuario.StatusValido());


        }
    }
}
