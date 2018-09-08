using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCTRL : MonoBehaviour {

    Animator _animator;
        void Start () {
        _animator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
	}
    MyEnums.DinoState _curDinoStateState;
    void UpdateANimatorState() {
        _animator.SetInteger("DinoState", (int)_curDinoStateState);
    }
    public void SetDinoState(int argState) {
        _curDinoStateState= (MyEnums.DinoState) argState ;

    }
    public void Animate_Advancing()
    {
        _animator.speed = 1;
        _animator.SetInteger("DinoState", (int)MyEnums.DinoState.Walking);
    }
    public void Animate_Backingup()
    {
        _animator.speed = -1;
        _animator.SetInteger("DinoState", (int)MyEnums.DinoState.Walking);

    }

    public void TriggerEat()
    {
        _animator.speed = 1;
        _animator.SetTrigger("TrigEat");
    }
    //void Update () {
    //    //if (Input.GetKeyDown(KeyCode.Alpha0)) { _curDinoStateState = MyEnums.DinoState.Idle; }
    //    //else
    //    //if (Input.GetKeyDown(KeyCode.Alpha1)) { _curDinoStateState = MyEnums.DinoState.Walking; }
    //    //else
    //    //if (Input.GetKeyDown(KeyCode.Space)) { _animator.SetTrigger("TrigEat"); }
    //    UpdateANimatorState();

    //}
}
