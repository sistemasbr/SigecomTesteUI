using System;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class LancarItensNaDevolucaoTeste: BaseTestes
    {
        //[Test(Description = "Lançar itens na devolução")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("Lancar")]
        //[AllureSubSuite("Devolução")]
        public void LancarItensNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarItensNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarItensNaDevolucaoPage>>()(DriverService);
            lancarItensNaDevolucaoPage.RealizarFluxoDeLancarItensNaDevolucao();
        }
    }
}
