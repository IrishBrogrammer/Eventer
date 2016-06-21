

public class AllTrueCondition : BaseCondition
{
    public override void Evaluate()
    {
       foreach( var cond in Conditions )
       {      
           if ( cond.Evaluate() == false )
           {
              //FailureAction.PerformAction();
              return;
           }
       }
       //SuccessAction.PerformAction();
    }
    
}