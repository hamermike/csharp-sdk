/*
 * Bandwidth.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
 */
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Bandwidth.Standard;
using Bandwidth.Standard.Utilities;

namespace Bandwidth.Standard.Voice.Models
{
    [JsonConverter(typeof(StringValuedEnumConverter))]
    public enum State2Enum
    {
        NOTRECORDING,
        PAUSED,
        RECORDING,
    }

    /// <summary>
    /// Helper for the enum type State2Enum
    /// </summary>
    public static class State2EnumHelper
    {
        //string values corresponding the enum elements
        private static List<string> stringValues = new List<string> { "NOT_RECORDING", "PAUSED", "RECORDING" };

        /// <summary>
        /// Converts a State2Enum value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The State2Enum value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(State2Enum enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case State2Enum.NOTRECORDING:
                case State2Enum.PAUSED:
                case State2Enum.RECORDING:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of State2Enum values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of State2Enum values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<State2Enum> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into State2Enum value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed State2Enum value</returns>
        public static State2Enum ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type State2Enum", value));

            return (State2Enum) index;
        }
    }
}