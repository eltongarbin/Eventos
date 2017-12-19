﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Eventos.IO.TestesAutomatizados.CadastrarEvento
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AdicionarNovoEventoFeature : Xunit.IClassFixture<AdicionarNovoEventoFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CadastroDeEvento.feature"
#line hidden
        
        public AdicionarNovoEventoFeature(AdicionarNovoEventoFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Adicionar novo Evento", "\tUm Organizador fará seu login pelo site\r\n\te seguirá para a área administrativa\r\n" +
                    "\tonde registrará um novo evento", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute(DisplayName="Registro de Novo Evento")]
        [Xunit.TraitAttribute("FeatureTitle", "Adicionar novo Evento")]
        [Xunit.TraitAttribute("Description", "Registro de Novo Evento")]
        [Xunit.TraitAttribute("Category", "TesteAutomatizadoCadastroNovoEvento")]
        public virtual void RegistroDeNovoEvento()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Registro de Novo Evento", new string[] {
                        "TesteAutomatizadoCadastroNovoEvento"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("que o Organizador está no site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 10
 testRunner.And("Realiza o Login", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 11
 testRunner.And("Navega até a area administrativa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 12
 testRunner.And("Clica em novo evento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Campo",
                        "Valor"});
            table1.AddRow(new string[] {
                        "nome",
                        "DevXperience"});
            table1.AddRow(new string[] {
                        "descricaoCurta",
                        "Um novo evento de tecnologia"});
            table1.AddRow(new string[] {
                        "descricaoLonga",
                        "Um novo evento de tecnologia"});
            table1.AddRow(new string[] {
                        "categoriaId",
                        "1bbfa7e9-5a1f-4cef-b209-58954303dfc3"});
            table1.AddRow(new string[] {
                        "//*[@id=\"dataInicio\"]/div/div/input",
                        "20/10/2019"});
            table1.AddRow(new string[] {
                        "//*[@id=\"dataFim\"]/div/div/input",
                        "22/10/2019"});
            table1.AddRow(new string[] {
                        "gratuito",
                        "false"});
            table1.AddRow(new string[] {
                        "valor",
                        "1.578,87"});
            table1.AddRow(new string[] {
                        "online",
                        "false"});
            table1.AddRow(new string[] {
                        "nomeEmpresa",
                        "DevX"});
            table1.AddRow(new string[] {
                        "logradouro",
                        "Av. Reboucas"});
            table1.AddRow(new string[] {
                        "numero",
                        "600"});
            table1.AddRow(new string[] {
                        "complemento",
                        "3 andar"});
            table1.AddRow(new string[] {
                        "bairro",
                        "Pinheiros"});
            table1.AddRow(new string[] {
                        "cep",
                        "05402000"});
            table1.AddRow(new string[] {
                        "cidade",
                        "São Paulo"});
            table1.AddRow(new string[] {
                        "estado",
                        "SP"});
#line 13
 testRunner.And("preenche o formulário com os valores", ((string)(null)), table1, "E ");
#line 32
 testRunner.When("clicar no botao adicionar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 33
 testRunner.Then("O evento é registrado e o usuario redirecionado para a lista de eventos", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AdicionarNovoEventoFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AdicionarNovoEventoFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
