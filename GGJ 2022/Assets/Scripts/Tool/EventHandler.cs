using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventHandler
{
    public static event Action EveryFeelHot;
    public static void CallEveryFeelHot()
    {
        EveryFeelHot?.Invoke();
    }

    public static event Action EveryNotFeelHot;
    public static void CallEveryNotFeelHot()
    {
        EveryNotFeelHot?.Invoke();
    }

    public static event Action TimeStop;
    public static void CallTimeStop()
    {
        TimeStop?.Invoke();
    }

    public static event Action TimeKeepGoing;
    public static void CallTimeKeepGoing()
    {
        TimeKeepGoing?.Invoke();
    }

}
