using System;
using System.Collections.Generic;
public class ConditionFactory<TOne,TTwo>
{
	private Dictionary<TTwo,Type> typeDict = new Dictionary<TTwo,Type>();

	public void Setup( Dictionary<TTwo,Type> dict )
	{
		typeDict = dict;
		//typeDict.Add( ConditionEventTypes.IsGreater ,  CreateIsGreaterEvent );
	}
	
	public TOne CreateEventType( TTwo eType )
	{
		UnityEngine.Debug.Log( " The key was " + eType.ToString() );
		if ( typeDict.ContainsKey( eType  ) )
		{
			return (TOne)Activator.CreateInstance( typeDict[eType] );
		}
		UnityEngine.Debug.Log( " Did not find key" );
		return default(TOne);	
	}
	
	
}