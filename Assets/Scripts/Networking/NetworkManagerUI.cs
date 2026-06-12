using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour {

    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    /*   TRYING SERVER AUTHORATIVE,  
         *
            private void Awake() {

                serverButton.onClick.AddListener(() => {
                    NetworkManager.Singleton.StartServer();
                });
                hostButton.onClick.AddListener(() => {
                    NetworkManager.Singleton.StartHost();
                });
                clientButton.onClick.AddListener(() => {
                    NetworkManager.Singleton.StartClient();
                });
            }*/

    private void Awake() {

        serverButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });

        hostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });

        clientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });

       /* clientButton.onClick.AddListener(() => {
            UnityTransport transport =
                NetworkManager.Singleton.GetComponent<UnityTransport>();

            transport.SetConnectionData(
                "192.168.1.246",
                7777
            );

            NetworkManager.Singleton.StartClient();
        });*/
    }
}
