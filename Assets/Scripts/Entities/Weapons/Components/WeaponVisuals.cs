using UnityEngine;

public class WeaponVisuals : MonoBehaviour
{
    private const string SHOOT_TRIGGER_NAME = "Shoot";
    private const string RELOAD_TRIGGER_NAME = "Reload";

    private const string SHOOT_SPEED_NAME = "ShootSpeed";
    private const string RELOAD_SPEED_NAME = "ReloadSpeed";

    [SerializeField] private Animator animator;
    [SerializeField] protected AudioSource audioSource;

    [SerializeField] private ParticleSystem muzzleFlash;

    [SerializeField] private AnimationClip shootClip;
    [SerializeField] private AnimationClip reloadClip;

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip noAmmoSound;

    public float ReloadAnimationDuration => reloadClip.length;


    public void TriggerShot(float duration)
    {
        if (shootClip.length > duration)
            animator.SetFloat(SHOOT_SPEED_NAME, 1 + shootClip.length / duration);
        else
            animator.SetFloat(SHOOT_SPEED_NAME, 1);

        animator.ResetTrigger(RELOAD_TRIGGER_NAME);
        animator.SetTrigger(SHOOT_TRIGGER_NAME);

        muzzleFlash.Play();
    }

    public void TriggerReload(float multiplier)
    {
        animator.SetFloat(RELOAD_SPEED_NAME, multiplier);

        animator.ResetTrigger(SHOOT_TRIGGER_NAME);
        animator.SetTrigger(RELOAD_TRIGGER_NAME);
    }

    public void PlayNoAmmo() { }
}
