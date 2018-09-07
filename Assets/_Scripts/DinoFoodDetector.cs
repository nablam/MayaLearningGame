using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFoodDetector : MonoBehaviour
{

    public DinoCTRL _dinoctrl;
    public GameObject FoodTargetObject;

    private void Awake()
    {
        _dinoctrl = GetComponent<DinoCTRL>();
        FoodTargetObject = GameObject.FindGameObjectWithTag("DinoFood");
    }
    float DistToFood = -1f; //enforce negative value as NOFOOD
    void CheckDistIfPossible()
    {
        if (FoodTargetObject != null)
        {
            DistToFood = Vector3.Distance(this.transform.position, FoodTargetObject.transform.position);
        }
        else
        {
            DistToFood = -1;
        }

        if (DistToFood > 0.1 && DistToFood < 4.2f) {
            _dinoctrl.TriggerEat();
            Destroy(FoodTargetObject);
        }
    }

    private void Update()
    {
        CheckDistIfPossible();
       // Debug.Log(Vector3.Distance(this.transform.position, FoodTargetObject.transform.position));
    }

    private void OnTriggerEnter2D(Collider2D argCollider)
    {
        Debug.Log("foood");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("foood????collision");

    }
}
