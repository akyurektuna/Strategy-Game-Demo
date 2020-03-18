using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonsScript : MonoBehaviour{
  
   
    public Sprite barracksSprite;
    private GameObject obj;
    /* the click methods are for the buttons 
        in the productionmenu
    */
    public void ClickBarrack(){
        obj = new GameObject();
        obj = Instantiate(obj,Input.mousePosition,transform.rotation);
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        renderer.sprite = barracksSprite;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,20f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
       
        obj.transform.position = objPosition;
      
       //obj -> barracks (clone)

    }

    public void ClickPowerPlant(){

    }
}
