using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
    private static T instance;
    public static T Instance{ get => instance; }

    protected virtual void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = (T)this;
    }

    protected virtual void OnDestory()
    {
        if(instance == this)
            instance = null;
    }
}
