using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeRestAPI.services
{
    class UserService
    {
        private readonly string BaseUrl = "http://fakerestapi.azurewebsites.net/";

        public IRestResponse GetAllUsers()
        {
            var restClient = new RestClient(BaseUrl + "/api/v1/Users");

            var restRequest = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            return restClient.Execute(restRequest);
        }
        

    }
}
