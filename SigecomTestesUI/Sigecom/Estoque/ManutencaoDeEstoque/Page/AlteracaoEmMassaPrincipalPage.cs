using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page
{
    public class AlteracaoEmMassaPrincipalPage: PageObjectModel
    {
        public AlteracaoEmMassaPrincipalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDaAlteracaoEmMassaPrincipalNaManutencaoDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeAlteracaoEmMassa);

            // Act
            DriverService.TrocarJanela();
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaOrigemDaMercadoria);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaOrigemDaMercadoria, 2);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaSituacaoTribuitaria);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaSituacaoTribuitaria, 2);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaNaturezaCfop);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaNaturezaCfop, 2);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDoCBenef);
            DriverService.DigitarNoCampoId(AlteracaoEmMassaModel.ElementoDoCampoDoCBenef, "SP099009");
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoConfirmar);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);

            // Assert
            DriverService.TrocarJanela();
            FecharTelaDeManutencaoDeEstoqueComEsc();
        }

        private void FecharTelaDeManutencaoDeEstoqueComEsc() =>
            DriverService.FecharJanelaComEsc(ManutencaoDeEstoqueModel.ElementoTelaDeManutencaoDeEstoque);
    }
}
