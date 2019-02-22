using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {
        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform TextPrice;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        

        // Use this for initialization
        void Start()
        {

            //add Audio Source as new game object component

            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }
        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log ("Active image target:" +name +" -size: " +size.x + "," +size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName.Button, Description and Panel will visible(active)
            
                
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                TextPrice.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);

                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound(locate in Resources/ sounds folder)and set text on TextDescription a description of the zombie
            
                if (name == "Menu16bit")
                {
                    TextTargetName.GetComponent<Text>().text = "CHICKEN & BACON SET";         
                    TextDescription.GetComponent<Text>().text = "Our famous Chicken & Bacon sandwich with curry dressing, wedge fries, 2 chicken wing and homemade chili sauce and remoulade as well as free choice of uor signaure fruit soda. You must try this sandwich!" ;
                    TextPrice.GetComponent<Text>().text = "THB249";
                }

            //If the target name was “unitychan” then add listener to ButtonActionwith location of the unitychan sound(locate in Resources/ soundsfolder) and set text on TextDescription a description of the unitychan/ robot
        
                if (name == "Menu216bit")
                {
                    TextTargetName.GetComponent<Text>().text = "CHILI CHEESE SANDWICH";
                    TextDescription.GetComponent<Text>().text = "This beauty is packed with everythin tha comes on our signature Cheese Steak Sandwich, with the addition of some jalapeno chilies and some special chili sauce to give it a nice little kick!";
                    TextPrice.GetComponent<Text>().text = "THB149";
                }
            }   
        }
//function to play sound
void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}