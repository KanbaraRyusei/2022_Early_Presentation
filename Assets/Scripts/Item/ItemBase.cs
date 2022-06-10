using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IUseItem
{
    public string Name => _name;
    public string Explanation => _explanation;
    public bool IsUsed => _isUsed;

    [SerializeField]
    [Header("ƒAƒCƒeƒ€–¼")]
    string _name;

    [SerializeField]
    [Header("à–¾")]
    string _explanation;

    bool _isUsed = false;

    public abstract void UseItem();
}
