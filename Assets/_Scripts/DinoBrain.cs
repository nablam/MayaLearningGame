using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBrain : MonoBehaviour {
    public GameObject FoodTargetObject;
    public bool _moveToFoodUpdate = false;
    int FoodDirection = 0;
    float DistToFood = -1f; //enforce negative value as NOFOOD
    float speed = 0.038f;
    Animator _animator;
    MyEnums.DinoState _curState;
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

  
    //WaitForFood
    public void Action_WaitForFood()
    {
        _curState = MyEnums.DinoState.Idle;
        _animator.speed = 1;
        _animator.SetInteger("DinoState", (int)_curState);
        _moveToFoodUpdate = false;
    }
    //HereIsSomeAmAM
    public void HereIsSomeAmAM(GameObject argAmAM) {
        //if (FoodTargetObject != null)
          //  Destroy(FoodTargetObject);
        FoodTargetObject = argAmAM;
        FoodDirection = (FoodTargetObject.transform.position.x < this.transform.position.x) ? -1 : 1;
    } 
    //TurnToFood
    public void Action_TurnToFood() {
            transform.GetChild(0).localScale = new Vector3(FoodDirection, 1, 1);         
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
    public void Action_EatFood() {
        Debug.Log("nom nom nom");
        _moveToFoodUpdate = false;
        _animator.speed = 1;
        _animator.SetTrigger("TrigEat");
    }
    void CheckDistIfPossible()
    {
        if (FoodTargetObject != null)
        {
            DistToFood = Vector3.Distance(this.transform.position, FoodTargetObject.transform.position);
        }
        else
        {
            DistToFood = -1;
            Debug.Log("YOO NO DIST FOOD");
        }

        if (DistToFood > 0.1 && DistToFood < 4.2f &&  _curState != MyEnums.DinoState.Idle)
        {
            Action_EatFood();
            Action_WaitForFood();//anim should play through then go to idle 
            Destroy(FoodTargetObject,4f);
        }
    }

    void Start()
    {
        Action_WaitForFood();
        HereIsSomeAmAM(FoodTargetObject);
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.M)) {
            if (FoodTargetObject != null)
            {
                Action_WaitForFood();
                HereIsSomeAmAM(FoodTargetObject);
                Action_TurnToFood();
                Action_MoveToFood();
            }
            else {
                Debug.Log("no food found");
            }
       
        }

        if (!_moveToFoodUpdate) return;
        CheckDistIfPossible();
        transform.Translate(new Vector3(FoodDirection,0,0) * speed);

    }
}
