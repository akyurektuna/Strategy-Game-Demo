using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            PlaceStructure();
        }
        
    }

    private void PlaceStructure(){
        if(!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBtn != null){
            GameObject structure =(GameObject)Instantiate(GameManager.Instance.ClickedBtn.StructurePrefab,transform.position,Quaternion.identity);
            structure.transform.SetParent(transform);
            //GameManager.Instance.ClickedBtn = null;
        }

       
    }
}
