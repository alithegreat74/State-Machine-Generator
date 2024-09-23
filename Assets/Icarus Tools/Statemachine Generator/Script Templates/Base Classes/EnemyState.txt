using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is for developing logic that is the same for all the enemy states
public class EnemyState:State
{
    protected Enemy enemyBase;
    public EnemyState(Entity entity, Statemachine stateMachine, string animBoolName, Enemy enemyBase) : base(entity,stateMachine,animBoolName)
    {
        this.enemyBase=enemyBase;
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
