using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSys : MonoBehaviour
{
    public GameObject _CenterExplos, _UpExplos, _DownExplos, _RightExplos, _LeftExplos;
    public GameObject _cell;
    public float _ExplosionTime;
    void Start()
    {
        StartCoroutine(Bombing());
    }

    IEnumerator Bombing()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Destroy(Instantiate(_CenterExplos, transform.position, Quaternion.identity), _ExplosionTime);
            if (_cell.GetComponent<CellSys>()._Up)
                Destroy(Instantiate(_UpExplos, transform.position, Quaternion.identity), _ExplosionTime);
            if (_cell.GetComponent<CellSys>()._Down)
                Destroy(Instantiate(_DownExplos, transform.position, Quaternion.identity), _ExplosionTime);
            if (_cell.GetComponent<CellSys>()._Right)
                Destroy(Instantiate(_RightExplos, transform.position, Quaternion.identity), _ExplosionTime);
            if (_cell.GetComponent<CellSys>()._Left)
                Destroy(Instantiate(_LeftExplos, transform.position, Quaternion.identity), _ExplosionTime);
            Destroy(gameObject);
        }
    }
}
