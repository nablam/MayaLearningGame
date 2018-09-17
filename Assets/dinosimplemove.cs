﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinosimplemove : MonoBehaviour {

    public GameObject FoodTargetObject;
    public bool _moveToFoodUpdate = false;
    int FoodDirection = 0;
      Animator _animator;
    MyEnums.DinoState _curState;
    Rigidbody2D rb2d;
    int CurSceneFoodIndex = 0;
     void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();


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
        _animator.speed = 0.75f;
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

    public void ActionJump()
    {
        if (hasJumped  ) return;
        Debug.Log("jumping");
        hasJumped = true;
        _animator.SetBool("hasjumped",hasJumped);
        _moveToFoodUpdate = false;
        _animator.speed = 3;
        _animator.SetTrigger("TrigJump");
        rb2d.AddForce(Vector2.up * 350f);
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


        if (Input.GetKeyDown(KeyCode.Space)) {
            if (  !isgrounded) return;

            ActionJump();
        }
    }

   public  bool isgrounded = false;
    public bool hasJumped = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isgrounded = true;
        hasJumped = false;
        _animator.SetBool("hasjumped", hasJumped);
        _animator.speed = 1;


        // Debug.Log("hit____ " + collision.gameObject.name);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isgrounded = true;
        hasJumped = false;
        _animator.SetBool("hasjumped", hasJumped);
        _animator.speed = 1;


        //  Debug.Log("hitstay " + collision.gameObject.name);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isgrounded = false;

        if (hasJumped)
        {
            _animator.SetBool("hasjumped", hasJumped);
        }
        // Debug.Log("hit_exit " + collision.gameObject.name);

    }


    private void OnColisionEnter2D(Collider2D collision)
    {
     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
  

    }
}