using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private DetectMouseOver uiMouseOver;
    [SerializeField] private Transform bulletSpawnPoint;

    private bool _canFire = true;

    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
    }

    private void Update()
    {
        //if statement from hell
        if (Input.GetMouseButton(0) && _canFire && WeaponsManager.Instance.equippedWeapon && !uiMouseOver.mouseOver && GameManager.Instance.gameState == GameManager.GameState.Gaming)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        _canFire = false;
        Shoot(WeaponsManager.Instance.equippedWeapon.bullet);
        yield return new WaitForSeconds(WeaponsManager.Instance.fireRate);
        _canFire = true;
    }
    
}
