using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class Forfun : NetworkBehaviour {

    [SerializeField]
    private Transform spawnedObjectPrefab; // arba Transform arba GameObject, jie beveik identiski, yra codemonkey video kuo skiriasi
    private Transform spawnedObjectTransform;

    //Codemonkey example Netcode 28min
    private NetworkVariable<MyCustomData> randomNumber = new NetworkVariable<MyCustomData>(
        new MyCustomData {
            _int = 666,
            _bool = true,
        }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public struct MyCustomData : INetworkSerializable { // nes unity nezino kaip serializinti my custom object.
        public int _int;
        public bool _bool;
        public FixedString128Bytes message; // 1 symbol - 1 byte, neegalima padidint ir pamazint allocated space

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter {//this is auto implemented, su alt+enter
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
            serializer.SerializeValue(ref message);
        }
    }

    public void Update() {

        if (!IsOwner) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            randomNumber.Value = new MyCustomData {
                _int = 10,
                _bool = false,
                message = "This is a message! Hello World!!!"
            };

        }

        if (Input.GetKeyDown(KeyCode.Y)) {
            TestServerRpc("test message from ServerRpc: ", new ServerRpcParams());
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            TestClientRpc(new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new List<ulong> { 1 } } });
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            spawnedObjectTransform = Instantiate(spawnedObjectPrefab); // sitaip instantiatina tik serveris, jei clientas bandys, bus error.
            spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        }

        if (Input.GetKeyDown(KeyCode.O)) {
            // spawnedObjectTransform.GetComponent<NetworkObject>().Despawn(true);// removina gameobject from network, but keeps gameobject itself alive
            Destroy(spawnedObjectTransform.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            PrintMessageServerRpc(new ServerRpcParams());
        }
    }
    public override void OnNetworkSpawn() {
        randomNumber.OnValueChanged += (MyCustomData previousValue, MyCustomData newValue) => {
            Debug.Log(OwnerClientId + "; random number: " + newValue._int + "; " +
                newValue._bool + " ; message:" + newValue.message);
        };
    }


    [ServerRpc]
    private void TestServerRpc(string message, ServerRpcParams serverRpcParams) { // name must end with ServerRpc, runs on the server, class must be
                                                 // inherited from NetworkBehaviour, this class must be on a gameobject with NetworkObject
                                                 // Taip pat galima passint i metoda params, bet tik VALUE TYPES, ne reference types, išimtis - strings
                                                 // Taip pat galima passinti parametra ServerRpcParams.send ir ServerRpcParams.receive (default struct)
        Debug.Log("TestServerRpc " + OwnerClientId+ " ; " + message + " | ServerRpcParams says: " + serverRpcParams.Send);
    }

    [ClientRpc]
    private void TestClientRpc(ClientRpcParams clientRpcParams) { //galima passinti parametra ClientRpcParams.send ir ClientRpcParams.receive (default struct)
        Debug.Log("testingClientRpc");
    }

    [ServerRpc]
    void PrintMessageServerRpc(ServerRpcParams serverRpcParams) {
        PrintMessageClientRpc();
    }

    //-----------------------------------------------------------------------------------
    //clientrpc - by default bet kuris client gali aktyvuoti, visi clients matys.
    [ClientRpc]
    void PrintMessageClientRpc() {
        // All clients (including sender) show letter Z
        Debug.Log("A client clicked Jump, All clients are shown jump");
    }
}
