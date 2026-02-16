using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class GerarHaverNaDevolucaoTeste: BaseTestes
    {
        //[Test(Description = "Gerar haver na devolucao")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("Haver")]
        //[AllureSubSuite("Devolucao")]
        public void GerarHaverNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var gerarHaverNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, GerarHaverNaDevolucaoPage>>()(DriverService);
            gerarHaverNaDevolucaoPage.RealizarFluxoDeGerarHaverNaDevolucao();
        }
    }
}
