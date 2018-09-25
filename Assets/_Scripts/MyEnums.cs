using UnityEngine;

public class MyEnums : MonoBehaviour
{

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

    public enum ScrolingState
    {
        LeftScrolling, //terrain move Right ro left
        Stopped,
        RightScrolling
    }

    public enum HillType
    {
        Ascend,
        JoinAscend,
        Flat,
        Descend,
        JoinDescend,
        Dirt,
        Sea
    }
    public enum Season
    {
        Spring,
        Winter,
        Fall,
        Summer
    }
    public enum Pickup
    {
        None,
        CoinPickup,
        FruitPickup,
        VeggiePickeup
    }
    public enum SoundName {
        OK,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Pasha,
        SpaceShip,
        Daddy,
        DaddyNo,
        GoToSpaceShip,
        Mamma,
        MammaNo,
        Maya,
        Mayano

    }
}