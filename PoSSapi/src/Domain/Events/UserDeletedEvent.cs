namespace PoSSapi.Domain.Events;

public class UserDeletedEvent : BaseEvent
{
    public UserDeletedEvent(User user)
    {
        User = user;
    }

    public User User { get; }
}
