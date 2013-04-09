﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using OpenQA.Selenium;
using BumblebeeIOS.Extensions;

namespace BumblebeeIOS.Implementation
{
    class InnerConvenience
    {
        public static Point GetElementLocation(IWebElement element)
        {
            var serializer = new JavaScriptSerializer();

            var dict = serializer.Deserialize<Dictionary<string, object>>(serializer.Serialize(element.GetAttribute<Dictionary<string, object>>("rect")));


            int x = int.Parse(((Dictionary<string, object>)dict["origin"])["x"].ToString());
            int y = int.Parse(((Dictionary<string, object>)dict["origin"])["y"].ToString());
            int height = int.Parse(((Dictionary<string, object>)dict["size"])["height"].ToString());
            int width = int.Parse(((Dictionary<string, object>)dict["size"])["width"].ToString());

            return new Point(x + width / 2, y + height / 2);
        }

        public static Point GetElementOrigin(IWebElement element)
        {
            var serializer = new JavaScriptSerializer();

            var dict = serializer.Deserialize<Dictionary<string, object>>(serializer.Serialize(element.GetAttribute<Dictionary<string, object>>("rect")));

            int x = int.Parse(((Dictionary<string, object>)dict["origin"])["x"].ToString());
            int y = int.Parse(((Dictionary<string, object>)dict["origin"])["y"].ToString());

            return new Point(x, y);
        }
    }
}
