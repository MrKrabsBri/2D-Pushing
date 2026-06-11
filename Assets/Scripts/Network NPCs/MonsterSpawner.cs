using Unity.Netcode;
using UnityEngine;

public class MonsterSpawner : NetworkBehaviour
{
    public GameObject monsterPrefab;
    public Transform spawnPoint;

    private void Awake() {
       // spawnPoint.position = new Vector3(-2.5f, 3f, 0);
    }

    public override void OnNetworkSpawn() {
        if (IsServer) {

            //spawnPoint.position = new Vector3(-2.5f, 3f, 0);
            GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
            monster.GetComponent<NetworkObject>().Spawn();
        }
    }

    public void destroyThisMonster() {
        if (IsServer) {
            GetComponent<NetworkObject>().Despawn(true);
        }
    }
}
