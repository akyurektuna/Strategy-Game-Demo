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
            //when cursor is being dragged the rectangle will be created when lmb is clicked with the ScreenHelper script.
            var rect = ScreenHelper.GetScreenRect(mousePos,Input.mousePosition);    
            ScreenHelper.DrawScreenRect(rect,new Color(0.8f, 0.8f,0.95f, 0.1f));
            ScreenHelper.DrawScreenRectBorder(rect,1,Color.white);
        }

   }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            //when the mouse button is down, casting a ray and checking if it hit any "soldier" tagged object
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

        //when the mouse button is up, select the units(soldiers) that are in the area
        if(Input.GetMouseButtonUp(0)){
            DeselectUnits();
            foreach(var selectableObject in FindObjectsOfType<BoxCollider>()){
                if(IsWithinSelectionBounds(selectableObject.transform) && selectableObject.CompareTag("soldier")){
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
        
    }

    private void DeselectUnits(){

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
