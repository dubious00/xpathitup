﻿/*
Copyright (C) 2010  Torgeir Helgevold

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPathItUp
{
    internal class SiblingElement:Base, ISibling
    {
        private int tagIndex = 0;
       
        public static SiblingElement Create(string tag, List<string> expressionParts, string siblingType)
        {
            return new SiblingElement(tag,expressionParts,siblingType);
        }

        private SiblingElement(string tag, List<string> expressionParts, string siblingType)
        {
            this.ExpressionParts = expressionParts;
            tagIndex++;
            this.ExpressionParts.Insert(tagIndex,string.Format("/{0}::{1}", siblingType, tag));
        }

        public new ILimitedWith With
        {
            get { return WithExpression.Create(this.ExpressionParts, this.tagIndex); }
        }
    }
}