﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using mds.ConfigClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mds.ConfigClient.Tests
{
    [TestClass()]
    public class ConfigServiceClientTests
    {
       
        [TestMethod()]
        public void RunInAppStartInitTest()
        {
            ConfigServiceClient ci = new ConfigServiceClient();
            var r = ci.RunInAppStartInit();
            Assert.IsTrue(r != null);
            Assert.IsTrue(r.Result);
        }

        [TestMethod()]
        public void GetComponentConfigTest()
        {

        }
    }
}