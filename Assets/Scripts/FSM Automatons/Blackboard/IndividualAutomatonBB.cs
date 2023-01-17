using System;
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
        private int automatonType = 0; //Stores type of automaton (default 0 = miner)
        private Vector3 destination; //Automaton destination

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
                    Debug.Log("Incorrect stat update in IndividualAutomatonBB: " + gameObject.name.ToString() + ", value requested: " + _stat);
                    break;
            }
        }

        /// <summary>
        /// An alternate version of Update Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Bannker)</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public override void _UpdateStat(int _stat, int newValue)
        {
            AutomatonController.UpdateStat(_stat, newValue);
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
                    Debug.Log("Incorrect stat update in IndividualAutomatonBB: " + gameObject.name.ToString() + ", value requested: " + _stat);
                    break;
            }
        }

        /// <summary>
        /// An alternate version of Increment Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Gold in Transit</br><br>2: Gold Lost</br><br>3: Breakdowns</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public override void _IncrementStat(int _stat, int incrementValue)
        {
            AutomatonController.IncrementStat(_stat, incrementValue);
            return;
        }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Broken Down</br><br>3: Automaton Type (0 = Miner, 1 = Banker)</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public override int GetStat(int _stat)
        {
            switch (_stat) //Select the stat value to return to the caller
            {
                case 0: //Stored Gold
                    return storedGold;
                case 1: //Broken Down
                    return brokenDown ? 1 : 0; //Converts bool to int
                case 2: //Automaton Type (0 = Miner, 1 = Banker)
                    return automatonType;
                default: //Error Case
                    Debug.Log("Incorrect stat request in IndividualAutomatonBB: " + gameObject.name.ToString() + ", value requested: " + _stat);
                    break;

            }
            return 999; //Error value to represent an incorrect _stat value
        }

        /// <summary>
        /// An alternate version of Get Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Banker)</br><br>5: Automaton Gold Lost</br><br>6: Autominer Cost</br><br>7: Autobanker Cost</br><br>8: Repair Cost</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public override int _GetStat(int _stat)
        {
            return AutomatonController.GetStat(_stat);
        }

        public override void UpdateDestination(int newDestination)
        { destination = AutomatonController.GetLocations()[newDestination].position; return; }
        public override Vector3 GetDestination()
        {return destination;}

        /*public override IndividualAutomatonBB GetBrokenDownAutomaton()
        {
            return AutomatonController.GetBrokenDownAutomaton(); //Returns top automaton from the list of broken down automatons
        }*/

        public override void AddBrokenDownAutomaton()
        {
            AutomatonController.AddBrokenDownAutomaton(this); return; //Adds automaton breakdown to controller
        }

        public void Awake()
        {
            if (gameObject.name.ToString().Contains("bank")) //If automaton is a banker, then...
            {
                AutomatonController.IncrementStat(5, 1); //Increase autobanker count by 1
                automatonType = 1; //Store reference to automaton being a banker
            }
            else //If automaton type is miner, then...
                AutomatonController.IncrementStat(4, 1); //Increased autominer count by 1
            //Else, if automaton is miner, use default value for miner 
        }
    }
}