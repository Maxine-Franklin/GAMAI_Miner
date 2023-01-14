using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace blackboard
{
    public class AutoMinerBB : Blackboard
    {
        //--Could use a void so that data is put in the BSM and the BSM runs the void to set the values of the UI and Locations
        [SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value
        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        [SerializeField] private int autoMinedGold = 0; //Gold that is yet to be banked
        /// <summary>
        /// <br>A value between 0-100</br><br>% chance to mine gold per check</br>
        /// </summary>
        [SerializeField] private int autoMineGoldChance = 0; //% chance to mine gold per check
        //breakdown likelihood stat

        private Vector3 destination; //Miner destination

        public override void AddUIElement(TextMeshProUGUI _itemUI)
        {
            itemUI.Add(_itemUI);
            return;
        }

        public override void UpdateStat(int _stat, int newValue)
        {
            switch (_stat) //Select the stat value to override
            {
                case 3: //AutoMined Gold
                    autoMinedGold = newValue;
                    break;
                case 4: //AutoMine Gold Chance
                    autoMineGoldChance = newValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in AutoMinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
        }

        public override void IncrementStat(int _stat, int incrementValue)
        {
            switch (_stat) //Select the stat value to increment
            {
                case 3: //AutoMined Gold
                    autoMinedGold += incrementValue;
                    break;
                case 4: //AutoMine Gold Chance
                    autoMineGoldChance += incrementValue;
                    break;
                default: //Error Case
                    Debug.Log("Incorrect stat update in AutoMinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
        }

        public override int GetStat(int _stat)
        {
            switch (_stat) //Select the stat value to return to the caller
            {
                case 3: //AutoMined Gold
                    return autoMinedGold;
                case 4: //AutoMine Gold Chance
                    return autoMineGoldChance;
                default: //Error Case
                    Debug.Log("Incorrect stat request in AutoMinerBB, value requested: " + _stat);
                    break;
            }
            return 999; //Error value to represent an incorrect _stat value
        }

        public override void UpdateDestination(int newDestination)
        { destination = locations[newDestination].position; return; }

        public override Vector3 GetDestination()
        {
            return destination;
        }

        // Update is called once per frame
        void Update()
        {
            itemUI[0].text = "AutoMiner Gold Stored: " + autoMinedGold.ToString(); //Updates mined gold UI element
        }
    }
}