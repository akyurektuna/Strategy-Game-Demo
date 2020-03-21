using UnityEngine;
using System.Collections;
public abstract class Structure : MonoBehaviour
{
    string name { get; }
    int dimensionX { get; }
    int dimensionY { get;  }

    
    public abstract void destroy();
    public abstract string structureInfo();

    public abstract bool producesUnits();

    
    public GameObject getGameObj(){
        GameObject gameObj = new GameObject();
        return gameObj;
    }
    
    
}
