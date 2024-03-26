using Modules.DamageSystem;
using Modules.MoveSystem;
using UnityEngine;

namespace Source.Modules.InputSystem
{
    public class InputScheme
    {
        public InputScheme(IMoveInput moveInput, IRotateInput rotateInput, IAttackInput attackInput, IFinishOffInput finishOffInput)
        {
            Debug.Log("VContainer on InputScheme");
            MoveInput = moveInput;
            RotateInput = rotateInput;
            AttackInput = attackInput;
            FinishOffInput = finishOffInput;
        }
       
        public IMoveInput MoveInput { get; private set; }

        public IRotateInput RotateInput { get; private set; }

        public IAttackInput AttackInput { get; private set; }

        public IFinishOffInput FinishOffInput { get; private set; }
    }
}