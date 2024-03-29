﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader.model;
using CsgoDamageVisualizerCore.utils;

namespace CsgoDamageVisualizerCore.loader
{
    public class CfgParser
    {

        private const string WEAPON_PREFAB_START_PATTERN = @"^\s+""weapon_\w+_prefab""\s*";
        private const string OPENING_BRACES_PATTERN = @"\s*?\{\s*";
        private const string CLOSING_BRACES_PATTERN = @"\s*?\}\s*";

        private State currentState = State.BEFORE_FIRST;
        private int currentIndentationLevel = 0;
        private int weaponDefintitionIdentationLevel = 0;

        public IReadOnlyDictionary<string, CfgWeapon> ParseCfgFile()
        {
            Dictionary<string, CfgWeapon> weapons = new Dictionary<string, CfgWeapon>();
            CfgWeapon currentWeapon = new CfgWeapon();
            IReadOnlyDictionary<string, string> cfgAttributeNameToInternalFieldNameMap = CfgWeapon.GetAttributeNameMap();

            CfgLoader loader = new CfgLoader();
            string[] lines = Task.Run(async() => await loader.LoadCfgFileAsync()).Result; // todo: make parsing work async ona per-line base (i.e. streaming each line)



            foreach (string line in lines)
            {
                State newState = FindNewState(line);

                switch (newState)
                {
                    case State.IN_WEAPON_DEFINITION:
                        {
                            if(currentState == State.BEFORE_FIRST || currentState == State.BETWEEN_WEAPON_DEFINITION) //if we are now in a weapon definition whereas we weren't before
                            {
                                currentWeapon = new CfgWeapon();
                            }

                            if (Regex.IsMatch(line, WEAPON_PREFAB_START_PATTERN))
                            {
                                currentWeapon.__name = line.Trim().Replace("\"", "");
                            }
                            else
                            {
                                KeyValuePair<string, string> attributeNameAndValue = GetAttributeNameAndValueFromLine(line);
                                if(attributeNameAndValue.Key != null && attributeNameAndValue.Value != null && cfgAttributeNameToInternalFieldNameMap.ContainsKey(attributeNameAndValue.Key))
                                {
                                    string instanceFieldName = cfgAttributeNameToInternalFieldNameMap[attributeNameAndValue.Key];
                                    CfgWeapon.SetValue(currentWeapon, instanceFieldName, attributeNameAndValue.Value);
                                }
                                
                            }
                        }
                        break;

                    case State.BETWEEN_WEAPON_DEFINITION:
                        {
                            if(currentState == State.IN_WEAPON_DEFINITION) //We left a weapon definition block
                            {
                                weapons.Add(currentWeapon.__name ?? throw new NullReferenceException("Could not extract prefab name for weapon " + currentWeapon), currentWeapon);
                            }
                        }
                        break;
                }

                currentState = newState;
            }

            return weapons;
        }

        //Find CFG file

        //Load lines of CFG file

        //for each {: increase indentation level, for each }: decrease it

        //if line matches "weapon_\s*_prefab": create new CfgWeapon, save indentation level

        //if attribute list doesnt exist: create it

        //write attribute into instance

        //if current indentation level == that of the opening "weapon_\s*_prefab": save current CfgWeapon to list

        //next line...

        

        private State FindNewState(string line)
        {
            if (Regex.IsMatch(line, OPENING_BRACES_PATTERN)) {
                currentIndentationLevel++;
            }
            
            if(Regex.IsMatch(line, CLOSING_BRACES_PATTERN))
            {
                currentIndentationLevel--;
            }

            switch (currentState)
            {
                case State.BEFORE_FIRST:
                    {
                        if (IsStartForNewWeaponDefinition(line))
                        {
                            weaponDefintitionIdentationLevel = currentIndentationLevel;
                            return State.IN_WEAPON_DEFINITION;
                        }
                        break;
                    }
                case State.BETWEEN_WEAPON_DEFINITION:
                    {
                        if (IsStartForNewWeaponDefinition(line))
                        {
                            return State.IN_WEAPON_DEFINITION;
                        }
                        break;
                    }
                case State.IN_WEAPON_DEFINITION:
                    {
                        if (Regex.IsMatch(line, CLOSING_BRACES_PATTERN) && currentIndentationLevel == weaponDefintitionIdentationLevel)
                        {

                            return State.BETWEEN_WEAPON_DEFINITION;
                        }
                        break;
                    }
            }
            return currentState;
        }

        private static bool IsStartForNewWeaponDefinition(string line)
        {
            IEnumerable<string> forbiddenMatches =
                from forbiddenWeaponName in ICsgoDamageVisualizerConfig.Instance.ForbiddenWeaponsList 
                    where line.Contains(forbiddenWeaponName)
                    select forbiddenWeaponName;

            return Regex.IsMatch(line, WEAPON_PREFAB_START_PATTERN)
                   && !forbiddenMatches.Any();
        }


        /// <summary>
        /// Gets the atribute name and the attribute value of a line. A line is only considered when its well-formed, matching  the following pattern:
        /// 
        ///     <list type="number">
        ///     <item>Any ammount of whitespaces (disregarded)</item>
        ///     <item>A doublt quote ("), marking the begin of the attribute name (not inclusive)</item>
        ///     <item>Any character, representing the atribute name</item>
        ///     <item>A seconds double quote, marking the end of the attrivute name (not inclusive)</item>
        ///     <item>Any number of whitespaces and one double quote (disregarded)</item>
        ///     <item>Any character, representing the attribute value</item>
        ///     <item>Either a double quote, a carriage return or a new line, marking the ned of the atribute value (not inclusive)</item>
        ///     </list>
        /// 
        /// </summary>
        /// <param name="s">The line to scan</param>
        /// <returns>The attribute name and value as a KeyValuePair. If the line is not well-formed, the key and value will be empty.</returns>
        public KeyValuePair<string, string> GetAttributeNameAndValueFromLine(string s)
        {
            if(Regex.IsMatch(s, @"\s*"".+""\s*""?.+""?")) //regex for attribute assignment: "<attribute name>" "<attribute value>"
            {
               
                string attributeName, attributeValue;
                string[] splitLine = (" " + s).Split('\"'); //preface with space to guarantee that the first element is always discardable, even if the actual line starts instantly with a quote (")
                attributeName = splitLine[1];
                if(splitLine.Length > 3) //only > 3 if the line has a second pair of quotes for the attribute value
                {
                    attributeValue = splitLine[3];
                }
                else
                {
                    attributeValue = splitLine[2].TrimStart();
                }

                return new KeyValuePair<string, string>(attributeName, attributeValue);
            }
            else
            {
                return new KeyValuePair<string, string>();
            }

            
        }

        public override string ToString()
        {
            return $"{nameof(CfgParser)}{{{nameof(currentState)}: {currentState}, {nameof(currentIndentationLevel)}: {currentIndentationLevel}, {nameof(weaponDefintitionIdentationLevel)}: {weaponDefintitionIdentationLevel}}}";
        }

        private enum State
        {
            BEFORE_FIRST,
            IN_WEAPON_DEFINITION,
            BETWEEN_WEAPON_DEFINITION
        }


    }

    
}
