using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer mR;

    void Awake()
    {
        mR = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;  // divided by localscale.x becoz ground's scale(size) is 20 hence for speed use per unit size
        mR.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;

    }
}
