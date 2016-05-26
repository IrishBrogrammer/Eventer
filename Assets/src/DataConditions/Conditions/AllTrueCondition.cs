

public class AllTrueCondition : BaseCondition
{
    public override void Evaluate()
    {
       foreach( var cond in Conditions )
            cond.Evaluate();
        
    }
    
}