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
        public void IncluiCategoriaAtiva_DeveraRetornarCategoria()
        {
            var controller = new CategoriaController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaAtiva();

            var result = controller.PostCategoria(item);

            Assert.IsNotNull(item.CodCategoria);
         }

        [TestMethod]
        public void IncluiCategoriaInativa_DeveraRetornarCategoria()
        {
            var controller = new CategoriaController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaInativa();

            var result = controller.PostCategoria(item);

            Assert.AreEqual(201,result);
        }

        [TestMethod]
        public void IncluiProdutoCategoriaInativa_DeveraRetornarErro()
        {
            var controller = new ProdutoController(new TestEstoqueWebAPIContext());

            var categoria = GetDemoCategoriaInativa();
            var item = GetDemoProduto();
            item.CodCategoria = categoria.CodCategoria;

            var result = controller.PostProduto(item);

            Assert.AreEqual(201, result);
        }

        [TestMethod]
        public void IncluiProdutoCategoriaAtiva_DeveraRetornarProduto()
        {
            var controller = new ProdutoController(new TestEstoqueWebAPIContext());

            var categoria = GetDemoCategoriaAtiva();
            var item = GetDemoProduto();
            item.CodCategoria = categoria.CodCategoria;

            var result = controller.PostProduto(item);

            Assert.AreEqual(201, result);
        }
  

        Produto GetDemoProduto()
        {   
            return new Produto() { CodProduto = 98, Nome = "Produto Demo ", Quantidade = 1 };
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