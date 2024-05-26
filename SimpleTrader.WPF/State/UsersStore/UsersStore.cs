
    using System;

    namespace SimpleTrader.WPF.State.UsersStore
    {
        public class UsersStore:IUsersStore
        {
            private int _userId;
            public int UserId
            {
                get => _userId;
                set
                {
                    _userId = value;
                    StateChanged?.Invoke();
                }
            }

            public event Action StateChanged;
        }
    }
