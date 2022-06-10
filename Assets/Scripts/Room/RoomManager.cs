using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RoomManager : SingletonMonoBehaviour<RoomManager>
{
    public bool RoomInPlayer => _roomInPlayer;
    public bool IsLight => _isLight;

    [SerializeField]
    [Header("Player‚Ìƒ^ƒO")]
    string _playerTag;

    bool _roomInPlayer = false;
    bool _isLight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _playerTag)
        {
            _roomInPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == _playerTag)
        {
            _roomInPlayer = false;
        }
    }
}
