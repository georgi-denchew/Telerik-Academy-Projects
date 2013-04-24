using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public interface IUserInterface
    {
        event EventHandler OnLeftPressed;

        event EventHandler OnRightPressed;

        event EventHandler OnActionPressed;

        event EventHandler OnEscapePressed;

        event EventHandler OnUpPressed;

        event EventHandler OnDownPressed;

        event EventHandler OnEnterPressed;

        void ProcessInput();
    }
}
