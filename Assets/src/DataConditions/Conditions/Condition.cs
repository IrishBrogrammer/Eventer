
public class Condition
{
    public IConditionEvent ConditionEvent;
    public IConditionParameters Parameters;
    public bool Evaluate()
    {
        return ConditionEvent.Evaluate( Parameters );
    }
}