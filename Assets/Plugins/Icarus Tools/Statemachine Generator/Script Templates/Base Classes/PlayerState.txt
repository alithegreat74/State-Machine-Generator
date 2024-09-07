using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{

    protected Player player;

    public PlayerState(Entity entity, Statemachine stateMachine, string animBoolName, Player player) : base(entity, stateMachine, animBoolName)
    {
        this.player=player;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

}
