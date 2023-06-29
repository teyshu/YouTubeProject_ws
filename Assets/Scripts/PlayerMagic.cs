using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public void ReceiveMagicFire(int lvlMagic)
    {
        print("Fire");
    }

    public void ReceiveMagicGround(int lvlMagic)
    {
        print("Ground");
    }

    public void ReceiveMagicWater(int lvlMagic)
    {
        print("Water");
    }
}
