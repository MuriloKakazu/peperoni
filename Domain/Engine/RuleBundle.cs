namespace Domain.Engine {
    public interface RuleBundle<Type> {
        RuleBundle<Type> Apply();
    }
}
