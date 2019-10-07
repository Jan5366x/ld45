using UnityEngine;

// Ensure that there exists only one instance of this object
public class SoundSlotUpdater : MonoBehaviour
{
    public float updateTime;
    
    private void Update()
    {
        updateTime -= Time.deltaTime;
        if (updateTime < 0)
        {
            RandomizedSounds.TriggerUpdate();
            updateTime = 0.3f;
        }
    }
}