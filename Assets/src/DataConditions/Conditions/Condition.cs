public class Condition
{

    public IConditionEvent ConditionEvent;
    public IConditionParameters Parameters;
    
    public Condition()
    {
        
    }
    public Condition( IConditionEvent evt , IConditionParameters prms )
    {
        ConditionEvent = evt;
        Parameters = prms;
    }
 
    public bool Evaluate()
    {     
        return ConditionEvent.Evaluate( Parameters );
    }
}