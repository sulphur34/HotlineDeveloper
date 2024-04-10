namespace Modules.DamageSystem
{
    public class ConditionPresenter
    {
        private Consciouness _consciouness;
        private ConsciounessView _consciounessView;
        
        public ConditionPresenter(Consciouness consciouness, ConsciounessView consciounessView)
        {
            _consciouness = consciouness;
            _consciounessView = consciounessView;

            _consciouness.Knoked += OnKnockedOut;
            _consciouness.Recovered += OnRecover;
        }

        private void OnKnockedOut()
        {
            _consciounessView.OnKnockedOut();
        }

        private void OnRecover()
        {
            _consciounessView.OnRecover();
        }

        public void Dispose()
        {
            _consciouness.Knoked -= OnKnockedOut;
            _consciouness.Recovered -= OnRecover;
        }
    }
}