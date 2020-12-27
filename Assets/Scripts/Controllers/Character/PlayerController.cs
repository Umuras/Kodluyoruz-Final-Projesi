using System;
using Game.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Controllers.Character
{
    public class PlayerController : MonoBehaviour
    {
        public float forwardForce;
        public float upForce;
        public Vector3 maxForceLimit;
        public float maxYPosLimit;
        public ParticleSystem particleEffect;
        public FuelBar fuelBar;
        public Text scoreText;

        private Rigidbody rb;
        private Vector3 totalForce;
        private PlayerState playerState;
        private LevelState levelState;
        private int _counter;

        #region Monobehaviour Functions
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            levelState = FindObjectOfType<LevelState>();
            fuelBar.OnFuelFinished += OnFuelFinished;

            totalForce = Vector3.zero;
            playerState = PlayerState.STANDING;
        }

        private void FixedUpdate()
        {
            // bu kuşulun en üstte olmassı gerekli
            if (transform.position.y <= -3)
            {
                playerState = PlayerState.DEAD;
                levelState.GameOver(false);
            }

            else if (playerState == PlayerState.MOVING && fuelBar.HasFuel())
            {
                fuelBar.BurnFuel();
                Move();
            }

            else if(playerState == PlayerState.STANDING)
            {
                fuelBar.RefillFuel();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("platform"))
            {
                Stand();
            }

            else if (collision.gameObject.CompareTag("finishLine"))
            {
                levelState.GameOver(true);
            }

            else if (collision.gameObject.CompareTag("checkpoint"))
            {
                playerState = PlayerState.DEAD;
                StopMove();
                levelState.GameOver(false);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("platform"))
            {
                playerState = PlayerState.MOVING;
            }
        }
        #endregion

        internal void IsMoving(bool isMoving)
        {
            if (isMoving)
                playerState = PlayerState.MOVING;

            else
            {
                StopMove();
            }
        }

        internal int GetScore()
        {
            return _counter;
        }

        private void Move()
        {
            if (transform.position.y > maxYPosLimit)
                return;

            Vector3 force = transform.forward * forwardForce + transform.up * upForce;
            if(!IsExceedForceLimit(force))
            {
                totalForce += force;
                // Debug.Log(totalForce);
                rb.AddForce(force, ForceMode.Impulse);
                if(!particleEffect.isPlaying)
                    particleEffect.Play();
            }

        }

        private void StopMove()
        {
            // Debug.Log("Stop");
            totalForce = Vector3.zero;
            particleEffect.Stop();
            playerState = PlayerState.FALLING;

            // adding downward froce to speed up falling
            Vector3 force = -transform.up * upForce / 2;
            rb.AddForce(force, ForceMode.Impulse);
        }

        private void Stand()
        {
            // force yüzünden devrilip düşmesin diye
            rb.velocity = Vector3.zero;
            playerState = PlayerState.STANDING;
        }

        private bool IsExceedForceLimit(Vector3 force)
        {
            Vector3 tempTotalForce = totalForce + force;
            if (tempTotalForce.magnitude > maxForceLimit.magnitude)
                return true;
            return false;
        }

        private void OnFuelFinished()
        {
            StopMove();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "coin")
            {
                other.gameObject.SetActive(false);

                _counter++;

                scoreText.text = "Score: " + _counter;
            }
        }
    }
}


