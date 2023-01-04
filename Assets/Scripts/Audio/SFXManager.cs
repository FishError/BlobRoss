using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    #region Player
    public AudioClip[] playerSoundEffects;
    #endregion

    #region Equipments
    public AudioClip[] equipmentSoundEffects;
    #endregion

    #region Mob Enemy
    public AudioClip[] archieSoundEffects;
    public AudioClip[] blombSoundEffects;
    public AudioClip[] dasherSoundEffects;
    #endregion

    #region Boss Enemy
    public AudioClip[] takoSoundEffects;
    #endregion

    #region Projectiles
    public AudioClip[] projectileSoundEffects;
    #endregion

    #region Color Droplets
    public AudioClip[] colorDropletSoundEffects;
    #endregion

    public static SFXManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (!AudioManager.Instance.CheckClipIsPlaying(clip))
            AudioManager.Instance.PlaySFXAudio(clip);
    }

    public void PlayPlayerBasedAudio(Player player, GameObject parentObject, int index, float delay, bool playAfterDestroy)
    {
        AudioSource audio = Object.Instantiate(player.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = parentObject;
        audio.GetComponent<SFXDestroyer>().playAfterDestroy = playAfterDestroy;
        audio.clip = playerSoundEffects[index];
        audio.PlayDelayed(delay);
    }

    public void PlayEquipmentBasedAudio(Equipment equipment, int index)
    {
        AudioSource audio = Object.Instantiate(equipment.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = equipment.gameObject;
        audio.clip = equipmentSoundEffects[index];
        audio.Play();
    }

    public void PlayEnemyBasedAudio(Enemy enemy, GameObject parentObject, int index, float delay, bool playAfterDestroy)
    {
        AudioSource audio = Object.Instantiate(enemy.audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = parentObject;
        audio.GetComponent<SFXDestroyer>().playAfterDestroy = playAfterDestroy;
        audio.clip = GetEnemyClipsBasedOnType(enemy, index);
        audio.PlayDelayed(delay);
    }

    public void PlayProjectileBasedAudio(AudioSource audioSource, int index, float volume)
    {
        AudioSource audio = Object.Instantiate(audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = this.gameObject;
        audio.PlayOneShot(projectileSoundEffects[index], volume);
    }

    public void PlayColorDropletBasedAudio(AudioSource audioSource, GameObject parentObject, int index, bool playAfterDestroy)
    {
        AudioSource audio = Object.Instantiate(audioSource);
        audio.GetComponent<SFXDestroyer>().parentObject = parentObject;
        audio.GetComponent<SFXDestroyer>().playAfterDestroy = playAfterDestroy;
        audio.clip = colorDropletSoundEffects[index];
        audio.Play();
    }

    public IEnumerator WaitForAudioClipToEnd(GameObject obj, float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        Destroy(obj);
    }

    public AudioClip GetEnemyClipsBasedOnType(Enemy enemy, int index)
    {
        switch (enemy)
        {
            case Archie:
                return archieSoundEffects[index];
            case Blomb:
                return blombSoundEffects[index];
            case Dasher:
                return dasherSoundEffects[index];
            case Tako:
                return takoSoundEffects[index];
            default:
                return null;
        }
    }
}
