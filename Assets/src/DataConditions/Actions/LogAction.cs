using UnityEngine;

public class LogAction : IConditionAction
{
    public string message;
  
    public void PerformAction( IConditionActionParameters parameters )
    {
        var actionParams = parameters as LogActionParameters;
        message = actionParams.Message;
        Debug.Log( message );
    }
    
}