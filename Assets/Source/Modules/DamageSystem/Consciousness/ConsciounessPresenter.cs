namespace Modules.DamageSystem
{
    public class ConsciounessPresenter
    {
        private Consciousness _consciousness;
        private ConsciousnessView _consciousnessView;
        
        public ConsciounessPresenter(Consciousness consciousness, ConsciousnessView consciousnessView)
        {
            _consciousness = consciousness;
            _consciousnessView = consciousnessView;

            _consciousness.Knocked += OnKnockedOut;
            _consciousness.Recovered += OnRecover;
        }

        private void OnKnockedOut()
        {
            _consciousnessView.OnKnockedOut();
        }

        private void OnRecover()
        {
            _consciousnessView.OnRecover();
        }

        public void Dispose()
        {
            _consciousness.Knocked -= OnKnockedOut;
            _consciousness.Recovered -= OnRecover;
        }
    }
}