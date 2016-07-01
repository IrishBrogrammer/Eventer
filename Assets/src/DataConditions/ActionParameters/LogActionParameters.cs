
public class  LogActionParameters : IConditionActionParameters
{
	public string Message;
	
	public LogActionParameters( string Message )
	{
		UnityEngine.Debug.Log( " Action paramer loader called" );
		this.Message = Message;
	}
	
	
}