using Modules.SavingsSystem;
using UnityEngine;

public class DeleteSaveButton : MonoBehaviour
{
    private SaveSystem _saveSystem = new SaveSystem();

    public void Delete()
    {
        _saveSystem.Clear();
    }
}