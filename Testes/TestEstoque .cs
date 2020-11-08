using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Estoque.WebAPI.Models;
using Estoque.WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.WebAPI.Tests
{

    [TestClass]
    public class TestCategoriaController
    {
        [TestMethod]
        public void PostCategoriaAtiva_DeveraRetornarCategoria()
        {
            var controller = new CategoriasController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaAtiva();

            var result = controller.PostCategoria(item);

            Assert.IsNotNull(item.CodCategoria);
         }
        [TestMethod]
        public void PostCategoriaInativa_DeveraRetornarCategoria()
        {
            var controller = new CategoriasController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaInativa();

            var result = controller.PostCategoria(item);

            Assert.AreEqual(result,500) ;
        }

        [TestMethod]
        public void PostProdutoCategoriaAtiva_DeveraRetornarProduto()
        {
            var controller = new CategoriasController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaAtiva();

            var result = controller.PostCategoria(item);

            Assert.IsNotNull(item.CodCategoria);
        }

        [TestMethod]
        public void PostProdutoCategoriaInativa_DeveraRetornarProduto()
        {
            var controller = new CategoriasController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaAtiva();

            var result = controller.PostCategoria(item);

            Assert.IsNotNull(item.CodCategoria);
        }

        Categoria GetDemoCategoriaAtiva()
        {
            return new Categoria() { CodCategoria = 98, NomeCategoria = "Categoria Demo Ativa", Status = 1 };
        }

        Categoria GetDemoCategoriaInativa()
        {
            return new Categoria() { CodCategoria = 99, NomeCategoria = "Categoria Demo Inativa", Status = 0 };
        }







        Produto GetDemoProduct()
        {
            return new Produto() { CodProduto = 3, Nome = "Demo name", Quantidade = 5, CodCategoria = 1 };
        }



    }
}