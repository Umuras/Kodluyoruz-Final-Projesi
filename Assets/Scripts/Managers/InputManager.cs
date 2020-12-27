using System;
using UnityEngine;

namespace Game.Managers
{

    public class InputManager : Singleton<InputManager>
    {
        public delegate void TapEvent();
        public delegate void HoldEvent();
        public delegate void ReleaseEvent();

        public TapEvent OnTap;
        public HoldEvent OnHold;
        public ReleaseEvent OnRelease;

        private Touch touch;
        private Vector2 touchStartPosition, touchEndPosition;

        private void Update()
        {

#if UNITY_EDITOR
            HandleKeyboardInput();
#endif

#if UNITY_ANDROID || UNITY_REMOTE
            HandleTouchInput();
#endif
        }

        private void HandleKeyboardInput()
        {
            if (Input.GetKey(KeyCode.Return)) // press enter key
            {
                Tap();
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Release();
            }

            else if (Input.GetKey(KeyCode.Space))
            {
                Hold();
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                }

                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    Hold();
                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = touch.position;

                    float x = touchEndPosition.x - touchStartPosition.x;
                    float y = touchEndPosition.y - touchStartPosition.y;

                    if (Mathf.Abs(x) <= 0 && Mathf.Abs(y) <= 0)
                    {
                        Tap();
                    }

                    else
                    {
                        Release();
                    }
                }
            }
        }

        private void Tap()
        {
            if (OnTap == null)
                return;

            Delegate[] calls = OnTap.GetInvocationList();
            foreach (Delegate call in calls)
            {
                ((TapEvent)call).Invoke();
            }
        }

        private void Hold()
        {
            if (OnHold == null)
                return;

            Delegate[] calls = OnHold.GetInvocationList();
            foreach (Delegate call in calls)
            {
                ((HoldEvent)call).Invoke();
            }
        }

        private void Release()
        {
            if (OnRelease == null)
                return;

            Delegate[] calls = OnRelease.GetInvocationList();
            foreach (Delegate call in calls)
            {
                ((ReleaseEvent)call).Invoke();
            }
        }

    }
}

