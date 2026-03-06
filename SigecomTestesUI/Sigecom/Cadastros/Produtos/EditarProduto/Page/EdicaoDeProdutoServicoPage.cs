using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model.CompararProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoServicoPage: IEdicaoDeProdutoPage
    {
        private readonly DriverService _driverService;

        public EdicaoDeProdutoServicoPage(DriverService driver) =>
            _driverService = driver;

        public void PesquisarProdutoQueSeraEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage)
        {
            edicaoDeProdutoBasePage.AbrirTelaDeCadastroDoProduto();
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeProdutoBasePage.RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(OriginalServicoModel.NomeDoProdutoParaPesquisar);
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), OriginalServicoModel.CategoriaDoProduto);
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EdicaoDeProdutoServicoModel.NomeDoProdutoAlterado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void VerificarCamposDeProdutoEditado()
        {
            //Não utilizado;
        }

        public void VerificarCamposDaAba()
        {
            //Não utilizado;
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoIbptNacional, EdicaoDeProdutoServicoModel.IbptNacional);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoIbptEstatual, EdicaoDeProdutoServicoModel.IbptEstatual);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoIbptImportado, EdicaoDeProdutoServicoModel.IbptImportado);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoIbptMunicipal, EdicaoDeProdutoServicoModel.IbptMunicipal);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoAliquotaIcms, EdicaoDeProdutoServicoModel.AliquotaIcms);
            _driverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoExigibilidadeIss, 1);
            _driverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoIndicadorIncentivo, 1);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoListaServicos, EdicaoDeProdutoServicoModel.ListaServicos);
            _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoNBS, EdicaoDeProdutoServicoModel.CodigoNBS);
        }

        public void VerificarCamposDaAbaEditado()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoIbptNacional), EdicaoDeProdutoServicoModel.IbptNacional);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoIbptEstatual), EdicaoDeProdutoServicoModel.IbptEstatual);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoIbptImportado), EdicaoDeProdutoServicoModel.IbptImportado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoIbptMunicipal), EdicaoDeProdutoServicoModel.IbptMunicipal);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoAliquotaIcms), EdicaoDeProdutoServicoModel.AliquotaIcms);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCodigoNBS), EdicaoDeProdutoServicoModel.CodigoNBS);
        }

        public void FluxoDePesquisaDoProdutoEditado(EdicaoDeProdutoBasePage edicaoDeProdutoBasePage,
            PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            edicaoDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(EdicaoDeProdutoServicoModel.NomeFinalDoProduto);
        }
    }
}
