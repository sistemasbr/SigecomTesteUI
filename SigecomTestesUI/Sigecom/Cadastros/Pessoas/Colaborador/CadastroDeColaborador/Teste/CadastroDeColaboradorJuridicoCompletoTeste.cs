using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Teste
{
    public class CadastroDeColaboradorJuridicoCompletoTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome", "REPEDIU ATIVIDADES DE INTERNET LTDA"},
            {"Cnpj", "40120973000189"},
            {"NomeFantasia","PLUG4SALES"},
            {"Cep","15700-082"},
            {"Endereco", "AVENIDA JOÃO AMADEU"},
            {"Numero","2345"},
            {"Bairro","CENTRO"},
            {"DataAdmissao", "01/01/1998"},
            {"EmailFuncionario", "teste@sistemasbr.net"},
            {"DiaPagamento", "07"},
            {"Salario", "800,00"},
            {"TelefoneFuncionario", "(11)96405-6467"},
            {"Cargo", "TESTER"}
        };

        [Test(Description = "Cadastro de colaborador jurídico completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarClienteJuridicoCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeColaboradorJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeColaboradorJuridicoPage>>();
            var cadastroDeColaboradorJuridicoPage = resolveCadastroDeColaboradorJuridicoPage(DriverService, _dadosDoCliente);
            cadastroDeColaboradorJuridicoPage.AcessarTelaDeCadastroDeColaborador();

            // Act
            cadastroDeColaboradorJuridicoPage.PreencherCamposCompleto();
            cadastroDeColaboradorJuridicoPage.VerificarCamposDoCarregados();
            cadastroDeColaboradorJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeColaboradorJuridicoPage.PesquisarColaboradorGravado(beginLifetimeScope);
        }
    }
}
