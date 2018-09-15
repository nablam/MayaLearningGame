using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleBackgroundCtrl : MonoBehaviour {
    public GameObject BS_Sky_L;
    public GameObject BS_Sky_M;
    public GameObject BS_Sky_R;
    List<GameObject> BS_Sky;
    public GameObject BS_Skyhill_L;
    public GameObject BS_Skyhill_M;
    public GameObject BS_Skyhill_R;
    List<GameObject> BS_Skyhills;
    public GameObject BS_Hill1_L;
    public GameObject BS_Hill1_M;
    public GameObject BS_Hill1_R;
    List<GameObject> BS_Hill1;
    public GameObject BS_Hill2_L;
    public GameObject BS_Hill2_M;
    public GameObject BS_Hill2_R;
    List<GameObject> BS_Hill2;

    public List<GameObject> Get_SkYs() { return this.BS_Sky; }
    public List<GameObject> Get_BS_Skyhills() { return this.BS_Skyhills; }
    public List<GameObject> Get_BS_Hill1() { return this.BS_Hill1; }
    public List<GameObject> Get_BS_Hill2() { return this.BS_Hill2; }



    public GameObject Back_Cloud1;
    public GameObject Back_Cloud2;


    void Start () {
        BS_Skyhills = new List<GameObject>();
        BS_Skyhills.Add(BS_Skyhill_L);
        BS_Skyhills.Add(BS_Skyhill_M);
        BS_Skyhills.Add(BS_Skyhill_R);
        BS_Sky = new List<GameObject>();
        BS_Sky.Add(BS_Sky_L);
        BS_Sky.Add(BS_Sky_M);
        BS_Sky.Add(BS_Sky_R);
        BS_Hill1 = new List<GameObject>();
        BS_Hill1.Add(BS_Hill1_L);
        BS_Hill1.Add(BS_Hill1_M);
        BS_Hill1.Add(BS_Hill1_R);
        BS_Hill2 = new List<GameObject>();
        BS_Hill2.Add(BS_Hill2_L);
        BS_Hill2.Add(BS_Hill2_M);
        BS_Hill2.Add(BS_Hill2_R);
 


    }



    // Update is called once per frame
    void Update () {
        CheckAllForRollOver(BS_Skyhills);
        CheckAllForRollOver(BS_Sky);
        CheckAllForRollOver(BS_Hill1);
        CheckAllForRollOver(BS_Hill2);




    }

    void CheckAllForRollOver(List<GameObject> argBacks) {
        foreach (GameObject gobs in argBacks)
        {
            if (gobs.transform.position.x > 19.2f)
            {
                gobs.transform.position = new Vector3(-19.20f, gobs.transform.position.y, gobs.transform.position.z);
            }
            if (gobs.transform.position.x < -19.2f)
            {
                gobs.transform.position = new Vector3(19.20f, gobs.transform.position.y, gobs.transform.position.z);
            }
        }
    }
}
