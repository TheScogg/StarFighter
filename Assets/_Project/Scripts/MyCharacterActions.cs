using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


public class MyCharacterActions : PlayerActionSet
{
    public PlayerAction RotateLeft;
    public PlayerAction RotateRight;
    public PlayerAction Forward;
    public PlayerAction Backwards;
    public PlayerAction Rotate;
    public PlayerAction Shoot;

    public PlayerOneAxisAction ThrustAxis;
    public PlayerOneAxisAction RotateAxis;
    public PlayerOneAxisAction StrafeAxis;

    public MyCharacterActions()
    {
        RotateLeft = CreatePlayerAction("Move Left");
        RotateRight = CreatePlayerAction("Move Right");
        Forward = CreatePlayerAction("Forward");
        Backwards = CreatePlayerAction("Backwards");
        Shoot = CreatePlayerAction("Shoot");
        RotateAxis = CreateOneAxisPlayerAction(RotateLeft, RotateRight);
        ThrustAxis = CreateOneAxisPlayerAction(Backwards, Forward);

    }


}