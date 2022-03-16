using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySys : MonoBehaviour
{

    public float _Speed;
    public float _timeToMove;
    public Sprite[] _defaultSprites;
    public Sprite[] _dirtSprites;
    public SpriteRenderer _enemySprite;
    public GameObject _Player;
    public GameObject _currentPoint;
    public GameObject _nextPoint;
    public Vector2 _StartPos;
    public IEnumerator _finding;
    int dir;

    void Start()
    {
        _finding = FindNewWay();
        StartCoroutine(_finding);
    }

    void Update()
    {
        if (_nextPoint != null)
        transform.position = Vector3.MoveTowards(transform.position, _nextPoint.transform.position, _Speed * Time.deltaTime);
    }

    public void NewWay()
    {
        int randDir = Random.Range(0, 4);
        dir = randDir;
        switch (randDir)
        {
            case 0:
                CheckNeighbor(_currentPoint.GetComponent<CellSys>()._Up);
                break;
            case 1:
                CheckNeighbor(_currentPoint.GetComponent<CellSys>()._Down);
                break;
            case 2:
                CheckNeighbor(_currentPoint.GetComponent<CellSys>()._Right);
                break;
            case 3:
                CheckNeighbor(_currentPoint.GetComponent<CellSys>()._Left);
                break;
        }
    }

    public void CheckNeighbor(GameObject check)
    {
        var grid = GridSys.single;
        for (int i = 0; i < grid._spawnPoints.Count; i++)
        {
            if (check != null)
            {
                _nextPoint = check;
                _currentPoint = _nextPoint;
                _enemySprite.sprite = _defaultSprites[dir];
            }
        }
    }

    public void Neutralized()
    {
        _enemySprite.sprite = _dirtSprites[dir];
        InterfaceSys.single._countNeutralizedEnemies++;
        InterfaceSys.single.UpdateCount();
        StopCoroutine(_finding);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            InterfaceSys.single.Lose(false);
    }

    IEnumerator FindNewWay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            NewWay();
        }
    }
}
