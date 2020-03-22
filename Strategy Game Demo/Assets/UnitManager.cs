using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{

     
    List<Transform> selectedUnits = new List<Transform>();
    bool isDragging = false;
    
    Vector3 mousePos;

    private void OnGUI() {
        if(isDragging){
            var rect = ScreenHelper.GetScreenRect(mousePos,Input.mousePosition);    
            ScreenHelper.DrawScreenRect(rect,new Color(0.8f, 0.8f,0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect,1,Color.white);
        }

   }
    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){

            mousePos = Input.mousePosition;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit2.collider != null){
                
                if(hit2.transform.CompareTag("soldier")){
                    SelectUnit(hit2.transform,Input.GetKey(KeyCode.LeftShift));
                }
                else{
                    isDragging = true;
                }
            }
        }

        //IsWithinSelectionBounds(selectableObject.transform) && 
        if(Input.GetMouseButtonUp(0)){
            DeselectUnits();
            foreach(var selectableObject in FindObjectsOfType<BoxCollider>()){
                Debug.Log("foreach??");
                if(IsWithinSelectionBounds(selectableObject.transform) && selectableObject.CompareTag("soldier")){
                    Debug.Log("forearch->if");
                    SelectUnit(selectableObject.transform,true);
                }
            }
            isDragging = false;
        }
    }

    private void SelectUnit(Transform unit,bool isMultiSelect = false){
        Debug.Log(isMultiSelect);
        if(!isMultiSelect){
            DeselectUnits();
        }
        selectedUnits.Add(unit);
        for(int i=0; i<selectedUnits.Count; i++){
            Debug.Log("SELECTED UNITS");
            Debug.Log(selectedUnits[i]);

        }
        
        //unit.Find("soldier(Clone)").gameObject.SetActive(true);
    }

    private void DeselectUnits(){
        /*
        for(int i=0; i<selectedUnits.Count; i++){
            selectedUnits[i].Find("soldier(Clone)").gameObject.SetActive(false);
        }
        */
        selectedUnits.Clear();
    }

    private bool IsWithinSelectionBounds(Transform transform){
        if(!isDragging){
            return false;
        }
        var camera = Camera.main;
        var viewportBounds = ScreenHelper.GetViewportBounds(camera,mousePos,Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(transform.position));
    }

}
