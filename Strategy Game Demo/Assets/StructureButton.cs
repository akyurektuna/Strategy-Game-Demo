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
            Structure structure = structurePrefab.GetComponent<Structure>();
            return structurePrefab;
        } 
    }

}
