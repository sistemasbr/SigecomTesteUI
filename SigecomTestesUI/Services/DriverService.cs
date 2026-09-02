using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace SigecomTestesUI.Services
{
    public class DriverService : IDisposable
    {
        private readonly WindowsDriver<WindowsElement> _driver;

        public DriverService(WindowsDriver<WindowsElement> windowsDriver) => _driver = windowsDriver;

        public void FecharSistema()
        {
            ClicarBotaoName("Sair/Login");
            FinalizarFecharDoSistema();
        }

        public void FecharSistemaComTelaAberta()
        {
            ClicarBotaoName("Sair/Login");
            TrocarJanela();
            ClicarBotaoName(", Sim (ENTER)");
            FinalizarFecharDoSistema();
        }

        private void FinalizarFecharDoSistema()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            if(VerificarSePossuiOValorNaTela(", Sim (ENTER)")) 
                ClicarBotaoName(", Sim (ENTER)");
            TrocarJanela();
            ValidarElementoExistentePorNome("Sistema de gestão comercial"); //tela de login
            ClicarBotaoName("Fechar"); // X da tela de login
            _driver.Dispose();
        }

        public void ValidarElementoExistentePorNome(string valor)
        {
            var elemento = EncontrarElementoName(valor);
            Assert.AreEqual(elemento.Text, valor);
        }

        public WindowsElement EncontrarElementoId(string idElemento) => 
            _driver.FindElementByAccessibilityId(idElemento);

        public WindowsElement EncontrarElementoName(string nomeElemento) => 
            _driver.FindElementByName(nomeElemento);

        public WindowsElement EncontrarElementoXPath(string caminhoElemento) => 
            _driver.FindElementByXPath(caminhoElemento);

        public string ObterValorElementoId(string nomeElemento) => 
            _driver.FindElementByAccessibilityId(nomeElemento).Text;

        public string ObterValorElementoName(string nomeElemento) => 
            _driver.FindElementByName(nomeElemento).Text;

        public string PegarValorDaColunaDaGrid(string nomeColuna) => 
            _driver.FindElementByName($"{nomeColuna} row 0").Text;

        public string PegarValorDaColunaDaGridNaPosicao(string nomeColuna, string posicao) =>
            _driver.FindElementByName($"{nomeColuna} row {posicao}").Text;

        public void TrocarJanela()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            var allWindowHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(allWindowHandles[0]);
        }

        public void TrocarJanelaLogin()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var allWindowHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(allWindowHandles[0]);
        }

        public void DigitarNoCampoId(string idElemento, string texto) => 
            _driver.FindElementByAccessibilityId(idElemento).SendKeys(texto);         

        public void DigitarNoCampoName(string nomeElemento, string texto) => 
            _driver.FindElementByName(nomeElemento).SendKeys(texto);

        public void DigitarNoCampoComTeclaDeAtalhoIdComThread(string idElemento, string texto, string teclaDeAtalho)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            Thread.Sleep(TimeSpan.FromSeconds(4));
            elemento.SendKeys(teclaDeAtalho);
        }

        public void DigitarNoCampoComTeclaDeAtalhoIdMaisF5(string idElemento, string texto, string teclaDeAtalho) => 
            DigitarNoCampoComTeclaDeAtalhoId(idElemento, texto, teclaDeAtalho).SendKeys(Keys.F5);

        public void DigitarNoCampoComTeclaDeAtalhoIdTriploEnter(string idElemento, string texto)
        {
            var elemento = DigitarNoCampoComTeclaDeAtalhoId(idElemento, texto, Keys.Enter);
            elemento.SendKeys(Keys.Enter);
            elemento.SendKeys(Keys.Enter);
        }

        public WindowsElement DigitarNoCampoComTeclaDeAtalhoId(string idElemento, string texto, string teclaDeAtalho)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            elemento.SendKeys(texto);
            elemento.SendKeys(teclaDeAtalho);
            return elemento;
        }

        public void RealizarSelecaoDaAcao(string idElemento, int posicao) => 
            RealizarSelecaoDaFormaDePagamento(idElemento, posicao);

        public void RealizarSelecaoDaFormaDePagamentoSemEnter(string idElemento, int posicao) =>
            DigitarNoCampoId(idElemento, posicao.ToString());

        public void RealizarSelecaoDaFormaDePagamento(string idElemento, int posicao)
        {
            var elemento = _driver.FindElementByAccessibilityId(idElemento);
            var acao = new Actions(_driver);
            acao.MoveToElement(elemento);
            acao.SendKeys(posicao.ToString());
            acao.SendKeys(Keys.Enter);
            acao.Perform();
        }

        public void ClicarNoToggleSwitchPeloId(string nomeDoCampo) =>
            ClicarBotaoId(nomeDoCampo);

        public void ClicarBotaoName(string nomeBotao) =>
            _driver.FindElementByName(nomeBotao).Click();

        public void ConfirmarPerguntaComEnter(int segundosDeEspera = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(segundosDeEspera));
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
            new Actions(_driver).SendKeys(Keys.Enter).Perform();
        }

        public void ClicarBotaoId(string nomeBotao) => 
            _driver.FindElementByAccessibilityId(nomeBotao).Click();

        public void DarDuploCliqueNoBotaoName(string nomeBotao)
        {
            var botaoEncontrado = _driver.FindElementByName(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
        }

        public void DarDuploCliqueNoBotaoId(string nomeBotao)
        {
            var botaoEncontrado = _driver.FindElementByAccessibilityId(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
        }

        public void EditarCampoComDuploCliqueNoBotaoId(string nomeBotao, string texto)
        {
            var botaoEncontrado = _driver.FindElementByAccessibilityId(nomeBotao);
            var acao = new Actions(_driver);
            acao.MoveToElement(botaoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            botaoEncontrado.SendKeys(texto);
        }

        public bool VerificarSePossuiOValorNaGrid(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);
            var elementoDaGridComName = ObterElementoDaGridComName(nomeColuna, campoDaGrid);
            return elementoDaGridComName.Text.Equals(nome);
        }

        public bool VerificarSePossuiOValorNaTela(string nome)
        {
            var driverPageSource = _driver.PageSource;
            return driverPageSource.Contains(nome);
        }

        public void CliqueNoElementoDaGridComVariosEVerificar(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);
            var elementoDaGridComName = ObterElementoDaGridComName(nomeColuna, campoDaGrid);
            RealizarAcaoDeClicarNoCampoDaGrid(nome, elementoDaGridComName);
            Assert.AreEqual(elementoDaGridComName.Text, nome);
        }

        public void CliqueNoElementoDaGridComVarios(string nomeColuna, string nome)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColuna, nome);

            RealizarAcaoDeClicarNoCampoDaGrid(nome, ObterElementoDaGridComName(nomeColuna, campoDaGrid));
        }

        public int RetornarPosicaoDoRegistroDesejado(string nomeColunaParaEncontrarValor, string valorParaSerEncontrado)
        {
            var campoDaGrid = ObterPosicaoDoElementoNaGrid(nomeColunaParaEncontrarValor, valorParaSerEncontrado);

            RealizarAcaoDeClicarNoCampoDaGrid(valorParaSerEncontrado, ObterElementoDaGridComName(nomeColunaParaEncontrarValor, campoDaGrid));
            return campoDaGrid;
        }

        public void EditarNaGridNaPosicao(string nomeColunaParaEditar, string valorParaEditar, int campoDaGrid)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeColunaParaEditar} row {campoDaGrid}");
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            elementoEncontrado.SendKeys(valorParaEditar);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        private int ObterPosicaoDoElementoNaGrid(string nomeColuna, string nome)
        {
            var campoDaGrid = 0;

            while (!ObterElementoDaGridComName(nomeColuna, campoDaGrid).Text.Equals(nome))
                campoDaGrid++;

            return campoDaGrid;
        }

        private WindowsElement ObterElementoDaGridComName(string nomeColuna, int campoDaGrid) => 
            _driver.FindElementByName($"{nomeColuna} row {campoDaGrid}");

        private void RealizarAcaoDeClicarNoCampoDaGrid(string nome, IWebElement botaoEncontrado)
        {
            if (!botaoEncontrado.Text.Equals(nome)) return;
            var acao = new Actions(_driver);
            acao.Click(botaoEncontrado);
            acao.Perform();
        }

        public void SelecionarItemComboBoxSemEnter(string nomeCampo, int posicao)
        {
            var campo = _driver.FindElementByAccessibilityId(nomeCampo);
            SelecionarItens(posicao, campo);
        }

        public void SelecionarItemComboBox(string nomeCampo, int posicao)
        {
            var campo = _driver.FindElementByAccessibilityId(nomeCampo);
            ConcluirSelecionarItens(posicao, campo);
        }

        private static void ConcluirSelecionarItens(int posicao, IWebElement elementoEncontrado)
        {
            SelecionarItens(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void SelecionarDoisItensDaGrid(string nomeCampo, int posicao)
        {
            var elementoEncontrado = _driver.FindElementByName(nomeCampo);
            ConcluirSelecionarItens(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        private static void SelecionarItens(int posicao, IWebElement elementoEncontrado)
        {
            elementoEncontrado.Click();
            EncontrarElementoNaComboBox(posicao, elementoEncontrado);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void SelecionarItensDoDropDown(int posicao)
        {
            var acao = new Actions(_driver);
            for (var i = 1; i <= posicao; i++)
                acao.SendKeys(Keys.ArrowDown);
            acao.SendKeys(Keys.Enter);
            acao.Perform();
        }

        public void ClicarNoCheckEditDaGrid(string nomeCampo)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row 0");
            elementoEncontrado.Click();
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void DigitarNovosItensNaGrid(string nomeCampo, string texto)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} new item row");
            DigitarItensNaGrid(texto, elementoEncontrado);
        }

        public void EditarItensNaGrid(string nomeCampo, string texto)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row 0");
            DigitarItensNaGrid(texto, elementoEncontrado);
        }

        private static void DigitarItensNaGrid(string texto, IWebElement elementoEncontrado)
        {
            elementoEncontrado.SendKeys(texto);
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void EditarItensNaGridComDuploClickComTab(string nomeCampo, string texto)
        {
            var elementoEncontrado = EditarItemDaGridComDuploClick(nomeCampo, texto, "0");
            elementoEncontrado.SendKeys(Keys.Tab);
        }

        public void EditarItensNaGridComDuploClickComEnter(string nomeCampo, string texto)
        {
            var elementoEncontrado = EditarItemDaGridComDuploClick(nomeCampo, texto, "0");
            elementoEncontrado.SendKeys(Keys.Enter);
        }

        public void EditarItensNaGridComDuploClickNaPosicaoDesejada(string nomeCampo, string texto, string posicao)
        {
            EditarItemDaGridComDuploClick(nomeCampo, texto, posicao);
        }

        public void EditarItensNaGridComDuploClickNaPosicaoDesejadaETab(string nomeCampo, string texto, string posicao)
        {
            EditarItemDaGridComDuploClick(nomeCampo, texto, posicao).SendKeys(Keys.Tab);
            
        }

        private WindowsElement EditarItemDaGridComDuploClick(string nomeCampo, string texto, string posicao)
        {
            var elementoEncontrado = _driver.FindElementByName($"{nomeCampo} row {posicao}");
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.DoubleClick();
            acao.Perform();
            elementoEncontrado.SendKeys(texto);
            return elementoEncontrado;
        }

        public void RemoverItensDaGridComBotaoDireito(string nomeCampo)
        {
            var elementoEncontrado = _driver.FindElementByAccessibilityId(nomeCampo);
            var acao = new Actions(_driver);
            acao.MoveToElement(elementoEncontrado);
            acao.Click();
            acao.Perform();
            elementoEncontrado.SendKeys(Keys.Delete);
        }

        private static void EncontrarElementoNaComboBox(int posicao, IWebElement campo)
        {
            for (var i = 1; i <= posicao; i++)
                campo.SendKeys(Keys.ArrowDown);
        }

        public void FecharJanelaComEscId(string idCampoParaFocar)
        {
            var campo = EncontrarElementoId(idCampoParaFocar);
            campo.SendKeys(Keys.Escape);
        }

        public void FecharJanelaComEsc(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela,Keys.Escape);

        public void AbrirPesquisaComF9(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F9);

        public void ConfirmarPesquisa(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F5);

        public void AbrirFecharAbaDeFiltroTelaDeConsulta(string nomeJanela) =>
            RealizarAcaoDaTeclaDeAtalhoNaTelaName(nomeJanela, Keys.F3);

        public void RealizarAcaoDaTeclaDeAtalhoNaTelaName(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByName(nomeJanela).SendKeys(teclaDeAtalho);
        public void RealizarAcaoDaTeclaDeAtalhoNaTelaId(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByAccessibilityId(nomeJanela).SendKeys(teclaDeAtalho);

        public void RealizarAcaoDaTeclaDeAtalhoCtrlAltCombinadaNaTela(string nomeJanela, string teclaDeAtalho) =>
            _driver.FindElementByName(nomeJanela).SendKeys(Keys.Control + Keys.Alt + teclaDeAtalho);

        public void FocarCampoName(string nomeCampo)
        {
            var campo = EncontrarElementoName(nomeCampo);
            campo.Click();
        }

        public void FocarCampoId(string nomeCampo)
        {
            var campo = EncontrarElementoId(nomeCampo);
            campo.Click();
        }

        public bool VerificarSeCheckEstaMarcado(string idCampo)
        {
            var estaMarcado = ObterValorElementoName(idCampo);
            if (estaMarcado == "Checked")
                return true;
            return false;
        }

        public void MatarProcessoSigecom()
        {
            foreach (var process in Process.GetProcessesByName("Sigecom"))
            {
                process.Kill();
            }
        }

        public void Dispose()
        {
            try
            {
                FecharSistema();
                _driver.Quit();
            }
            catch (Exception)
            {
                MatarProcessoSigecom();
            }
        }

        public void DisposeComTelaAberta()
        {
            try
            {
                FecharSistemaComTelaAberta();
                _driver.Quit();
            }
            catch (Exception)
            {
                MatarProcessoSigecom();
            }
        }
    }
}
