using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class ItemBase : MonoBehaviour, IUseItem
{
    public string Name => _name;
    public string Explanation => _explanation;
    public bool IsTake => _isTake;
    public bool IsUsed => _isUsed;

    [SerializeField]
    [Header("ÉAÉCÉeÉÄñº")]
    string _name;

    [SerializeField]
    [Header("ê‡ñæ")]
    string _explanation;

    Rigidbody2D _rb;

    bool _isTake = false;
    bool _isUsed = false;

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public abstract void UseItem();

    public void TakeItem()
    {
        _isTake = true;
    }
}
