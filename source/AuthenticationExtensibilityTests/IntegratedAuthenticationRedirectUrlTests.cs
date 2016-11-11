﻿using NSubstitute;
using NUnit.Framework;
using Octopus.Server.Extensibility.Authentication.HostServices;

namespace AuthenticationExtensibilityTests
{
    [TestFixture]
    public class IntegratedAuthenticationRedirectUrlTests
    {
        [TestCase("http://site1", "/folder1/api", null, ExpectedResult = true)]
        [TestCase("http://site1", "~/folder1/api", null, ExpectedResult = true)]
        [TestCase("http://site1", "http://site1/folder1/api", null, ExpectedResult = true)]
        [TestCase("http://localhost:8065", "http://localhost:9005", "http://localhost:9005", ExpectedResult = true)]
        [TestCase("http://localhost:8065", "https://localhost:9005", "https://localhost:9005", ExpectedResult = true)]
        [TestCase("https://localhost:8065", "https://localhost:9005", "https://localhost:9005", ExpectedResult = true)]
        [TestCase("https://localhost:8065", "http://localhost:9005", "http://localhost:9005", ExpectedResult = true)]
        [TestCase("http://localhost:8065", "http://localhost:9005", "*", ExpectedResult = true)]
        [TestCase("http://localhost:8065", "https://localhost:9005", "*", ExpectedResult = true)]
        [TestCase("https://localhost:8065", "https://localhost:9005", "*", ExpectedResult = true)]
        [TestCase("https://localhost:8065", "http://localhost:9005", "*", ExpectedResult = true)]
        [TestCase("http://site1", "folder1/api", null, ExpectedResult = false)]
        [TestCase("http://site1", "http://site2/folder1/api", null, ExpectedResult = false)]
        [TestCase("https://localhost:8065", "http://localhost:9005", "https://localhost:9005", ExpectedResult = false)]
        public bool IsPathLocalTest(string directoryPath, string url, string corsWhitelist)
        {
            return Requests.IsLocalUrl(directoryPath, url, corsWhitelist);
        }
    }
}