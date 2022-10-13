using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace blackboard
{
    /// <summary>
    /// The blackboard contains all the USEFUL data that is required for our Behaviour Tree.
    /// Inherit from the blackboard to have agent specific data
    /// </summary>
    public class Blackboard : MonoBehaviour
    {
        public virtual void AddUIElement(TextMeshProUGUI _itemUI) { } //Add UI Element to sub-blackboards
    }
}