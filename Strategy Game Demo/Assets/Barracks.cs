using UnityEngine;
public class Barracks : Structure{
 
string name { get{ return "Barracks";} }
   int dimensionX {  get{ return 4;}}
    int dimensionY {  get{ return 4;} }



 public Barracks(){
   //Barracks b = getGameObj().AddComponent<Barracks>();  
 }
  public void createSoldier(GameObject prefab){
      GameObject soldier = Instantiate(prefab,transform.position+new Vector3(0,-2,0),Quaternion.identity);
      soldier.transform.SetParent(transform);
  }

  public Barracks createBarracks(){
    return getGameObj().AddComponent<Barracks>(); 
  }
  

  public override void destroy(){
      
  }

  public override string structureInfo(){
    return "Barracks \nCan produce soldier units.";
  }

  public override bool producesUnits(){
    return true;
  }
}
