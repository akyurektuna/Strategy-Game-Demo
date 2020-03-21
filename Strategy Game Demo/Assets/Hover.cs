using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>
{

    private SpriteRenderer spriteRenderer;
    [SerializeField] private string selectableTag = "Selectable";

    //private bool canBePlaced;

    public bool canBePlaced { get; private set; }
    void Start(){
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        //canBePlaced = true;
    }

    void Update(){
        FollowMouse();
    
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        var selection = hit.transform;
            
            //tag of the object that ray hit is checked
            if(selection.CompareTag(selectableTag)){
                //tint red
                transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                canBePlaced = false;
            }
            else{
                //tint green
                transform.gameObject.GetComponent<Renderer>().material.color = Color.green;
                canBePlaced = true;
            }
    }

    private void FollowMouse(){ 
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x,transform.position.y,0);
    }


    //call to this method is done in GameManager
    //after a button is clicked in the Production Menu
    public void Activate(Sprite sprite){
        this.spriteRenderer.sprite = sprite;
    }

    public void Deactivate(){
        
        //GameManager.Instance.ClickedBtn = null;
        this.spriteRenderer.sprite = null;
    }
}
