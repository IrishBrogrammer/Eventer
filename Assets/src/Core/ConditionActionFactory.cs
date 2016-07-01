using System;
using System.Collections.Generic;

public static class ConditionActionFactory
{
	private static ConditionFactory<IConditionAction,ConditionActionTypes> factory = new ConditionFactory<IConditionAction,ConditionActionTypes>();
	
	public static void Setup()
	{
		Dictionary<ConditionActionTypes,Type> typeDict = new Dictionary<ConditionActionTypes,Type>();
		typeDict.Add( ConditionActionTypes.UnityLogMessage ,  typeof( LogAction ) );
		factory.Setup( typeDict );
	}
	
	public static IConditionAction CreateActionType( ConditionActionTypes eType )
	{
		UnityEngine.Debug.Log( " Action type is " + eType.ToString() );
		return factory.CreateEventType( eType );	
	}

	
}