using UnityEngine;
using System.Collections.Generic;

public class scenetest : MonoBehaviour {
	
	public TextAsset testJson;
	
	private EventerTypeContainer ParameterContainer;
	
	private EventerParser eventParser;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log( " Starting tests " );
		eventParser = new EventerParser();	
		//RunTests();
		LoadJson();
	}
	
	private void LoadJson()
	{
		ConditionEventFactory.Setup();
		Debug.Log( " Brian" );
		if ( testJson.text != null )
			Debug.Log( testJson.text );
			
		var jsonString = testJson.text;
	
		eventParser.ParseJson( jsonString );				
	}
	
	
	
	private List<BaseCondition> CreateConditionList()
	{
		BaseCondition firstTest = new AllTrueCondition();
		firstTest.ConditionType = "ALL";
	//	firstTest.FailureAction = new LogAction( "Failed action" );
	//	firstTest.SuccessAction = new LogAction( " Sucess Action" );
		
		List<Condition> conditionList = new List<Condition>();
		var cond = new Condition();
		cond.ConditionEvent = new IsGreaterEvent();
		cond.ConditionEvent.SetConditionEventType( "IsGreater" );
		cond.Parameters = new IsGreaterParameters( 7 , 5 );
		conditionList.Add( cond );
		
		cond = new Condition();
		cond.ConditionEvent = new IsGreaterEvent();
		cond.Parameters = new IsGreaterParameters( 2 , 5 );	
		conditionList.Add( cond );
		
		firstTest.Conditions = conditionList;
		
		List<BaseCondition> testList = new List<BaseCondition>();
		testList.Add( firstTest );
		return testList;
	}
	
	
	
	void RunTests()
	{
		
		Debug.Log( " All tests successful" );
		
		var testList = CreateConditionList();
		var controller = new ConditionalController();
		
		controller.EvaluateConditions( testList );
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
