namespace Slingshot
{
    public class SlingShotService
    {
        public SlingShotService(SlingshotConfig config)
        {
            new SlingShotController(config);
        }
    }
}