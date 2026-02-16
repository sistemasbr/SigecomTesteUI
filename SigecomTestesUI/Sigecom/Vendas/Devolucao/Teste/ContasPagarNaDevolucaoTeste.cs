using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class ContasPagarNaDevolucaoTeste: BaseTestes
    {
        //[Test(Description = "Contas a pagar na devolução")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("ContasPagar")]
        //[AllureSubSuite("Devolução")]
        public void ContasAPagarNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contasPagarNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, ContasPagarNaDevolucaoPage>>()(DriverService);
            contasPagarNaDevolucaoPage.RealizarFluxoDeContasAPagarNaDevolucao();
        }
    }
}
