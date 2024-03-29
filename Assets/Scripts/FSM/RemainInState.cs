using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Remain In State", fileName = "RemainInState")]
    public sealed class RemainInState : BaseState //Tells the FSM when not to perform a transition
    {}
}