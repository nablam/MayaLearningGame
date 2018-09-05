using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCTRL : MonoBehaviour {
    public List<SeatIt> MySeats;


    void Start () {
		
	}
    bool AllreadyLockedDragMees;
    bool AllAreSeated;
         // Update is called once per frame
	void Update () {
        if (AllAreSeated) {  return; }
        int Counted_OccupiedSeats = 0;

        for (int x =0; x< MySeats.Count; x++) {
            if (MySeats[x].Seat1_Ocupied) {
                Counted_OccupiedSeats++;
            }
        }
        if (Counted_OccupiedSeats == MySeats.Count) {
            AllAreSeated = true;
            Debug.Log("ALL ABOARD");
            foreach (SeatIt st in MySeats) {
                st.OneTime_lock_MyBuddySittingonme();
            }
            GetComponent<TrainMover>().TurnEnginsOn();
        }
	}
}
