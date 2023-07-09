using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : Magic
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            MagicAttack();
        }
    }

}
