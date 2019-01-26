using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseChildren : MonoBehaviour
{
    [SerializeField] private Transform[] children;

    public void Release()
    {
        for(int i = 0; i < children.Length; i++)
        {
            children[i].transform.parent = null;

            children[i].GetComponent<Rigidbody2D>().AddForce(
                new Vector2(Random.Range(-1, 1), Random.Range(0.1f, 0.5f) * 5), ForceMode2D.Impulse);
        }
    }
}
