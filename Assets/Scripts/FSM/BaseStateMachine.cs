/*
 * Title: Unity AI Development: A Finite-state Machine Tutorial
 * Author: Garegin Tadevosyan
 * Availability: https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial
 * Used as a learning tool for how to create the basics of an FSM system
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using blackboard;
using UnityEngine;
using UnityEngine.UI;

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents; //Stores cached components to increase effiency of state actions

        [SerializeField] private List<Transform> locations = new List<Transform>(); //All locations the miner can traval too

        public Blackboard _blackboard;

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
            //destination = locations[0].position; //Set's default destination to the mine
            _blackboard.UpdateDestination(0); //Set's default destination to the mine
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
            }
        }
    }
}