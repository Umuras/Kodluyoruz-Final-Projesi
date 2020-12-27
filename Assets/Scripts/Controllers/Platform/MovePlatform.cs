// #define DEBUG
using Game;
using UnityEngine;

namespace Game.Controllers.Platform
{

    public class MovePlatform : MonoBehaviour
    {
        public PlatformMovingDirection direction;
        public float speed;
        public float movementRange;

        private Vector3 directionVector = Vector3.zero;
        private Vector3 defaultPosition;
        private float posChange;

        private void Start()
        {
            defaultPosition = transform.position;
            SetDirectionVector();
        }

        public void Update()
        {
            if (direction == PlatformMovingDirection.NONE)
                return;
#if DEBUG
            SetDirectionVector();
#endif
            Move();
        }

        private void SetDirectionVector()
        {
            if (direction == PlatformMovingDirection.NONE)
                directionVector = Vector3.zero;

            else if (direction == PlatformMovingDirection.HORIZONTAL)
                directionVector = Constants.X_AXIS;

            else if (direction == PlatformMovingDirection.VERTICAL)
                directionVector = Constants.Y_AXIS;

            else if (direction == PlatformMovingDirection.Z_AXIS)
                directionVector = Constants.Z_AXIS;
        }

        private void Move()
        {
            posChange = Mathf.Sin(Time.time * speed) * movementRange;
            transform.position = defaultPosition + directionVector * posChange;
        }
    }
}
