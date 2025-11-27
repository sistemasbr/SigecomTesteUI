using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Compra.Xml.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Compra.Xml.Page
{
    public class CompraXmlCompletaPage:PageObjectModel
    {
        public CompraXmlCompletaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CompraXmlModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CompraXmlModel.BotaoSubMenu);

        public void RealizarFluxoDaCompraXml()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DarDuploCliqueNoBotaoName("Fornecedor row 0");

            // Act
            DriverService.EditarItensNaGridComDuploClickNaPosicaoDesejada(CompraXmlModel.CampoDaGridDeItens, "", "0");
            DriverService.ClicarBotaoId(CompraXmlModel.ElementoDeAssociarProdutoDoXml);
            DriverService.TrocarJanela();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraXmlModel.ElementoPesquisaDeProduto, "11", Keys.Enter);
            DriverService.TrocarJanela();
            ClicarBotaoName(CompraXmlModel.ElementoNameDoConfirmar);
            DriverService.EditarItensNaGridComDuploClickNaPosicaoDesejada(CompraXmlModel.CampoDaGridDeItens, "", "1");
            DriverService.ClicarBotaoId(CompraXmlModel.ElementoDeAssociarProdutoDoXml);
            DriverService.TrocarJanela();
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CompraXmlModel.ElementoPesquisaDeProduto, "11", Keys.Enter);
            DriverService.TrocarJanela();
            ClicarBotaoName(CompraXmlModel.ElementoNameDoConfirmar);

            // Assert
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            Assert.AreEqual(DriverService.ObterValorElementoId(CompraXmlModel.ElementoDoTotalDuplicatas), "R$150,00");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao(CompraXmlModel.TituloGridValorDuplicata, "0"), "150,00");
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            ClicarBotaoName(CompraXmlModel.ElementoDoAvancarCompra);
            EsperarAcaoEmSegundos(1);
            FecharTelaDeCompraXmlComEsc();
        }

        private void FecharTelaDeCompraXmlComEsc() =>
            DriverService.FecharJanelaComEsc(CompraXmlModel.ElementoTelaDeCompra);
    }
}
