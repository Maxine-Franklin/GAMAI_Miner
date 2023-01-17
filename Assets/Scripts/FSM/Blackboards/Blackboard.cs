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
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Overworked</br><br>6: Rent Payed</br><br>7: Unload Desire</br><br>8: Repair Desire</br><br>9: UnloadingNumerator</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public virtual void UpdateStat(int _stat, int newValue) { }

        /// <summary>
        /// An alternate version of Update Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public virtual void _UpdateStat(int _stat, int newValue) { }

        /// <summary>
        /// Increment a stat by a inputted value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Gold Lost</br><br>6: UnloadingNumerator</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public virtual void IncrementStat(int _stat, int incrementValue) { }

        /// <summary>
        /// An alternate version of Increment Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public virtual void _IncrementStat(int _stat, int incrementValue) { }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Mined Gold</br><br>1: Banked Gold</br><br>2: Tiredness</br><br>3: Banking Desire</br><br>4: Sleeping Desire</br><br>5: Rent</br><br>6: Rent Payed</br><br>7: Overworked</br><br>8: Unload Desire</br><br>9: Repair Desire</br><br>10: Gold Lost</br><br>11: UnloadingNumerator</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public virtual int GetStat(int _stat) { return 999; }

        /// <summary>
        /// An alternate version of Get Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public virtual int _GetStat(int _stat) { return 999; }

        /// <summary>
        /// Updates the destination of the agent (used by navAgent)
        /// </summary>
        /// <param name="newDestination"><br>0: Mine</br><br>1: Bank</br><br>2: Home</br><br>3: Store</br></param>
        public virtual void UpdateDestination(int newDestination) { }

        /// <summary>
        /// Updates the destination of the agent (used by navAgent)
        /// </summary>
        /// <param name="newDestination">A Vector3 positional variable</param>
        public virtual void UpdateDestination(Vector3 newDestination) { }

        public virtual Vector3 GetDestination() { return new Vector3(0, 0, 0); }

        /// <summary>
        /// Obtain all locations from a blackboard
        /// </summary>
        /// <returns></returns>
        public virtual List<Transform> GetLocations() { return new List<Transform>(); }

        ///<summery>
        /// Add new automaton to the end of the breakdown list
        /// </summery>
        /// <param name="newBreakdown">New automaton breakdown to add to the list</param>
        public virtual void AddBrokenDownAutomaton(IndividualAutomatonBB newBreakdown) { }

        /// <summary>
        /// Used to add current automaton to the list of broken down automatons
        /// </summary>
        public virtual void AddBrokenDownAutomaton() { }

        /// <summary>
        /// Obtain the automaton that has been broken down the longest
        /// </summary>
        /// <returns>A broken down automaton class</returns>
        public virtual IndividualAutomatonBB GetBrokenDownAutomaton() { return new IndividualAutomatonBB(); }

        /// <summary>
        /// Get current repair target
        /// </summary>
        /// <returns>Automaton at the top of the broken down list when repairs started</returns>
        public virtual IndividualAutomatonBB GetCurrentRepairTarget() { return new IndividualAutomatonBB(); }

        /// <summary>
        /// Removes the automaton that has been broken down the longest from the list of automatons
        /// </summary>
        public virtual void RemoveBrokenDownAutomaton() { return; }

        /// <summary>
        /// Removes a specific automaton from the list of broken down automatons
        /// </summary>
        /// <param name="target">The automaton to be removed</param>
        public virtual void RemoveBrokenDownAutomaton(IndividualAutomatonBB target) { return; }
    }
}