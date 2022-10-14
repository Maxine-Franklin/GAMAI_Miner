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

        /// <summary>
        /// Set the value of a stat to a specific value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: AutoMined Gold</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public virtual void UpdateStat(int _stat, int newValue) { }

        /// <summary>
        /// Increment a stat by a inputted value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: AutoMined Gold</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public virtual void IncrementStat(int _stat, int incrementValue) { }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: AutoMined Gold</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public virtual int GetStat(int _stat) { return 999; }
    }
}