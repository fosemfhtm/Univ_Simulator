﻿using Patterns.StateMachine;

namespace Tools.UI.Card
{
    public interface IUiCard : IStateMachineHandler, IUiCardComponents, IUiCardTransform
    {
        bool IsDragging { get; }
        bool IsHovering { get; }
        bool IsDisabled { get; }
        void Disable();
        void Enable();
        void Select();
        void Unselect();
        void Hover();
        void Draw();
        void Discard();
        // int Attack { get; }
        // int Defense { get; }
        // int Heal { get; }
    }
}