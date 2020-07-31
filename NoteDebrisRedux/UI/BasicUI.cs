using CustomUI.GameplaySettings;


namespace NoteDebrisRedux.UI
{
    class BasicUI
    {
        public static void CreateGameplayOptionsUI()
        {
            ToggleOption isModEnabled = GameplaySettingsUI.CreateToggleOption(GameplaySettingsPanels.PlayerSettingsRight, "Redux Debris", hintText: "Removes the debris quicker");
            isModEnabled.GetValue = Settings._isModEnabled;
            isModEnabled.OnToggle += (value) => { Settings._isModEnabled = value; };
        }
    }
}