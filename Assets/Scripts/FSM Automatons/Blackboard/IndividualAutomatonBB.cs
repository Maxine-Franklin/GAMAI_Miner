using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace blackboard
{
    public class IndividualAutomatonBB : Blackboard
    {
        [SerializeField] private Blackboard AutomatonController; //Automaton's Controller

        private int storedGold = 0; //Gold stored on an autobanker
        private bool brokenDown = false; //If automaton is currently broken down

        /// <summary>
        /// Set the value of a stat to a specific value
        /// </summary>
        /// <param name="_stat"><br>0: Stored Gold</br><br>1: Broken Down</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public override void UpdateStat(int _stat, int newValue)
        {
            switch (_stat) //Select the stat value to override
            {
                case 0: //Stored Gold
                    storedGold = newValue; break;
                case 1: //Broken Down
                    if (newValue == 1)
                        brokenDown = true;
                    else
                        brokenDown = false;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in IndividualAutomatonBB, value requested: " + _stat);
                    break;
            }
        }
        /// <summary>
        /// Increment a stat by a inputted value
        /// </summary>
        /// <param name="_stat"><br>0: Stored Gold</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public override void IncrementStat(int _stat, int incrementValue)
        {
            switch (_stat) //Select the stat value to increment
            {
                case 0: //Stored Gold
                    storedGold += incrementValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in IndividualAutomatonBB, value requested: " + _stat);
                    break;
            }
        }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public override int GetStat(int _stat)
        {
            switch (_stat) //Select the stat value to return to the caller
            {
                case 0: //Stored Gold
                    return storedGold;
                case 1: //Broken Down
                    return brokenDown ? 1 : 0; //Converts bool to int
                default: //Error Case
                    Debug.Log("Incorrect stat request in AutomatonBB, value requested: " + _stat);
                    break;

            }
            return 999; //Error value to represent an incorrect _stat value
        }
    }
}