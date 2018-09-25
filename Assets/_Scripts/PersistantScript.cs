using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantScript : MonoBehaviour {
    /// <summary>
    ///  This Script is set to execute first ! in order to insure that we don't have a null instance when other scripts try to access this in otherscripts.awake
    /// </summary>
    public static PersistantScript Instance = null;
    void Awake () {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            _coinsToPickup = 3;
            _coinsToPickupMapSize = _coinsToPickup * 10;
        }


	}
   public AudioSource audioData;
    AudioSource[] audioDataChildren;

    void Start()
    {
        curaudioIndex = 0;
        audioDataChildren = GetComponentsInChildren<AudioSource>();
        
        Debug.Log("found "+ audioDataChildren.Length + " audio source");
        audioData = GetComponent<AudioSource>();
       // audioData.Play(0);
    }

    public void PlayAudio(MyEnums.SoundName argSoundName) {
        transform.GetChild((int)argSoundName).GetComponent<AudioSource>().Play(0);
    }

    int curaudioIndex;
    public void PlayAudioCycle() {
        if (curaudioIndex >= audioDataChildren.Length) curaudioIndex = 0;
        if (curaudioIndex < 0) curaudioIndex = audioDataChildren.Length;
        transform.GetChild(curaudioIndex++).GetComponent<AudioSource>().Play(0);
    }

        int _coinsToPickup;
    public int CoinsToPickup
    {
        get
        {
            return _coinsToPickup;
        }

        set
        {
            _coinsToPickup = value;
        }
    }

    int _coinsToPickupMapSize;
    public int CoinsToPickupMapSize
    {
        get
        {
            return _coinsToPickupMapSize;
        }

        set
        {
            _coinsToPickupMapSize = value;
            _coinsToPickupMapSize = _coinsToPickup * 10;
        }
    }
}
