using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnData  {


    private int _stateNumber;
    public int StateNumber1
    {
        get
        {
            return _stateNumber;
        }

        set
        {
            _stateNumber = value;
        }
    }

    private MyEnums.Season _mySeason;
    public MyEnums.Season MySeason
    {
        get
        {
            return _mySeason;
        }

        set
        {
            _mySeason = value;
        }
    }

    private MyEnums.Pickup _mypickup;
    public MyEnums.Pickup Mypickup
    {
        get
        {
            return _mypickup;
        }

        set
        {
            _mypickup = value;
        }
    }


    public ColumnData(int argstate, MyEnums.Season argseason, MyEnums.Pickup argPickyp) {
        _stateNumber = argstate;
        _mySeason = argseason;
        _mypickup = argPickyp;
    }

    public ColumnData(int argstate, MyEnums.Season argseason)
    {
        _stateNumber = argstate;
        _mySeason = argseason;
        _mypickup = MyEnums.Pickup.None;
    }
}
