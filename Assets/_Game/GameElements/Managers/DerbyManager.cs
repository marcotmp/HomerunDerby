using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcoTMP.Derby
{
    public class DerbyManager : MonoBehaviour
    {
        // Elements
        public Ball ball;
        public Batter batter;
        public Pitcher pitcher;
        public Catcher catcher;

        // HUD
        public UITimer timer;
        public DerbyScoreboard scoreboard;

        // Messages
        public UIMessage distanceMessage;
        public UIMessage homerunMessage;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            //batter.Init();
            //pitcher.Init();
            //timer.Init();

            catcher.OnBallCatched = () =>
            {
                Debug.Log("Catcher catched the ball");
                ActivateBattingAndPitching();
            };
            ball.OnLandOnHomerun = DoHomerun;
            pitcher.OnReleaseBall = OnReleaseBall;

            // when the bat is in position, check if hit the ball
            batter.OnBatSwang = ProcessHit;

            ActivateBattingAndPitching();
        }

        private void ActivateBattingAndPitching()
        {
            pitcher.GrabBall(ball);
            catcher.ReleaseBall();
            pitcher.Activate();
            batter.Activate();
        }

        private void OnReleaseBall()
        {
            Debug.Log("Ball move to home");
            ball.MoveToHome();
        }

        // called when batter has the specific bat frame animation
        public void ProcessHit()
        {
            Debug.Log("Ball was hit!");
            // if bat and ball are in the close range
            if (ball.IsInHitZone)
            {
                // deactivate batter
                batter.Deactivate();
                //view.SetFlyView();
                ball.MoveBy(Vector3.one);

                // maybe the interface should be:
                // velocity comes from batter homerun average
                // direction is a value calculated from the bat position
                // velocity = batter.GetHitVelocity();
                // direction = GetDirection(batter.BatPosition, ball);
                // move = direction * velocity;
                // ball.MoveTo(move);
                //

                // but for now
                // 
                // Vector3 move;
                // move.x = Random.Range(-1, 1); // horizontal movement
                // move.y = Random.Range(-1, 1); // vertical movement
                // move.z = 1;
                // move *= Random.Range(5, 100); // intensity
                // ball.MoveTo(move);

            }
        }

        public void DoHomerun()
        {
            scoreboard.homerun++;
            float seconds = 3;
            homerunMessage.Show(seconds, ActivateBattingAndPitching);
        }
    }

}