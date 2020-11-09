using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Estoque.WebAPI.Models

namespace Produto.Test
{
    [TestClass]
    public class UnitTest1
    {
        // [metodo]_[condicao]_[resultadoEsperado]

        [TestMethod]
        public void NomeUusuario_EnviarStringTamanhoMenorQueTres_ErroValidacao()
        {  
            //Arrange
            Usuario usuario = new Usuario();
            usuario.NomeUsuario = 'A';
            //Act
            bool ModeloValido = usuario.ModelValidationNode;
            //Assert
            Assert(ModeloValido);

        }
    }
}
