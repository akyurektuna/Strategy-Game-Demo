using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>
{

    private SpriteRenderer spriteRenderer;

    void Start(){
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update(){
        FollowMouse();
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
