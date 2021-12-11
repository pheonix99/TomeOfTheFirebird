namespace CrusaderForge.Config
{
    public interface IDisableableGroup : ICollapseableGroup
    {
        bool GroupIsDisabled();
        void SetGroupDisabled(bool value);
    }
}
