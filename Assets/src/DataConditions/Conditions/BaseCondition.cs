using System.Collections.Generic;

/* Base class for all conditions  */
public enum  eConditionTypes
{
    ALL,
    ANY
}
public abstract class BaseCondition : IDataCondition 
{
    public string ConditionType;
    public EventerAction SuccessAction;
    public EventerAction FailureAction;
    public List<Condition> Conditions;
    public abstract void Evaluate();
}