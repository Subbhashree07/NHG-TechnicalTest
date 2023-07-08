using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace TechnicalTest
{
    [Binding]
    public class LocationTestSteps
    {
        private readonly LocationClient _locationClient;
        
        public LocationTestSteps(LocationClient locationClient)
        {
            _locationClient = locationClient;
        }

        [Given(@"I make a request to get location information (.*),(.*)")]
        public void GivenIMakeARequestToGetLocationInformation(string countryCode, string postCode)
        {
            //call GetLocationMethod method to make a call to URL and retrieve response
            _locationClient.GetLocationInformation(countryCode, postCode);
        }
        
        [Then(@"I verify the request status (.*)")]
        public void ThenTheRequestShouldBeSuccessful(string isSuccessful)
        {
            //call verifyRequestStatus method to assert the request status
            _locationClient.VerifyRequestStatus(isSuccessful);

        }
    }
}
