using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackEmployees.Constants;
using TrackEmployees.Model;
using TrackEmployees.RestClient;

namespace TrackEmployees.Services
{
    public class Services
    {
        public Services()
        {
        }

        public Task<Employees> LoginInfo(Employees emp)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            var result = restClient.PostAsync(emp, Constants.Constants.LOGIN_URL);

            return result;

        }

        public Task<List<Employees>> GetEmployee()
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            var result = restClient.GetAsync(Constants.Constants.ALLEMPLOYEES_URL);

            return result;

        }

        public Task<Employees> Register(Employees emp)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            var result = restClient.PostAsync(emp, Constants.Constants.REGISTRATION_URL);

            return result;

        }
        public Task<bool> UpdatePassword(Employees emp)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            var result = restClient.PutAsync(emp, Constants.Constants.UPDATE_PASSWORD_URL);

            return result;

        }
        public Task<bool> UpdateLatLong(Employees emp)
        {
            RestClient<Employees> restClient = new RestClient<Employees>();
            var result = restClient.PutAsync(emp, Constants.Constants.UPDATE_LAT_LONG_URL);

            return result;

        }
    }
}
