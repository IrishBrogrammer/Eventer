using ExtensionMethods;
using System.Collections.Generic;
// Give valid json parse it and load it into a collection of EventerConditions
public class EventerParser
{
	private readonly EventerTypeContainer ParameterContainer;
	private readonly EventerTypeContainer ActionsParameterContainer;
	
	public EventerParser()
	{
		ParameterContainer = new EventerTypeContainer( typeof( IConditionParameters) );
		ActionsParameterContainer = new EventerTypeContainer( typeof( IConditionActionParameters ) );
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
		if ( obj.ContainsKey( "Conditions") )
		{
			IList<object> oList = obj["Conditions"] as IList<object>;
			dataCond.Conditions = LoadConditions( oList );
		}
		else
		{
			UnityEngine.Debug.Log( " no conditions found " );
		}
				
		dataCond.SuccessAction = LoadAction( "SuccessAction" , obj );
		dataCond.FailureAction = LoadAction( "FailureAction" , obj );	
		
		dataCond.SuccessAction.InvokeAction();
		
		return dataCond;	
	}
	
	private EventerAction LoadAction( string key , Dictionary<string,object> obj )
	{
		if ( obj.ContainsKey( key ) )
		{
			var actionDict = obj[key] as Dictionary<string,object>;
			return CreateAction( actionDict );
		}
		
		return null;
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
			CreateParameter<IConditionParameters>( "ConditionParams" , ParameterContainer , obj )
		);
	}
	
	private EventerAction CreateAction(  Dictionary<string,object> obj )
	{
		return new EventerAction(
			CreateActionEvent( "Action" , obj ),
			CreateParameter<IConditionActionParameters>( "Params" , ActionsParameterContainer , obj )
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
	
	private IConditionAction CreateActionEvent( string keyName ,  Dictionary<string,object> obj )
	{
		if ( obj.ContainsKey( keyName ) == false  )
		{
			UnityEngine.Debug.Log( " Could not find action on condition passed in" );
			return null;
		}
		
		string eventType = obj[keyName] as string;
		return ConditionActionFactory.CreateActionType( eventType.ToEnum<ConditionActionTypes>() );
	}
	
	

	private static T CreateParameter<T>( string keyName , EventerTypeContainer container ,  Dictionary<string,object> obj )
	{
		if ( obj.ContainsKey( keyName ) == false )
		{
			UnityEngine.Debug.Log( " Could not find parameter loader for " + keyName );
		}

		var conditionObj = obj[keyName] as Dictionary<string,object>;
		return (T)container.CreateInstanceOfType( conditionObj );

	}
	
}