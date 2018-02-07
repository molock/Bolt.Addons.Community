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
    [UnitTitle("Decay Function of Range")]
    [UnitOrder(4)]
    public class DecayFunctionOfRange : Unit
    {
        public DecayFunctionOfRange() : base() { }

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
        [PortLabel("MinimumRange")]
        public ValueInput minimumRange { get; private set; }


        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("MaximumRange")]
        public ValueInput maximumRange { get; private set; }

        /// <summary>
        /// The minimum valid output.  Returned when the input is 0.
        /// </summary>
        [DoNotSerialize]
        [PortLabel("MinimumValue")]
        public ValueInput minimumValue { get; private set; }


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
        protected float defaultMinimumRange => 0;

        [DoNotSerialize]
        protected float defaultMaximumRange => 100;

        [DoNotSerialize]
        protected float defaultMinimum => 0;

        [DoNotSerialize]
        protected float defaultDecayFactor => 1;

        [DoNotSerialize]
        protected float defaultScale => 1;

        protected override void Definition()
        {
            input = ValueInput<float>(nameof(input), 0);
            minimumRange = ValueInput<float>(nameof(minimumRange),defaultMinimumRange);
            maximumRange = ValueInput<float>(nameof(maximumRange), defaultMaximumRange);
            minimumValue = ValueInput<float>(nameof(minimumValue), defaultMinimum);
            decayFactor = ValueInput<float>(nameof(decayFactor), defaultDecayFactor);
            scale = ValueInput<float>(nameof(scale), defaultScale);
            output = ValueOutput<float>(nameof(output), (x) => output.GetValue<float>());

            Relation(minimumRange, input);
            Relation(maximumRange, output);
            Relation(input, output);
            Relation(minimumValue, output);
            Relation(decayFactor, output);
            Relation(scale, output);
        }

        private float Operation(Recursion recursion)
        {
            return MathLibrary.DecayFunctionOfRange(input.GetValue<float>(), minimumRange.GetValue<float>(), maximumRange.GetValue<float>(), maximumRange.GetValue<float>(), decayFactor.GetValue<float>(), scale.GetValue<float>());
        }
    }
}