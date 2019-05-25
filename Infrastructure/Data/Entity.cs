namespace Infrastructure.Data {
    public interface Entity {
        string Id { get; set; }

        bool HasId();
    }
}