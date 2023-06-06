using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public GunScript gunScriptAk;
    public GunScript gunScriptSnip;
    public int bulletCountAk;
    public int InBulletCountAk;
    public int bulletCountSnip;
    public int InBulletCountSnip;

    private void Start()
    {

        FindGunScripts();
    }

    private void Update()
    {

        if (gunScriptAk == null || gunScriptSnip == null)
        {
            FindGunScripts();
        }

        if (gunScriptAk != null)
        {
            bulletCountAk = gunScriptAk.bulletsIHave;
            InBulletCountAk = gunScriptAk.bulletsInTheGun;
            //Debug.Log("AK Bullet Count: " + bulletCountAk);
        }

        if (gunScriptSnip != null)
        {
            bulletCountSnip = gunScriptSnip.bulletsIHave;
            InBulletCountSnip = gunScriptSnip.bulletsInTheGun;
            //Debug.Log("Sniper Bullet Count: " + bulletCountSnip);
        }
    }

    private void FindGunScripts()
    {
        GameObject weaponObjectAk = GameObject.FindGameObjectWithTag("Weapon");
        if (weaponObjectAk != null)
        {
            gunScriptAk = weaponObjectAk.GetComponent<GunScript>();
        }

        GameObject weaponObjectSnip = GameObject.FindGameObjectWithTag("Weapon2");
        if (weaponObjectSnip != null)
        {
            gunScriptSnip = weaponObjectSnip.GetComponent<GunScript>();
        }
    }
}