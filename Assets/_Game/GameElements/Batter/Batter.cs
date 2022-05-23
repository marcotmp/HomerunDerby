using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcoTMP.Derby
{
    public class Batter : MonoBehaviour
    {
        public Transform bat;
        public Transform batIdlePosition;
        public Transform batHitPosition;

        [SerializeField] private InputController input;
        private bool isBatting;

        public Action OnBatSwang { get; internal set; }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Activate()
        {
            // start reading input
            input.OnPressButtonA = StartSwingAnim;

            // set Idle state
            // if HumanIdleState, read input
            // if BotIdleState, use some basic AI logic
        }

        internal void Deactivate()
        {
            // stop reading input
            input.OnPressButtonA = null;
            // change state to inactive
        }

        private void StartSwingAnim()
        {
            if (!isBatting)
                StartCoroutine(DoBatAnimation());
        }

        private IEnumerator DoBatAnimation()
        {
            isBatting = true;
            bat.position = batHitPosition.position;
            yield return new WaitForSeconds(1);
            bat.position = batIdlePosition.position;
            
            OnBatSwang();
            isBatting = false;
        }
    }
}