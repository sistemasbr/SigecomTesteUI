using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class DevolverDinheiroNaDevolucaoTeste: BaseTestes
    {
        //[Test(Description = "Devolver dinheiro na devolução")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("DevolverDinheiro")]
        //[AllureSubSuite("Devolução")]
        public void DevolverDinheiroNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var devolverDinheiroNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, DevolverDinheiroNaDevolucaoPage>>()(DriverService);
            devolverDinheiroNaDevolucaoPage.RealizarFluxoDeDevolverDinheiroNaDevolucao();
        }
    }
}
