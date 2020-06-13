﻿using Military.Contracts;
using Military.Enumerations;
using Military.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Mission : IMission
    {

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParceState(state);
        }
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            this.State = State.Finished;
        }

        private State TryParceState(string stateStr)
        {
            State state;

            bool parsed = Enum.TryParse<State>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }
            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
        }
    }
}
