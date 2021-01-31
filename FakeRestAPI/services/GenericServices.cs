using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeRestAPI.services
{
    class GenericServices
    {
        private readonly string BaseUrl = "http://fakerestapi.azurewebsites.net/";

        public IRestResponse GetRequestParameters(string version, string endPoint, int id)
        {
            var restClient = new RestClient(BaseUrl + $"api/{version}/{endPoint}/{id}");

            var restRequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);
        }
    }
}
