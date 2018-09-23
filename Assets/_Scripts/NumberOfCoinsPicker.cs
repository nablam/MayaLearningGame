using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberOfCoinsPicker : MonoBehaviour {

    public TextMesh tm;

    int randXpos; //min -7 max 7 
    int randYPos; //min -4 max 4
    int numOfCoins = 1; //stick 1 through 5 for now, maybe check the current date and increment accordingly

    

	void Start () {
        tm.transform.position = new Vector3(Random.Range(-7, 8), Random.Range(-4, 5), 1);
        numOfCoins = Random.Range(1, 6);
        tm.text = numOfCoins.ToString();
        if (PersistantScript.Instance != null)
        {
            PersistantScript.Instance.CoinsToPickup = numOfCoins;
        }
        StartCoroutine(Wait5Seconds());
    }

    IEnumerator Wait5Seconds() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("CoinsScene");

    }

}
