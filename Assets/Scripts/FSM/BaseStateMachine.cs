using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Code built using https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial for learning

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents; //Stores cached components to increase effiency of state actions

        [SerializeField] private List<TextMeshProUGUI> itemUI = new List<TextMeshProUGUI>(); //UI element that shows the mined gold value


        public int minedGold = 0; //Gold that is yet to be banked
        public int bankedGold = 0; //Gold that has been banked

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
            //currentState.Execute(this);
            //UpdateAI();
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
                itemUI[0].text = "Gold Mined: " + minedGold.ToString(); //Updates mined gold UI element
                itemUI[1].text = "Gold Banked: " + bankedGold.ToString(); //Updates banked gold UI element
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