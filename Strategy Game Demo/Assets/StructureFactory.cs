public class StructureFactory: Singleton<StructureFactory>{

    public enum Structures{
            Barracks,
            PowerPlant
    }

   public Structure FactoryMethod(Structures structureType){
       Structure structure = null;
       switch(structureType){
           case Structures.Barracks:
                structure = new Barracks();
                break;
           case Structures.PowerPlant:
                structure = new PowerPlant();
                break;     
            default:
                return null;

       }
       return structure;

   }
}
