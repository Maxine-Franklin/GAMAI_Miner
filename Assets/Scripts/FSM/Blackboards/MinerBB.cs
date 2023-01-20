using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace blackboard
{
    public class MinerBB : Blackboard
    {
        [SerializeField] private AutomatonBB AutomatonController; //Reference to automaton master blackboard
        private IndividualAutomatonBB brokenDownAutomaton; //Refernce to currently tracked broken down automaton

        [SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value
        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        [SerializeField] private string thoughts = "Begining Process"; //Miner thoughts, used to represent what the miner is currently doing

        [SerializeField] private int minedGold = 0; //Gold that is yet to be banked
        [SerializeField] private int bankedGold = 0; //Gold that has been banked
        [SerializeField] private int tiredness = 0; //Miner tiredness level

        private bool overworked = false; //Tracks if miner has become overworked
        private int goldLost = 0; //Tracks gold lost due to being overworked
        private int unloadingNumerator = 0; //Numerator to cap how many unloading cycles can occur

        private int bankingDesire = 0; //Desire to go to the bank and store mined gold
        private int sleepDesire = 0; //Desire to go home and restore tiredness (costs rent)
        private int unloadDesire = 0; //Desire to unload any autominers
        private int repairDesire = 0; //Desire to repair any broken down automatons

        [SerializeField] int rent = 4; //{Temporary Location} Cost to sleep at home
        private int rentPayed = 0; //Tracks if rent has been payed to stop duplicate payments

        private Vector3 destination; //Miner destination

        public override void UpdateCurrentThought(string newThought)
        {   thoughts = newThought; return;  }

        public override void AddUIElement(TextMeshProUGUI _itemUI)
        {
            itemUI.Add(_itemUI);
            return;
        }

        public override void UpdateStat(int _stat, int newValue)
        {
            switch (_stat) //Select the stat value to override
            {
                case 0: //Mined Gold
                    minedGold = newValue;
                    break;
                case 1: //Banked Gold
                    bankedGold = newValue;
                    break;
                case 2: //Tiredness
                    tiredness = newValue;
                    break;
                case 3: //Banking Desire
                    bankingDesire = newValue;
                    break;
                case 4: //Sleeping Desire
                    sleepDesire = newValue;
                    break;
                case 5: //Overworked
                    if (newValue == 1)
                        overworked = true;
                    else
                        overworked = false;
                    break;
                case 6: //Rent Payed
                    rentPayed = newValue;
                    break;
                case 7: //Unload Desire
                    unloadDesire = newValue;
                    break;
                case 8: //Repair Desire
                    repairDesire = newValue;
                    break;
                case 9: //Unloading Numerator
                    unloadingNumerator = newValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in MinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
        }


        /// <summary>
        /// An alternate version of Update Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Bannker)</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public override void _UpdateStat(int _stat, int newValue)
        {
            AutomatonController._UpdateStat(_stat, newValue);
            return;
        }

        public override void IncrementStat(int _stat, int incrementValue)
        {
            switch (_stat) //Select the stat value to increment
            {
                case 0: //Mined Gold
                    minedGold += incrementValue;
                    break;
                case 1: //Banked Gold
                    bankedGold += incrementValue;
                    break;
                case 2: //Tiredness
                    tiredness += incrementValue;
                    break;
                case 3: //Banking Desire
                    bankingDesire += incrementValue;
                    break;
                case 4: //Sleeping Desire
                    sleepDesire += incrementValue;
                    break;
                case 5: //Gold Lost
                    goldLost += incrementValue;
                    break;
                case 6: //Unloading Numerator
                    unloadingNumerator += incrementValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in MinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
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

        public override int GetStat(int _stat)
        {
            switch (_stat) //Select the stat value to return to the caller
            {
                case 0: //Mined Gold
                    return minedGold;
                case 1: //Banked Gold
                    return bankedGold;
                case 2: //Tiredness
                    return tiredness;
                case 3: //Banking Desire
                    return bankingDesire;
                case 4: //Sleeping Desire
                    return sleepDesire;
                case 5: //Rent
                    return rent;
                case 6: //Rent Payment
                    return rentPayed;
                case 7: //Overworked
                    if (overworked) //If overworked then...
                        return 1; //Return true
                    else //If not overworked then...
                        return 0; //Return false
                case 8: //Unload Desire
                    return unloadDesire;
                case 9: //Repair Desire
                    return repairDesire;
                case 10: //Gold Lost
                    return goldLost;
                case 11: //Unloading Numerator
                    return unloadingNumerator;
                default: //Error Case
                    Debug.Log("Incorrect stat request in MinerBB, value requested: " + _stat);
                    break;
            }
            return 999; //Error value to represent an incorrect _stat value
        }

        /// <summary>
        /// An alternate version of Get Stat that obtains a stat from blackboard held within a blackboard
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Banker)</br><br>5: Automaton Gold Lost</br><br>6: Autominer Cost</br><br>7: Autobanker Cost</br><br>8: Repair Cost</br><br>9: Autominer Count</br><br>10: Autobanker Count</br><br>11: Breakdowns</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public override int _GetStat(int _stat)
        {
            return AutomatonController.GetStat(_stat);
        }

        public override void UpdateDestination(int newDestination)
        { destination = locations[newDestination].position; return; }


        public override void UpdateDestination(Vector3 newDestination)
        { destination = newDestination; return; }

        public override Vector3 GetDestination()
        {
            return destination;
        }

        public override IndividualAutomatonBB GetBrokenDownAutomaton()
        {
            brokenDownAutomaton = AutomatonController.GetBrokenDownAutomaton();
            return brokenDownAutomaton; //Returns top automaton from the list of broken down automatons
        }

        public override IndividualAutomatonBB GetCurrentRepairTarget()
        {
            return brokenDownAutomaton;
        }

        public override void RemoveBrokenDownAutomaton()
        {
            AutomatonController.RemoveBrokenDownAutomaton(brokenDownAutomaton); return; //Removes the repair target from the broken down list
        }

        // Update is called once per frame
        void Update()
        {
            itemUI[0].text = "Gold Mined: " + minedGold.ToString(); //Updates mined gold UI element
            itemUI[1].text = "Gold Banked: " + bankedGold.ToString(); //Updates banked gold UI element
            itemUI[2].text = "Tiredness: " + tiredness.ToString(); //Updates tiredness UI element
            itemUI[3].text = "Banking Desire: " + bankingDesire.ToString(); //Updates banking desire UI element
            itemUI[4].text = "Sleeping Desire: " + sleepDesire.ToString(); //Updates sleeping desire UI element
            itemUI[5].text = "Unloading Desire: " + unloadDesire.ToString(); //Updates unloading desire UI element
            itemUI[6].text = "Repair Desire: " + repairDesire.ToString(); //Updated repair desire UI element
            itemUI[7].text = "Gold Lost: " + goldLost.ToString(); //Updates gold lost UI element
            itemUI[8].enabled = overworked; //Enables overworked UI element visibility if miner is overworked
            itemUI[9].text = thoughts; //Display of current miner thought
        }
    }
}