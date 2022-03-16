using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    public GameObject _bombPrefab;

    public void FuncSpawnBomb()
    {
        var bomb = Instantiate(_bombPrefab, GridSys.single._nearestPointCoords, Quaternion.identity);
        bomb.GetComponent<BombSys>()._cell = GridSys.single._nearestPoint;
    }
}
