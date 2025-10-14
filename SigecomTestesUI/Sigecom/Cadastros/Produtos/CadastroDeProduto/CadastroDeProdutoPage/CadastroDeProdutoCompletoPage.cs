using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage
{
    public class CadastroDeProdutoCompletoPage: ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoCompletoPage(DriverService driver) =>
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoCompletoModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoInterno, CadastroDeProdutoBaseModel.CodigoInternoDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoCompletoModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));

                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoGarantiaEmDias, CadastroDeProdutoCompletoModel.GarantiaEmDias);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoEstoque, CadastroDeProdutoCompletoModel.Estoque);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoEstoqueMinimo, CadastroDeProdutoCompletoModel.EstoqueMinimo);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoEstoqueMaximo, CadastroDeProdutoCompletoModel.EstoqueMaximo);

                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);

                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoMarca, CadastroDeProdutoCompletoModel.Marca, Keys.Enter);
                _driverService.TrocarJanela();
                _driverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5("textEditPesquisa", CadastroDeProdutoCompletoModel.Marca, Keys.Enter);
                _driverService.TrocarJanela();
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoFornecedor, CadastroDeProdutoCompletoModel.Fornecedor, Keys.Enter);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoLocal, CadastroDeProdutoCompletoModel.Local);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoObs, CadastroDeProdutoCompletoModel.Obs);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAba()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoDescricao, CadastroDeProdutoCompletoModel.Descricao);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            cadastroDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoBasePage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(CadastroDeProdutoCompletoModel.NomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(CadastroDeProdutoCompletoModel.NomeFinalDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }
    }
}
