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
    public List<Condition> Conditions;
    public abstract void Evaluate();
}