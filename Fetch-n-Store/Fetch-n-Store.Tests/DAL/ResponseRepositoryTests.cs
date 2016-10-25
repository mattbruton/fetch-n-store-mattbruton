using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using Fetch_n_Store.DAL;
using System.Collections.Generic;
using System.Linq;
using Fetch_n_Store.Models;

namespace Fetch_n_Store.Tests.DAL
{
    [TestClass]
    public class ResponseRepositoryTests
    {
        Mock<ResponseContext> mock_context { get; set; }
        Mock<DbSet<Response>> mock_response_table { get; set; }
        List<Response> response_list { get; set; }
        ResponseRepository repo { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
