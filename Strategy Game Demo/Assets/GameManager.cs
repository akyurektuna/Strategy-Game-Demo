using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public StructureButton ClickedBtn { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickStructure(StructureButton sb){
        this.ClickedBtn = sb;
        Hover.Instance.Activate(sb.Sprite);
    }
}
