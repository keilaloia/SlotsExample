using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class clickEvent : MonoBehaviour {


    private static clickEvent _instance;
    public static clickEvent instance { get { return _instance; } }

    public event Action clicked;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    public void OnClick()//trigger click event for all scripts listening
    {
        if (clicked != null)
        {
            clicked();
        }
    }

}
