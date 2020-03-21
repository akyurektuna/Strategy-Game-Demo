using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject childPanel;
    /*
    In the map, a background tile and structure tile can be at the same position on top of each other
        so to choose the desired one Selectable Tag is initialized and used.
    */
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Sprite buttonImg;
    [SerializeField]private GameObject prefabUnit;

    private  GameObject panelTextObj;
    private Text text;
    private GameObject button;
    
    
private void Start() {
    panelTextObj = new GameObject();  
    text = panelTextObj.AddComponent<Text>();  
    button = new GameObject();

}
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
                Structure str = go.GetComponent<Structure>();
                //the method to update information panel is called with the clicked object as parameter.
                updateInfoPanel(str);
            }

        }
    }


   public void updateInfoPanel(Structure str){
       //structureInfo() is a method of Structure class and returns a string, child classes have their own structureInfo() methods.
        text.text = str.structureInfo();
 
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        panelTextObj.transform.SetParent(panel.transform);
        panelTextObj.transform.position = panelTextObj.transform.parent.position;

        //producesUnit() is a method of Structure class and returns a boolean, child classes have their own structureInfo() methods.
        //if the clicked structure can produce units there should be a button to activate and produce units. 
        if(str.producesUnits()){
            CreateButton(childPanel.transform,childPanel.transform.position,str);        
        }
        if(!str.producesUnits() && button != null){
            //if(button != null){
                Destroy(button);
            //} 
        }
    }



    public void CreateButton(Transform panel ,Vector3 position, Structure structure){
        button = new GameObject();
        button.transform.parent = panel;
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.transform.position = position;
        button.AddComponent<Image>();
        button.GetComponent<Image>().sprite = buttonImg;
        button.GetComponent<Button>().onClick.AddListener(delegate{ methodButton(structure); });
}

    public void methodButton(Structure structure){
        //right now only the barracks can create units, when different type of structures are added this part should be customized.
        ((Barracks)structure).createSoldier(prefabUnit);
    }

}

