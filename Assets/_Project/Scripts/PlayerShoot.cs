using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerShoot : MonoBehaviour
{
    MyCharacterActions characterActions;
    InputDevice inputDevice = InputManager.ActiveDevice;
    public ObjectPool objectPool;

    // Referenced in Fire(). Just declaring it here to avoid re-declaring it over and over.
    public GameObject bulletPrefab;

    // Gun, Turret, etc. Locations
    public Transform[] guns;

    //GameObject bullet;
    public int bulletSpeed = 50;
    public float bulletCooldown = .2f;
    private float bulletCooldownTimer;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize Variables - put into own method later
        characterActions = new MyCharacterActions();
        bulletCooldownTimer = bulletCooldown;

        InControlBindings();
        InitObjectPool();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bulletCooldownTimer -= Time.deltaTime;

        if (characterActions.Shoot.IsPressed && bulletCooldownTimer <= 0)
        {
            Fire();
        }
    }

    void InControlBindings()
    {
        characterActions.Shoot.AddDefaultBinding(InputControlType.LeftBumper);
        characterActions.Shoot.AddDefaultBinding(Key.Space);
    }

    void InitObjectPool()
    {
        if (bulletPrefab)
        {
            objectPool.InitializePool(100, bulletPrefab);
        } else {
            Debug.LogError("Cannot initialize bulletPrefab. No prefab.");
        }
    }

    void Fire()
    {

        foreach (Transform gun in guns)
        {
            GameObject bullet = objectPool.
                GetObjectFromPool(gun.transform.position, Quaternion.identity, gun.transform.forward);
        }

        // Reset bulletCooldownTimer to bulletCooldown
        bulletCooldownTimer = bulletCooldown;
    }
}
