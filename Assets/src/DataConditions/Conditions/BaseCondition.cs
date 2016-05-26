using System.Collections.Generic;

/* Base class for all conditions  */
public enum  eConditionTypes
{
    ALL,
    ANY
}
public abstract class BaseCondition : IDataCondition 
{
    public eConditionTypes ConditionType;
    public IConditionAction SuccessAction;
    public IConditionAction FailureAction;
    protected List<Condition> Conditions;
    public abstract void Evaluate();
}