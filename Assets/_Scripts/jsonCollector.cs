using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// I decided to use an abstract class instead of an interface because both json files need to be parsed in the same way 
/// </summary>
public abstract class jsonCollector : MonoBehaviour
{
    protected string wheelName = "reelstrips.json";
    protected string spinName = "spins.json";

    protected static T loadJSONdata<T>(string path, T data)
    {
        string dataPath = Path.Combine(Application.streamingAssetsPath, path);

        if (File.Exists(dataPath))
        {
            data = JsonConvert.DeserializeObject<T>(File.ReadAllText(dataPath));
            
        }
        else
            Debug.LogError("No file to be found");

        return data;
    }
}
