namespace Infrastructure.States
{
    public interface IPayloadedTwoState<TPayload1, TPayload2> : IExitableState
    {
        void Enter(TPayload1 payload1, TPayload2 payload2);
    }
}