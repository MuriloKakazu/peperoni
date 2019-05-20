namespace Domain.Builder {
    public interface IBuilder<Type> {
        Type Build();
    }
}
