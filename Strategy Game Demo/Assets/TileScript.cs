using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        Debug.Log("helov");
        if(Input.GetMouseButton(0)){
            PlaceTower();
        }
        
    }

    private void PlaceTower(){

    }
}
