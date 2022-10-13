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

        public int minedGold = 0; //Gold that is yet to be banked
        public int bankedGold = 0; //Gold that has been banked
        public int tiredness = 0; //Miner tiredness level
        public Vector3 destination //Miner destination
        { get; set; }

        public override void AddUIElement(TextMeshProUGUI _itemUI)
        {
            itemUI.Add(_itemUI);
            return;
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