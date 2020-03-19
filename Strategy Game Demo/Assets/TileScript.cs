using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{

    private void OnMouseOver() {
        if(Input.GetMouseButton(0)){
            PlaceStructure();
        }
        
    }

    private void PlaceStructure(){
        if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null){
            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("barracks")){
                StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.Barracks);
                 GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
                structure.transform.SetParent(transform);
            }

            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("powerplant")){
                StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.PowerPlant);
                 GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
                structure.transform.SetParent(transform);
            }
            
            //GameManager.Instance.ClickedBtn = null;
        }

       
    }
}
