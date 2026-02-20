using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoVaziaTeste: BaseTestes
    {
        [Test(Description = "Pesquisa de Produto Vazia")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Produto")]
        public void PesquisarProdutoComCampoVazio()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            var pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);

            // Act
            pesquisaDeProdutoPage.PesquisarComF9UmProdutoNaTelaDeCadastroDeProduto(beginLifetimeScope, out var cadastroDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter("");

            // Assert
            Assert.True(pesquisaDeProdutoPage.VerificarSeExisteQualquerProdutoNaGrid());
            pesquisaDeProdutoPage.FecharTelasDeProduto(cadastroDeProdutoPage);
        }
    }
}
