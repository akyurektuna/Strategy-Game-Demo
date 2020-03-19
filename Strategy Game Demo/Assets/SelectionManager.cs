using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    /*
    In the map, a background tile and structure tile can be at the same position on top of each other
        so to choose the desired one Selectable Tag is initialized and used.
    */
    [SerializeField] private string selectableTag = "Selectable";

    void Update()
    {
        Debug.Log("update?");
        
        if(Input.GetMouseButtonDown(0)){

            //casting a ray to click on a structure to update information panel
            //if the structure is able to create units, it will be shown on this panel
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            var selection = hit.transform;

            //tag of the object that ray hit is checked
            if(selection.CompareTag(selectableTag)){
                GameObject go = hit.collider.gameObject;
                Debug.Log("go: "+go);
                
                //TileScript t = new TileScript();
                updateInfoPanel(go);
            }

        }
        
    }


    void updateInfoPanel(GameObject gameObj){
        GameObject newText = new GameObject();
        Barracks b = new Barracks();
       //need to have the structure (structure that the ray hit and has been created before) and use that structures info method.

        Text text = newText.AddComponent<Text>();
        text.text = b.structureInfo();
 
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        newText.transform.SetParent(panel.transform);
        newText.transform.position = newText.transform.parent.position;
    }
}

