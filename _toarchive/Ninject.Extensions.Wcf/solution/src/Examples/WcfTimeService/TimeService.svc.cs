﻿#region License

// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using System;
using System.ServiceModel;
using WindowsTimeService;

#endregion

namespace WcfTimeService
{

    public class TimeService : ITimeService
    {
        private readonly ISystemClock _systemClock;

     

        public TimeService( ISystemClock systemClock )
        {
            _systemClock = systemClock;
        }

        #region Implementation of ITimeService

        public DateTime WhatTimeIsIt()
        {
            return _systemClock.Now;
        }

        #endregion
    }
}