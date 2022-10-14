using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using blackboard;
using UnityEngine;
using UnityEngine.UI;

//Code built using https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial for learning

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents; //Stores cached components to increase effiency of state actions

        //[SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value
        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        public Blackboard _blackboard;

        //public int minedGold = 0; //Gold that is yet to be banked
        //public int bankedGold = 0; //Gold that has been banked
        //public int tiredness = 0; //Miner tiredness level
        public Vector3 destination //Miner destination
        { get; set; }
        /// <summary>
        /// Updates the destination of the miner (used by navAgent)
        /// </summary>
        /// <param name="newDestination"><br>0: Mine</br><br>1: Bank</br><br>2: Home</br><br>3: Store</br></param>
        public void UpdateDestination(int newDestination) { destination = locations[newDestination].position; return; }

        private void Awake()
        {
            currentState = _initialState;
            _cachedComponents = new Dictionary<Type, Component>();
        }

        public BaseState currentState { get; set; }

        float timer = 0.5f;

        // Start is called before the first frame update
        void Start()
        {
            destination = locations[0].position; //Set's default destination to the mine
        }

        public new T GetComponent<T>() where T : Component //Code to either return cached component
        {
            if (_cachedComponents.ContainsKey(typeof(T))) //If component is already cached then...
                return _cachedComponents[typeof(T)] as T; //Return cached component as type of component

            var component = base.GetComponent<T>(); //Obtains the uncached component
            if (component != null) //If the uncached component exists then...
                _cachedComponents.Add(typeof(T), component); //Cache the component

            return component; //Returns the resultant component
        }

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime; //Decreases timer value by the time since the last frame
            if(timer<0f) //If timer value is less than or equal to 0 then...
            {
                timer = 0.5f; //Resets FSM execution timer to 500 milliseconds
                currentState.Execute(this); //Executes current state
                //itemUI[0].text = "Gold Mined: " + minedGold.ToString(); //Updates mined gold UI element
                //itemUI[1].text = "Gold Banked: " + bankedGold.ToString(); //Updates banked gold UI element
                //itemUI[2].text = "Tiredness: " + tiredness.ToString(); //Updates tiredness UI element
            }
        }

        /*WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

        IEnumerator UpdateAI() //Calls AI execute functions every waitForSeconds seconds (currently 500 milliseconds)
        {
            while(true)
            {
                currentState.Execute(this);
                _minedGold.text = "Gold Mined: " + minedGold.ToString();
                yield return waitForSeconds;
            }
        }*/
    }
}