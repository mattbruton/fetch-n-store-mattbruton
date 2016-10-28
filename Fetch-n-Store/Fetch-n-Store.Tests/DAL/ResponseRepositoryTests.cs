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

        public void ConnectMocksToDatastore()
        {
            var queryable_list = response_list.AsQueryable();

            mock_response_table.As<IQueryable<Response>>().Setup(x => x.Provider).Returns(queryable_list.Provider);
            mock_response_table.As<IQueryable<Response>>().Setup(x => x.Expression).Returns(queryable_list.Expression);
            mock_response_table.As<IQueryable<Response>>().Setup(x => x.ElementType).Returns(queryable_list.ElementType);
            mock_response_table.As<IQueryable<Response>>().Setup(x => x.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(x => x.Responses).Returns(mock_response_table.Object);

            mock_response_table.Setup(t => t.Add(It.IsAny<Response>())).Callback((Response v) => response_list.Add(v));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ResponseContext>();
            mock_response_table = new Mock<DbSet<Response>>();
            response_list = new List<Response>();
            repo = new ResponseRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoEnsureRepoCanBeInstantiated()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureRepoEmptyByDefault()
        {
            List<Response> actual_responses = repo.GetAllResponses();
            int expected_response_count = 0;
            int actual_response_count = actual_responses.Count();

            Assert.AreEqual(expected_response_count, actual_response_count);
        }

        [TestMethod]
        public void RepoEnsureRepoCanStoreReponses()
        {
            Response testResponse = new Response { ResponseId = 0, HttpMethod = "GET", ResponseTimeLength = "23ms", StatusCode = "200", TimeOfRequest = "Yesterday", URL = "http://api.github.com" };
            repo.AddResponse(testResponse);
            int expected_response_count = 1;
            int actual_response_count = repo.GetAllResponses().Count();

            Assert.AreEqual(expected_response_count, actual_response_count);
        }
    }
}
