using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatIt : MonoBehaviour {

    public  bool Seat1_Ocupied;
    public Transform Seat_1;
    GameObject curSeatedBuddy_seat1;

    private void OnTriggerEnter2D(Collider2D argCollider)
    {
        if (Seat1_Ocupied) { Lockitplz_singleSeat(argCollider); return; }
        Occupy_Seat1(argCollider);
    }

    void Occupy_Seat1(Collider2D argCollider)
    {
        if (argCollider.gameObject.CompareTag("Buddy"))
        {
            GameObject newBuddy = Instantiate(argCollider.gameObject, Seat_1.position, Quaternion.identity);
            Seat1_Ocupied = true;
            curSeatedBuddy_seat1 = newBuddy;
            Destroy(argCollider.gameObject);
        }
    }




    void Vaate_SingleSeat_(Collider2D argCollider) {
        if (argCollider.gameObject.CompareTag("Buddy"))
        {
            if (curSeatedBuddy_seat1 != null)
            {
                if (curSeatedBuddy_seat1.GetInstanceID() == argCollider.gameObject.GetInstanceID())
                {

                    Seat1_Ocupied = false;
                    curSeatedBuddy_seat1 = null;
                }
            }
           
            //else if (curSeatedBuddy_seat2.GetInstanceID() == argCollider.gameObject.GetInstanceID())
            //{

            //    Seat2_Ocupied = false;
            //    curSeatedBuddy_seat2 = null;
            //}

        }

    }

    void Vacate_seat1(Collider2D argCollider)
    {
        if (argCollider.gameObject.CompareTag("Buddy"))
        {
            if (curSeatedBuddy_seat1.GetInstanceID() == argCollider.gameObject.GetInstanceID())
            {
                Seat1_Ocupied = false;
                curSeatedBuddy_seat1 = null;
            }
           
        }

    }

    void Lockitplz_singleSeat(Collider2D argCollider) {
        if (Seat1_Ocupied)
        {
            argCollider.gameObject.GetComponent<DragMe>().Lockit();
        }
    }

    public void OneTime_lock_MyBuddySittingonme() {

        if (Seat1_Ocupied)
        {
            curSeatedBuddy_seat1.transform.parent = this.transform;
            curSeatedBuddy_seat1.GetComponent<DragMe>().SetOneTimeLock();

        }
    }

    private void OnTriggerExit2D(Collider2D argCollider)
    {
        Vaate_SingleSeat_(argCollider);
    }


}
