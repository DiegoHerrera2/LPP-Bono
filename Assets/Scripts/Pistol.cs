using DG.Tweening;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform bulletOrigin;
    public float speed;


    public int recoil;
    public float recoilDuration;
    public float recoilRecoverDuration;


    public float firingDelay;
    private float delay = 0;

    public StarterAssetsInputs input;

    private AudioSource _audioSource;
    private Transform _transform;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        var rotation = _transform.localEulerAngles;
        var position = _transform.localPosition;
        if ((input.firing && delay <= 0) && !input.sprint)
        {
            var bulletCreated = Instantiate(bullet, bulletOrigin.position, Quaternion.LookRotation(transform.forward));
            bulletCreated.velocity = transform.forward * speed;
            _audioSource.Play();
            _transform.DOLocalRotate(new Vector3(recoil, rotation.y, rotation.z), recoilDuration);
            
            delay = firingDelay;
        }
        else if (input.sprint)
        {
            _transform.DOLocalRotate(new Vector3(-recoil, rotation.y, rotation.z), 1);
        }

        if (rotation.x != 0) _transform.DOLocalRotate(new Vector3(0, rotation.y, rotation.z), recoilRecoverDuration);


        input.firing = false;
        if (delay > 0) delay -= Time.deltaTime;
        

    }
}
