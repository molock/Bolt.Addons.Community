﻿using Ludiq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bolt.Addons.Community.Logic.Units
{
    /// <summary>
    /// Branches flow by checking if a condition is true or false.
    /// </summary>
    [UnitCategory("Control")]
    [TypeIcon(typeof(ISelectUnit))]
    [UnitOrder(0)]
    public sealed class Gate : Unit
    {
        public Gate() : base() { }

        /// <summary>
        /// The entry point for the branch.
        /// </summary>
        [DoNotSerialize]
        public ControlInput enter { get; private set; }


        /// <summary>
        /// The entry point for the branch.
        /// </summary>
        [DoNotSerialize]
        public ControlInput open { get; private set; }


        /// <summary>
        /// The entry point for the branch.
        /// </summary>
        [DoNotSerialize]
        public ControlInput close { get; private set; }



        /// <summary>
        /// The entry point for the branch.
        /// </summary>
        [DoNotSerialize]
        public ControlInput toggle { get; private set; }


        /// <summary>
        /// The condition to check.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Initially Open")]
        public ValueInput initialState { get; private set; }


        /// </summary>
        [DoNotSerialize]
        [PortLabel("Exit")]
        public ControlOutput exit { get; private set; }

        private bool _isInitial = true;
        private bool _isOpen = false;

        protected override void Definition()
        {
            enter = ControlInput(nameof(enter), Enter);
            open = ControlInput(nameof(open), Open);
            close = ControlInput(nameof(close), Close);
            toggle = ControlInput(nameof(toggle), Toggle);
            initialState = ValueInput<bool>(nameof(initialState), true);
            exit = ControlOutput(nameof(exit));

            Relation(enter, exit);
            Relation(initialState, exit);
        }


        public void Enter(Flow flow)
        {
            PrepInitialState();

            if (_isOpen)
                flow.Invoke(exit);
        }

        private void Open(Flow obj)
        {
            _isOpen = true;
        }

        private void Close(Flow obj)
        {
            _isOpen = false;
        }

        private void Toggle(Flow obj)
        {
            _isOpen = !_isOpen;
        }



        private void PrepInitialState()
        {
            if (_isInitial)
                _isOpen = initialState.GetValue<bool>();
            _isInitial = false;
        }
    }
}