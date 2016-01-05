The purpose of the project is to create an easy way to create xpath expressions for verifying the presence of elements in a document.

Expressions can be created based on attributes, parents, siblings, children, contained text and exact text.

More features will be supported in the near future.

Examples:
```
XPathFinder.Find.Tag("a").With.Parent("div").With.Parent("div").ToXPathExpression();

XPathFinder.Find.Tag("a").Containing("Home Page").ToXPathExpression();

XPathFinder.Find.Tag("div").With.Attribute("class","SomeCssClass").ToXPathExpression();

XPathFinder.Find.Tag("a").With.Attribute("href", "http://test.test.com").ToXPathExpression();

XPathFinder.Find.Tag("a").With.Text("Test").ToXPathExpression();

XPathFinder.Find.Tag("div").With.Attribute("class", "myClass").And.Attribute("attr1", "test1").And.Attribute("attr2","test2").ToXPathExpression();

string xpath = XPathFinder.Find.Tag("div").With.Attribute("id").Containing("_txtUserName").ToXPathExpression();

string xpath = XPathFinder.Find.Tag("a").With.Attribute("href", "http://www.test.com").And.Attribute("id").Containing("_lnkHome").ToXPathExpression();



```
Check out these article for more information on xpathitup <br />
http://www.unit-testing.net/CurrentArticle/How-To-Write-XPath-for-Selenium-Tests.html <br />
http://www.unit-testing.net/CurrentArticle/How-To-Make-Web-Tests-Less-Fragile.html

<b>Terms of Use</b><br />

This library is free software; you can redistribute it and/or <br />
modify it under the terms of the GNU General Public License<br />
as published by the Free Software Foundation; either version 2<br />
of the License, or (at your option) any later version.<br />

This library is distributed in the hope that it will be useful,<br />
but WITHOUT ANY WARRANTY; without even the implied warranty of<br />
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the<br />
GNU General Public License for more details.<br />

You should have received a copy of the GNU General Public License<br />
along with this library; if not, write to the Free Software<br />
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.<br />