using UnityEngine;

public class Spawn : MonoBehaviour
{


    [System.Serializable]
    public struct sO
    {
        public GameObject prefab;

        [Range(0f, 1f)] public float spawnChance;
    }

    public sO[] objects;
    private float minCalltime = 1f;
    private float maxCalltime = 2f;

    private void OnEnable()
    {
        Invoke(nameof(spawn), Random.Range(minCalltime, maxCalltime));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void spawn()
    {
        float spawnChance = Random.value;
        foreach (var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacles = Instantiate(obj.prefab);
                obstacles.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(spawn), Random.Range(minCalltime, maxCalltime));
    }

}
