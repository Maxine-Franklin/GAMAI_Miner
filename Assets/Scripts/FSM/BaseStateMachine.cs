using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code built using https://www.toptal.com/unity-unity3d/unity-ai-development-finite-state-machine-tutorial for learning

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState _initialState;

    private void Awake()
    {
        currentState = _initialState;
    }

    public BaseState currentState { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        currentState.Execute(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
