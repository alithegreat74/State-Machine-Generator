using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody rb { get; private set; }
    public Statemachine statemachine { get; private set;}
    #endregion



    protected virtual void Awake()
    {
        statemachine=new Statemachine();
    }

    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        statemachine.currentState.Update();
    }
}
