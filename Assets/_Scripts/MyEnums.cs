using UnityEngine;

public class MyEnums : MonoBehaviour {

    public enum ColliderTypes
    {
        Type_Maya,
        Type_Julie,
        Type_Nabil,
        Type_Elmo,
        Type_Cmonster,
        Type_Lion,
        Type_Pasha,
        Type_Minnie,
		Type_Mickey,
		Type_Mouminek,
		Type_Foxy,
		Type_LittleBrother,
		Type_Froggy,
		Type_Zoe
    }

    public enum DinoState
    {
        Idle,
        Walking
    }

    public enum ScrolingState {
        LeftScrolling, //terrain move Right ro left
        Stopped,
        RightScrolling
    }
}
