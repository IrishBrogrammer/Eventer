using System;
using System.Collections.Generic;

[System.Serializable]
public class ConditionContainer
{
	public List<RiskyDepth> ScreenConditions;
}



public abstract class TestDepth 
{
	public int Score;
	
	public abstract int GetScore();
}

public class RiskyDepth : TestDepth 
{
	public override int GetScore()
	{
		return Score;
	}
	
}


public class MultipleDepth : RiskyDepth
{
	public int Layer;
	public override int GetScore()
	{
		return Score * Layer;
	}
}