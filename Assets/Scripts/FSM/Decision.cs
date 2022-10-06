using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : ScriptableObject //Abstract class from which all other decisions would define their custom behaviour
{
    public abstract bool Decide(BaseStateMachine state);
}
