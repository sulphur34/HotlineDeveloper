using UnityEngine;
using VContainer;

namespace Source.Modules.EquipperSystem
{
    public class EquipperSetup : MonoBehaviour
    {
        private EquipperPresenter _equipperPresenter;
        
        [Inject]
        public void Construct(EquipperConfig config)
        {
            Equipper equipper = new Equipper(config.ItemContainer, config.ThrowSpeed);
            // _equipperPresenter = new EquipperPresenter();
        }
    }
}