using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCTRL : MonoBehaviour {

    public GameObject Maya;
    public GameObject Julie;
    public GameObject Nabil;

    bool Mayaplaced = false;
    bool Julieplaced = false;
    bool Nabilplaced = false;

    bool ShipLAunched = false;
    
   
    
    // Use this for initialization
    void Start () {
       // Debug.Log("on "+ gameObject.name);
        Maya.SetActive(false);
        Julie.SetActive(false);
        Nabil.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Mayaplaced && Nabilplaced && Julieplaced) {
            if (!ShipLAunched)
            StartCoroutine(Launchin2());
        }
        if (ShipLAunched) {
            transform.Translate(Vector2.up * 0.15f);
        }
    }
    IEnumerator Launchin2() {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.ShowCanvas();
        GameManager.Instance.ShowGoToMonne();
    }

    IEnumerator ShowResteIn5()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ShowReset();
        
    }

    public void Ignition() {
        ShipLAunched = true;
        StartCoroutine(ShowResteIn5());
    }

    private void OnTriggerEnter2D(Collider2D argCollider)
    {
        Debug.Log("trigg");
        Debug.Log("hit");
        if (argCollider.gameObject.GetComponent<DragMe>().Type == MyEnums.ColliderTypes.Type_Maya)
        {
            Destroy(argCollider.gameObject);
            Maya.SetActive(true);
            Mayaplaced = true;

        }
        else
        if (argCollider.gameObject.GetComponent<DragMe>().Type == MyEnums.ColliderTypes.Type_Julie)
        {
            Destroy(argCollider.gameObject);
            Julie.SetActive(true);
            Julieplaced = true;

        }
        else
        if (argCollider.gameObject.GetComponent<DragMe>().Type == MyEnums.ColliderTypes.Type_Nabil)
        {
            Destroy(argCollider.gameObject);
            Nabil.SetActive(true);
            Nabilplaced = true;

        }
    }
 


}
