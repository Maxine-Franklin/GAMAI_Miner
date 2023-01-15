using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

        private bool overworked = false; //Tracks if miner has become overworked
        private int goldLost = 0; //Tracks gold lost due to being overworked

        private int bankingDesire = 0; //Desire to go to the bank and store mined gold
        private int sleepDesire = 0; //Desire to go home and restore tiredness (costs rent)

        [SerializeField] int rent = 4; //{Temporary Location} Cost to sleep at home
        private int rentPayed = 0; //Tracks if rent has been payed to stop duplicate payments

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
                case 3: //Banking Desire
                    bankingDesire = incrementValue;
                    break;
                case 4: //Sleeping Desire
                    sleepDesire = incrementValue;
                    break;
                case 5: //Gold Lost
                    goldLost = incrementValue;
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
                default: //Error Case
                    Debug.Log("Incorrect stat request in MinerBB, value requested: " + _stat);
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
            itemUI[0].text = "Gold Mined: " + minedGold.ToString(); //Updates mined gold UI element
            itemUI[1].text = "Gold Banked: " + bankedGold.ToString(); //Updates banked gold UI element
            itemUI[2].text = "Tiredness: " + tiredness.ToString(); //Updates tiredness UI element
            itemUI[3].text = "Banking Desire: " + bankingDesire.ToString(); //Updates banking desire UI element
            itemUI[4].text = "Sleeping Desire: " + sleepDesire.ToString(); //Updates sleeping desire UI element
            itemUI[5].enabled = overworked; //Enables overworked UI element visibility if miner is overworked
            itemUI[6].text = "Gold Lost: " + goldLost.ToString(); //Updates gold lost UI element
        }
    }
}