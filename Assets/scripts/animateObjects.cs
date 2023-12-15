using UnityEngine;

public class animateObjects : MonoBehaviour
{
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;  // Camera.Main will call object tagged MainCamera.
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            DestroyImmediate(gameObject);
        }
    }
}
