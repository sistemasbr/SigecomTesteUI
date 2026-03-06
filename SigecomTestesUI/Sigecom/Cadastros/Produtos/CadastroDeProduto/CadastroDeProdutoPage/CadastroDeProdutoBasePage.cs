using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Login.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.ExceptionProduto;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Enum;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.CadastroDeProdutoPage
{
    public class CadastroDeProdutoBasePage : PageObjectModel
    {
        public CadastroDeProdutoBasePage(DriverService driver) : base(driver)
        {
        }

        public bool ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaComF9(CadastroDeProdutoModel.BotaoPesquisar);

        public void ClicarNoAtalhoDePesquisarNaTelaPrincipal() =>
            DriverService.AbrirPesquisaComF9(LoginPageModel.ElementoTelaPrincipal);

        public void ClicarNoAtalhoDePesquisarNaTelasDeVenda(string elementoDaTela) =>
            DriverService.AbrirPesquisaComF9(elementoDaTela);

        public void ClicarNoBotaoNovo()
        {
            try
            {
                ClicarBotaoName(CadastroDeProdutoModel.BotaoNovoCadastro);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public void PreencherCamposDeImpostosDeServico()
        {
            DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
            DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
            var verificarNcm = DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm)
                .Equals("00000000");
            Assert.True(verificarNcm);
            DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCodigoNBS, CadastroDeProdutoServicoModel.CodigoNBS);
        }

        public void GravarAoEditarEFecharATela()
        {
            DriverService.ConfirmarPesquisa(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
            FecharJanelaCadastroDeProdutoComEsc();
        }

        public bool FecharJanelaCadastroDeProdutoComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public void RealizarFluxoDeCadastrarProduto(TipoDeProduto tipo, string aba)
        {
            // Arange
            AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto();

            // Act
            PreencherCamposDoProduto(tipo);
            VerificarSePrecoDeVendaFoiCalculado();
            AcessarAba(CadastroDeProdutoModel.AbaImpostos);
            PreencherCamposDeImpostos();
            AcessarAba(aba);
            PreencherCamposDaAba(tipo);
            Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProduto(tipo);
        }

        public void AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarNoBotaoNovo();
        }

        public bool PreencherCamposDoProduto(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto)
                    .PreencherCamposDoProduto();
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public bool VerificarSePrecoDeVendaFoiCalculado()
        {
            var precoDeVenda =
                double.Parse(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda));
            return precoDeVenda.Equals(double.Parse(CadastroDeProdutoBaseModel.PrecoVendaDoProduto));
        }

        public bool AcessarAba(string aba)
        {
            try
            {
                DriverService.ClicarBotaoName(aba);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public bool PreencherCamposDeImpostos()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm,
                    CadastroDeProdutoBaseModel.NcmDoProduto);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public bool PreencherCamposDaAba(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto)
                    .PreencherCamposDaAba();
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public bool Gravar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeProdutoException(exception.ToString());
            }
        }

        public void RealizarFluxoDePesquisaDoProduto(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
            beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto)
                .FluxoDePesquisaDoProduto(this, pesquisaDeProdutoPage);
        }
    }
}
