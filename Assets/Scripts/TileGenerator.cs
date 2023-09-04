using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;
    [SerializeField] private float _startPosYSpawn = -40f;
    private float _spawnPosition = 0;
    private float _tileLength = 30f;
    private int _startTiles = 2;
    private Vector3 _spawnTilePos = new Vector3(0, 0, 0);

    public void Initialization()
    {
        SpawnTile(0);

        for (int i = 0; i < _startTiles; i++)
        {
            RandomTileIndex();
        }

        _spawnTilePos = new Vector3(0, _startPosYSpawn, 0);
    }

    private void OnEnable()
    {
        TriggerSpawnTile.OnTileSpawned += RandomTileIndex;
    }

    private void OnDisable()
    {
        TriggerSpawnTile.OnTileSpawned -= RandomTileIndex;
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject spawnTile = Instantiate(_tiles[tileIndex], transform.forward * _spawnPosition + _spawnTilePos, transform.rotation);
        spawnTile.transform.DOMoveY(0, 2f);
        _spawnPosition += _tileLength;
    }

    public void RandomTileIndex()
    {
        int randomIndex = Random.Range(0, _tiles.Length);
        SpawnTile(randomIndex);
    }
}
