﻿using RuleBasedEngine.Engine.Interfaces;
using System;
using System.Linq.Expressions;

namespace RuleBasedEngine.Engine
{
    partial class RuleEngine : ICanCreateCondition
    {
        public ICanAddStringOperation If<T>(Expression<Func<T, string>> member)
        {
            InitiateCondition<T, string>(member);
            return this;
        }

        public ICanAddIntOperation If<T>(Expression<Func<T, int>> member)
        {
            InitiateCondition<T, int>(member);
            return this;
        }

        public ICanAddBoolOperation If<T>(Expression<Func<T, bool>> member)
        {
            InitiateCondition<T, bool>(member);
            return this;
        }

        public ICanAddDateTimeOperation If<T>(Expression<Func<T, DateTime>> member)
        {
            InitiateCondition<T, DateTime>(member);
            return this;
        }

        public ICanAddOperation If<T, M>(Expression<Func<T, M>> member)
        {
            InitiateCondition<T, M>(member);
            return this;
        }
    }
}
