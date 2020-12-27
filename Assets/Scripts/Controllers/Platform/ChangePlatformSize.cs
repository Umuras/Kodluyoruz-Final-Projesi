#define DEBUG
using UnityEngine;

namespace Game.Controllers.Platform
{
    public class ChangePlatformSize : MonoBehaviour
    {
        public PlatformSizeChangeType sizeChangeType;
        public float maxSizeLimit = 3;
        public float MinSizeLimit = 2;

        private Vector3 defaultSize;
        private Vector3 changeVector = Vector3.zero;

        private void Start()
        {
            defaultSize = transform.localScale;
            SetChangeVector();
        }

        void Update()
        {
            if (sizeChangeType == PlatformSizeChangeType.NONE)
                return;
#if DEBUG
            SetChangeVector();
#endif
            UpdateSize();
        }

        private void SetChangeVector()
        {
            if (sizeChangeType == PlatformSizeChangeType.NONE)
                changeVector = Vector3.zero;

            else if (sizeChangeType == PlatformSizeChangeType.WIDTH_CHANGE)
                changeVector = Constants.X_AXIS;

            else if (sizeChangeType == PlatformSizeChangeType.LENGTH_CHANGE)
                changeVector = Constants.Y_AXIS;

            else if (sizeChangeType == PlatformSizeChangeType.DEPTH_CHANGE)
                changeVector = Constants.Z_AXIS;

            else if (sizeChangeType == PlatformSizeChangeType.UNIFORM_CHANGE)
                changeVector = new Vector3(1, 1, 1);
        }

        private void UpdateSize()
        {
            float changeAmount = Mathf.PingPong(Time.time, (maxSizeLimit - MinSizeLimit)) + MinSizeLimit;
            transform.localScale = defaultSize + changeVector * changeAmount;
        }

    }
}

