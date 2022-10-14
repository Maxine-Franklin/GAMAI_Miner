using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace blackboard
{
    public class MinerBB : Blackboard
    {
        //--Could use a void so that data is put in the BSM and the BSM runs the void to set the values of the UI and Locations
        [SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value
        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        [SerializeField] private int minedGold = 0; //Gold that is yet to be banked
        [SerializeField] private int bankedGold = 0; //Gold that has been banked
        [SerializeField] private int tiredness = 0; //Miner tiredness level
        public Vector3 destination //Miner destination
        { get; set; }

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
                default: //Error Case
                    Debug.Log("Incorrect stat update in MinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
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
                default: //Error Case
                    Debug.Log("Incorrect stat update in MinerBB, value requested: " + _stat);
                    break;
            }
            return; //Returns to caller
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
                default: //Error Case
                    Debug.Log("Incorrect stat request in MinerBB, value requested: " + _stat);
                    break;
            }
            return 999; //Error value to represent an incorrect _stat value
        }

        // Update is called once per frame
        void Update()
        {
            itemUI[0].text = "Gold Mined: " + minedGold.ToString(); //Updates mined gold UI element
            itemUI[1].text = "Gold Banked: " + bankedGold.ToString(); //Updates banked gold UI element
            itemUI[2].text = "Tiredness: " + tiredness.ToString(); //Updates tiredness UI element
        }
    }
}