using System.Collections.Generic;

public class PiggyService
{
    public PiggyService(PiggieController piggieController, List<PiggyScriptableObject> piggySOList)
    {
        piggieController.Initialize(piggySOList);
    }
}
