using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Devolucao.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Devolucao.Teste
{
    public class DevolucaoParcialNaDevolucaoTeste: BaseTestes
    {
        //[Test(Description = "Devolução parcial na devolução")]
        //[AllureTag("CI")]
        //[AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        //[AllureIssue("1")]
        //[AllureTms("1")]
        //[AllureOwner("Takaki")]
        //[AllureSuite("DevolucaoParcial")]
        //[AllureSubSuite("Devolução")]
        public void DevolucaoParcialNaDevolucao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var devolucaoParcialNaDevolucaoPage = beginLifetimeScope.Resolve<Func<DriverService, DevolucaoParcialNaDevolucaoPage>>()(DriverService);
            devolucaoParcialNaDevolucaoPage.RealizarFluxoDeDevolucaoParcialNaDevolucao();
        }
    }
}
