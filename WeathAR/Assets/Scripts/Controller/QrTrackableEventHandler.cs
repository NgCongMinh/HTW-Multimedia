namespace Controller
{
    public class QrTrackableEventHandler : DefaultTrackableEventHandler
    {

        public QRTargetController qrTargetController;
        
        
        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();
            
            qrTargetController.Register();
            
        }
    }
}