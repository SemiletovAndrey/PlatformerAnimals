
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform spawn;
    [SerializeField] protected float speedBullet = 10;
    [SerializeField] protected float shotPeriod = 0.5f;
    [SerializeField] protected AudioSource shotSound;
    [SerializeField] protected GameObject flash;
    [SerializeField] private ParticleSystem smokeEffect;

    private float _timer;

    void Update()
    {
        _timer += Time.unscaledDeltaTime;

        if (_timer > shotPeriod)
        {
            if(Input.GetMouseButton(0))
            {
                _timer = 0;
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = spawn.forward * speedBullet;
        shotSound.pitch = Random.Range(0.6f, 1.4f);
        shotSound.Play();
        flash.SetActive(true);
        Invoke(nameof(HideFlash), 0.12f);
        smokeEffect.Play();
    }

    public void HideFlash()
    {
        flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }
    
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }
}
