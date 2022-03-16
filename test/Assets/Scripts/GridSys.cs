using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSys : MonoBehaviour
{
    static public GridSys single;
    public float _delay;
    public int countX, countY;
    public GameObject _Player;
    public float _plusX, _plusY, _plusXadd;
    public GameObject _point;
    public GameObject _obstacle;
    public GameObject _nearestPoint;
    public Vector2 _nearestPointCoords;
    public List<GameObject> _spawnPoints;
    public Vector3 _originPos;
    public Vector2[] _exceptions;
    public GameObject[] _enemy;

    private void Awake()
    {
        single = this;
    }

    void Start()
    {
        StartCoroutine(CheckNearestPoint());
        SpawnCells();
        CheckNeighborCells();
        for (int e = 0; e < _enemy.Length; e++)
            for (int i = 0; i < _spawnPoints.Count; i++)
                if (_spawnPoints[i].GetComponent<CellSys>()._xPos == _enemy[e].GetComponent<EnemySys>()._StartPos.x && _spawnPoints[i].GetComponent<CellSys>()._yPos == _enemy[e].GetComponent<EnemySys>()._StartPos.y)
                    _enemy[e].GetComponent<EnemySys>()._currentPoint = _spawnPoints[i];
    }

    public void SpawnCells()
    {
        for (int i = 0; i < countY; i++)
        {
            for (int j = 0; j < countX; j++)
            {
                bool skip = false;
                for (int k = 0; k < _exceptions.Length; k++)
                    if (_exceptions[k].x == j && _exceptions[k].y == i)
                    {
                        Instantiate(_obstacle, new Vector3(_originPos.x + _plusX * j + _plusXadd * i, _originPos.y - _plusY * i, 0), Quaternion.identity);
                        skip = true;
                    }
                if (skip)
                    continue;
                var spawnpoint = Instantiate(_point, new Vector3(_originPos.x + _plusX * j + _plusXadd * i, _originPos.y - _plusY * i, 0), Quaternion.identity);
                _spawnPoints.Add(spawnpoint);
                var spawnsys = spawnpoint.GetComponent<CellSys>();
                spawnsys._xPos = j;
                spawnsys._yPos = i;
            }
        }
    }


    public void CheckNeighborCells()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            var curCell = _spawnPoints[i].GetComponent<CellSys>();
            for (int j = 0; j < _spawnPoints.Count; j++)
            {
                var cell = _spawnPoints[j].GetComponent<CellSys>();
                if (cell._xPos == curCell._xPos && cell._yPos == curCell._yPos + 1)
                    curCell._Down = _spawnPoints[j];
                if (cell._xPos == curCell._xPos && cell._yPos == curCell._yPos - 1)
                    curCell._Up = _spawnPoints[j];
                if (cell._xPos == curCell._xPos + 1 && cell._yPos == curCell._yPos)
                    curCell._Right = _spawnPoints[j];
                if (cell._xPos == curCell._xPos - 1 && cell._yPos == curCell._yPos)
                    curCell._Left = _spawnPoints[j];
            }
        }
    }


    IEnumerator CheckNearestPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                if (_nearestPoint == null || Vector3.Distance(_spawnPoints[i].transform.position, _Player.transform.position) < Vector3.Distance(_nearestPoint.transform.position, _Player.transform.position))
                {
                    _nearestPoint = _spawnPoints[i];
                    _nearestPointCoords = _spawnPoints[i].transform.position;
                }
            }
        }
    }
}
