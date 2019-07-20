namespace Controller
{
    /**
     * Custom implementation of DefaultTrackableEventHandler which invokes the registration of the attached object to TargetController.
     *
     * @author Cong Minh Nguyen, Tuan Tung Tran
     * @date 20.07.2019
     */
    public class QrTrackableEventHandler : DefaultTrackableEventHandler
    {
        public QrTargetController qrTargetController;


        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();

            qrTargetController.Register();
        }
    }
}