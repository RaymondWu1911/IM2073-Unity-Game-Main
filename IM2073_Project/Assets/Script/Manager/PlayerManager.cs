using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ray 
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;
        CameraHandler cameraHandler;
        PlayerLocomotion playerLocomotion;
        
        public bool isInteracting;
        public bool isSprinting;
        public bool canDoCombo;
        
    // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
            anim = GetComponentInChildren<Animator>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
        }

    // Update is called once per frame
        void Update()
        {
            float delta = Time.deltaTime;

            isInteracting = anim.GetBool("isInteracting");
            canDoCombo = anim.GetBool("canDoCombo");
    
            inputHandler.TickInput(delta);
            playerLocomotion.HandleMovement(delta);        
            playerLocomotion.HandleRollingAndSprinting(delta);
        }

        private void FixedUpdate() 
        {
            float delta = Time.fixedDeltaTime;

            if (cameraHandler != null) 
            {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
            }
        }

        private void LateUpdate()
        {
            inputHandler.rollFlag = false;
            inputHandler.sprintFlag = false;
            inputHandler.rb_Input = false;
            inputHandler.rt_Input = false;
        }

        private void Awake()
        {
            cameraHandler = CameraHandler.singleton;
        }
    }
}