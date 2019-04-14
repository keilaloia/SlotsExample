using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowResultsprocessor : MonoBehaviour {

    private spinModel sModel;
    public reelModel[] rModel = new reelModel[3];
    private void Awake()
    {
        sModel = GetComponent<spinModel>();
    }

    public void windowResults()
    {
#if (UNITY_EDITOR)

        resultWindow.instance.Result = sModel.Result;
        resultWindow.instance.reelOne = sModel.ReelIndex[0];
        resultWindow.instance.reelTwo = sModel.ReelIndex[1];
        resultWindow.instance.reelThree = sModel.ReelIndex[2];
        resultWindow.instance.winAmount = sModel.winAmount;
        resultWindow.instance.ActiveReelCount = sModel.ActiveReelCount;

        resultWindow.instance.reelOneImage = rModel[0].reelPool[sModel.ReelIndex[0]];
        if(rModel[1].isActiveAndEnabled)
        resultWindow.instance.reelTwoImage = rModel[1].reelPool[sModel.ReelIndex[1]];
        if (rModel[2].isActiveAndEnabled)
            resultWindow.instance.reelThreeImage = rModel[2].reelPool[sModel.ReelIndex[2]];
#endif
    }
}
