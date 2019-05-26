namespace Infrastructure.Builder {
    public interface IBuilder<Type> {
        Type Build();
    }
}
