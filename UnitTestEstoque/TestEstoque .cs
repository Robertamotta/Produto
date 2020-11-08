using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Estoque.WebAPI.Models;
using Estoque.WebAPI.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Estoque.WebAPI.Tests
{

    [TestClass]
    public class TestCategoriaController
    {
        [TestMethod]
        public async Task IncluiCategoriaAtiva_DeveraRetornarOKAsync()
        {
            var controller = new CategoriaController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaAtiva();

            var result = controller.PostCategoria(item);
            
            Assert.IsInstanceOfType(result, typeof(Categoria));
        }

        [TestMethod]
        public void IncluiCategoriaInativa_DeveraRetornarOK()
        {
            var controller = new CategoriaController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaInativa();

            var result = controller.PostCategoria(item);

            Assert.IsNull(result.AsyncState);

        }

        [TestMethod]
        public void IncluiProdutoCategoriaInativa_DeveraRetornarErro()
        {
            var controller = new ProdutoController(new TestEstoqueWebAPIContext());

            var categoria = GetDemoCategoriaInativa();
            var item = GetDemoProduto();
            item.CodCategoria = categoria.CodCategoria;

            var result = controller.PostProduto(item);

            Assert.IsNull(result.AsyncState);

        }

        [TestMethod]
        public void IncluiProdutoCategoriaAtiva_DeveraRetornarOK()
        {
            var controller = new ProdutoController(new TestEstoqueWebAPIContext());

            var categoria = GetDemoCategoriaAtiva();
            var item = GetDemoProduto();
            item.CodCategoria = categoria.CodCategoria;

            var result = controller.PostProduto(item);

            Assert.IsNull(result.AsyncState);

        }


        Produto GetDemoProduto()
        {
            var controller = new ProdutoController(new TestEstoqueWebAPIContext());
            var result = controller.DeleteProduto(98);
            return new Produto() { CodProduto = 98, Nome = "Produto Demo ", Quantidade = 1 };
        }


        Categoria GetDemoCategoriaAtiva()

        {
            //var controller = new CategoriaController(new TestEstoqueWebAPIContext());
            //var result = controller.DeleteCategoria(98);

            return new Categoria() { CodCategoria = 98, NomeCategoria = "Categoria Demo Ativa", Status = 1 };
        }

        Categoria GetDemoCategoriaInativa()
        {
            var controller = new CategoriaController(new TestEstoqueWebAPIContext());
            var result = controller.DeleteCategoria(99);

            return new Categoria() { CodCategoria = 99, NomeCategoria = "Categoria Demo Inativa", Status = 0 };
        }

        Produto GetDemoProduct()
        {
            return new Produto() { CodProduto = 3, Nome = "Demo name", Quantidade = 5, CodCategoria = 1 };
        }


    }
}