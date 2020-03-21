public class StructureFactory: Singleton<StructureFactory>{

    public enum Structures{
            Barracks,
            PowerPlant
    }

   public Structure FactoryMethod(Structures structureType){
       Structure structure = null;
       Barracks b = new Barracks();
       PowerPlant p =  new PowerPlant();
       switch(structureType){
           case Structures.Barracks:
                structure = b.createBarracks();
                break;
           case Structures.PowerPlant:
                structure = p.createPowerplant();
                break;     
            default:
                return null;

       }
       return structure;

   }
}
