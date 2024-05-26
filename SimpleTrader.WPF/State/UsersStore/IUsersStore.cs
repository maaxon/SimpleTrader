using System;

namespace SimpleTrader.WPF.State.UsersStore
{
    public interface IUsersStore
    {
        int UserId { get; set; }
        event Action StateChanged;
    }
}