using UnityEngine;

public class LogAction : IConditionAction
{
    public LogAction( string msg )
    {
        message = msg;
    }
    
    
    private string message;
    
    
    public void PerformAction()
    {
        Debug.Log( message );
    }
    
}