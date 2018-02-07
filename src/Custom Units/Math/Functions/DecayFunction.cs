﻿using Ludiq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Bolt.Addons.Community.Custom_Units.Math.Functions
{
    /// <summary>
    /// Takes a given float input (0-1) and scales it across the specified range.
    /// </summary>
    [UnitCategory("Math/Functions")]
    [UnitTitle("Decay")]
    [UnitOrder(3)]
    public class DecayFunction : Unit
    {
        public DecayFunction() : base() { }

        /// <summary>
        /// The (0-1) input to interpolate onto the range between minimum and maximum
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueInput input { get; private set; }

        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Minimum")]
        public ValueInput minimum { get; private set; }

        /// <summary>
        /// The maximum valid output.  Returned when the input is 1.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("DecayFactor")]
        public ValueInput decayFactor { get; private set; }

        /// <summary>
        /// The maximum valid output.  Returned when the input is 1.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("Scale")]
        public ValueInput scale { get; private set; }


        /// <summary>
        /// The result of the interpolation (minimum-maximum).
        /// </summary>
        [DoNotSerialize]
        [PortLabelHidden]
        public ValueOutput output { get; private set; }

        [DoNotSerialize]
        protected float defaultMinimum => 0;

        [DoNotSerialize]
        protected float defaultDecayFactor => 1;

        [DoNotSerialize]
        protected float defaultScale => 1;

        protected override void Definition()
        {
            input = ValueInput<float>(nameof(input), 0);
            minimum = ValueInput<float>(nameof(minimum), defaultMinimum);
            decayFactor = ValueInput<float>(nameof(decayFactor), defaultDecayFactor);
            scale = ValueInput<float>(nameof(scale), defaultScale);
            output = ValueOutput<float>(nameof(output), (x) => output.GetValue<float>());

            Relation(input, output);
            Relation(minimum, output);
            Relation(decayFactor, output);
            Relation(scale, output);
        }

        private float Operation(Recursion recursion)
        {
            return MathLibrary.DecayFunction(input.GetValue<float>(), minimum.GetValue<float>(), decayFactor.GetValue<float>(), scale.GetValue<float>());
        }
    }
}