
public interface IConditionEvent
{
    void SetConditionEventType( string type );
    string GetConditionEventType();
    bool Evaluate( IConditionParameters parameters );
}