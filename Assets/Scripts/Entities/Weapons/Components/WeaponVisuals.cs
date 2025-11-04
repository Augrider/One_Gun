using UnityEngine;

public class WeaponVisuals : MonoBehaviour
{
    private const string SHOOT_TRIGGER_NAME = "Shoot";
    private const string RELOAD_TRIGGER_NAME = "Reload";

    [SerializeField] private Animator animator;
    [SerializeField] protected AudioSource audioSource;

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip noAmmoSound;


    public void TriggerShot() { }
    public void TriggerReload() { }
    public void PlayNoAmmo() { }
}
