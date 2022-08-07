﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using CsgoDamageVisualizerCore.loader.model;
using CsgoDamageVisualizerCore.extensions;

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

            CfgLoader loader = new CfgLoader();
            string[] lines = Task.Run(async() => await loader.LoadCfgFileAsync()).Result;

            foreach(string line in lines)
            {
                findNewState(line);

                switch (currentState)
                {

                }
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

        

        private void findNewState(string line)
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
                            currentState = State.IN_WEAPON_DEFINITION;
                            weaponDefintitionIdentationLevel = currentIndentationLevel;
                        }
                        break;
                    }
                case State.BETWEEN_WEAPON_DEFINITION:
                    {
                        if (Regex.IsMatch(line, WEAPON_PREFAB_START_PATTERN))
                        {
                            currentState = State.IN_WEAPON_DEFINITION;
                        }
                        break;
                    }
                case State.IN_WEAPON_DEFINITION:
                    {
                        if (Regex.IsMatch(line, CLOSING_BRACES_PATTERN) && currentIndentationLevel == weaponDefintitionIdentationLevel)
                        {

                            currentState = State.BETWEEN_WEAPON_DEFINITION;
                        }
                        break;
                    }
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