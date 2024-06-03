using UnityEngine;
using UnityEngine.UI;

public class CastBar : MonoBehaviour
{
    [SerializeField] private Slider castSlider;
    [SerializeField] private PlayerInput playerInput;

    private float castCooldownDuration;
    private bool isCasting;
    private float castStartTime; // Time when the casting starts

    private void Awake()
    {
        if (playerInput == null) playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Start()
    {
        castCooldownDuration = 3; // Set cast cooldown duration to 3 seconds
        castSlider.maxValue = castCooldownDuration;
        castSlider.value = castSlider.maxValue; // Ensure the slider starts full
    }

    private void Update()
    {
        // Check if currently within the cooldown period after casting
        if (Time.time < playerInput.LastCast)
        {
            if (!isCasting)
            {
                // A new cast has started
                isCasting = true;
                // Adjust castStartTime to account for the cooldown already added to lastCast
                castStartTime = playerInput.LastCast - castCooldownDuration; 
                castSlider.value = 0; // Start from zero
            }
        }
        else
        {
            // If outside the cooldown period, and the cast is complete
            if (isCasting)
            {
                isCasting = false;
            }
            // Ensure the slider remains full when not casting
            castSlider.value = castSlider.maxValue;
        }

        // If a cast is in progress, update the slider value to reflect casting progress
        if (isCasting)
        {
            float castingProgress = Time.time - castStartTime;
            // Ensure castingProgress calculation takes the offset into account
            castSlider.value = Mathf.Clamp(castingProgress, 0, castCooldownDuration);

            // Once casting completes, no need to explicitly reset isCasting here as it's handled above
        }
    }

}
