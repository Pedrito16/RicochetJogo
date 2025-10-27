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
    public void SpawnBarrier(Transform enemyToSpawn, int barrierHealth)
    {
        GameObject barrier = Instantiate(magicBarrierPrefab, enemyToSpawn.position, Quaternion.identity);
        barrier.GetComponent<MagicBarrierInstance>().Setup(barrierHealth);
        barrier.transform.SetParent(enemyToSpawn);
        barrier.transform.localPosition = Vector3.zero;
    }
}
