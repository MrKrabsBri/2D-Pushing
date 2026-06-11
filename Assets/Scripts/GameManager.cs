using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Monster monsterBat;

    void Update() {


        if (monsterBat != null) { 
            Debug.Log("found a monster: " + monsterBat.name); 
        }
       // monsterBat = GameObject.Find("Enemy_Bat").GetComponent<Monster>();
       


        if (Input.GetKeyDown(KeyCode.Q)) {
            monsterBat.destroyThisMonster();
        }
    }

}
