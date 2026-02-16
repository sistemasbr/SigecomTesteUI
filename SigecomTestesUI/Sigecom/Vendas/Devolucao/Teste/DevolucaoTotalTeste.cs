using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class DevolucaoTotalTeste: BaseTestes
    {
        //[Test(Description = "Devolução total")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("Devolucao")]
        public void DevolucaoTotal()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var devolucaoTotalNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, DevolucaoTotalPage>>()(DriverService);
            devolucaoTotalNaDevolucaoPage.RealizarFluxoDeDevolucaoTotalNaDevolucao();
        }
    }
}
