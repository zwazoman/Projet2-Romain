using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// enum d�crivant les diff�rents sons possibles
/// </summary>
public enum Sounds
{
    Jump,
    Fall,
    Attack,
    PowerUpPickup,
    SuperJump,
    Dash,
    Shield,
    Projectile,
    EnemyDeath,
    Death,
    Win,
}

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// the size of the AudioPool
    /// </summary>
    [SerializeField] int _poolSize;

    /// <summary>
    /// prefab with an audiosource on it
    /// </summary>
    [SerializeField] AudioSource _SFXObject;

    [SerializeField] List<Clip> _clips;

    public Queue<AudioSource> AudioPool = new Queue<AudioSource>();

    //singleton
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Audio Manager");
                instance = go.AddComponent<AudioManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            AudioSource source = Instantiate(_SFXObject);
            source.gameObject.SetActive(false);
            AudioPool.Enqueue(source);
        }
    }

    /// <summary>
    /// sors de la pool/queue une audiosource et active son gameObject
    /// </summary>
    /// <returns></returns>
    AudioSource UseFromPool()
    {
        if (AudioPool.Count == 0)
        {
            print("plus assez d'audiosources");
            return null;
        }
        AudioSource currentSource = AudioPool.Dequeue();
        currentSource.gameObject.SetActive(true);
        return currentSource;
    }

    /// <summary>
    /// renvoie l'audioSource dans la pool et d�sactive son gameObject
    /// </summary>
    /// <param name="source"></param>
    public void BackToPool(AudioSource source)
    {
        source.gameObject.SetActive(false);
        AudioPool.Enqueue(source);
    }

    /// <summary>
    /// chosit une liste dans une liste via un enum et choisit ensuite un audioclip au hasard dans ce dernier pour le jouer.
    /// </summary>
    /// <param name="choosenSound"></param>
    /// <param name="volume"></param>
    /// <param name="pitch"></param>
    public void PlaySFXClip(Sounds choosenSound, float volume = 1f, float pitch = 1f)
    {
        if (_clips[(int)choosenSound].ClipList.Count == 0) // cas si l'array n'a pas �t� remplie correctement
        {
            print("y'a pas de sons l�");
            return;
        }

        AudioClip audioClip = _clips[(int)choosenSound].ClipList[Random.Range(0, _clips[(int)choosenSound].ClipList.Count)]; // choisit l'array correcte en fonction de l'enum en param�tre et y choisit un clip au hasard

        AudioSource audioSource = UseFromPool();
        if (audioSource == null) return;

        audioSource.clip = audioClip; // assigne le clip random � l'auriosource
        audioSource.volume = volume; // assigne le volume � l'audiosource
        audioSource.pitch = pitch; // assigne le pitch a� l'audiosource
        audioSource.spatialBlend = 0; // d�sactive la spatialisation
        audioSource.bypassEffects = false;

        audioSource.Play(); // joue le son

        float clipLength = audioSource.clip.length; // d�termine la longueur du son

        StartCoroutine(HandleSoundEnd(audioSource, clipLength));
    }

    /// <summary>
    /// chosit une liste dans une liste via un enum et choisit ensuite un audioclip au hasard dans ce dernier pour le jouer. le son sera plac� a un endroit donn� et prendra en compte ou non les effets
    /// </summary>
    /// <param name="choosenSound"></param>
    /// <param name="position"></param>
    /// <param name="bypassesEffects"></param>
    /// <param name="volume"></param>
    /// <param name="pitch"></param>
    public void PlaySFXClipAtPosition(Sounds choosenSound, Vector3 position, bool bypassesEffects = false, float volume = 1f, float pitch = 1f)
    {
        if (_clips[(int)choosenSound].ClipList.Count == 0) // cas si la liste n'a pas �t� remplie correctement
        {
            print("y'a pas de sons l�");
            return;
        }

        AudioClip audioClip = _clips[(int)choosenSound].ClipList[Random.Range(0, _clips[(int)choosenSound].ClipList.Count)]; // choisit la liste correcte en fonction de l'enum en param�tre et y choisit un clip au hasard

        AudioSource audioSource = UseFromPool();
        audioSource.gameObject.transform.position = position;

        audioSource.clip = audioClip;
        audioSource.volume = volume; // assigne le volume � l'audiosource
        audioSource.pitch = pitch; // assigne le pitch � l'audiosource
        audioSource.spatialBlend = 1; // g�re bien le blend rapport a l'audiolistener
        audioSource.bypassEffects = bypassesEffects; // g�re le bypass ou non des effets

        audioSource.Play(); // joue le son

        float clipLength = audioSource.clip.length; // d�termine la longueur du son

        StartCoroutine(HandleSoundEnd(audioSource, clipLength));
    }

    /// <summary>
    /// utilise une audiosource sortie de l'audiopool pour jouer un son. renvoie cette audiosource afin quelle soit mofifi�e en temps r�el dans le code
    /// </summary>
    /// <param name="choosenSound"></param>
    /// <returns></returns>
    public AudioSource PlaySFXClipModulableSource(Sounds choosenSound)
    {
        AudioClip audioClip = _clips[(int)choosenSound].ClipList[Random.Range(0, _clips[(int)choosenSound].ClipList.Count)];
        AudioSource audioSource = UseFromPool();
        audioSource.clip = audioClip;
        audioSource.Play();
        return audioSource;
    }

    /// <summary>
    /// g�re le retour a la pool d'une audiosource s'arr�tant apres la fin de son clip
    /// </summary>
    /// <param name="source"></param>
    /// <param name="clipLength"></param>
    /// <returns></returns>
    IEnumerator HandleSoundEnd(AudioSource source, float clipLength)
    {
        yield return new WaitForSecondsRealtime(clipLength);
        BackToPool(source);
    }
}
