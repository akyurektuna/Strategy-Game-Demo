using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
     private void Update() {}

    private void OnMouseOver() {
        Debug.Log("mouse over working");

        if(Input.GetMouseButton(0)){
            if(GameManager.Instance.ClickedBtn != null){
                 PlaceStructure();
            }
        }
        
    }

    private Structure PlaceStructure(){
        Structure createdStructure = null;
        if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null){
            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("barracks")){
                createdStructure = StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.Barracks);
                GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
                structure.transform.SetParent(transform);
            }

            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("powerplant")){
                 createdStructure = StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.PowerPlant);
                 GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
                structure.transform.SetParent(transform);
            }
            
            //GameManager.Instance.ClickedBtn = null;
        }
        return createdStructure;
       
    }
}
