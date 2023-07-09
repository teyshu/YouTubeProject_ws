using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action LeftTheCastle;

    public static void OnLeftTheCastle()
    {
        LeftTheCastle?.Invoke();
    }
}
