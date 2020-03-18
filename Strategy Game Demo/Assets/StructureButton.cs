using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureButton : MonoBehaviour
{

    [SerializeField]
    private GameObject structurePrefab;
    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite { get{
        return sprite;
    } }
    public GameObject StructurePrefab { 
        get{
            return structurePrefab;
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
