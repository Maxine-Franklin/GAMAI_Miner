using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Code built using https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial for learning

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Type, Component> _cachedComponents; //Stores cached components to increase effiency of state actions

        [SerializeField] private TextMeshPro _minedGold; //UI element that shows the mined gold value

        public int minedGold = 0; //Gold that is yet to be banked

        private void Awake()
        {
            currentState = _initialState;
            _cachedComponents = new Dictionary<Type, Component>();
        }

        public BaseState currentState { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            currentState.Execute(this);
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
            _minedGold.text = minedGold.ToString();
        }
    }
}