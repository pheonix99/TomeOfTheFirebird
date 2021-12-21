namespace TomeOfTheFirebird.Config
{
    public interface IUpdatableSettings
    {
        void OverrideSettings(IUpdatableSettings userSettings);
        void Init();
    }
}
