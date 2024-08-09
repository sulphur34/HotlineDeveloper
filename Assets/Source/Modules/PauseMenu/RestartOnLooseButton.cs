namespace Modules.PauseMenu
{
    public class RestartOnLooseButton : RestartLevelButton
    {
        protected override void MakeOnClick()
        {
            PauseSetter.Enable();
            base.MakeOnClick();
        }
    }
}