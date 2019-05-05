using Newtonsoft.Json;
using System;

namespace Data.Model.Geolocation {
    [Serializable]
    public class Address {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [JsonProperty("cep")]
        public string PostalCode { get; set; }
        public string Country { get; set; } = "Brasil";
        [JsonProperty("uf")]
        public string FederativeUnit { get; set; }
        [JsonProperty("localidade")]
        public string City { get; set; }
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }
        [JsonProperty("logradouro")]
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Additional { get; set; }
    }
}
