
public class Barracks : Structure{
  public Barracks(){}
string name { get{ return "Barracks";} }
   int dimensionX {  get{ return 4;}}
    int dimensionY {  get{ return 4;} }

  public void createSoldier(){
      //update here
  }

  public override void destroy(){
      
  }

  public override string structureInfo(){
    return "Barracks \nCan produce soldier units.";
  }
}
