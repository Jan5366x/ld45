using UnityEngine;
using UnityEngine.Assertions;

public class PlayerSetup : MonoBehaviour
{
    public Transform SpawnArmorPrefab;
    public Transform SpawnSwordPrefab;

    public static int damageMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        switch (MainMenu.choice)
        {
            case 0:
                SpawnArmor();
                // TODO: Spawn Reaper
                break;
            case 1:
                SpawnSword();
                // TODO: Spawn Reaper
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
    }

    private void SpawnSword()
    {
        damageMultiplier = 5;

        GameObject playerObject = GameObject.FindWithTag("Player");
        Instantiate(SpawnSwordPrefab, playerObject.transform);
    }

    private void SpawnNaked()
    {
        damageMultiplier = 1;
    }
}