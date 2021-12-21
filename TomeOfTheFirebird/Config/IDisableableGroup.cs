namespace TomeOfTheFirebird.Config
{
    public interface IDisableableGroup : ICollapseableGroup
    {
        bool GroupIsDisabled();
        void SetGroupDisabled(bool value);
    }
}
