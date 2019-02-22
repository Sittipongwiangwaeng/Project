using UnityEngine;
using UnityEngine.UI;
namespace Vuforia
{
    /// &lt;summary&gt;
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// &lt;/summary&gt;
    public class DefaultTrackableEventHandler : MonoBehaviour,
    ITrackableEventHandler
    {
        public Transform TextName;
        public Transform ButtonAction;
        public Transform TextDescription;
        public Transform PanelDescription;
        #region PRIVATE_MEMBER_VARIABLES
        private TrackableBehaviour mTrackableBehaviour;
        #endregion // PRIVATE_MEMBER_VARIABLES
        #region UNTIY_MONOBEHAVIOUR_METHODS
        void Start()
        {
            mTrackableBehaviour = GetComponent <TrackableBehaviour> ();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }
        #endregion // UNTIY_MONOBEHAVIOUR_METHODS
        #region PUBLIC_METHODS
        /// &lt;summary&gt;
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// &lt;/summary&gt;
        public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {

                OnTrackingLost();
            }
        }
        #endregion // PUBLIC_METHODS

        #region PRIVATE_METHODS
        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren <Renderer> (true);
            Collider[] colliderComponents = GetComponentsInChildren <Collider> (true);
            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }
            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }
            Debug.Log("Trackable" + mTrackableBehaviour.TrackableName + "found");
        }
        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }
            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }
            Debug.Log("Trackable" +mTrackableBehaviour.TrackableName + "lost");

            TextName.GetComponent <Text> ().text = "SCAN" ;
            ButtonAction.gameObject.SetActive(false);
            TextDescription.gameObject.SetActive(false);
            PanelDescription.gameObject.SetActive(false);
        }
        #endregion // PRIVATE_METHODS

    }
}