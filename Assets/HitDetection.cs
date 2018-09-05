using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {

    public MyEnums.ColliderTypes Type;
	// Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigg");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DragMe>().Type == Type) {
            Destroy(this.gameObject);
        }
    }
}
