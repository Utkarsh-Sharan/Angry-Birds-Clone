using System.Collections.Generic;

public class PiggyService
{
    public PiggyService(List<PiggyScriptableObject> piggySOList)
    {
        PiggyController piggyController = new PiggyController(piggySOList);
    }
}
