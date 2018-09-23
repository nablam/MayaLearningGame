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
