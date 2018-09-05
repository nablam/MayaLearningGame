using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMe : MonoBehaviour {

    float deltax, deltay;
    Rigidbody2D rb;
    bool moveallowed = false;
    public MyEnums.ColliderTypes Type;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //PhysicsMaterial2D mat = new PhysicsMaterial2D();
        //mat.bounciness = 0.45f;
        //mat.friction = 0.4f;
        //GetComponent<BoxCollider2D>().sharedMaterial = mat;

        rb.freezeRotation = true;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        GetComponent<BoxCollider2D>().sharedMaterial = null;
    }



    private Vector3 offset;

    void OnMouseDown()
    {
        if (OneTimeLock) return;


        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }


    bool IsLocked;
    public void Lockit() {
        IsLocked = true;
    }
    void OnMouseUp()
    {
        if (OneTimeLock) return;

        if (IsLocked) { IsLocked = false; }
       
    }

    void OnMouseDrag()
    {
        if (OneTimeLock) return;

        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

    // Update is called once per frame

    public bool OneTimeLock; //for ready to start train. should no longer have access to touch drag// called from seat only
    public void SetOneTimeLock() { OneTimeLock = true; }

    void LateUpdate () {
        if (OneTimeLock) return;

        if (IsLocked) return;
        DragFoo();

    }

    void DragFoo() {
        if (OneTimeLock) return;

        if (Input.touchCount > 0) {
            Touch tch = Input.GetTouch(0);
            Vector2 TouchPos = Camera.main.ScreenToWorldPoint(tch.position);
            switch (tch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(TouchPos)){
                        deltax = TouchPos.x - transform.position.x;
                        deltay = TouchPos.y - transform.position.y;
                        moveallowed = true;

                        rb.freezeRotation = true;
                        rb.velocity = new Vector2(0, 0);
                        rb.gravityScale=0;
                        GetComponent<BoxCollider2D>().sharedMaterial = null;

                    }
                    break;

                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(TouchPos) && moveallowed)
                    {
                        rb.MovePosition(new Vector2(TouchPos.x - deltax, TouchPos.y - deltay ));
                    }
                        break;
                case TouchPhase.Ended:
                    moveallowed = false;
                    rb.freezeRotation =false;
                    rb.velocity = new Vector2(0, 0);
                    rb.gravityScale = 2;
                    PhysicsMaterial2D mat = new PhysicsMaterial2D();
                    mat.bounciness = 0.45f;
                    mat.friction = 0.4f;
                    GetComponent<BoxCollider2D>().sharedMaterial = mat;
                    break;
            }

        }

    }
}
