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
        /// <summary>
        /// Set current thought of AI
        /// </summary>
        /// <param name="newThought">The new thought overridng the old thought</param>
        public virtual void UpdateCurrentThought(string newThought) { }

        /// <summary>
        /// Add UI element to list of UI elements that the blackboard can edit
        /// </summary>
        /// <param name="_itemUI">UI element to be added to the list</param>
        public virtual void AddUIElement(TextMeshProUGUI _itemUI) { } //Add UI Element to sub-blackboards

        /// <summary>
        /// Set the value of a stat to a specific value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Overworked</br><br>6: Rent Payed</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public virtual void UpdateStat(int _stat, int newValue) { }

        /// <summary>
        /// Increment a stat by a inputted value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Gold Lost</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public virtual void IncrementStat(int _stat, int incrementValue) { }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Rent</br><br>6: Rent Payed</br><br>7: Overworked</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public virtual int GetStat(int _stat) { return 999; }

        /// <summary>
        /// Updates the destination of the miner (used by navAgent)
        /// </summary>
        /// <param name="newDestination"><br>0: Mine</br><br>1: Bank</br><br>2: Home</br><br>3: Store</br></param>
        public virtual void UpdateDestination(int newDestination) { }

        public virtual Vector3 GetDestination() { return new Vector3(0, 0, 0); }
    }
}