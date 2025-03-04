using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
        public Canvas mainMenuCanvas;

        public int something;
        public List<int> somethingToList;
        
        public List<GameObject> menuItems;

        private Action _multipleActions;
        
        
        [Header("Main Menu Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;

        public void Awake()
        {
                // _multipleActions += () =>
                // {
                //         
                //         QuitButton();
                //         PlayButton();
                // };
                // _multipleActions -= PlayButton;
                // _multipleActions.Invoke();
                
                
                
                this.menuItems.Add(playButton.gameObject);
                this.menuItems.Add(exitButton.gameObject);

                var somethingToTake = this.menuItems.FirstOrDefault(x => x.gameObject.name.ToLower().Contains("play"));

                if (somethingToTake != null)
                {
                        Debug.Log($"From Lambda Expression {somethingToTake.gameObject.name}");
                }
                for (int i = 0; i < this.menuItems.Count; i++)
                {
                        string childName = this.menuItems[i].name.ToLower();
                        Button button = this.menuItems[i].GetComponent<Button>();

                        switch (childName)
                        {
                                case string name when name.Contains("play"):
                                        this.playButton = button;
                                        break;

                                case string name when name.Contains("quit"):
                                        this.exitButton = button;
                                        break;
                        }
                }
              
                playButton.onClick.AddListener(PlayButton);
                exitButton.onClick.AddListener(QuitButton);
        }

        private void PlayButton()
        {
                SceneManager.LoadSceneAsync(1);
        }
        private void QuitButton()
        {
                Debug.Log("Quit");
        }
     
}
