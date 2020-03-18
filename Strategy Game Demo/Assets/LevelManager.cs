using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] 
    private GameObject tileObject;
    public float TileSize{
        get{return tileObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
    }
    // Start is called before the first frame update
    void Start(){ 
        CreateLevel();
        }

    //making background tile for the camera view so the bounds are edges of the camera view
    // using just one type of tile  
    private void CreateLevel(){
        //worldStart is the starting point for the background tiles which is top left corner of the camera
       Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height));
        Camera cam = Camera.main;
        //taking height and width to calculate how many tiles to put on x and y axes
        float height = 2f*cam.orthographicSize;
        float width = height*cam.aspect;
        for( int y=0;y<height/TileSize;y++){
            for(int x=0; x<width/TileSize; x++){
                GameObject newTile = Instantiate(tileObject);
                 newTile.AddComponent<TileScript>();
                newTile.transform.position = new Vector3(worldStart.x+TileSize*x,worldStart.y- TileSize*y,0);
            }
        }
    
    }
}
