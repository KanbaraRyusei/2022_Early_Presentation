using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject GhostRoom { get; private set; }
    public GhostBase Ghost { get; private set; }
    public PlayerBase Player => _player;
    public float Timer => _time;
    public bool OpenDoor => _openDoor;

    [SerializeField]
    [Header("ゴースト")]
    GhostBase[] _ghosts;

    [SerializeField]
    [Header("Playerのタグ")]
    string _playerTag;

    float _time = 0f;
    bool _openDoor = false;
    PlayerBase _player;
    List<GameObject> _rooms = new List<GameObject>();

    private void Update()
    {
        _time += Time.deltaTime;
    }

    public void GameStart()
    {
        GhostRoomDecision();
        GhostDecision();
        PlayerSearch();
    }

    public void DoorOpen()
    {
        _openDoor = true;
    }

    void GhostRoomDecision()
    {
        GhostRoom = _rooms[Random.Range(0, _rooms.Count)];
    }

    void GhostDecision()
    {
        Ghost = _ghosts[Random.Range(0, _ghosts.Length)];
    }

    void PlayerSearch()
    {
        _player = GameObject.FindWithTag(_playerTag).GetComponent<PlayerBase>();
    }
}
