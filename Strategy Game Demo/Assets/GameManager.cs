using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   public StructureButton ClickedBtn { get; private set; }

    //picks up the structure when button is clicked in the production menu
    public void PickStructure(StructureButton sbutton){
        this.ClickedBtn = sbutton;
        Hover.Instance.Activate(sbutton.Sprite);
    }


    //unclick method can be used for deactivating button after it is used.
    public void unclick(){
        ClickedBtn = null;
    }
}
