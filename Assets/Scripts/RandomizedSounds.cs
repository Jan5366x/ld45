using UnityEngine;

public class RandomizedSounds : MonoBehaviour
{
    public static string HURT = "Audio/Hurt";
    public static string ATTACK = "Audio/Attack";
    public static string MOVEMENT = "Audio/Movement";
    public static string SPOTTED = "Audio/Spotted";
    public RandomizedSound[] sounds;

    public void Play()
    {
        int totalWeight = 0;
        foreach (RandomizedSound randomizedSound in sounds)
        {
            totalWeight += randomizedSound.weight;
        }

        int chosenSound = Random.Range(0, totalWeight);
        totalWeight = 0;
        AudioSource source = GetComponent<AudioSource>();

        foreach (RandomizedSound randomizedSound in sounds)
        {
            if (totalWeight <= chosenSound && chosenSound < totalWeight + randomizedSound.weight)
            {
                source.PlayOneShot(randomizedSound.clip);
                break;
            }

            totalWeight += randomizedSound.weight;
        }
    }

    public static void Play(Transform baseObject, string soundSet)
    {
        Transform hurt = baseObject.transform.Find(soundSet);
        Debug.Log("+++" + baseObject + " " + soundSet + " " + hurt);
        if (hurt)
        {
            hurt.GetComponent<RandomizedSounds>().Play();
        }
    }
}