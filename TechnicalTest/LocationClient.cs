using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechnicalTest.Service;

namespace TechnicalTest
{
    public class LocationClient
    {
        private readonly RestService _resrService;
        private readonly ConfigurationProvider _configurationProvider;
        private RestResponse Response;

        public LocationClient(RestService restService, ConfigurationProvider configurationProvider)
        {
            _resrService = restService;
            _configurationProvider = configurationProvider;
        }

        public void GetLocationInformation(string countryCode, string postCode)
        {
            var url = _configurationProvider.GetUrl();
            //Format the url with countrycode and postcode
            url = String.Format(url, countryCode, postCode);
            Console.WriteLine("Location url = " + url);
            //Call get method to retrieve the location information
            Response = _resrService.Get(url);
            
        }

        public void VerifyRequestStatus(string isSuccessful)
        {
            //assert the response status to Httpstatuscode
            if (isSuccessful.Equals("true"))
            {
                Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Console.WriteLine("Location is available as expected in zippopotam.us API");
            }
            else
            {
                Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Console.WriteLine("Location is not found in zippopotam.us API");
            }
        }
    }
}

