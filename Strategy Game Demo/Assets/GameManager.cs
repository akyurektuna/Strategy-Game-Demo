using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    void Update() {
        if(Input.GetMouseButtonDown(0)){
          
        }
    }


    public StructureButton ClickedBtn { get; private set; }

    public void PickStructure(StructureButton sb){
        this.ClickedBtn = sb;
        Hover.Instance.Activate(sb.Sprite);
    }
}
