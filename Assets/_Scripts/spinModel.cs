using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinModel : jsonCollector {

    public spinWrapper sData = new spinWrapper();

    public int Result = 0;

    public int[] ReelIndex;
    public int ActiveReelCount;
    public int winAmount;

    //  public static spinController instance { get; private set; } }
    private static spinModel _instance;
    public static spinModel instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        sData = loadJSONdata(spinName, sData);

    }
    private void Start()
    {
        clickEvent.instance.clicked += spinPicker;

    }
    public void spinPicker()
    {
        Result = chooseData(sData.Spins.Length);
        ReelIndex = sData.Spins[Result].ReelIndex;
        ActiveReelCount = sData.Spins[Result].ActiveReelCount;
        winAmount = sData.Spins[Result].WinAmount;
    }
    private int chooseData(int length )
    {      
        return Random.Range(0, length - 1);

    }


}
