using Model;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles logic for toggle button.
 *
 * @author Max Shakurov, Cong Minh Nguyen
 * @date 20.07.2019
 * @link <https://github.com/Kalxoznik/Unity-Toggle-controller> <Unity-Toggle-controller> @endlink
 */
namespace Menu
{
    public class TemperatureToggleController : MonoBehaviour
    {
        public bool isOn;

        public Color onColorBg;
        public Color offColorBg;

        public Image toggleBgImage;
        public RectTransform toggle;

        public GameObject handle;
        private RectTransform handleTransform;

        private float handleSize;
        private float onPosX;
        private float offPosX;

        public float handleOffset;

        public GameObject onIcon;
        public GameObject offIcon;


        public float speed;
        static float t = 0.0f;

        private bool switching = false;


        void Awake()
        {
            handleTransform = handle.GetComponent<RectTransform>();
            RectTransform handleRect = handle.GetComponent<RectTransform>();
            handleSize = handleRect.sizeDelta.x;
            float toggleSizeX = toggle.sizeDelta.x;
            onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
            offPosX = onPosX * -1;
        }


        void Start()
        {
            if (isOn)
            {
                toggleBgImage.color = onColorBg;
                handleTransform.localPosition = new Vector3(onPosX, 0f, 0f);
                onIcon.gameObject.SetActive(true);
                offIcon.gameObject.SetActive(false);
            }
            else
            {
                toggleBgImage.color = offColorBg;
                handleTransform.localPosition = new Vector3(offPosX, 0f, 0f);
                onIcon.gameObject.SetActive(false);
                offIcon.gameObject.SetActive(true);
            }
        }

        void Update()
        {
            if (switching)
            {
                Toggle(isOn);
            }
        }

        private void ChangeTemperatureUnit()
        {
            Settings.temperatureUnit = isOn ? TemperatureUnit.Celsius : TemperatureUnit.Fahrenheit;
        }

        public void Switching()
        {
            switching = true;
        }


        public void Toggle(bool toggleStatus)
        {
            if (!onIcon.active || !offIcon.active)
            {
                onIcon.SetActive(true);
                offIcon.SetActive(true);
            }

            if (toggleStatus)
            {
                toggleBgImage.color = SmoothColor(onColorBg, offColorBg);
                Transparency(onIcon, 1f, 0f);
                Transparency(offIcon, 0f, 1f);
                handleTransform.localPosition = SmoothMove(handle, onPosX, offPosX);
            }
            else
            {
                toggleBgImage.color = SmoothColor(offColorBg, onColorBg);
                Transparency(onIcon, 0f, 1f);
                Transparency(offIcon, 1f, 0f);
                handleTransform.localPosition = SmoothMove(handle, offPosX, onPosX);
            }
        }


        Vector3 SmoothMove(GameObject toggleHandle, float startPosX, float endPosX)
        {
            Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += speed * Time.deltaTime), 0f, 0f);
            StopSwitching();
            return position;
        }

        Color SmoothColor(Color startCol, Color endCol)
        {
            Color resultCol;
            resultCol = Color.Lerp(startCol, endCol, t += speed * Time.deltaTime);
            return resultCol;
        }

        CanvasGroup Transparency(GameObject alphaObj, float startAlpha, float endAlpha)
        {
            CanvasGroup alphaVal;
            alphaVal = alphaObj.gameObject.GetComponent<CanvasGroup>();
            alphaVal.alpha = Mathf.Lerp(startAlpha, endAlpha, t += speed * Time.deltaTime);
            return alphaVal;
        }

        void StopSwitching()
        {
            if (t > 1.0f)
            {
                switching = false;

                t = 0.0f;
                switch (isOn)
                {
                    case true:
                        isOn = false;
                        ChangeTemperatureUnit();
                        break;

                    case false:
                        isOn = true;
                        ChangeTemperatureUnit();
                        break;
                }
            }
        }
    }
}