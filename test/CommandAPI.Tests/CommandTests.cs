using System;
using Xunit;
using CommandAPI.Models;
namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {
        Command testCommand;

        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something",
                Platform = "Some platform",
                CommandLine = "Some commandline"
            };
        }

        [Fact]
        public void CanChangeHowTo()
        {
            //Act
            testCommand.HowTo = "Start Unit Tests";
            //Assert
            Assert.Equal("Start Unit Tests", testCommand.HowTo);
        }
        [Fact]
        public void CanChangePlatform()
        {
            //Act
            testCommand.Platform = ".NET Core";
            //Assert
            Assert.Equal(".NET Core", testCommand.Platform);
        }
        [Fact]
        public void CanChangeCommandLine()
        {
            //Act
            testCommand.CommandLine = "dotnet watch run";
            //Assert
            Assert.Equal("dotnet watch run", testCommand.CommandLine);
        }

        public void Dispose()
        {
            testCommand = null;
        }
    }
}