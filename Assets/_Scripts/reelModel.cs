using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//populate our reelModel with data from the json file
public class reelModel : jsonCollector, Ipopulate
{
    [SerializeField]
    [Range(0, 2)]
    private int _slot;
    public int slot { get { return _slot; } }

    private reelData _rData = new reelData();

    private string[] _reelPool;
    public string[] reelPool { get { return _reelPool; } }


    private void Awake()
    {
        _rData = loadJSONdata(wheelName, _rData);
        Populate(_rData.ReelStrips[this._slot]);
    }

    public void Populate(string[] var)
    {
       _reelPool = new string[var.Length];
        for (int i = 0; i < var.Length; i++)
        {
            reelPool[i] = var[i];
        }

    }
}
