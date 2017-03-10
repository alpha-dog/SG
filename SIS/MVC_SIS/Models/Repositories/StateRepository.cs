using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public static class StateRepository
    {
        private static List<State> _state;

        static StateRepository()
        {
            // sample data
            _state = new List<State>
            {
                new State { StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateAbbreviation="OH", StateName="Ohio" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            return _state;
        }

        public static State Get(string stateAbbreviation)
        {
            return _state.FirstOrDefault(s => s.StateAbbreviation == stateAbbreviation);
        }
        
        public static void Add(string stateName, string stateAbrv )
        {
            State state = new State();
            state.StateName = stateName;
            state.StateAbbreviation = stateAbrv;

            _state.Add(state);
            //Major major = new Major();
            //major.MajorName = majorName;
            //major.MajorId = _majors.Max(c => c.MajorId) + 1;

            //_majors.Add(major);
        }

        public static void Edit(State state)
        {
            var selectedState = _state.FirstOrDefault(s => s.StateAbbreviation == state.StateAbbreviation);

            selectedState.StateName = state.StateName;
            //selectedState.StateAbbreviation = state.StateAbbreviation;
        }

        public static void Delete(string stateAbbreviation)
        {

            _state.RemoveAll(s => s.StateAbbreviation == stateAbbreviation);
        }

        public static void Add(State newState)//What the hell did i make this for
        {
            State state = new State();
            state.StateName = newState.StateName;
            state.StateAbbreviation = newState.StateAbbreviation;

            _state.Add(state);
        }
    }
}