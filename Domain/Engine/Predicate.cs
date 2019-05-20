namespace Domain.Engine {
    public interface Predicate<Type> {
        bool IsValid(Type value);
    }
}
