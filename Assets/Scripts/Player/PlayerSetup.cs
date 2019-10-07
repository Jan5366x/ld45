using UnityEngine;
using UnityEngine.Assertions;

public class PlayerSetup : MonoBehaviour
{
    public Transform SpawnArmorPrefab;
    public Transform SpawnSwordPrefab;
    public Transform SpawnKillerPrefab;

    public static int damageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        switch (MainMenu.choice)
        {
            case 0:
                SpawnArmor();
                break;
            case 1:
                SpawnSword();
                break;
            case 2:
                SpawnNaked();
                break;
            default:
                Assert.IsTrue(false, "How did you get here?");
                break;
        }
    }

    private void SpawnArmor()
    {
        damageMultiplier = 10;

        GameObject player = GameObject.FindWithTag("Player");
        Instantiate(SpawnArmorPrefab, player.transform);
        SpawnKiller(player);
    }

    private void SpawnSword()
    {
        damageMultiplier = 5;

        GameObject player = GameObject.FindWithTag("Player");
        Instantiate(SpawnSwordPrefab, player.transform);
        SpawnKiller(player);
    }

    private void SpawnKiller(GameObject player)
    {
        Vector3 position = player.transform.position;
        position += Random.insideUnitSphere * Random.Range(1, 5);
        position.z = 0;
        Instantiate(SpawnKillerPrefab, position, player.transform.rotation);
    }

    private void SpawnNaked()
    {
        damageMultiplier = 1;
    }
}