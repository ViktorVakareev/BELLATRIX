﻿// <copyright file="ComboBox.cs" company="Automate The Planet Ltd.">
// Copyright 2021 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Diagnostics;
using Bellatrix.Desktop.Contracts;
using Bellatrix.Desktop.Events;

namespace Bellatrix.Desktop
{
    public class ComboBox : Component, IElementDisabled, IElementInnerText
    {
        public static event EventHandler<ElementActionEventArgs> Hovering;
        public static event EventHandler<ElementActionEventArgs> Hovered;
        public static event EventHandler<ElementActionEventArgs> Selecting;
        public static event EventHandler<ElementActionEventArgs> Selected;

        public virtual void Hover()
        {
            Hover(Hovering, Hovered);
        }

        public virtual void SelectByText(string value)
        {
            Selecting?.Invoke(this, new ElementActionEventArgs(this, value));

            if (WrappedElement.Text != value)
            {
                WrappedElement.SendKeys(value);
            }

            Selected?.Invoke(this, new ElementActionEventArgs(this, value));
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public virtual string InnerText => GetInnerText();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public virtual bool IsDisabled => GetIsDisabled();
    }
}