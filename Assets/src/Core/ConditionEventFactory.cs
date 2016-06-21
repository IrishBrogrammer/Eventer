using System;
using System.Collections.Generic;
public static class ConditionEventFactory
{
	private delegate IConditionEvent CreateEvent();
	private static Dictionary<ConditionEventTypes,CreateEvent> typeDict = new Dictionary<ConditionEventTypes,CreateEvent>();

	public static void Setup()
	{
		typeDict.Add( ConditionEventTypes.IsGreater ,  CreateIsGreaterEvent );
	}
	
	public static IConditionEvent CreateEventType( ConditionEventTypes eType )
	{
		if ( typeDict.ContainsKey( eType  ) )
		{
			return typeDict[eType]();
		}
		UnityEngine.Debug.Log( " Did not find key" );
		return null;	
	}
	
	private static IConditionEvent CreateIsGreaterEvent()
	{
		return new IsGreaterEvent();
	}
	
	
	
}