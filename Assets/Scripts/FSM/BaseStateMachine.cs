using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code built using https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial for learning

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState _initialState;
        private Dictionary<Types, Component> _cachedComponents;

        private void Awake()
        {
            currentState = _initialState;
            _cachedComponents = new Dictionary<Types, Component>();
        }

        public BaseState currentState { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            currentState.Execute(this);
        }

        public new T GetComponent<T>() where T : Component
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}