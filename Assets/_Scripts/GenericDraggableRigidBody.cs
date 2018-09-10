using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class GenericDraggableRigidBody : MonoBehaviour {

    float LowestY = -4f;
    private Vector3 offset;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //GetComponent<BoxCollider2D>().sharedMaterial = null;
    }
    void OnMouseDown()
    {
        if (rb.isKinematic) {
            rb.isKinematic = false;
        }
            rb.constraints = RigidbodyConstraints2D.None;
        rb.freezeRotation = true;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

    void OnMouseUp()
    {
        if (rb.isKinematic)
        {
            rb.isKinematic = false;
        }

        rb.freezeRotation = false;
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 2;
    }
    private void FixedUpdate()
    {
        CheckOutOfBOundLow();
    }

    bool isOutOfBound = false;
    void CheckOutOfBOundLow() {
        if (transform.position.y <= LowestY)
        {
            isOutOfBound = true;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            rb.isKinematic = true;
            transform.position = new Vector3(this.transform.position.x, LowestY, this.transform.position.z);
        }
    }
}
