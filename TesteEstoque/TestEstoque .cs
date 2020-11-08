using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
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

            var result =  controller.PostCategoria(item);

            Assert.IsNotNull(item.CodCategoria);
         }
        [TestMethod]
        public void PostCategoriaInativa_DeveraRetornarCategoria()
        {
            var controller = new CategoriasController(new TestEstoqueWebAPIContext());

            var item = GetDemoCategoriaInativa();

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


    }
    [TestClass]
    public class TestProdutosController
    {
        [TestMethod]
        public void PostProduct_CategoriaAtiva()
        {
            var controller = new ProdutosController(new TestEstoqueWebAPIContext());

            var item = GetDemoProduct();
            var categoriaativa = GetDemoCategoriaAtiva();
            item.CodCategoria = categoriaativa.CodCategoria;

            var result = controller.PostProduto(item);

            var redirectToActionResult = Assert.IsNotInstanceOfType<RedirectToActionResult>(result);
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();

            Assert.IsNotNull(item.CodProduto);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var controller = new ProdutosController(new TestEstoqueWebAPIContext());

            var item = GetDemoProduct();

            var result = controller.PutProduto(item.CodProduto, item);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.Status);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var controller = new ProdutosController(new TestEstoqueWebAPIContext());

            var badresult = controller.PutProduto(999, GetDemoProduct());
            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }



        Produto GetDemoProduct()
        {
            return new Produto() { CodProduto = 3, Nome = "Demo name", Quantidade = 5,CodCategoria = 1 };
        }

        Categoria GetDemoCategoriaAtiva()
        {
            return new Categoria() { CodCategoria = 98, NomeCategoria = "Categoria Demo Ativa", Status = 1 };
        }

        Categoria GetDemoCategoriaInativa()
        {
            return new Categoria() { CodCategoria = 99, NomeCategoria = "Categoria Demo Inativa", Status = 0 };
        }



    }
}