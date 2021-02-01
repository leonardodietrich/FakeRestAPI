using FakeRestAPI.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FakeRestAPI.steps
{
    [Binding]
    class GenericSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private HttpRequestContoller _controller;

        public IRestResponse restResponse { get; set; }

        public GenericSteps(ScenarioContext scenarioContext, HttpRequestContoller httpControler)
        {
            _scenarioContext = scenarioContext;
            _controller = httpControler;
        }

        [Given(@"que o usuario acessou a API")]
        public void DadoQueOUsuarioAcessouAAPI()
        {

        }

        //[When(@"o usuario solicitar um GET em '(.*)' da versão '(.*)' passando o parametro '(.*)'")]
        //public void QuandoOUsuarioSolicitarUmEmDaVersao(string endPoint, string version, int parameter/*, string p3*/)
        //{

        //    restResponse = _controller.GetRequestParameters(version, endPoint, parameter/*, p3*/);

        //}

        [When(@"o usuario solicitar um '(.*)' em '(.*)' da versão '(.*)' passando o parametro '(.*)'")]
        public void QuandoOUsuarioSolicitarUmEmDaVersaoPassandoOParametro(string httpMethodName, string endPoint, string version, int parameter)
        {
            HttpMethod httpMethod = HttpRequestContoller.GetHttpMethod(httpMethodName);

            var urlBase = !string.IsNullOrEmpty(version) ? $"{version}" : string.Empty;

            restResponse = _controller.HttpRequest(httpMethod.ToString(), urlBase, endPoint, parameter);

           
        }


        [Then(@"vou receber um JSON com a response")]
        public void EntaoVouReceberUmJsonComValores(string responseContent)
        {

            Assert.AreEqual(responseContent, restResponse.Content, $"O conteúdo da response esperada ({responseContent})não foi o retornado. Retorno Atual: Conteúdo da response: {restResponse.Content}");

        }

        [Then(@"vou receber o retorno '(.*)'")]
        public void EntaoVouReceberORetorno(string HttpStatusCode)
        {

            restResponse.StatusCode.Equals(HttpStatusCode);

        }
    }
}
