using System;
using UnityEngine;

//watch the 2nd reel once it stops trigger this one and end the game
public class endWatcher : MonoBehaviour {

    private reelController _reelController;
    public Watcher watch;

    private static endWatcher _instance;
    public static endWatcher instance { get { return _instance; } }

    public event Action finishGame;
    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _reelController = GetComponent<reelController>();
        clickEvent.instance.clicked += enabler;

    }

    private void enabler()
    {
        watch.roundThree += endSpin;
    }

    private void endSpin()//check final spin of all the slots
    {
        _reelController.runSpin(10f, .3f);
        watch.roundThree -= endSpin;
        if(finishGame != null)
        {
            finishGame();
        }
    }


}
