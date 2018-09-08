using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoBrain : MonoBehaviour {
    public GameObject FoodTargetObject;
    public bool _moveToFoodUpdate = false;
    int FoodDirection = 0;
    float speed = 0.038f;
    Animator _animator;
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

  
    //WaitForFood
    public void Action_WaitForFood()
    {
        _animator.speed = 1;
        _animator.SetInteger("DinoState", (int)MyEnums.DinoState.Idle);
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
        _moveToFoodUpdate = true;
        _animator.SetInteger("DinoState", (int)MyEnums.DinoState.Walking);
        _animator.speed = 1;
    }
    //EatFood

    void Start()
    {
        Action_WaitForFood();
        HereIsSomeAmAM(FoodTargetObject);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.M)) {
            Action_TurnToFood();
            Action_MoveToFood();
        }

        if (!_moveToFoodUpdate) return;
        transform.Translate(new Vector3(FoodDirection,0,0) * speed);

    }
}
