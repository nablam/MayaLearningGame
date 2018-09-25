using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLandScrol : MonoBehaviour {

    int _id_ofvisibleColumn = 0;
    public GameObject ExplosionObj;
    Transform ColumnTransform;
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

    public void SetColumnTransform(Transform argT) {
        ColumnTransform = argT;
    }

    public void Explode(Vector3 pos) {
        GameObject expObj = Instantiate(ExplosionObj);
        expObj.transform.position = pos;
        expObj.transform.parent = ColumnTransform;
    }
}
