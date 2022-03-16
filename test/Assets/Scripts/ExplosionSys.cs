using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSys : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.GetComponent<EnemySys>().Neutralized();
        if (collision.gameObject.tag == "Player")
            InterfaceSys.single.Lose(true);
    }
}
