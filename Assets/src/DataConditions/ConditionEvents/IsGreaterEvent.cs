
public class IsGreaterEvent : BaseConditionEvent
{
    public override bool Evaluate( IConditionParameters parameters )
    {
        IsGreaterParameters param = parameters as IsGreaterParameters;
        
        if ( param == null )
            return false; 
        
        return param.Value > param.MinValue;
    }
    
}