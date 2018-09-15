using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinosimplemove : MonoBehaviour {

    public GameObject FoodTargetObject;
    public bool _moveToFoodUpdate = false;
    int FoodDirection = 0;
      Animator _animator;
    MyEnums.DinoState _curState;
    int CurSceneFoodIndex = 0;
     void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
 
    }
    void Start()
    {
        
        Action_WaitForFood();
     
    }


    //WaitForFood
    public void Action_WaitForFood()
    {
        _curState = MyEnums.DinoState.Idle;
        _animator.speed = 1;
        _animator.SetInteger("DinoState", (int)_curState);
        _moveToFoodUpdate = false;
    }
   
    //TurnToFood
    public void Action_Direction(int arg)
    {
        transform.GetChild(0).localScale = new Vector3(arg, 1, 1);
    }
    //MoveToFood
    public void Action_MoveToFood()
    {
        _curState = MyEnums.DinoState.Walking;
        _moveToFoodUpdate = true;
        _animator.speed = 1;
        _animator.SetInteger("DinoState", (int)_curState);
    }
    //EatFood
    public void Action_EatFood()
    {
        Debug.Log("nom nom nom");
        _moveToFoodUpdate = false;
        _animator.speed = 1;
        _animator.SetTrigger("TrigEat");
    }
   

  
    

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha0)) { _curDinoStateState = MyEnums.DinoState.Idle; }
        //else
        //if (Input.GetKeyDown(KeyCode.Alpha1)) { _curDinoStateState = MyEnums.DinoState.Walking; }
        //else
        //if (Input.GetKeyDown(KeyCode.Space)) { _animator.SetTrigger("TrigEat"); }


        //if (Input.GetKey(KeyCode.LeftArrow)) { this.transform.Translate(Vector2.right * 0.06f); }
        //else
        //   if (Input.GetKey(KeyCode.RightArrow)) { this.transform.Translate(Vector2.left * 0.06f); }
        //else
        //    this.transform.Translate(Vector2.left * 0);

        //  UpdateANimatorState();

    }
}
