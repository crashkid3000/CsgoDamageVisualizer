using System;
using System.Collections.Generic;
using System.Linq;
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

        private const string WEAPON_PREFAB_START_PATTERN = @"\s+weapon_\w+_prefab\s*";
        private const string OPENING_BRACES_PATTERN = @"\s+\{\s+";
        private const string CLOSING_BRACES_PATTERN = @"\s+\}\s+";

        private State currentState = State.BEFORE_FIRST;
        private int currentIndentationLevel = 0;
        private int weaponDefintitionIdentationLevel = 0;

        public IReadOnlyDictionary<string, CfgWeapon> ParseCfgFile()
        {
            Dictionary<string, CfgWeapon> weapons = new Dictionary<string, CfgWeapon>();
            CfgWeapon currentWeapon;

            CfgLoader loader = new CfgLoader();
            string[] lines = Task.Run(async() => await loader.LoadCfgFileAsync()).Result;

            foreach(string line in lines)
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
                        if (Regex.IsMatch(line, WEAPON_PREFAB_START_PATTERN))
                        {
                            weaponDefintitionIdentationLevel = currentIndentationLevel;
                            return State.IN_WEAPON_DEFINITION;
                        }
                        break;
                    }
                case State.BETWEEN_WEAPON_DEFINITION:
                    {
                        if (Regex.IsMatch(line, WEAPON_PREFAB_START_PATTERN))
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
            if(Regex.IsMatch(s, @"\s+"".+""\s*""?.+""?")) //regex for attribute assignment: "<attribute name>" "<attribute value>"
            {
                int indexAttributeNameStarts, indexAttributeNameEnds;
                string attributeName, attributeValue;
                IEnumerable<char> _attribName, _attribVal;

                _attribName = s.SkipWhile(character => !character.Equals('\"')).TakeWhile(character => !character.Equals('\"'));
                attributeName = string.Concat(_attribName);
                indexAttributeNameStarts = Regex.Match(s, attributeName).Index;
                indexAttributeNameEnds = indexAttributeNameStarts + attributeName.Length;
                s = s.Remove(0, indexAttributeNameEnds);
                s = s.TrimStart();
                _attribVal = s.SkipWhile(character => character.Equals('\"') || char.IsWhiteSpace(character)).TakeWhile(character => !character.Equals('\"') || !character.Equals('\r') || !character.Equals('\n'));
                attributeValue = string.Concat(_attribVal);

                return new KeyValuePair<string, string>(attributeName, attributeValue);
            }
            else
            {
                return new KeyValuePair<string, string>();
            }

            
        }

        private enum State
        {
            BEFORE_FIRST,
            IN_WEAPON_DEFINITION,
            BETWEEN_WEAPON_DEFINITION
        }


    }

    
}
