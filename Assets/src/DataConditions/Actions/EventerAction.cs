using System;

public class EventerAction
{
	public IConditionAction action;
	public IConditionActionParameters parameters;
	
	public EventerAction( IConditionAction act , IConditionActionParameters actionParameters )
	{
		act = action;
		parameters = actionParameters;
	}
	
	public void InvokeAction()
	{
		action.PerformAction( parameters );
	}
	
}