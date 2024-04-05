namespace Modules.DamageSystem
{
    public class ConditionPresenter
    {
        private Condition _condition;
        private ConditionView _conditionView;
        
        public ConditionPresenter(Condition condition, ConditionView conditionView)
        {
            _condition = condition;
            _conditionView = conditionView;

            _condition.Knoked += OnKnockedOut;
            _condition.Recovered += OnRecover;
        }

        private void OnKnockedOut()
        {
            _conditionView.OnKnockedOut();
        }

        private void OnRecover()
        {
            _conditionView.OnRecover();
        }

        public void Dispose()
        {
            _condition.Knoked -= OnKnockedOut;
            _condition.Recovered -= OnRecover;
        }
    }
}