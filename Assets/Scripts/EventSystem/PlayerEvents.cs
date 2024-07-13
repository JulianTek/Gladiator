using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public delegate void PlayerBoolEvent(bool boolean);

    public PlayerBoolEvent OnPlayerMove;
}
