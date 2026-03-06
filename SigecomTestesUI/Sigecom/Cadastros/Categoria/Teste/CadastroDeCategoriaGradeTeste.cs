using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Page;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaGradeTeste: BaseTestes
    {
        [Test(Description = "Cadastro de Categoria grade Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaGradeSomenteCamposObrigatorios()
        {
            var dadosDeCategoria = new Dictionary<string, string>
            {
                {"Grupo", "GRUPO GRADE"},
                {"Markup", "0"}
            };
            
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeCategoriaPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            var cadastroDeCategoriaPage = resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoria);
            cadastroDeCategoriaPage.AbrirTelaDeCategoriaParaTeste();

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoriaGrade(CadastroDeCategoriaModel.ElementoToggleGrade);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            cadastroDeCategoriaPage.PesquisarCategoriaGravada();
        }
    }
}
