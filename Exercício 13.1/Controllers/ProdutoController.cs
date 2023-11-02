using Exercício_13._1.DAO;
using Exercício_13._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Exercício_13._1.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ProdutoDAO dao = new ProdutoDAO();
            List<ProdutoViewModel> lista = dao.Listagem();
            return View(lista);
        }

        private void ValidaDados(ProdutoViewModel produto, string operacao)
        {
            ModelState.Clear();
            ProdutoDAO dao = new ProdutoDAO();
            if (operacao == "I" && dao.Consulta(produto.Id) != null)
                ModelState.AddModelError("IdProduto", "Código já está em uso.");
            if (operacao == "A" && dao.Consulta(produto.Id) == null)
                ModelState.AddModelError("IdProduto", "Aluno não existe.");
            if (produto.Id <= 0)
                ModelState.AddModelError("IdProduto", "Id inválido!");

            if (string.IsNullOrEmpty(produto.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome do produto.");
            if (produto.IdCategoria <= 0)
                ModelState.AddModelError("IdCategoria", "Informe o código da categoria.");
            if (produto. <= 0)
                ModelState.AddModelError("IdCategoria", "Informe o código da categoria.");
            if (produto.ValorLocacao < 0 || produto.ValorLocacao == null)
                ModelState.AddModelError("ValorLocacao", "Campo obrigatório.");
            if (produto.DataAquisicao > DateTime.Now)
                ModelState.AddModelError("DataAquisicao", "Data inválida!");
        }

        public IActionResult Create()
        {
            try
            {
                ViewBag.Operacao = "I";
                ProdutoViewModel produto = new ProdutoViewModel();
                produto.DataCriacaoProduto = DateTime.Now;
                ProdutoDAO dao = new ProdutoDAO();
                produto.Id = dao.ProximoId();
                PreparaListaCategoriasParaCombo();
                return View("Form", produto);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Salvar(ProdutoViewModel produto, string Operacao)
        {
            try
            {
                ValidaDados(produto, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    PreparaListaCategoriasParaCombo();
                    return View("Form", produto);
                }
                else
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    if (Operacao == "I")
                        dao.Insert(produto);
                    else
                        dao.Update(produto);
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Editar(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                ProdutoDAO dao = new ProdutoDAO();
                ProdutoViewModel produto = dao.Consulta(id);
                PreparaListaCategoriasParaCombo();

                if (produto == null)
                    return RedirectToAction("Index");
                else
                    return View("Form", produto);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                ProdutoDAO dao = new ProdutoDAO();
                dao.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        private void PreparaListaCategoriasParaCombo()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            var categorias = categoriaDAO.ListaCategorias();
            List<SelectListItem> listaCategorias = new List<SelectListItem>();

            listaCategorias.Add(new SelectListItem("Selecione uma categoria...", "0"));
            foreach (var categoria in categorias)
            {
                SelectListItem item = new SelectListItem(categoria.Descricao, categoria.Id.ToString());
                listaCategorias.Add(item);
            }
            ViewBag.Categorias = listaCategorias;
        }

        private void PreparaListaMarcasParaCombo()
        {
            MarcaDAO marcaDAO = new MarcaDAO();
            var marcas = marcaDAO.ListaMarcas();
            List<SelectListItem> listaMarcas = new List<SelectListItem>();

            listaMarcas.Add(new SelectListItem("Selecione uma marca...", "0"));
            foreach (var marca in marcas)
            {
                SelectListItem item = new SelectListItem(marca.Descricao, marca.Id.ToString());
                listaMarcas.Add(item);
            }
            ViewBag.Marcas = listaMarcas;
        }
    }
}
