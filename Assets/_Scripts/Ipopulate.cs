using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipopulate
{
    string[] reelPool { get;}
    void Populate(string[] var);
}
