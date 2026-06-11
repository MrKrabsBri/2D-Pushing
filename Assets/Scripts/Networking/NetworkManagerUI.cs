using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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
    }
}
