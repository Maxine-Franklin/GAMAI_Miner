using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace blackboard
{
    public class AutomatonBB : Blackboard
    {
        [SerializeField] private MinerBB minerBlackboard; //Contains a reference to the miner blackboard
        //--Could use a void so that data is put in the BSM and the BSM runs the void to set the values of the UI and Locations
        [SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value
        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        [SerializeField] private int autoMinedGold = 0; //Auto-mined gold that is yet to be banked
        [SerializeField] private int miningChance = 33; //Chance to mine gold per tick per miner
        [SerializeField] private int goldInTransit = 0; //Gold in transit from autominer to bank
        [SerializeField] private readonly int autominerCost = 12; //Cost per autominer purchased
        [SerializeField] private readonly int autobankerCost = 18; //Cost per autobanker purchased
        [SerializeField] private int[] breakdownChance = new int[1]; //Chance of automaton breaking down (autominer, autobanker)
        //private bool brokenDown = false; Reserved for personal blackboards
        private int goldLost = 0; //Tracks gold lost in mining
        private int breakdowns = 0; //List of how many automatons are suffering from a breakdown

        //private Vector3 autoDestination; //Reserved for personal blackboards

        public override void AddUIElement(TextMeshProUGUI _itemUI)
        {
            itemUI.Add(_itemUI);
            return;
        }

        /// <summary>
        /// Set the value of a stat to a specific value
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Bannker)</br></param>
        /// <param name="newValue">The new value of the specified stat</param>
        public override void UpdateStat(int _stat, int newValue)
        {
            switch (_stat) //Select the stat value to override
            {
                case 0: //Automined Gold
                    autoMinedGold = newValue;
                    break;
                case 1: //Automine Chance
                    miningChance = newValue;
                    break;
                case 2: //Gold in Transit
                    goldInTransit = newValue;
                    break;
                case 3: //Breakdown Chance (Miner)
                    breakdownChance[0] = newValue;
                    break;
                case 4: //Breakdown Chance (Banker)
                    breakdownChance[1] = newValue;
                    break;
                /*case 5: //Broken Down
                    if (newValue == 1)
                        brokenDown = true;
                    else
                        brokenDown = false;
                    break;*/ //Reserved for personal blackboards
                default: //Error Case
                    Debug.Log("Incorrect stat update in AutomatonBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
        }

        /// <summary>
        /// Increment a stat by a inputted value
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Gold in Transit</br><br>2: Gold Lost</br></param>
        /// <param name="incrementValue">A positive or negative integer to incremenet the current value by</param>
        public override void IncrementStat(int _stat, int incrementValue)
        {
            switch (_stat) //Select the stat value to increment
            {
                case 0: //Automined Gold
                    autoMinedGold += incrementValue;
                    break;
                case 1: //Gold in Transit
                    goldInTransit += incrementValue;
                    break;
                case 2: //Gold Lost
                    goldLost += incrementValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in AutomatonBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
        }

        /// <summary>
        /// Obtain a specified stat's value
        /// </summary>
        /// <param name="_stat"><br>0: Automined Gold</br><br>1: Automine Chance</br><br>2: Gold in Transit</br><br>3: Breakdown Chance (Miner)</br><br>4: Breakdown Chance (Banker)</br><br>5: Automaton Gold Lost</br><br>6: Autominer Cost</br><br>7: Autobanker Cost</br></param>
        /// <returns><br>The integer value of a stat</br><br>If value is 999, an error has occured</br></returns>
        public override int GetStat(int _stat)
        {
            switch (_stat) //Select the stat value to return to the caller
            {
                case 0: //Automined Gold
                    return autoMinedGold;
                case 1: //Automine Chance
                    return miningChance;
                case 2: //Gold in Transit
                    return goldInTransit;
                case 3: //Breakdown Chance (Miner)
                    return breakdownChance[0];
                case 4: //Breakdown Chance (Banker)
                    return breakdownChance[1];
                case 5: //Automaton Gold Lost
                    return goldLost;
                case 6: //Autominer cost
                    return autominerCost;
                case 7: //Autobanker cost
                    return autobankerCost;
                /*case 6: //Overworked
                    if (brokenDown) //If overworked then...
                        return 1; //Return true
                    else //If not overworked then...
                        return 0; //Return false*/ //Reserved for personal blackboards
                default: //Error Case
                    Debug.Log("Incorrect stat request in AutomatonBB, value requested: " + _stat);
                    break;
            }
            return 999; //Error value to represent an incorrect _stat value
        }

        /*public override void UpdateDestination(int newDestination)
        { destination = locations[newDestination].position; return; }*/ //Reserved for personal blackboards

        /*public override Vector3 GetDestination()
        {return destination;}*/ //Reserved for personal blackboards

        // Update is called once per frame
        void Update()
        {
            itemUI[0].text = "Automaton Mined Gold: " + autoMinedGold.ToString(); //Updates auto mined gold UI element
            itemUI[1].text = "Gold in Transit: " + goldInTransit.ToString(); //Updates gold in transit UI element
            itemUI[2].text = "Automaton Gold Lost: " + goldLost.ToString();
            itemUI[2].text = "Current Breakdowns: " + breakdowns.ToString(); //Updates breakdown count UI element
        }
    }
}