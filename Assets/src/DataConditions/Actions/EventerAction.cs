using System;

public class EventerAction
{
	public IConditionAction action;
	public IConditionActionParameters parameters;
	
	public EventerAction( IConditionAction act , IConditionActionParameters actionParameters )
	{
		action = act;
		parameters = actionParameters;
	}
	
	public void InvokeAction()
	{
		action.PerformAction( parameters );
	}
	
}