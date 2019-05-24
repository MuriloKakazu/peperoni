using Infrastructure.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Infrastructure.Client {

    public class RestClient<ResponseType> {
        protected HttpClient Client { get; set; }
        protected HttpRequestMessage Request { get; set; }
        protected HttpResponseMessage Response { get; set; }
        protected ICollection<HttpStatusCode> ExpectedStatuses { get; set; }

        public RestClient() {
            Client = new HttpClient();
            Request = new HttpRequestMessage();
            Response = new HttpResponseMessage();
            ExpectedStatuses = new List<HttpStatusCode>();
        }

        public RestClient<ResponseType> Header(string key, string value) {
            Request.Headers.Add(key, value);

            return this;
        }

        public RestClient<ResponseType> Header(IDictionary<string, string> values) {
            foreach (var key in values.Keys) {
                var value = values[key];
                Header(key, value);
            }

            return this;
        }

        public RestClient<ResponseType> Expect(HttpStatusCode statusCode) {
            ExpectedStatuses.Add(statusCode);

            return this;
        }

        public RestClient<ResponseType> Expect(ICollection<HttpStatusCode> statusCodes) {
            foreach (var status in statusCodes) {
                Expect(status);
            }

            return this;
        }

        public RestClient<ResponseType> Method(HttpMethod method) {
            Request.Method = method;

            return this;
        }

        public RestClient<ResponseType> Endpoint(Uri endpoint) {
            Request.RequestUri = endpoint;

            return this;
        }

        public RestClient<ResponseType> Endpoint(string endpoint) {
            return Endpoint(new Uri(endpoint));
        }

        public RestClient<ResponseType> Body(string body) {
            Request.Content = new StringContent(body);

            return this;
        }

        public RestClient<ResponseType> Timeout(int timeoutMs) {
            return Timeout(TimeSpan.FromMilliseconds(timeoutMs));
        }

        public RestClient<ResponseType> Timeout(TimeSpan timeSpan) {
            Client.Timeout = timeSpan;

            return this;
        }

        public RestClient<ResponseType> Execute() {
            Response = Client.SendAsync(Request).Result;

            if (!ExpectedStatuses.Contains(Response.StatusCode)) {
                throw new RestClientException($"Unexpected status code: {Response.StatusCode.Format()}");
            }

            return this;
        }

        public ResponseType Result() {
            var isSuccessful = (bool) Response?.IsSuccessStatusCode;

            if (isSuccessful) {
                return JsonConvert.DeserializeObject<ResponseType>(Response.Content.ReadAsStringAsync().Result);
            } else {
                throw new RestClientException("Can not retrieve result from unsuccessful response.");
            }
        }

        public class RestClientException : Exception {
            public RestClientException(string message)
                : base(message) { }
        }
    }
}