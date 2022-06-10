using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject GhostRoom { get; private set; }
    public GhostBase Ghost { get; private set; }
    public PlayerBase Player => _player;

    [SerializeField]
    [Header("ゴースト")]
    GhostBase[] _ghosts;

    [SerializeField]
    [Header("Playerのタグ")]
    string _playerTag;

    PlayerBase _player;
    List<GameObject> _rooms = new List<GameObject>();

    public void GameStart()
    {
        GhostRoomDecision();
        GhostDecision();
        PlayerSearch();
    }

    private void GhostRoomDecision()
    {
        GhostRoom = _rooms[Random.Range(0, _rooms.Count)];
    }

    private void GhostDecision()
    {
        Ghost = _ghosts[Random.Range(0, _ghosts.Length)];
    }

    private void PlayerSearch()
    {
        _player = GameObject.FindWithTag(_playerTag).GetComponent<PlayerBase>();
    }
}
