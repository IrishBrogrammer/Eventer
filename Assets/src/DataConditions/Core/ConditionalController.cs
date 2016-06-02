using System.Collections.Generic;

public class ConditionalController
{
    public void EvaluateConditions( List<BaseCondition> conditionsToTest )
    {
        foreach( var cond in conditionsToTest )
            cond.Evaluate();
    }
    
}