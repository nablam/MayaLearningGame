using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLandScrol : MonoBehaviour {

    int _id_ofvisibleColumn = 0;

    public int ID_ofvisibleColumn
    {
        get
        {
            return _id_ofvisibleColumn;
        }

        set
        {
            _id_ofvisibleColumn = value;
        }
    }


}
