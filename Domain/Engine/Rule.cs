namespace Domain.Engine {
    public interface Rule<Type> {
        Rule<Type> Apply(Type value);
    }
}
