using System;
using System.Collections.Generic;
public static class ConditionEventFactory
{
	private static ConditionFactory<IConditionEvent,ConditionEventTypes> factory = new ConditionFactory<IConditionEvent,ConditionEventTypes>();
	
	public static void Setup()
	{
		Dictionary<ConditionEventTypes,Type> typeDict = new Dictionary<ConditionEventTypes,Type>();
		typeDict.Add( ConditionEventTypes.IsGreater ,  typeof(IsGreaterEvent ) );
		
		factory.Setup( typeDict );
	}
	
	public static IConditionEvent CreateEventType( ConditionEventTypes eType )
	{
		return factory.CreateEventType( eType );	
	}

	
}