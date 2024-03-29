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
using NUnit.Framework;
using XPathItUp;

namespace UnitTests
{
    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void Will_Create_Xpath_With_Position_With_Parent_Anded1()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Parent("li").With.Attribute("class").Containing("secondNavItem").And.Position(2).
                And.Parent("ul").With.Parent("div").With.Attribute("class").Containing("questionBankNav").ToXPathExpression();
            Assert.AreEqual("//div[contains(@class,'questionBankNav')]/ul/li[contains(@class,'secondNavItem') and position()=2]/a", xpath);
        }

        [Test]
        public void Will_Create_Xpath_With_Position_With_Parent_Anded2()
        {
            string xpath = XPathFinder.Find.Tag("a").With.Position(2).And.Parent("li").With.Attribute("class").Containing(
                "secondNavItem").And.Parent("ul").With.Parent("div").With.Attribute("class").
                Containing("questionBankNav").ToXPathExpression();

            Assert.AreEqual("//div[contains(@class,'questionBankNav')]/ul/li[contains(@class,'secondNavItem')]/a[position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Two_Attributes()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Attribute("class").Containing("myClass").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and contains(@class,'myClass') and position()=3]", xpath);

            xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id", "someId").And.Attribute("class", "myClass").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and @id='someId' and @class='myClass' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Text_And_Position_And_Partial_Attribute()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Text("divText").And.Attribute("id").Containing("_id").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div[text()='divText' and contains(@id,'_id') and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("span").With.Position(3).ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::span[position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_And_Child_Anded()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Position(1).And.Child("span").ToXPathExpression();
            Assert.AreEqual("//div[position()=1]/span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_And_Text_On_Following_Sibling()
        {
            string xpath = XPathFinder.Find.Tag("div").With.FollowingSibling("span").With.Text("myText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//div/following-sibling::span[text()='myText' and position()=3]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.Position(2).ToXPathExpression();
            Assert.AreEqual("//div/span[position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Partial_Attribute_And_Position_On_Child1()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.Attribute("id").Containing("myId").And.Position(2).ToXPathExpression();
            Assert.AreEqual("//div/span[contains(@id,'myId') and position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Partial_Attribute_And_Position_On_Child2()
        {
            string xpath = XPathFinder.Find.Tag("td").With.Child("span").With.FollowingSibling("td").With
                    .Child("div").
                    With.Child("div").
                    With.Child("div").
                    With.Child("select").With.Attribute("id").Containing("_myId").And.Position(1).ToXPathExpression();

            Assert.AreEqual("//td/span/following-sibling::td/div/div/div/select[contains(@id,'_myId') and position()=1]", xpath);

        }

        [Test]
        public void Will_Create_Xpath_Query_With_Attribute_And_Position_On_Child()
        {
            string xpath = XPathFinder.Find.Tag("div").With.Child("span").With.Attribute("id","myId").And.Position(2).ToXPathExpression();
            Assert.AreEqual("//div/span[@id='myId' and position()=2]", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Parent()
        {
            string xpath = XPathFinder.Find.Tag("span").With.Parent("div").With.Position(2).ToXPathExpression();
            Assert.AreEqual("//div[position()=2]/span", xpath);
        }

        [Test]
        public void Will_Create_Xpath_Query_With_Position_On_Tag_With_Partial_Text()
        {
            string xpath = XPathFinder.Find.Tag("span").Containing("myText").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//span[contains(.,'myText') and position()=3]", xpath);

            xpath = XPathFinder.Find.Tag("span").Containing("myText").And.Attribute("class","test").And.Position(3).ToXPathExpression();
            Assert.AreEqual("//span[contains(.,'myText') and @class='test' and position()=3]", xpath);
        }

    }
}
