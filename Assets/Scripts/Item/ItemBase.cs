using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IUseItem
{
    [SerializeField]
    string _name;

    public abstract void UseItem();
}
