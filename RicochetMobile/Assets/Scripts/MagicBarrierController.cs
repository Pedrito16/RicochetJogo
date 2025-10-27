using UnityEngine;

public class MagicBarrierController : MonoBehaviour
{
    [SerializeField] GameObject magicBarrierPrefab;
    public static MagicBarrierController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SpawnBarrier(Transform enemyToSpawn)
    {
        GameObject barrier = Instantiate(magicBarrierPrefab, enemyToSpawn.position, Quaternion.identity);
        barrier.transform.SetParent(enemyToSpawn);
        barrier.transform.localPosition = Vector3.zero;
    }
}
