using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace FakeRestAPI.services
{
    /// <summary>
    /// Define a classe HttpRequestsController.
    /// </summary>
    class HttpRequestContoller
    {
        private readonly string BaseUrl = "http://fakerestapi.azurewebsites.net/";

        /// <summary>
        /// Realiza a requisição na API.
        /// </summary>
        /// <param name="urlBase">Url Base do endpoint que será feita a requisição.</param>
        /// <param name="httpMethod">Método Http que será utilizado.</param>
        /// <param name="endPoint">Endoint que será feita a requisição.</param>
        /// <param name="id">Parametro de entrada que será utilizado na requisição</param>
        public IRestResponse HttpRequest(string httpMethod, string urlBase, string endPoint, int id)
        {
            var restClient = new RestClient(BaseUrl + $"{urlBase}/{endPoint}/{id}");

            //var restRequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            var restRequest = new RestRequest(httpMethod) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);

        }

        /// <summary>
        /// Obtém o HttpMethod a partir do nome.
        /// </summary>
        /// <param name="httpMethodName">Nome do método http.</param>
        /// <returns>Retorna o HttpMethod correspondente ao nome.</returns>
        public static HttpMethod GetHttpMethod(string httpMethodName)
        {
            switch (httpMethodName.ToLower(Thread.CurrentThread.CurrentUICulture)) 
            {
                case "post":
                    return HttpMethod.Post;
                case "patch":
                    return HttpMethod.Patch;
                case "put":
                    return HttpMethod.Put;
                case "delete":
                    return HttpMethod.Delete;
                case "options":
                    return HttpMethod.Options;
                case "trace":
                    return HttpMethod.Trace;
                case "head":
                    return HttpMethod.Head;
                default:
                    return HttpMethod.Get;
            }
        }
    }
}
