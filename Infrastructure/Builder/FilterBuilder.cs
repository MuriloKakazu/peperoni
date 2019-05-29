using Infrastructure.Data;

namespace Infrastructure.Builder {
    public class FilterBuilder {
        private Filter Filter { get; set; }

        public FilterBuilder() {
            Filter = new Filter();
        }

        public FilterBuilder WithKey(string key) {
            Filter.Key = key;
            return this;
        }

        public FilterBuilder WithValue(object value) {
            Filter.Value = value;
            return this;
        }

        private void SetParameter() {
            Filter.Parameter = new ParameterBuilder<object>()
                .WithName(Filter.Key)
                .WithValue(Filter.Value)
                .Build();
        }

        public Filter Build() {
            SetParameter();
            return Filter;
        }
    }
}
