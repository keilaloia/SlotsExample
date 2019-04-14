using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//watch if we have finished first spin
public class Watcher : MonoBehaviour {

    // Use this for initialization
    private reelController _reelController;

    public event Action roundThree;

	void Start () {
        _reelController = GetComponent<reelController>();
        clickEvent.instance.clicked += enabler;
	}
	
    private void enabler()
    {
        _reelController.FoundMatch += finishSpin;

    }

    private void finishSpin()
    {
        _reelController.runSpin(10f, .3f);//stop after .3 seconds

        _reelController.FoundMatch -= finishSpin;

        if (roundThree != null)//notify final round of watchers that we're done
        {
            roundThree();
        }
    }


}
