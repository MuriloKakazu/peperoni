using Data.Model.Geolocation;
using Domain.Client;
using Domain.Extension;
using System;
using System.Net;
using System.Net.Http;

namespace Domain.Service {
    
    public class AddressService {
        const string BaseEndpoint = "https://viacep.com.br/ws";
        const string ResponseFormat = "json";

        public Address GetAddressFromPostalCode(string postalCode) {
            try {
                var endpoint = $"{BaseEndpoint}/{postalCode.Numeric()}/{ResponseFormat}";

                var client = new RestClient<Address>()
                    .Expect(HttpStatusCode.OK)
                    .Method(HttpMethod.Get)
                    .Endpoint(endpoint)
                    .Timeout(10000)
                    .Execute();

                return client.Result();
            } catch (RestClient<Address>.RestClientException e) {
                throw new AddressServiceException($"Client exception: {e.Message}");
            } catch (Exception e) {
                throw new AddressServiceException($"Unknown exception: {e.Message}");
            }
        }

        public class AddressServiceException : Exception {
            public AddressServiceException(string message)
                : base(message) { }
        }
    }
}
