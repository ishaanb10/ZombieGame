using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weaponMuzzle;	// called playerCam in video
	public float range = 100f;
	public float damage = 25f;
	public Animator playerAnimator;

	void Start(){
	}
	
	void Update(){
		if(playerAnimator.GetBool("isShooting")){
			playerAnimator.SetBool("isShooting", false);
		}

		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}
	
	void Shoot(){
		playerAnimator.SetBool("isShooting", true);
		
		RaycastHit hit;
		
		if(Physics.Raycast(weaponMuzzle.transform.position, transform.forward, out hit, range)){
            //object hit
            
			EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
			if(enemyManager){	// enemyManager != null
				enemyManager.Hit(damage);
                // Debug.Log("hit");
			}
        }
	}
}
