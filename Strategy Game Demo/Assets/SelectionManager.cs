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

    private  GameObject panelTextObj;
    private Text text;
    
private void Start() {
    panelTextObj = new GameObject();  
    text = panelTextObj.AddComponent<Text>();  
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
                Debug.Log("go: "+go);
                
                //TileScript t = new TileScript();
                updateInfoPanel(go);
            }

        }
        
    }


   public void updateInfoPanel(GameObject gameObj){
        Barracks b = new Barracks();
 
        text.text = b.structureInfo();
 
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        panelTextObj.transform.SetParent(panel.transform);
        panelTextObj.transform.position = panelTextObj.transform.parent.position;

        CreateButton(childPanel.transform,childPanel.transform.position);        
    }



    public void CreateButton(Transform panel ,Vector3 position){
        GameObject button = new GameObject();
        button.transform.parent = panel;
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.transform.position = position;
        button.AddComponent<Image>();
        button.GetComponent<Image>().sprite = buttonImg;
    //button.GetComponent<RectTransform>().SetSize(size);
    //last parameter UnityEngine.Events.UnityAction method
    //button.GetComponent<Button>().onClick.AddListener(method);
}

public void methodButton(){

}

}

