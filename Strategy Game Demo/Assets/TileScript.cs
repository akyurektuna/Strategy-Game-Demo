using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
     private void Update() {}

    private void OnMouseOver() {
        if(Input.GetMouseButton(0)){
            if(GameManager.Instance.ClickedBtn != null && Hover.Instance.canBePlaced == true){
                 PlaceStructure();
            }
        }
        
    }

    private Structure PlaceStructure(){
        Structure createdStructure = null;
        if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null){
            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("barracks")){
                createdStructure = StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.Barracks); //from the structure factory, specific structure is created
                GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity); //game object instantiated on the map
                structure.AddComponent<Barracks>(); //game object now has the structure component
                structure.transform.SetParent(transform);
            }

            if(GameManager.Instance.ClickedBtn.StructurePrefab.name.Equals("powerplant")){
                createdStructure = StructureFactory.Instance.FactoryMethod(StructureFactory.Structures.PowerPlant);
                GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
                structure.AddComponent<PowerPlant>();
                structure.transform.SetParent(transform);
            }
        }

        //after a structure is placed, sprite on the cursor disappears and to place a structure again player has to reclick the button on the production menu.
        Hover.Instance.Deactivate();
        GameManager.Instance.unclick();
        return createdStructure;

    }
}
