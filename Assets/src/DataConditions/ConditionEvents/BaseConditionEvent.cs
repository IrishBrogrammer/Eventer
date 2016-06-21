
public abstract class BaseConditionEvent : IConditionEvent 
{
	public string ConditionType;
	public void SetConditionEventType( string type )
	{
		ConditionType = type;
	}
	public string GetConditionEventType()
	{
		return ConditionType;
	}
	
	public abstract bool Evaluate( IConditionParameters parameters );
}