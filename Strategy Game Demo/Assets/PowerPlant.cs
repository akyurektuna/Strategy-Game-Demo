
public class PowerPlant : Structure{
   public PowerPlant(){}

   string name { get{ return "PowerPlant";} }
   int dimensionX {  get{ return 2;}}
    int dimensionY {  get{ return 3;} }


   public override void destroy(){
       
   }
     public override string structureInfo(){
    return "Power Plant";
  }

}
