using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Page
{
    public class AlteracaoEmMassaComTodasAsTogglesPage: PageObjectModel
    {
        public AlteracaoEmMassaComTodasAsTogglesPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDaAlteracaoEmMassaComTodasAsTogglesNaManutencaoDeEstoque()
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
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDoCest);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaNcm);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(AlteracaoEmMassaModel.ElementoDoCampoDoCest, "", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5("txtPesquisa",
                "0100100", Keys.Enter);

            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaCstPis);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaCstPis, 1);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaClassificacaoPis);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaClassificacaoPis, 1);

            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoTipoDeAlteracao, 1);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(AlteracaoEmMassaModel.ElementoDoValorDaVenda, "10", Keys.Enter);

            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaCategoria);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(AlteracaoEmMassaModel.ElementoDoCampoDaCategoria, "Balanca", Keys.Enter); 
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDaMarca);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDaMarca, 1);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDoFornecedor);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDoFornecedor, 1);
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDoLocal);
            DriverService.DigitarNoCampoId(AlteracaoEmMassaModel.ElementoDoCampoDoLocal, "Teste");
            DriverService.ClicarNoToggleSwitchPeloId(AlteracaoEmMassaModel.ElementoDaToggleDoAtivoDesativo);
            DriverService.SelecionarItemComboBox(AlteracaoEmMassaModel.ElementoDoCampoDoAtivoDesativo, 1);

            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoConfirmar);
            DriverService.TrocarJanela();
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoSim);
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
