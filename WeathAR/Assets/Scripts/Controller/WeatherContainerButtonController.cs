using System;
using Model;
using UnityEngine;

namespace Controller
{
    /**
     * Handles logic for the buttons in the weather container.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    public class WeatherContainerButtonController : MonoBehaviour
    {
        private DayType currentDayType;

        private Action<DayType> callback;

        /**
         * Bind the given callback to the system.
         *
         * @param[in] callback callback function which handles the changes of the day type
         */
        public void Bind(Action<DayType> callback)
        {
            ResetValues();

            this.callback = callback;
            callback(currentDayType);
        }

        private void ResetValues()
        {
            currentDayType = DayType.Today;
        }

        /**
         * Switch forward.
         */
        public void SwitchForward()
        {
            DayType nextDayType;
            switch (currentDayType)
            {
                case DayType.Today:
                    nextDayType = DayType.Tomorrow;
                    break;
                //case DayType.Tomorrow:
                //case DayType.DayAfterTomorrow:
                default:
                    nextDayType = DayType.DayAfterTomorrow;
                    break;
            }

            // fetch new data if necessary
            if (nextDayType != currentDayType)
            {
                callback(nextDayType);
                currentDayType = nextDayType;
                UpdateButtons();
            }
        }

        /**
         * Switch backward.
         */
        public void SwitchBackward()
        {
            DayType previousDayType;
            switch (currentDayType)
            {
                case DayType.DayAfterTomorrow:
                    previousDayType = DayType.Tomorrow;
                    break;
                case DayType.Tomorrow:
                case DayType.Today:
                default:
                    previousDayType = DayType.Today;
                    break;
            }

            // fetch new data if necessary
            if (previousDayType != currentDayType)
            {
                callback(previousDayType);
                currentDayType = previousDayType;
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            switch (currentDayType)
            {
                case DayType.Today:
                    ChangeClickableState("ForwardButton", true);
                    ChangeClickableState("BackwardButton", false);
                    break;
                case DayType.Tomorrow:
                    ChangeClickableState("ForwardButton", true);
                    ChangeClickableState("BackwardButton", true);
                    break;
                case DayType.DayAfterTomorrow:
                    ChangeClickableState("ForwardButton", false);
                    ChangeClickableState("BackwardButton", true);
                    break;
            }
        }

        private void ChangeClickableState(string elementName, bool active)
        {
            transform.Find(elementName).gameObject.SetActive(active);
        }
    }
}