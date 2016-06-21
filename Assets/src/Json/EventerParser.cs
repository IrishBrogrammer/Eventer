using ExtensionMethods;
using System.Collections.Generic;
// Give valid json parse it and load it into a collection of EventerConditions
public class EventerParser
{
	private readonly EventerTypeContainer ParameterContainer;
	
	public EventerParser()
	{
		ParameterContainer = new EventerTypeContainer( typeof( IConditionParameters) );
	}
	
	
	public List<IDataCondition> ParseJson( string jsonText )
	{
		IList<object> oList = fastJSON.JSON.Parse( jsonText ) as IList<object>;
		
		List<IDataCondition> conditions = new List<IDataCondition>();
		
		foreach( var obj in oList )
		{
			Dictionary<string,object> objDict = obj as Dictionary<string,object>;	
			conditions.Add( CreateDataCondition( objDict ) );
		}	
		
		return conditions;
	}
	
	private IDataCondition CreateDataCondition( Dictionary<string,object> obj  )
	{
		if ( obj.ContainsKey( "ConditionType") == false ) 
		{
			UnityEngine.Debug.Log( " Type not specified" );
			return null;
		}
		
		
		string condType = obj["ConditionType"] as string;
		
		var dataCond = new  AllTrueCondition();
		
		List<Condition> conditions = new List<Condition>();
		if ( obj.ContainsKey( "Conditions") == false )
		{
			IList<object> oList = obj["Conditions"] as IList<object>;
			conditions = LoadConditions( oList );
		}
		
		dataCond.Conditions = conditions;
		
		
		return dataCond;	
	}
	
	private List<Condition> LoadConditions( IList<object> oList )
	{
		List<Condition> conditions = new List<Condition>();
		
		foreach( var obj in oList )
		{
			Dictionary<string,object> objDict = obj as Dictionary<string,object>;	
			conditions.Add( CreateCondition( objDict ) );	
		}	
		
		return conditions;
	}

	private Condition CreateCondition( Dictionary<string,object> obj )
	{
		return new Condition(
			 CreateConditionEvent( obj ), 
			 CreateConditionParameters( obj )
		);
	}
	
	private IConditionEvent CreateConditionEvent( Dictionary<string,object> obj )
	{
		if ( obj.ContainsKey( "ConditionEvent") == false )
		{
			UnityEngine.Debug.Log( " Could not find event type on condition passed in" );
			return null;
		}
		
		string eventType = obj["ConditionEvent"] as string;		
		return ConditionEventFactory.CreateEventType( eventType.ToEnum<ConditionEventTypes>() );
	}
	
	private IConditionParameters CreateConditionParameters( Dictionary<string,object> obj )
	{
		if ( obj.ContainsKey( "ConditionParams" ) == false )
		{
			UnityEngine.Debug.Log( " Could not find event parameters on condition passed in" );	
		}		
		
		var conditionObj = obj["ConditionParams"] as Dictionary<string,object>;
		return ParameterContainer.CreateInstanceOfType( conditionObj ) as IConditionParameters; 
	}
	
}